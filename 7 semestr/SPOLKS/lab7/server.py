import socket
import select
import sys
import os
import time
import threading

import rtwork, filework
from multiprocessing import Process

__TCP_BUF_SIZE = 4048


def __tcp_server_process(conn, addr, verbosity):

    print "PARENT PROCESS PID: " + str(os.getppid())
    print "PROCESS PID: " + str(os.getpid())

    print "connected by", addr
    ad = int(addr[1])
    print "PORT>>>>>>>>> ", ad

    if ad % 2:
        __file(conn, addr, verbosity)
    else:
        __sys_inf(conn)

    conn.close()
    print '{0} disconnected'.format(addr)

    return True

def __file(conn, addr, verbosity):
    data_length = 0
    filename = filework.random_name()
    f = open(filename, 'wb')

    while True:
        rtr, rtw, ie = select.select([conn], [], [conn], 10.0)
        if conn in ie and verbosity == True:
            urg = conn.recv(__TCP_BUF_SIZE, socket.MSG_OOB)
            data = rtwork.recieve(conn, __TCP_BUF_SIZE)
            f.write(data)
            print "{0} bytes recieved from {1}".format(data_length, addr)

        elif conn in rtr:
            data = rtwork.recieve(conn, __TCP_BUF_SIZE)
            if not data:
                break
            f.write(data)
        else:
            break

        data_length += len(data)
    f.close()

def __sys_inf(conn):
    while True:
        rtr, rtw, ie = select.select([conn], [], [conn], 10.0)

        if conn in rtr:
            data = rtwork.recieve(conn, __TCP_BUF_SIZE)
            if not data:
                break
            print "Information about system: {0}".format(data)
        else:
            break

def __tcp_server_routine(server, verbosity=False):

    conn, addr = server.accept()
    p = Process(target=__tcp_server_process, args=(conn, addr, verbosity))
    # ps -ax | grep main.py
    p.start()
    # conn.close()
    print p, p.is_alive()
    time.sleep(2)
    print p, p.is_alive()

    return True


tcp_server = __tcp_server_routine
tcp_server_urg = lambda s: __tcp_server_routine(s, True)