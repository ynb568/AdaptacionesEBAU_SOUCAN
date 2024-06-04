use AdaptacionesEBAU_SOUCAN;
go


insert into PlazosRegistro (fechaIni, fechaFin, cursoConvocatoria)
	values ('2024-07-04','2025-01-10','Curso 2024-2025 1� Cuatrimestre');
go

insert into Municipio (nombreMunicipio) values
	('Alfoz de Lloredo'),
	('Ampuero'),
	('Astillero (El)'),
	('Camargo'),
	('Laredo'),
	('Reinosa'),
	('Reoc�n'),
	('Santo�a'),
	('Santa Cruz de Bezana'),
	('Santander'),
	('Torrelavega')
go

insert into Direccion (nombreDireccion, idmunicipio)
	values ('DirTest',1);
go

insert into Sede (nombreSede) values
	('1: EDIFICIO INTERFACULTATIVO'),
	('2: ETSI INDUSTRIALES Y TELECOMUNICACIONES'),
	('3: ETSI CAMINOS'),
	('4: FACULTAD DE CIENCIAS ECON�MICAS Y EMPRESARIALES'),
	('5: FACULTAD DE ENFERMER�A'),
	('6: FACULTAD DE MEDICINA'),
	('7: EDIFICIO TRES TORRES'),
	('8: ESCUELA DE TURISMO ALTAMIRA'),
	('9: ESCUELA POLIT�CNICA DE INGENIER�A DE MINAS Y ENERG�A'),
	('10: ESCUELA OFICIAL DE IDIOMAS DE TORRELAVEGA'),
	('11: ESCUELA OFICIAL DE IDIOMAS DE LAREDO'),
	('12: IES ATAULFO ARGENTA DE CASTRO URDIALES'),
	('13: IES JOS� HIERRO DE SAN VICENTE'),
	('14: IES MONTESCLAROS DE REINOSA'),
	('15: IES VALLE DE SAJA DE CABEZ�N')
go

insert into Asignatura (nombreAsignatura, fase1, fase2) values
	('Lengua Castellana y Literatura II', 1, 1),
	('Lengua Extranjera II: Ingl�s', 1, 1),
	('Lengua Extranjera II: Franc�s', 1, 1),
	('Lengua Extranjera II: Alem�n', 1, 1),
	('Historia de Espa�a', 1, 1),
	('Historia de la Filosof�a', 1, 1),
	('Dibujo Art�stico II', 1, 1),
	('An�lisis Musical II', 1, 1),
	('Artes Esc�nicas II', 1, 1),
	('Matem�ticas II', 1, 1),
	('Matem�ticas aplicadas a las Ciencias Sociales II', 1, 1), 
	('Ciencias Generales',1 , 1),
	('Lat�n II',1 , 1),
	('Matem�ticas aplicadas a las Ciencias Sociales II',1,1), 
	('Biolog�a',0,1),
	('Coro y T�cnica Vocal II',0,1),
	('Dibujo T�cnico Aplicado a las Artes Pl�sticas y al Dise�o II',0,1),
	('Dibujo T�cnico II',0,1),
	('Dise�o',0,1),
	('Empresa y Dise�o de Modelos de Negocio',0,1),
	('F�sica',0,1),
	('Fundamentos Art�sticos',0,1),
	('Geograf�a',0,1),
	('Geolog�a y Ciencias Ambientales',0,1),
	('Griego II',0,1),
	('Historia de la M�sica y la Danza',0,1),
	('Historia del Arte',0,1),
	('Literatura Dram�tica',0,1),
	('Movimientos Culturales y Art�sticos',0,1),
	('Qu�mica',0,1),
	('T�cnicas de Expresi�n Gr�fico Pl�stica',0,1),
	('Tecnolog�a e Ingenier�a',0,1)
go

insert into Documento (nombreDocumento)
	values ('NomDoctest');
go

/*
insert into Diagnostico (nombreDiagnostico, descripcion, activo)
	values ('DiagTest', 'DescripDiagnostico Test', 1);
go
*/

insert into Diagnostico (idDiagnostico, nombreDiagnostico, descripcion) values
	(1, 'Discapacidad Visual', 'El estudiante cuenta con una agudeza visual inferior o igual a 6/18')
go

insert into Diagnostico (nombreDiagnostico, descripcion) values 
	('Discapacidad Motriz'),
	('Discapacidad Visual'),
	('Discapacidad Auditiva'),
	('Trastorno por D�ficit de Atenci�n e Hiperactividad(TDAH)'),
	('Dificultades Espec�ficas de Aprendizaje (Dislexia, Disgraf�a, etc.)'),
	('Trastorno del Espectro Autista (TEA)'),
	('Otras necesidades espec�ficas debidas a problemas de salud mental'),
	('Otras necesidades espec�ficas debidas a problemas de salud f�sica (permanentes o temporales sobrevenidos)')
go



insert into Adaptacion (idAdaptacion, nombreAdaptacion, descripcion, excepcional, descripcionExcepcional) values
	('Adaptaci�n de textos: fuente', 'Solicite la fuente deseada en el campo observaciones', 1, 'Solicitable en caso de tener una agudeza visual '),
	('Adaptaci�n de textos: tama�o', 'Solicite la fuente deseada en el campo observaciones', 0, '')
go

insert into Adaptacion(nombreAdaptacion) values
	('Aula de apoyo'),
	('Ampliaci�n de tiempo: 15 minutos m�s'),
	('Ampliaci�n de tiempo: 30 minutos m�s'),
	('Aula accesible'),
	('Adaptaci�n de los ex�menes (en coordinaci�n con la ONCE)'),
	('Adaptaci�n de textos: interlineado'),
	('Adaptaci�n de im�genes o mapas'),
	('Flexo'),
	('Lupa'),
	('Atril'),
	('L�nea Braille'),
	('Ordenador'),
	('Equipo FM'),
	('Visitar con antelaci�n las instalaciones donde se celebrar� el ex�men'),
	('Hoja pautada'),
	('Asiento en primeras filas'),
	('Lectura de los enunciados en voz alta a petici�n del estudiante'),
	('Descansos durante el examen, sin salir del aula, para realizarejercicios de relajaci�n en su asiento'),
	('Descansos durante el examen, sin salir del aula, para realizar estiramientos en su asiento'),
	('Permiso para beber agua y/o tomar medicaci�n'),
	('Asiento reservado'),
	('Mobiliario adaptado'),
	('Permiso para disponer y utilizar el gluc�metro o acceso a los dispositivos de administraci�n de insulina, si se precisa, as� como	tomar alg�n alimento'),
	('Permiso para acudir al servicio'),
	('Acompa�amiento por parte de una persona de referencia en el tiempo de descanso entre ex�menes (es necesario facilitar un nombre y tel�fono de contacto)')
go

insert into AdaptacionDiagnostico (idAdaptacion, idDiagnostico) values 
	(1,1),
	(2,1),
	(8,1),
	(9,1),
	(10,1),
	(11,1)
go