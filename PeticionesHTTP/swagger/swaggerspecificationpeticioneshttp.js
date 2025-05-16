
// swaggerspecificationpeticioneshttp.js

const swaggerJSDoc = require('swagger-jsdoc');

const options = {
    definition: {
        openapi: '3.0.0',
        info: {
            title: 'Peticiones HTTP API',
            version: '1.0.0',
            description: 'BackEnd Peticiones HTTP'
        }
    },
    apis: ['./application/*.js'], 
};

const swaggerSpec = swaggerJSDoc(options);

module.exports = swaggerSpec;
