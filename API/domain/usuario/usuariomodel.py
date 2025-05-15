
# usuariomodel:

from pydantic import BaseModel

class Usuario(BaseModel):
    IdUsuario: int
    Usuario: str
    Clave: str
    Nombre: str
    Apellido: str
    Correo: str
    TarjetaCredito: str
    CVV: str
