USE FITNESSBASE

CREATE TABLE CLASSUSER (

Nick CHAR(20),
NombreUsuario VARCHAR(20),
Apellidos VARCHAR(20),
Correo VARCHAR(30) NOT NULL,
Contraseña VARCHAR(25) NOT NULL,
Peso FLOAT ,
Edad INT,
Descripcion VARCHAR(200),
ScorePoints INT DEFAULT(0),
IsConnected BIT DEFAULT(0),
CONSTRAINT pk_Nick PRIMARY KEY(Nick),



);