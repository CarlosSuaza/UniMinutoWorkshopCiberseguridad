
# webapiflujodata:

from fastapi import FastAPI

from core.security.base64.base64decode import Base64Decode
from core.security.base64.base64encode import Base64Encode
from core.security.binary.binariodecode import BinaryDecode
from core.security.binary.binarioencode import BinaryEncode
from domain.usuario.usuariomodel import Usuario

app: FastAPI = FastAPI(
    title = "Web API Flujo Data",
    description = "IUE202402"
)

#####################################################################################

@app.get("/operacionget",
         summary = "Operacion Get",
         description = "Operacion Tipo Get",
         tags = ["Get"] 
)
async def operacion_get(documentocliente: str):
    return documentocliente, " Autenticacion Exitosa"

#####################################################################################

@app.post("/operacionpost",
          response_model = Usuario,
          summary = "Operacion Post",
          description= "Operacion Tipo Post",
          tags = ["Post"] 
)
async def operacion_post(usuario: Usuario):
    return usuario

#####################################################################################

@app.post("/cifrarbase64",
          response_model = Usuario,
          summary = "Operacion Cifrar Base64",
          description= "Operacion Cifrar Base64",
          tags = ["Base64"] 
)
async def operacion_cifrar_base64(usuario: Usuario):
    cifrar = Base64Encode()
    usuario.Usuario = cifrar.encrypt(usuario.Usuario)
    usuario.Clave = cifrar.encrypt(usuario.Clave)
    usuario.TarjetaCredito = cifrar.encrypt(usuario.TarjetaCredito)
    usuario.CVV = cifrar.encrypt(usuario.CVV)
    return usuario

#####################################################################################

@app.post("/decifrarbase64",
          response_model = Usuario,
          summary = "Operacion Decifrar Base64",
          description= "Operacion Decifrar Base64",
          tags = ["Base64"] 
)
async def operacion_decifrar_base64(usuario: Usuario):
    decifrar = Base64Decode()
    usuario.Usuario = decifrar.decrypt(usuario.Usuario)
    usuario.Clave = decifrar.decrypt(usuario.Clave)
    usuario.TarjetaCredito = decifrar.decrypt(usuario.TarjetaCredito)
    usuario.CVV = decifrar.decrypt(usuario.CVV)    
    return usuario

#####################################################################################

@app.post("/cifrarbinario",
          response_model = Usuario,
          summary = "Operacion Cifrar Binario",
          description= "Operacion Cifrar Binario",
          tags = ["Binario"] 
)
async def operacion_cifrar_base64(usuario: Usuario):
    cifrar = BinaryEncode()
    usuario.Usuario = cifrar.encrypt(usuario.Usuario)
    usuario.Clave = cifrar.encrypt(usuario.Clave)
    usuario.TarjetaCredito = cifrar.encrypt(usuario.TarjetaCredito)
    usuario.CVV = cifrar.encrypt(usuario.CVV)
    return usuario

#####################################################################################

@app.post("/decifrarbinario",
          response_model = Usuario,
          summary = "Operacion Decifrar Binario",
          description= "Operacion Decifrar Binario",
          tags = ["Binario"] 
)
async def operacion_decifrar_base64(usuario: Usuario):
    decifrar = BinaryDecode()
    usuario.Usuario = decifrar.decrypt(usuario.Usuario)
    usuario.Clave = decifrar.decrypt(usuario.Clave)
    usuario.TarjetaCredito = decifrar.decrypt(usuario.TarjetaCredito)
    usuario.CVV = decifrar.decrypt(usuario.CVV)     
    return usuario

#####################################################################################