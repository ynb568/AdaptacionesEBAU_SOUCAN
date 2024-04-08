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

insert into Sede (nombreSede)
	values ('SedeTest');
go

insert into Asignatura (nombreAsignatura, activo, fase1, fase2)
	values ('AsignaturaTest1', 1, 1, 1), 
			('AsignatuaTest2',1, 1, 1);
go

insert into Documento (nombreDocumento)
	values ('NomDoctest');
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