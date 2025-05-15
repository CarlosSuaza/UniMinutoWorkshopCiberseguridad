
import base64

class Base64Decode:
    def __init__(self):
        pass

    def decrypt(self, ciphertext):
        ciphertext_bytes = ciphertext.encode('utf-8')
        decrypted_bytes = base64.b64decode(ciphertext_bytes)
        decrypted_text = decrypted_bytes.decode('utf-8')
        return decrypted_text