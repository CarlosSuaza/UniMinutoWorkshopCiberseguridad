import hashlib
#q1w2e3r4t5
def main():
    clave = str(input("Introduce la contraseña a cifrar: ")).encode('utf-8')

    md5 = hashlib.md5(clave).hexdigest()
    print("Hash MD5: %s" % str(md5))

    sha1 = hashlib.sha1(clave).hexdigest()
    print("Hash SHA1: %s" % str(sha1))

    sha224 = hashlib.sha224(clave).hexdigest()
    print("Hash SHA224: %s" % str(sha224))

    sha256 = hashlib.sha256(clave).hexdigest()
    print("Hash SHA256: %s" % str(sha256))

    sha384 = hashlib.sha384(clave).hexdigest()
    print("Hash SHA384: %s" % str(sha384))

    sha512 = hashlib.sha512(clave).hexdigest()
    print("Hash SHA512: %s" % str(sha512))

if __name__ == '__main__':
    main()