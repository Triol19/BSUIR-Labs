import sys
import os
import select
import socket
import platform

import filework, rtwork
from math import ceil

__TCP_BUF_SIZE = 4048


def __tcp_client_routine(conn, filename, verbosity=False):

    ad = int(conn.getsockname()[1])
    print "------------------", ad

    if ad % 2:
        __file(conn, filename, verbosity)
    else:
        __sys_inf(conn)

    conn.close()

def __sys_inf(conn):
    bytes_sended = 0
    i = 0
    while i<10:
        buffer = platform.platform()
        rtr, rtw, ie = select.select([], [conn], [], 10.0)

        if conn in rtw:
            success = rtwork.transmit(conn, buffer)
        else:
            break
        if not success:
            break
        i+=1

def __file(conn, filename, verbosity=False):
    f = open(filename, 'rb')
    f_size = filework.get_fsize(f)
    __URG_PERIOD = int(f_size) / __TCP_BUF_SIZE / 10 * __TCP_BUF_SIZE
    # print __URG_PERIOD, ">>>>>>>>>>>>>>"
    bytes_sended = 0

    while True:
        if verbosity and bytes_sended % __URG_PERIOD == 0:
            conn.send('!', socket.MSG_OOB)
            print ("%s bytes sended" % bytes_sended)

        buffer = f.read(__TCP_BUF_SIZE)
        rtr, rtw, ie = select.select([], [conn], [], 10.0)

        if conn in rtw:
            success = rtwork.transmit(conn, buffer)
        else:
            break

        if bytes_sended == f_size or not success:
            break

        bytes_sended += len(buffer)
    f.close()




tcp_client = __tcp_client_routine
tcp_client_urg = lambda conn, filename: __tcp_client_routine(conn, filename, True)
