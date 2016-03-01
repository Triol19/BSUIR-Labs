import argparse, json, threading, select, fcntl, os, sys, socket, signal, struct, time, errno
from time import strftime
from net_interface import Interface

PORT = 5555
PACKET_SIZE = 1024


class ChatThread(threading.Thread):
    def __init__(self, chat):
        super(ChatThread, self).__init__()  # init thread
        self._chat = chat
        self._terminated = False
    def run(self):
        while True:
            self._chat.process()
            if self._terminated:
                break
    def shutdown(self):
        self._terminated = True

class Chat(object):
    def __init__(self, nick, my_ip ,bcast):
        self._nick = nick
        self._bcast = bcast
        self._my_ip = my_ip
        try:
            self._s = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
            self._s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
            self._s.setsockopt(socket.SOL_SOCKET, socket.SO_BROADCAST, 1)
            self._s.bind(('', PORT))
        except socket.error, e:
            print "Error when creating a socket"


    def process(self):
        r, w, x = select.select([self._s],[],[],0.5) # use only list for read
        if r:
            packet, addr = self._s.recvfrom(PACKET_SIZE)
            if (addr[0] == self._my_ip) and (addr[1] == PORT):
            	return
                #print "my packet"
            try:
                data = json.loads(packet)
                if "message" in data:
                	if "nick" in data:
                		print "[{}]{}: {}".format(strftime("%Y-%m-%d %H:%M:%S"), data['nick'], data['message'])
                elif "command" in data:
                    self.parse_command(addr, data['command'], data)
            except ValueError, e:
                print "Invalid packet received"

    def send_nick(self, address):
        data = {
            'nick': self._nick,
            'command': 'pong'
        }
        enc_data = json.dumps(data)
        self._s.sendto(enc_data, address)

    def send(self, message):
        data = {
            "nick": self._nick,
            "message": message
        }
        data_enc = json.dumps(data)
        self._s.sendto(data_enc, (self._bcast, PORT))

    def list(self):
        data = {
            "command": "ping"
        }
        data_enc = json.dumps(data)
        self._s.sendto(data_enc, (self._bcast, PORT))

    def parse_command(self,address, command, data):
        if command == "ping":
            self.send_nick(address)
        elif command == "pong":
			if 'nick' in data:
				print "\nUser {} ip {}".format(data['nick'], address[0])

    def close(self):
        self._s.close()

def print_protompt():
	print ">>>",

def print_help():
	print """list - list chat users
!quit - quit a chat
!send <message> - send a message"""

def main():
    parser = argparse.ArgumentParser(description='Python broadcast chat')
    parser.add_argument("nickname", help="User nickname in chat")
    parser.add_argument("interface", help="Network interface")
    args = parser.parse_args()
    ifname = args.interface
    interface = Interface()
    host_addr = interface.getAddr(ifname)
    net_addr = interface.getNetmask(ifname)
    bcast_addr = interface.getBroadcast(ifname)
    netmask = interface.getNetmask(ifname)
    print "******Interface params******"
    print "host_addr ", host_addr
    print "netmask   ", netmask
    print "bcast_addr", bcast_addr
    chat = Chat(args.nickname, host_addr, bcast_addr)
    thread = ChatThread(chat)
    thread.start()
    try:
        while True:
            print_protompt()
            command = raw_input()
            if command in ["!help", "!h"]:
                print_help()
            elif command in ["!quit", "!q"]:
                break
            elif command in ["!list", "!l"]:
                print "User lists:"
                chat.list()
            elif (command[:5] == ["!send"]) or (command[:2] == "!s"):
                if command.startswith("!send "):
                    message = command[6:]
                elif command.startswith("!s"):
                    message = command[3:]
                else:
                    print "Command error"
                    continue
                chat.send(message)
                # continue
            elif not command:
            	continue
            else:
                print "Invalid command. type '!help' or '!h' for help"
    except KeyboardInterrupt:
        print "\nGood bye!"
    finally:
        thread.shutdown()
        thread.join()
        chat.close()

if __name__ == "__main__":
    main()