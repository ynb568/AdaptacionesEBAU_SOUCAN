use AdaptacionesEBAU_SOUCAN;
go

insert into PlazosRegistro (fechaIni, fechaFin, cursoConvocatoria)
	values ('2024-03-04','2025-01-10','Curso 2024-2025 1º Cuatrimestre');
go

insert into Municipio (nombreMunicipio) values
	('Alfoz de Lloredo'),
	('Ampuero'),
	('Astillero (El)'),
	('Camargo'),
	('Laredo'),
	('Reinosa'),
	('Reocín'),
	('Santoña'),
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
	('4: FACULTAD DE CIENCIAS ECONÓMICAS Y EMPRESARIALES'),
	('5: FACULTAD DE ENFERMERÍA'),
	('6: FACULTAD DE MEDICINA'),
	('7: EDIFICIO TRES TORRES'),
	('8: ESCUELA DE TURISMO ALTAMIRA'),
	('9: ESCUELA POLITÉCNICA DE INGENIERÍA DE MINAS Y ENERGÍA'),
	('10: ESCUELA OFICIAL DE IDIOMAS DE TORRELAVEGA'),
	('11: ESCUELA OFICIAL DE IDIOMAS DE LAREDO'),
	('12: IES ATAULFO ARGENTA DE CASTRO URDIALES'),
	('13: IES JOSÉ HIERRO DE SAN VICENTE'),
	('14: IES MONTESCLAROS DE REINOSA'),
	('15: IES VALLE DE SAJA DE CABEZÓN')
go

insert into CentroEducativo (idCE, nombreCE, idSede, telefonoCE,
								nombreOrientador, apellidosOrientador, telefonoOrientador, correoOrientador,
								nombreEquipoDirectivo, apellidosEquipoDirectivo, telefonoEquipoDirectivo,
								idDireccion)
	values (1, 'Universidad de Cantabria', 1, '942222333', 
				'Benito', 'Martínez Toral', '678333444', 'benitomartinez@gmail.com',
				'Mercedes', 'García Sainz', '612444555', 1);
go

insert into Estudiante (dniEstudiante, nombreEstudiante, ap1Estudiante, ap2Estudiante,
							nombreCompletoTutor1, telefonoTutor1, nombreCompletoTutor2, telefonoTutor2,
							ordinaria, extraordinaria, observaciones, cursoConvocatoria, idCE)
	values ('12345678A', 'Roberto', 'Bolado', 'García',
				'Manuel Bolado', '678555666', 'Maria Teresa García', '634666777',
				1, 0, 'Estudiante de Segundo de Bachillerato que se presenta a la convocatoria 24-25', 
				'Curso 2024-2025 1º Cuatrimestre', 1);
go

insert into Documento (nombreDocumento) values
	('Credenciales de Diagnóstico'),
	('Documentación del Estudiante')
go

insert into DocumentoEstudiante (idEstudiante, idDocumento, rutaDocumento, validado)
	values (1, 1, 'RutaDocTest', null);
go

insert into Apunte (descripcion, idEstudiante)
	values ('Reunion del 20-08-2024', 1);
go

insert into Asignatura (nombreAsignatura, fase1, fase2) values
	('Lengua Castellana y Literatura II', 1, 1),
	('Lengua Extranjera II: Inglés', 1, 1),
	('Lengua Extranjera II: Francés', 1, 1),
	('Lengua Extranjera II: Alemán', 1, 1),
	('Historia de España', 1, 1),
	('Historia de la Filosofía', 1, 1),
	('Dibujo Artístico II', 1, 1),
	('Análisis Musical II', 1, 1),
	('Artes Escénicas II', 1, 1),
	('Matemáticas II', 1, 1),
	('Matemáticas aplicadas a las Ciencias Sociales II', 1, 1), 
	('Ciencias Generales',1 , 1),
	('Latín II',1 , 1),
	('Matemáticas aplicadas a las Ciencias Sociales II',1,1), 
	('Biología',0,1),
	('Coro y Técnica Vocal II',0,1),
	('Dibujo Técnico Aplicado a las Artes Plásticas y al Diseño II',0,1),
	('Dibujo Técnico II',0,1),
	('Diseño',0,1),
	('Empresa y Diseño de Modelos de Negocio',0,1),
	('Física',0,1),
	('Fundamentos Artísticos',0,1),
	('Geografía',0,1),
	('Geología y Ciencias Ambientales',0,1),
	('Griego II',0,1),
	('Historia de la Música y la Danza',0,1),
	('Historia del Arte',0,1),
	('Literatura Dramática',0,1),
	('Movimientos Culturales y Artísticos',0,1),
	('Química',0,1),
	('Técnicas de Expresión Gráfico Plástica',0,1),
	('Tecnología e Ingeniería',0,1)
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
	('Trastorno por Déficit de Atención e Hiperactividad(TDAH)'),
	('Dificultades Específicas de Aprendizaje (Dislexia, Disgrafía, etc.)'),
	('Trastorno del Espectro Autista (TEA)'),
	('Otras necesidades específicas debidas a problemas de salud mental'),
	('Otras necesidades específicas debidas a problemas de salud física (permanentes o temporales sobrevenidos)')
go



insert into Adaptacion (nombreAdaptacion, descripcion, excepcional, descripcionExcepcional) values
	('Adaptación de textos: fuente', 'Solicite la fuente deseada en el campo observaciones', 1, 'Solicitable en caso de tener una agudeza visual '),
	('Adaptación de textos: tamaño', 'Solicite la fuente deseada en el campo observaciones', 0, '')
go

insert into Adaptacion(nombreAdaptacion) values
	('Aula de apoyo'),
	('Ampliación de tiempo: 15 minutos más'),
	('Ampliación de tiempo: 30 minutos más'),
	('Aula accesible'),
	('Adaptación de los exámenes (en coordinación con la ONCE)'),
	('Adaptación de textos: interlineado'),
	('Adaptación de imágenes o mapas'),
	('Flexo'),
	('Lupa'),
	('Atril'),
	('Línea Braille'),
	('Ordenador'),
	('Equipo FM'),
	('Visitar con antelación las instalaciones donde se celebrará el exámen'),
	('Hoja pautada'),
	('Asiento en primeras filas'),
	('Lectura de los enunciados en voz alta a petición del estudiante'),
	('Descansos durante el examen, sin salir del aula, para realizarejercicios de relajación en su asiento'),
	('Descansos durante el examen, sin salir del aula, para realizar estiramientos en su asiento'),
	('Permiso para beber agua y/o tomar medicación'),
	('Asiento reservado'),
	('Mobiliario adaptado'),
	('Permiso para disponer y utilizar el glucómetro o acceso a los dispositivos de administración de insulina, si se precisa, así como	tomar algún alimento'),
	('Permiso para acudir al servicio'),
	('Acompañamiento por parte de una persona de referencia en el tiempo de descanso entre exámenes (es necesario facilitar un nombre y teléfono de contacto)')
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