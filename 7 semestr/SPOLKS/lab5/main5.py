 # -*- coding: utf-8 -*-
import sys
import socket
import argparse
import os
import fcntl

BUF_SIZE = 128

def run_server(host, portc, filename, ports):
	d="next"
	if portc in range(1024,65535) and ports in range(1024,65535):
		#s = socket.socket()	
		s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
		#fcntl.fcntl(s.fileno(), fcntl.F_SETOWN, os.getpid());
		s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
		s.settimeout(5)
		s.bind(('',ports))
		#s.listen(1)
		#conn, addr = s.accept()
		#print 'Connected with client. IP:{0}'.format(addr[0])
	else: 
		print 'Enter port in range 1024 <=> 65535'
		return 0
	
	f = open(filename, 'rb')
	filesize = os.stat(filename).st_size
	sentsize = 0
	perflag = 0
	'''try:
		number = conn.recv(1024)
		print number
	except:
		print "Lost Connection"
		return 0
	f.seek(int(number),0)

	sentsize += int(number)'''


	try:
		s.sendto('length', (host, portc))
		number, addr = s.recvfrom(BUF_SIZE)
		print number
		f.seek(int(number),0)
		sentsize += int(number)
	except:
		print "Lost Connection"
		return 0
	
	while True:
		if d=="next":
			data = f.read(BUF_SIZE)
			sentsize += BUF_SIZE
		percent = int(float(sentsize)*100/float(filesize))	#rings
		print "{0} Kb of {1} Kb sent ({2}%)".format(sentsize/1024, filesize/1024, percent)
		sys.stdout.write('\033M')			#escape symbols rule
		if not data:
			sys.stdout.write('\033D')
			print 'Data has been transfered'
			s.sendto('CLOSE', (host, portc))
			#There ain't no such thing as a free lunch
			break
		try:
			s.sendto(data, (host, portc))
			#conn.send(data)
		except socket.error:
			print 'Transfer fail'
			#conn.close()
			f.close()
			s.close()	
			return 0  # sys.exit
		'''if (percent % 10 == 0) & (perflag != percent) & (percent <92):
			perflag = percent
			sys.stdout.write('\033D') # go next line
			print '\033[37;1;41m Urgent flag sent at {0}% \033[0m'.format(percent)
			conn.send(b'{}'.format(percent/10), socket.MSG_OOB)'''
		try:
			#s.bind(('',ports))
			d, a = s.recvfrom(BUF_SIZE)
			#print d, a
		except socket.error:
			print 'Transfer fail'
			#conn.close()
			f.close()
			s.close()	
			return 0  # sys.exit
			
	f.close()
	s.close()
	
	
def run_client(host, ports, portc):
	if portc in range(1024,65535) and ports in range(1024,65535):
		#s = socket.socket()
		s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
		#fcntl.fcntl(s.fileno(), fcntl.F_SETOWN, os.getpid());
		s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)    
		#s.bind((host,port))
		s.bind(('',portc))
		'''try:
			s.connect((host,port))  # <= tuple = 1 argument, not 2!
		except:
			print "Server is OFF"
			s.close()
			return 0'''
	else:
		print 'Enter port in range 1024 <=> 65535'
		return 0
	
	f = open('rcvd.file','ab')
	rcvdsize = 0
	s.settimeout(5)

	'''temp=os.path.getsize('rcvd.file')
	print temp
	try:
		s.send(str(temp))
	except:
		print "Lost Connection"
		s.close()
		return 0
	rcvdsize += temp'''

	'''temp=os.path.getsize('rcvd.file')
	print temp
	try:
		s.sendto(str(temp), (host, ports))
	except:
		print "Lost Connection"
		s.close()
		return 0
	rcvdsize += temp'''

	while True:
		try:
			data, addr = s.recvfrom(BUF_SIZE)
			if data=="length":
				temp=os.path.getsize('rcvd.file')
				print temp
				s.sendto(str(temp), (host, ports))
				continue
		except:
			sys.stdout.write('\033D')
			print "Lost Connection"
			s.close()
			f.close()
			return 0
		if data == "CLOSE":
			break

		rcvdsize += BUF_SIZE
		f.write(data)
		print '\033[0;32m {0} Kb received \033[0m'.format(rcvdsize/1024)
		sys.stdout.write('\033M')
		##########################
		try:
			s.sendto("next", (host, ports))
			#conn.send(data)
		except socket.error:
			print 'Transfer fail'
			#conn.close()
			f.close()
			s.close()	
			return 0  # sys.exit
		#print "PEREDALO!"
		##########################
	sys.stdout.write('\033D')		
	print 'Done!'
	f.close()
	s.close()
	 

def main():
	parser = argparse.ArgumentParser()
#	subparsers = parser.add_subparsers(help='Select mode')
	group = parser.add_mutually_exclusive_group()
	group.add_argument("-s", "--server", help="Run as server", action="store_true")
	group.add_argument("-c", "--client", help="Run as client", action="store_true")
	parser.add_argument("-ac", "--addressc", help="Destination host (client mode)", default="192.168.12.52")
	parser.add_argument("-as", "--addresss", help="Destination host (client mode)", default="192.168.12.52")
	parser.add_argument("-p", "--port", type=int, help="Port to listen/connect to", default=5005)
	
	parser.add_argument("-p1", "--portc", type=int, help="Port to listen/connect to", default=5005)
	parser.add_argument("-p2", "--ports", type=int, help="Port to listen/connect to", default=5000)
	parser.add_argument("-f", "--file", help="File to send (server mode)", default="send.file")
	args = parser.parse_args()
	if args.server:
		print 'Server mode'
		run_server(args.addressc, args.portc, args.file, args.ports)
	if args.client:
		print 'Client mode'
		run_client(args.addresss, args.ports, args.portc)

if __name__ == '__main__':
        main()

