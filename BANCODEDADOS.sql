CREATE TABLE TabPacientes(
CodPaciente varchar(255),
NomePaciente varchar(255),
CPF varchar(255),
Email varchar(255),
Ativo bit,
Senha varchar(255),
DataIns datetime,
PRIMARY KEY(CodPaciente));

CREATE TABLE TabAgendamentos(
 CodAgenda varchar(255),
 CodMedico varchar(255),
 CodPaciente varchar(255),
 DataInicioConsulta datetime,
 DataFinalConsulta datetime,
 TempoConsulta int,
 StatusConsulta int,
 PRIMARY KEY(CodAgenda),
 FOREIGN KEY(CodMedico) REFERENCES TabMedicos(CodMedico),
 FOREIGN KEY(CodPaciente) REFERENCES TabPacientes(CodPaciente)
);

CREATE TABLE TabEspecialidades(
CodEspecialidade int,
NomeEspecialidade varchar(255)
PRIMARY KEY(CodEspecialidade));

CREATE TABLE TabMedicos(
CodMedico varchar(255) NOT NULL,
NomeMedico varchar(255) NULL,
Email varchar(255) NULL,
CRM varchar(255) NULL,
CPF varchar(255) NULL,
Senha varchar(255) NULL,
DataIns datetime NULL,
CodEspecialidade int NULL,
Ativo bit NULL,
PRIMARY KEY(CodMedico));

ALTER TABLE TabMedicos ADD FOREIGN KEY(CodEspecialidade)
REFERENCES TabEspecialidades(CodEspecialidade);

INSERT INTO TabEspecialidades(CodEspecialidade, NomeEspecialidade)VALUES(1,'Clínica médica');
INSERT INTO TabEspecialidades(CodEspecialidade, NomeEspecialidade)VALUES(2,'Pediatria');
INSERT INTO TabEspecialidades(CodEspecialidade, NomeEspecialidade)VALUES(3,'Ginecologia e obstetrícia');
INSERT INTO TabEspecialidades(CodEspecialidade, NomeEspecialidade)VALUES(4,'Cardiologia');
INSERT INTO TabEspecialidades(CodEspecialidade, NomeEspecialidade)VALUES(5,'Ortopedia e traumatologia');
INSERT INTO TabEspecialidades(CodEspecialidade, NomeEspecialidade)VALUES(6,'Dermatologia');
INSERT INTO TabEspecialidades(CodEspecialidade, NomeEspecialidade)VALUES(7,'Infectologia');
INSERT INTO TabEspecialidades(CodEspecialidade, NomeEspecialidade)VALUES(8,'Oftalmologia');