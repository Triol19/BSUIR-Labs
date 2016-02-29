#!/usr/bin/env python

import os, argparse, sys, netserver, netparser, netclient
from server import *
from client import *


def main():

    parser = netparser.create_parser('-t', '-u', '-c', '-s', '-v')
    args = parser.parse_args() # namespace with args from terminal
    if args.args: # that's means that we write ip + port + filename => client
        cl_nfo = netparser.parse_list(args.args)
	cl_args = (cl_nfo.filename, cl_nfo.host, cl_nfo.port,)

    if args.udp:
        if args.port:
            print "Udp server runs on port", args.port
            netserver.run_udp_server(args.port, udp_server)
        elif cl_nfo:
            print ("Connecting to ({0}, {1})").format(cl_nfo.host, cl_nfo.port)
            netclient.run_udp_client(cl_nfo.host, cl_nfo.port, udp_client, cl_args)
    elif args.tcp:
        if args.port:
            print "Tcp server runs on port", args.port
            if args.verbosity:
                netserver.run_tcp_server(args.port, tcp_server_urg)
            else:
                netserver.run_tcp_server(args.port, tcp_server)
        elif cl_nfo:
            print ("Connecting to ({0}, {1})").format(cl_nfo.host, cl_nfo.port)
            if args.verbosity:
                netclient.run_tcp_client(cl_nfo.host, cl_nfo.port, tcp_client_urg, (cl_nfo.filename,))
            else:
                netclient.run_tcp_client(cl_nfo.host, cl_nfo.port, tcp_client, (cl_nfo.filename,))


if __name__ == "__main__":
    main()
