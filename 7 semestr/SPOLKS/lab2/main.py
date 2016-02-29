import sys
import socket


def start_server(PORT):
	print 'Port:{0}'.format(PORT)
	s = socket.socket()					# new socket
	s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) # [Errno 98] Address already in use (for more fast socket closing)	(reuse the address within the TIME_WAIT period)
	s.bind(("",PORT))					# wait to connect client with PORT parameter
	s.listen(1)
	conn, addr = s.accept()					# return a client socket (with address information)
	print 'Connected with client. Client IP: {0}'.format(addr[0])
	
	while 1:
		data = conn.recv(1024)				#data from socket(client) <=1024 bytes
		if not data: 
		    break
		conn.send(data)  				# echo from server to client (through socket)
		print data.rstrip() 				# print data from client (on server side)
		if data.rstrip() == "-f":			# exit 
			print 'By'
			conn.shutdown(socket.SHUT_RDWR)		#SHUT_RD stop sending and reciving
			break
	conn.close()
	
	

def main():
	if len(sys.argv) != 2:								
		start_server(5005)
	else:
		try:						
			start_server(int(sys.argv[1]))
		except Exception:
			print 'Something goes wrong =('
	return 0


if __name__ == '__main__':
	main()
