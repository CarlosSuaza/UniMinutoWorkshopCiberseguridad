
class BinaryDecode:
    def __init__(self):
        pass

    def decrypt(self, ciphertext):
        decrypted_text = ''.join(chr(int(ciphertext[i:i+8], 2)) for i in range(0, len(ciphertext), 8))
        return decrypted_text