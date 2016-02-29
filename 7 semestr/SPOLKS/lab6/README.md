Лабораторная работа №6: Организация параллельной обработки запросов на сервере с помощью мультиплексирования

Модификация программы из л/р №5. Модифицировать сервер для организации параллельного обслуживания нескольких клиентов с помощью мультиплексирования (select, pselect, poll).

Intruction for launch:
	- run tcp-server: `./main.py -ts <port_num>`
	- run tcp-client: `./main.py -tc <port_num> <host_name> <file_name>`
	- for tcp-connection also available verbosity data transmittion with flags --verbosity или -v
	- run udp-client: `./main.py -us <port_num>`
	- run udp-client: `./main.py -uc <port_num> <host_name> <file_name>`

