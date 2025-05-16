
// domain/object/usuario/modelusuario.js

class ModelUsuario{
    constructor(
                idusuario,
                documento,
                nombres,
                apellidos){
        this.idusuario = idusuario;
        this.documento = documento;
        this.nombres = nombres;
        this.apellidos = apellidos;
    }
}

module.exports = { ModelUsuario };