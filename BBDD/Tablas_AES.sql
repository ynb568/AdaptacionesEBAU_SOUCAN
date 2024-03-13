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
	activo bit,
	fechaIni date,
	fechaFin date
);

create table Municipio (
	idMunicipio int primary key identity,
	nombreMunicipio varchar(50) not null
);

create table Direccion (
	idDireccion int primary key identity,
	direccion varchar(100) not null,
	idMunicipio int foreign key references Municipio(idMunicipio)
);

create table Usuario (
	idUsuario int primary key identity,
	correo varchar(100) not null,
	contrasenha varchar(500) not null
);

create table Soucan (
	idSoucan int primary key references Usuario(idUsuario)
);


create table CEDisponible (
	idCED int primary key identity,
	nombreCED varchar(100) not null,
);

create table Sede (
	idSede int primary key identity,
	nombreSede varchar(100) not null,
	activo bit
);

create table CentroEducativo (
	idCE int primary key references Usuario(idUsuario),
	--PARA SACAR EL NOMBRE A ELEGIR DEL CE A PARTIR DE LA LISTA DISPONIBLE / UNICO
	idCED int foreign key references CEDisponible(idCED) unique not null, 
	idSede int foreign key references Sede(idSede),
	telefonoCE varchar(9) not null,
	nombreOrientador varchar(50) not null,
	apellidosOrientador varchar (100) not null,
	telefonoOrientador varchar(9),
	correoOrientador varchar(100) not null,
	-- COMO ESPECIFICO QUIEN TIENE QUE METER LOS DATOS?
	nombreEquipoDirectivo varchar(50) not null,
	apellidosEquipoDirectivo varchar(100) not null,
	telefonoEquipoDirectivo varchar(9) not null,
	correoEquipoDirectivo varchar(100) not null,
	--
	fechaRegistro datetime default getdate(),
	idDireccion int foreign key references Direccion(idDireccion),
	validado int default 0
);

create table Estudiante (
	idEstudiante int primary key identity,
	nombreEstudiante varchar(50) not null,
	ap1Estudiante varchar(50) not null,
	ap2Estudiante varchar(50) not null,
	convocatoria varchar(20) check (convocatoria in ('Ordinaria', 'Extraordinaria')),
	documentos varchar(MAX),
	fechaRegistro datetime default getdate(),
	idDireccion int foreign key references Direccion(idDireccion),
	idCE int foreign key references CentroEducativo (idCE)
);

create table Apunte (
	idApunte int primary key identity,
	descripcion varchar(500),
	idEstudiante int foreign key references Estudiante(idEstudiante)
);

create table Asignatura (
	idAsignatura int primary key identity,
	nombreAsignatura varchar(100) not null,
	activo bit default 1,
	fase1 bit,
	fase2 bit
);

create table AsignaturaEstudiantePrevista (
	idAsignatura int foreign key references Asignatura(idAsignatura),
	idEstudiante int foreign key references Estudiante(idEstudiante),
	fase1 bit,
	fase2 bit,
	primary key (idAsignatura, idEstudiante)
);

create table AsignaturaEstudianteMatriculada (
	idAsignatura int foreign key references Asignatura(idAsignatura),
	idEstudiante int foreign key references Estudiante(idEstudiante),
	fase1 bit,
	fase2 bit,
	primary key (idAsignatura, idEstudiante)
);

create table Diagnostico (
	idDiagnostico int primary key identity,
	nombreDiagnostico varchar(100) not null,
	activo bit default 1,
	descripcion varchar(500)
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
	descripcion varchar(500)
);

create table AdaptacionDiagnostico (
	idDiagnostico int foreign key references Diagnostico(idDiagnostico),
	idAdaptacion int foreign key references Adaptacion(idAdaptacion),
	descripcion varchar(500),
	excepcional bit,
	descripcionExcepcional varchar(500),
	primary key (idDiagnostico, idAdaptacion)
);

create table AdaptacionDiagnosticoEstudiante (
	idAdaptacion int foreign key references Adaptacion(idAdaptacion),
	idDiagnostico int foreign key references Diagnostico(idDiagnostico),
	idEstudiante int foreign key references Estudiante(idEstudiante),
	observaciones varchar(500),
	revision varchar(500),
	primary key (idAdaptacion, idDiagnostico, idEstudiante)
);