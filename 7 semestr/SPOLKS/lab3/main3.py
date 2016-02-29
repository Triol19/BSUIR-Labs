#iptables -P INPUT DROP/ACCEPT

import sys
import socket
import os
import time
BUF_SIZE = 128

def start_client(ip):
	port = int(raw_input('Input port: '))   
	if port in range(1024,65535):
		#s = socket.socket()
		s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

		#s.setsockopt(socket.SOL_SOCKET, )
		s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)				#for more fast socket closing
		#host = socket.gethostname()
		#print host
		#s.connect(("192.168.12.52",port))
		try:
			s.connect((ip,port))  # <= tuple = 1 argument, not 2!
		except:
			print "Server is OFF"
			s.close()
			return 0
	else:
		print 'Enter port in range 0<=> 65535'
		return 0
	file_name=raw_input('Input file name: ')
	try:
		f = open(file_name,'a')  # ab
	except IOError:
		print 'You must enter filename!'
		return 0
	temp=os.path.getsize(file_name)
	print temp
	try:
		s.send(str(temp))
	except:
		print "Lost Connection"
		s.close()
		return 0
	begin = int(time.time()) // 60
	print "Time of start: {0}".format(begin)
	#while 1:
	data=1
	s.settimeout(5.0)
	while data != b"":
		try:
			data = s.recv(BUF_SIZE)
		except:
			print "Lost Connection"
			s.close()
			return 0
		if not data: 
			print 'Data has been received'
			break
		f.write(data)
	end = int(time.time()) // 60
	print "Time of end: {0}".format(end)
	s.close()
		
	
def start_server():
	port = int(raw_input('Input port: '))   
	if port in range(1024,65535):
		#s = socket.socket()
		s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
		s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)	#for more fast socket closing
		s.bind(("",port))
		s.listen(1)
		conn, addr = s.accept()
		print 'Connected with client. IP:{0}'.format(addr[0])
	else:
		print 'Enter port in range 0<=> 65535'
		return 0
	file_name=raw_input('Input file name: ')
	try:
		f = open(file_name)
	except IOError:
		print 'You must enter filename!'
		return 0
	try:
		number = conn.recv(1024)
		print number
	except:
		print "Lost Connection"
		return 0
	f.seek(int(number),0)
	N_transactions=0
	#while 1:
	data=1
	#s.settimeout(5.0)
	while data != b"":
		#s.gettimeout()
		data = f.read(BUF_SIZE)
		#s.settimeout(5.0)
		if not data: 
			print 'Data has been transfered'
			break
		try:
			conn.settimeout(5.0)
			conn.send(data)
			N_transactions+=1
		except:
			print 'Transfering failed, restart client, transaction success = {0}'.format(N_transactions)
			conn.close()
			s.close()	
			start_server()
			return 0  # sys.exit
	conn.close()
		

def main():
	try:
		print sys.argv[1]
		if sys.argv[1] == 'client':	
			print sys.argv[2]											
			print 'Starting client...'
			start_client(sys.argv[2])
		elif sys.argv[1] == 'server':												
			print 'Starting server...'
			start_server()
		else:
			print "Enter 'client %ip%' or 'server' only!"
	except IndexError:
		print "Enter 'client %ip%' or 'server'"
	return 0


if __name__ == '__main__':
	main()

'''It is good practice to use the with keyword when dealing with file objects. This has the advantage that the file is properly closed after its suite finishes, even if an exception is raised on the way.

>>> with open('/tmp/workfile', 'r') as f:
...     read_data = f.read()'''