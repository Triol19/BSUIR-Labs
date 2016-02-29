Лабораторная работа №8: Организация параллельной обработки запросов на сервере с помощью процессов.

Модификация программы из л/р №5. Модифицировать сервер для организации параллельного обслуживания нескольких клиентов с помощью выделения отдельного процесса (process).

Intruction for launch:

	- run tcp-server: `./main.py -ts <port>`
	- run tcp-client: `./main.py -tc <port> <host> <filename>`
	- for tcp-connection also available verbosity data transmittion with flags --verbosity или -v
