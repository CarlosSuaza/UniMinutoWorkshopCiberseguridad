
import base64

class Base64Encode:
    def __init__(self):
        pass

    def encrypt(self, plaintext):
        plaintext_bytes = plaintext.encode('utf-8')
        encrypted_bytes = base64.b64encode(plaintext_bytes)
        encrypted_text = encrypted_bytes.decode('utf-8')
        return encrypted_text