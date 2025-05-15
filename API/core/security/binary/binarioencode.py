
class BinaryEncode:
    def __init__(self):
        pass

    def encrypt(self, plaintext):
        encrypted_text = ''.join(format(ord(char), '08b') for char in plaintext)
        return encrypted_text

