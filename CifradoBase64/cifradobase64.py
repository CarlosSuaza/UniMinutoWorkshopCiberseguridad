import base64

class Base64Cipher:
    def __init__(self):
        pass
    
    def encrypt(self, data):
        # Codificar los datos a Base64
        encoded_data = base64.b64encode(data.encode('utf-8'))
        return encoded_data.decode('utf-8')
    
    def decrypt(self, encoded_data):
        # Decodificar los datos desde Base64
        decoded_data = base64.b64decode(encoded_data.encode('utf-8'))
        return decoded_data.decode('utf-8')

# Ejemplo de uso
if __name__ == "__main__":
    cipher = Base64Cipher()
    print("Ingresa un mensaje")
    data = str(input("Introduce mensaje a cifrar en Base64: "))
    
    # Cifrado
    encrypted_data = cipher.encrypt(data)
    print("Mensaje cifrado:", encrypted_data)
    
    # Descifrado
    decrypted_data = cipher.decrypt(encrypted_data)
    print("Mensaje descifrado:", decrypted_data)
