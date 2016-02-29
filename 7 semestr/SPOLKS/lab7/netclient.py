import socket
import sys

def __client_socket_create(isTcp=True):

    sock_type = socket.SOCK_STREAM
    s = socket.socket(socket.AF_INET, sock_type)
    s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    return s


def __make_client(host, port, action, a_args, isTcp=True):

    try:
        client_socket = __client_socket_create(isTcp)
        client_socket.connect((host, port))

        action(client_socket, *a_args)

    except KeyboardInterrupt as e:
        print 'keyboard interrupt detected.\nterminate.'
    except socket.error as e:
        print 'socket error {0}'.format(e)
    except IOError as e:
        print 'can\'t open file.\nterminate'
    except Exception as e:
        print 'exception occured: {0}.\nterminate.'.format(e)
    finally:
        if client_socket != None:
            client_socket.close()

        sys.exit(0)


def run_tcp_client(host, port, action, a_args=()):

    return __make_client(host, port, action, a_args)