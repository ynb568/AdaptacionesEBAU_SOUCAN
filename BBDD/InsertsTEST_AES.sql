use AdaptacionesEBAU_SOUCAN;
go

insert into PlazosRegistro (fechaIni, fechaFin, cursoConvocatoria)
	values ('2024-01-01','2024-12-31','Curso 2024');
go

insert into Municipio (nombreMunicipio)
	values ('MunTest');
go

insert into Direccion (nombreDireccion, idmunicipio)
	values ('DirTest',1);
go

insert into Usuario (correo, contrasenha) --contrasenha = test
	values ('test@gmail.com', '9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08');
go

insert into Sede (nombreSede)
	values ('SedeTest');
go

insert into CentroEducativo (idCE, nombreCE, idSede, telefonoCE,
								nombreOrientador, apellidosOrientador, telefonoOrientador, correoOrientador,
								nombreEquipoDirectivo, apellidosEquipoDirectivo, telefonoEquipoDirectivo,
								idDireccion)
	values (1, 'CETest', 1, '111222333', 
				'NomOTest', 'ApOTest', '222333444', 'testO@gmail.com',
				'NomEDTest', 'ApEDTest', '333444555', 1);
go

insert into Estudiante (dniEstudiante, nombreEstudiante, ap1Estudiante, ap2Estudiante,
							nombreCompletoTutor1, telefonoTutor1, nombreCompletoTutor2, telefonoTutor2,
							ordinaria, extraordinaria, observaciones, validado, cursoConvocatoria, idCE)
	values ('12345678A', 'NomETest', 'Ap1Test', 'Ap2Test',
				'Tut1test', '444555666', 'Tut2Test', '555666777',
				1, 0, 'Observaciones Estudiante Test 1', null, 'Curso 2024', 1);
go

insert into Documento (nombreDocumento)
	values ('NomDoctest');
go

insert into DocumentoEstudiante (idEstudiante, idDocumento, rutaDocumento, validado)
	values (1, 1, 'RutaDocTest', null);
go

insert into Apunte (descripcion, idEstudiante)
	values ('Apunte Estudiante Test', 1);
go


insert into Asignatura (nombreAsignatura, activo, fase1, fase2)
	values ('AsignaturaTest1', 1, 1, 1), 
			('AsignatuaTest2',1, 1, 1);
go

insert into AsignaturaEstudiantePrevista (idAsignatura, idEstudiante, fase1, fase2)
	values (1, 1, 1, 0);
go

insert into AsignaturaEstudianteMatriculada(idAsignatura, idEstudiante, fase1, fase2)
	values (2, 1, 1, 0);
go

insert into Diagnostico (nombreDiagnostico, descripcion, activo)
	values ('DiagTest', 'DescripDiagnostico Test', 1);
go

insert into Adaptacion (nombreAdaptacion, descripcion, excepcional, descripcionExcepcional, activo)
	values ('AdapTest', 'DescripAdaptacion Test', 1, 'DescripExcep Test', 1);
go

insert into AdaptacionDiagnostico (idAdaptacion, idDiagnostico)
	values (1,1);
go

insert into AdaptacionDiagnosticoEstudiante (idAdaptacion, idDiagnostico, idEstudiante, 
												validado, observaciones, revision)
	values (1,1,1, null, 'ObserAdapEst Test', 'RevisionAdapEst test');
go
