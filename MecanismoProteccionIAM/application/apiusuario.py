
# apiusuario.py

import jwt
import re

from fastapi import FastAPI, Depends, HTTPException, status
from fastapi.security import OAuth2PasswordBearer
from fastapi.middleware.cors import CORSMiddleware

from domain.modelousuario import ModeloUsuario
from core.coreseguridad import CoreSeguridad

app: FastAPI = FastAPI(
    title = "API Usuario",
    description = "UNMWC202501"
)

origins = ["*"]

app.add_middleware(
    CORSMiddleware,
    allow_origins=origins,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# Configuración para OAuth2
oauth2_scheme = OAuth2PasswordBearer(tokenUrl="token")
JWT_SECRET_KEY = "UNMWC202501"

###########################################################################

# Get
@app.get(
    "/consultarusuarios",
    response_model = ModeloUsuario,
    summary = "Consultar Modelo Usuarios",
    description = "Consultar Objeto Usuarios",
    tags = ["Usuario"]
)
async def consultar_usuarios():
    return ModeloUsuario(
        IdUsuario='1',
        Usuario='User',
        Clave='Password',
        Documento='71764044',
        Nombres='Carlos',
        Apellidos='Suaza',
        TarjetaCredito='1234567890',
        CVV='1234'
    )

###########################################################################

# Get
@app.get(
    "/consultarusuarioid",
    response_model=list,
    summary = "Consultar Modelo Usuario Id",
    description = "Consultar Objeto Usuario Id",
    tags = ["Usuario"]
)
async def consultar_usuario_id(id:str):
    ids_autorizados = ['1']
    if id not in ids_autorizados:
        raise HTTPException(status_code=401, detail="Usuario no autorizado")
    
    return ModeloUsuario(
        IdUsuario='1',
        Usuario='User',
        Clave='Password',
        Documento=documento,
        Nombres='Carlos',
        Apellidos='Suaza',
        TarjetaCredito='1234567890',
        CVV='1234'
    )

###########################################################################

# Get
@app.get(
    "/consultarusuarionombres",
    response_model=list,
    summary = "Consultar Modelo Usuario Nombres",
    description = "Consultar Objeto Usuario Nombres",
    tags = ["Usuario"]
)
async def consultar_usuario_documento(documento:str):
    documentos_autorizados = ['71764044']
    if documento not in documentos_autorizados:
        raise HTTPException(status_code=401, detail="Usuario no autorizado")
    
    return ModeloUsuario(
        IdUsuario='1',
        Usuario='User',
        Clave='Password',
        Documento=documento,
        Nombres='Carlos',
        Apellidos='Suaza',
        TarjetaCredito='1234567890',
        CVV='1234'
    )

###########################################################################

# Post
@app.post(
    "/ingresarusuario",
    summary = "Ingresar Modelo Usuario",
    description = "Ingresar Objeto Usuario",
    tags = ["Usuario"]
)
async def ingresar_usuario(modelousuario: ModeloUsuario):
    modelousuario.IdUsuario = '1'
    modelousuario.Usuario = 'User'
    modelousuario.Clave = 'Password'
    modelousuario.Documento = '71764044'
    modelousuario.Nombres = 'Carlos'
    modelousuario.Apellidos = 'Suaza'
    modelousuario.TarjetaCredito = '1234567890'
    modelousuario.CVV = '1234'
    return modelousuario


###########################################################################

# Put
@app.put(
    "/modificarusuario",
    summary = "Modificar Modelo Usuario",
    description = "Modificar Objeto Usuario",
    tags = ["Usuario"]
)
async def modificar_usuario(id:str, modelousuario:ModeloUsuario):
    ids_autorizados = ['1']
    if id not in ids_autorizados:
        raise HTTPException(status_code=401, detail="Usuario no autorizado")    
        
    modelousuario.IdUsuario = '1'
    modelousuario.Usuario = 'User'
    modelousuario.Clave = 'Password'
    modelousuario.Documento = '71764044'
    modelousuario.Nombres = 'Carlos'
    modelousuario.Apellidos = 'Suaza'
    modelousuario.TarjetaCredito = '1234567890'
    modelousuario.CVV = '1234'
    return modelousuario

###########################################################################

# Delete
@app.delete(
    "/retirarusuario",
    summary = "Retirar Modelo Usuario",
    description = "Retirar Objeto Usuario",
    tags = ["Usuario"]
)
async def retirar_usuario(id:str):
    ids_autorizados = ['1']
    if id not in ids_autorizados:
        raise HTTPException(status_code=401, detail="Usuario no autorizado")
    
    return ModeloUsuario(
        IdUsuario='1',
        Usuario='User',
        Clave='Password',
        Documento=documento,
        Nombres='Carlos',
        Apellidos='Suaza',
        TarjetaCredito='1234567890',
        CVV='1234'
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
          response_model = ModeloUsuario,
          summary = "Operacion Post",
          description= "Operacion Tipo Post",
          tags = ["Post"] 
)
async def operacion_post(modelousuario: ModeloUsuario):
    return modelousuario

#####################################################################################

@app.post("/cifrarbase64",
          response_model = ModeloUsuario,
          summary = "Operacion Cifrar Base64",
          description= "Operacion Cifrar Base64",
          tags = ["Base64"] 
)
async def operacion_cifrar_base64(modelousuario: ModeloUsuario):
    cifrar = Base64Encode()
    modelousuario.Usuario = cifrar.encrypt(modelousuario.Usuario)
    modelousuario.Clave = cifrar.encrypt(modelousuario.Clave)
    modelousuario.TarjetaCredito = cifrar.encrypt(modelousuario.TarjetaCredito)
    modelousuario.CVV = cifrar.encrypt(modelousuario.CVV)
    return modelousuario

#####################################################################################

@app.post("/decifrarbase64",
          response_model = ModeloUsuario,
          summary = "Operacion Decifrar Base64",
          description= "Operacion Decifrar Base64",
          tags = ["Base64"] 
)
async def operacion_decifrar_base64(modelousuario: ModeloUsuario):
    decifrar = Base64Decode()
    modelousuario.Usuario = decifrar.decrypt(modelousuario.Usuario)
    modelousuario.Clave = decifrar.decrypt(modelousuario.Clave)
    modelousuario.TarjetaCredito = decifrar.decrypt(modelousuario.TarjetaCredito)
    modelousuario.CVV = decifrar.decrypt(modelousuario.CVV)    
    return modelousuario

#####################################################################################

@app.post("/cifrarbinario",
          response_model = ModeloUsuario,
          summary = "Operacion Cifrar Binario",
          description= "Operacion Cifrar Binario",
          tags = ["Binario"] 
)
async def operacion_cifrar_base64(modelousuario: ModeloUsuario):
    cifrar = BinaryEncode()
    modelousuario.Usuario = cifrar.encrypt(modelousuario.Usuario)
    modelousuario.Clave = cifrar.encrypt(modelousuario.Clave)
    modelousuario.TarjetaCredito = cifrar.encrypt(modelousuario.TarjetaCredito)
    modelousuario.CVV = cifrar.encrypt(modelousuario.CVV)
    return modelousuario

#####################################################################################

@app.post("/decifrarbinario",
          response_model = ModeloUsuario,
          summary = "Operacion Decifrar Binario",
          description= "Operacion Decifrar Binario",
          tags = ["Binario"] 
)
async def operacion_decifrar_base64(modelousuario: ModeloUsuario):
    decifrar = BinaryDecode()
    modelousuario.Usuario = decifrar.decrypt(modelousuario.Usuario)
    modelousuario.Clave = decifrar.decrypt(modelousuario.Clave)
    modelousuario.TarjetaCredito = decifrar.decrypt(modelousuario.TarjetaCredito)
    modelousuario.CVV = decifrar.decrypt(modelousuario.CVV)     
    return modelousuario

#####################################################################################

@app.get(
    "/aescifrar",
    summary="AESCifrar",
    description="AES Cifrar",
    tags=["AES"]
)
async def aes_cifrar(textoplano: str, llave: str) -> str:
    textocifrado: str
    if (len(llave) >= 16):
        coreseguridad = CoreSeguridad()
        textocifrado = coreseguridad.cifrar(textoplano, llave)
    else:
        textocifrado = f"Longitud de Clave Menor a 16 caracteres"
    return textocifrado

@app.get(
    "/aesdescifrar",
    summary="AESDescifrar",
    description="AES Descifrar",
    tags=["AES"]
)
async def aes_descifrar(textocifrado: str, llave: str) -> str:
    textoplano: str
    if (len(llave) >= 16):
        coreseguridad = CoreSeguridad()
        textoplano = coreseguridad.decifrar(textocifrado, llave)
    else:
        textoplano = f"Longitud de Clave Menor a 16 caracteres"
    return textoplano    

###########################################################################    

# Post
@app.post(
    "/registrarusuario",
    summary = "Registrar Modelo Usuario",
    description = "Registrar Objeto Usuario",
    tags = ["Registrar"]
)
async def registrar_usuario(modelousuario: ModeloUsuario):
    clave: str = modelousuario.Clave
    resultado: str
    if (len(clave) >= 16):
        if (re.search(r"[a-z]", clave)):
            if (re.search(r"[A-Z]", clave)):
                if (re.search(r"\d", clave)):
                    if (re.search(r"[!@#$%^&*(),.?\":{}|<>]", clave)):
                        return modelousuario  
                    else:
                        resultado = f"Clave debe contener Caracteres Especiales"
                else:
                    resultado = f"Clave debe contener Numeros"
            else:
                resultado = f"Clave debe contener Mayusculas"
        else:
            resultado = f"Clave debe contener Minusculas"
    else:
        resultado = f"Longitud de Clave Menor a 16 Caracteres"
    return resultado

###########################################################################    

# Post
@app.post(
    "/autenticarusuario", 
    summary = "Autenticar Modelo Usuario",
    description = "Autenticar Objeto Usuario",
    tags = ["Autenticar"]
)
async def autenticar_usuario(modelousuario: ModeloUsuario): 
    usuario_autenticado = False
    usuarios_autorizados = ['User']
    claves_autorizados = ['Password']
    
    if (modelousuario.Usuario in usuarios_autorizados) and (modelousuario.Clave in claves_autorizados):
        usuario_autenticado = True  

    if usuario_autenticado:
        return usuario_autenticado
    else:
        raise HTTPException(status_code=status.HTTP_401_UNAUTHORIZED, detail="Credenciales inválidas")    

###########################################################################    

# Post
@app.post(
    "/autenticartokenizarusuario",
    summary = "Autenticar Modelo Usuario",
    description = "Autenticar Objeto Usuario",
    tags = ["Autenticar"]
)
async def autenticar_tokenizar_usuario(modelousuario: ModeloUsuario):
    usuario_autenticado = False
    usuarios_autorizados = ['User']
    claves_autorizados = ['Password']
    
    if (modelousuario.Usuario in usuarios_autorizados) and (modelousuario.Clave in claves_autorizados):
        usuario_autenticado = True  

    if usuario_autenticado:
        token = jwt.encode({"Documento": modelousuario.Documento}, JWT_SECRET_KEY, algorithm="HS256")
        return {"access_token": token, "token_type": "bearer", "resultado": "Usuario autenticado y tokenizado exitosamente"}  
    else:
        raise HTTPException(status_code=status.HTTP_401_UNAUTHORIZED, detail="Credenciales inválidas")  

###########################################################################       

# Post
@app.post(
    "/autorizartokenizarusuario",
    summary = "Autorizar Modelo Usuario",
    description = "Autorizar Objeto Usuario",
    tags = ["Autorizar"]
)
def autorizar_tokenizar_usuario(token: str):
    try:
        payload = jwt.decode(token, JWT_SECRET_KEY, algorithms=["HS256"])

        documento: str = payload["Documento"]

        documentos_autorizados = ['71764044']
                    
        if (documento in documentos_autorizados):
            usuario_autorizado_tokenizado = documento         

        if usuario_autorizado_tokenizado is None:
            raise HTTPException(status_code=status.HTTP_401_UNAUTHORIZED, detail="Token inválido")
        return {"access_token": token, "Usuario": usuario_autorizado_tokenizado}   
    except jwt.PyJWTError:
        raise HTTPException(status_code=status.HTTP_401_UNAUTHORIZED, detail="Token inválido") 
 
 ###########################################################################    