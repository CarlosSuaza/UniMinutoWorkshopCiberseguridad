
// index.js

const express = require('express');
const bodyParser = require('body-parser');
const swaggerUi = require('swagger-ui-express');
const cors = require('cors');
const swaggerSpecificationPeticionesHTTP = require('./swagger/swaggerspecificationpeticioneshttp');
const apiPeticionesHTTP = require('./application/apipeticioneshttp');

var app = express();

app.use(cors());

app.use(bodyParser.json());

app.use('/api-doc', swaggerUi.serve, swaggerUi.setup(swaggerSpecificationPeticionesHTTP));

app.use(apiPeticionesHTTP);

const PORT = process.env.PORT || 8067;

app.listen(PORT, () => {
	console.log(``);
	console.log(`----------------------------------------------------------------------------------------------------------------------`);
	console.log(``);	
    console.log(`Server running on port ${PORT}`);
	console.log(`Swagger docs available at http://localhost:${PORT}/api-doc`);
	console.log(`Get operation available at http://localhost:${PORT}/operaciongetusuario`);
	console.log(`Get operation available at http://localhost:${PORT}/operaciongetusuariodocumento?documento=`);
	console.log(`Get operation available at http://localhost:${PORT}/operaciongetusuarioid/id`);
	console.log(`Get operation available at http://localhost:${PORT}/operacionpostusuario`);
	console.log(`Get operation available at http://localhost:${PORT}/operacionputusuario`);
	console.log(`Get operation available at http://localhost:${PORT}/operaciondeleteusuario?documento=`);
	console.log(``);
	console.log(`----------------------------------------------------------------------------------------------------------------------`);
	console.log(``);
	
});

