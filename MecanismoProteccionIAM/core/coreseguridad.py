
# coreusuario.py

from Crypto.Cipher import AES
from Crypto.Util.Padding import pad, unpad
from base64 import b64encode, b64decode

from domain.modelousuario import ModeloUsuario

class CoreSeguridad():

    def __init__(self) -> None:
        pass

    def cifrar(self, textoplano: str, llave: int) -> str:
        textocifrado: str
        key = b'1234567890123456'
        iv = b'1234567890123456'
        #key = bin(llave)
        #iv = bin(llave)    
		#iv = ciphertext[:16]		
        cipher = AES.new(key, AES.MODE_CBC, iv)
        ciphertext = cipher.encrypt(pad(textoplano.encode(), AES.block_size))
        textocifrado = b64encode(ciphertext)
        return textocifrado
    
    def decifrar(self, textocifrado: str, llave: int) -> str:
        textodescifrado: str
        key = b'1234567890123456'
        iv = b'1234567890123456'
        #key = bin(llave)
        #iv = bin(llave)     
		#iv = ciphertext[:16]
        cipher = AES.new(key, AES.MODE_CBC, iv)
        decrypted_text = unpad(cipher.decrypt(b64decode(textocifrado)), AES.block_size)
        textodescifrado = decrypted_text.decode()        
        return textodescifrado  		