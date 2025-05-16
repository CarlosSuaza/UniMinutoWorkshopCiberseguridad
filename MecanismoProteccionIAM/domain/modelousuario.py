
# modelousuario.py

from pydantic import BaseModel

class ModeloUsuario(BaseModel):
    IdUsuario: str
    Usuario: str
    Clave: str
    Documento: str
    Nombres: str
    Apellidos: str
    TarjetaCredito: str
    CVV: str