
// apiparqueadero.js

const express = require('express');

const { ModelUsuario } = require('../domain/object/usuario/modelusuario');

var router = express.Router();

// GET
/**
 * @swagger
 * /operaciongetusuario:
 *   get:
 *     tags:
 *       - Usuario
 *     summary: Get all ModelUsuario
 *     responses:
 *       200:
 *         description: List of ModelUsuario
 */
router.get('/operaciongetusuario', async (req, res) => {
	try {		
        const modelusuario = new ModelUsuario();
        res.status(200).json(modelusuario);	

	} catch (err) {
		res.status(500).json({ error: err.message });
	}
});

// GET
/**
 * @swagger
 * /operaciongetusuariodocumento:
 *   get:
 *     tags:
 *       - Usuario
 *     summary: Get ModelUsuario by Documento
 *     parameters:
 *       - name: documento
 *         in: query
 *         description: Documento
 *         required: true
 *         schema:
 *           type: string
 *           default: 0
 *     responses:
 *       200:
 *         description: Respuesta exitosa
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 results:
 *                   type: array
 *                   items:
 *                     type: string
 *       404:
 *         description: Usuario no encontrado
 */ 
router.get('/operaciongetusuariodocumento', async(req, res) => {
    try{
        const { documento } = req.query;
        
        if (documento != ''){
            const modelusuario = new ModelUsuario('1', 'TuDocumento', 'TusNombres', 'TusApellidos');
            res.status(200).json(modelusuario);
        }
        else {
            res.status(404).json({ message: 'Usuario no valido'});
        }
    } catch (err){
        res.status(500).json({ error: err.message });
    }
});

// GET
/**
 * @swagger
 * /operaciongetusuarioid/{id}:
 *   get:
 *     tags:
 *       - Usuario
 *     summary: Get ModelUsuario by Id
 *     parameters:
 *       - name: id
 *         in: path
 *         description: IdUsuario
 *         required: true
 *         schema:
 *           type: string
 *           default: 0
 *     responses:
 *       200:
 *         description: Respuesta exitosa
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 results:
 *                   type: array
 *                   items:
 *                     type: string
 *       404:
 *         description: Usuario no encontrado
 */ 
router.get('/operaciongetusuarioid/:id', async(req, res) => {
    try{
        const { id } = req.params;
        
        if (id != ''){
            const modelusuario = new ModelUsuario('1', 'TuDocumento', 'TusNombres', 'TusApellidos');
            res.status(200).json(modelusuario);
        }
        else {
            res.status(404).json({ message: 'Usuario no valido'});
        }
    } catch (err){
        res.status(500).json({ error: err.message });
    }
});

// POST
/**
 * @swagger
 * /operacionpostusuario:
 *   post:
 *     tags:
 *       - Usuario
 *     summary: Post ModelUsuario
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               idusuario:
 *                 type: string
 *               documento:
 *                 type: string
 *               nombres:
 *                 type: string 
 *               apellidos:
 *                 type: string 
 *     responses:
 *       201:
 *         description: ModelUsuario created
 */
router.post('/operacionpostusuario', async (req, res) => {
    try{
		const { cuerpo } = req.body;
        if (cuerpo != ''){
            const modelusuario = new ModelUsuario('1', 'TuDocumento', 'TusNombres', 'TusApellidos');
            res.status(200).json(modelusuario);
        }
        else {
            res.status(404).json({ message: 'Usuario no valido'});
        }
    } catch (err){
        res.status(500).json({ error: err.message });
    }	
});

// PUT
/**
 * @swagger
 * /operacionputusuario: 
 *   put:
 *     tags:
 *       - Usuario
 *     summary: Update ModelUsuario
 *     parameters:
 *       - name: documento
 *         in: query
 *         required: true
 *         schema:
 *           type: string
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               idusuario:
 *                 type: string
 *               documento:
 *                 type: string
 *               nombres:
 *                 type: string 
 *               apellidos:
 *                 type: string 
 *     responses:
 *       201:
 *         description: ModelUsuario updated
 */
router.put('/operacionputusuariodocumento', async (req, res) => {
    try{
        const { documento } = req.query;
        
        if (documento != ''){
            const modelusuario = new ModelUsuario('1', 'TuDocumento', 'TusNombres', 'TusApellidos');
            res.status(200).json(modelusuario);
        }
        else {
            res.status(404).json({ message: 'Usuario no valido'});
        }
    } catch (err){
        res.status(500).json({ error: err.message });
    }
});

// DELETE
/**
 * @swagger
 * /operaciondeleteusuariodocumento:
 *   delete:
 *     tags:
 *       - Usuario
 *     summary: Delete a ModelUsuario
 *     parameters:
 *       - name: documento
 *         in: query
 *         required: true
 *         schema:
 *           type: string
 *     responses:
 *       204:
 *         description: ModelUsuario deleted
 */
router.delete('/operaciondeleteusuario', async (req, res) => {	
    try{
        const { documento } = req.query;
        
        if (documento != ''){
            const modelusuario = new ModelUsuario('1', 'TuDocumento', 'TusNombres', 'TusApellidos');
            res.status(200).json(modelusuario);
        }
        else {
            res.status(404).json({ message: 'Usuario no valido'});
        }
    } catch (err){
        res.status(500).json({ error: err.message });
    }
});

module.exports = router;