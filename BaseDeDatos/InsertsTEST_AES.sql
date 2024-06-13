use AdaptacionesEBAU_SOUCAN;
go

insert into PlazosRegistro (fechaIni, fechaFin, cursoConvocatoria)
	values ('2024-03-04','2025-01-10','Curso 2024-2025 1� Cuatrimestre');
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
	values ('Calle Honduras 19',1);
go

insert into Usuario (correo, contrasenha) --contrasenha = test
	values ('UC@gmail.com', '9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08');
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

insert into CentroEducativo (idCE, nombreCE, idSede, telefonoCE,
								nombreOrientador, apellidosOrientador, telefonoOrientador, correoOrientador,
								nombreEquipoDirectivo, apellidosEquipoDirectivo, telefonoEquipoDirectivo,
								idDireccion)
	values (1, 'Universidad de Cantabria', 1, '942222333', 
				'Benito', 'Mart�nez Toral', '678333444', 'benitomartinez@gmail.com',
				'Mercedes', 'Garc�a Sainz', '612444555', 1);
go

insert into Estudiante (dniEstudiante, nombreEstudiante, ap1Estudiante, ap2Estudiante,
							nombreCompletoTutor1, telefonoTutor1, nombreCompletoTutor2, telefonoTutor2,
							ordinaria, extraordinaria, observaciones, cursoConvocatoria, idCE)
	values ('12345678A', 'Roberto', 'Bolado', 'Garc�a',
				'Manuel Bolado', '678555666', 'Maria Teresa Garc�a', '634666777',
				1, 0, 'Estudiante de Segundo de Bachillerato que se presenta a la convocatoria 24-25', 
				'Curso 2024-2025 1� Cuatrimestre', 1);
go

insert into Documento (nombreDocumento) values
	('Credenciales de Diagn�stico'),
	('Documentaci�n del Estudiante')
go

insert into DocumentoEstudiante (idEstudiante, idDocumento, rutaDocumento, validado)
	values (1, 1, 'RutaDocTest', null);
go

insert into Apunte (descripcion, idEstudiante)
	values ('Reunion del 20-08-2024', 1);
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

insert into AsignaturaEstudiantePrevista (idAsignatura, idEstudiante, fase1, fase2)
	values (1, 1, 1, 0);
go

insert into AsignaturaEstudianteMatriculada(idAsignatura, idEstudiante, fase1, fase2)
	values (2, 1, 1, 0);
go


insert into Diagnostico (nombreDiagnostico, descripcion) values
	('Discapacidad Visual', 'El estudiante cuenta con una agudeza visual inferior o igual a 6/18')
go

insert into Diagnostico (nombreDiagnostico) values 
	('Discapacidad Motriz'),
	('Discapacidad Visual'),
	('Discapacidad Auditiva'),
	('Trastorno por D�ficit de Atenci�n e Hiperactividad(TDAH)'),
	('Dificultades Espec�ficas de Aprendizaje (Dislexia, Disgraf�a, etc.)'),
	('Trastorno del Espectro Autista (TEA)'),
	('Otras necesidades espec�ficas debidas a problemas de salud mental'),
	('Otras necesidades espec�ficas debidas a problemas de salud f�sica (permanentes o temporales sobrevenidos)')
go



insert into Adaptacion (nombreAdaptacion, descripcion, excepcional, descripcionExcepcional) values
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
	(2,2),
	(8,1),
	(9,1),
	(10,1),
	(11,2)
go

insert into AdaptacionDiagnosticoEstudiante (idAdaptacion, idDiagnostico, idEstudiante, 
												validado, observaciones, revision)
	values (1,1,1, 0, 'Fuente de letra: Comic Sans', 'Se requiere otra fuente');
go

/*
delete from AdaptacionDiagnosticoEstudiante;

delete from AdaptacionDiagnostico;

delete from Adaptacion;

delete from Diagnostico;

delete from AsignaturaEstudianteMatriculada;

delete from AsignaturaEstudiantePrevista;

delete from Asignatura;

delete from Apunte;

delete from DocumentoEstudiante;

delete from Documento;

delete from Estudiante;

delete from CentroEducativo;

delete from Sede;

delete from Usuario;

delete from Direccion;

delete from Municipio;

delete from PlazosRegistro;
*/