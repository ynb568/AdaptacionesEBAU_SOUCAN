use master;
go

if exists (select * from sys.databases where name='AdaptacionesEBAU_SOUCAN')
	drop database AdaptacionesEBAU_SOUCAN
go
create database AdaptacionesEBAU_SOUCAN;
go

use AdaptacionesEBAU_SOUCAN;
go

create table PlazosRegistro (
	idPlazo int primary key identity,
	activo bit default 1,
	fechaIni date not null,
	fechaFin date not null,
	cursoConvocatoria varchar(10) not null
);

create table Municipio (
	idMunicipio int primary key identity,
	nombreMunicipio varchar(50) not null unique
);

create table Direccion (
	idDireccion int primary key identity,
	direccion varchar(100) not null,
	idMunicipio int foreign key references Municipio(idMunicipio)
);

create table Usuario (
	idUsuario int primary key identity,
	correo varchar(100) not null unique,
	contrasenha varchar(500) not null unique,
	constraint  ck_correo check (correo like ('%@%.%'))
);

create table Soucan (
	idSoucan int primary key references Usuario(idUsuario)
);

create table Sede (
	idSede int primary key identity,
	nombreSede varchar(100) not null unique,
	activo bit default 1
);

create table CentroEducativo (
	idCE int primary key references Usuario(idUsuario),
	--idCED int foreign key references CEDisponible(idCED) unique not null,
	nombreCE varchar(100) not null unique,
	idSede int foreign key references Sede(idSede) null,
	--los datos que puede no tener el centro en el momento pueden ser nulos
	telefonoCE varchar(9) null unique,
	nombreOrientador varchar(50) null,
	apellidosOrientador varchar (100) null,
	telefonoOrientador varchar(9) null unique,
	correoOrientador varchar(100) null unique,
	nombreEquipoDirectivo varchar(50) null,
	apellidosEquipoDirectivo varchar(100) null,
	telefonoEquipoDirectivo varchar(9) null unique,
	--
	fechaRegistro datetime default getdate(),
	idDireccion int foreign key references Direccion(idDireccion) not null,
	constraint  ck_correoO check (correoOrientador like ('%@%.%')),
	constraint ck_tlfnCE check (telefonoCE like ('[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')),
	constraint ck_tlfnO check (telefonoOrientador like ('[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')),
	constraint ck_tlfnED check (telefonoEquipoDirectivo like ('[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')),
);

create table Estudiante (
	idEstudiante int primary key identity,
	dni varchar(20) not null, --Puede ser DNI,NIE o Pasaporte
	nombreEstudiante varchar(50) not null,
	ap1Estudiante varchar(50) not null,
	ap2Estudiante varchar(50) not null,
	nombreCompletoTutor1 varchar(100) null,
	telefonoTutor1 varchar(9) null,
	nombreCompletoTutor2 varchar(100) null,
	telefonoTutor2 varchar(9) null,
	ordinaria bit null,
	extraordinaria bit null,
	observaciones varchar(500) null,
	validado bit null,
	cursoConvocatoria varchar(10),
	fechaRegistro datetime default getdate(),
	--idDireccion int foreign key references Direccion(idDireccion),
	idCE int foreign key references CentroEducativo (idCE) not null,
	constraint ck_tlfnT1 check (telefonoTutor1 like ('[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')),
	constraint ck_tlfnT2 check (telefonoTutor2 like ('[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')),
);

create table Documento (
	idDocumento int primary key identity,
	nombreDocumento varchar(100) not null	
);

create table DocumentoEstudiante (
	idEstudiante int foreign key references Estudiante(idEstudiante),
	idDocumento int foreign key references Documento(idDocumento),
	rutaDocumento varchar(MAX) null,
	validado bit null
);

create table Apunte (
	idApunte int primary key identity,
	descripcion varchar(500) not null,
	idEstudiante int foreign key references Estudiante(idEstudiante)
);

create table Asignatura (
	idAsignatura int primary key identity,
	nombreAsignatura varchar(100) not null,
	activo bit default 1,
	fase1 bit default 0,
	fase2 bit default 0
);

create table AsignaturaEstudiantePrevista (
	idAsignatura int foreign key references Asignatura(idAsignatura),
	idEstudiante int foreign key references Estudiante(idEstudiante),
	fase1 bit default 0,
	fase2 bit default 0,
	primary key (idAsignatura, idEstudiante)
);

create table AsignaturaEstudianteMatriculada (
	idAsignatura int foreign key references Asignatura(idAsignatura),
	idEstudiante int foreign key references Estudiante(idEstudiante),
	fase1 bit default 0,
	fase2 bit default 0,
	primary key (idAsignatura, idEstudiante)
);

create table Diagnostico (
	idDiagnostico int primary key identity,
	nombreDiagnostico varchar(100) not null,
	activo bit default 1,
	descripcion varchar(500) null
);

create table DiagnosticoEstudiante (
	idDiagnostico int foreign key references Diagnostico(idDiagnostico),
	idEstudiante int foreign key references Estudiante(idEstudiante),
	primary key (idDiagnostico, idEstudiante)
);

create table Adaptacion (
	idAdaptacion int primary key identity,
	nombreAdaptacion varchar(100) not null,
	activo bit default 1,
	descripcion varchar(500) null
);

create table AdaptacionDiagnostico (
	idDiagnostico int foreign key references Diagnostico(idDiagnostico),
	idAdaptacion int foreign key references Adaptacion(idAdaptacion),
	descripcion varchar(500) null,
	excepcional bit default 0,
	descripcionExcepcional varchar(500) null,
	primary key (idDiagnostico, idAdaptacion)
);

create table AdaptacionDiagnosticoEstudiante (
	idAdaptacion int foreign key references Adaptacion(idAdaptacion),
	idDiagnostico int foreign key references Diagnostico(idDiagnostico),
	idEstudiante int foreign key references Estudiante(idEstudiante),
	validado bit null,
	observaciones varchar(500) null,
	revision varchar(500) null,
	aprobado bit default null,
	primary key (idAdaptacion, idDiagnostico, idEstudiante)
);