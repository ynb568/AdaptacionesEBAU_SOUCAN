use AdaptacionesEBAU_SOUCAN;
go


--INSERTS INICIALES
--Asignaturas
insert into Asignatura(nombreAsignatura, fase1, fase2) values
	/*
	('Lengua Castellana y Literatura II', 1, 1),
	('Primera Lengua Extranjera II: Inglés', 1, 1),
	('Primera Lengua Extranjera II: Francés', 1, 1),
	('Primera Lengua Extranjera II: Alemán', 1, 1),
	('Historia de España', 1, 1),
	('Historia de la Filosofía', 1, 1),
	('Artes Plásticas, Imagen y Diseño: Dibujo Artístico II', 1, 1),
	('Música y Artes Escénicas: Análisis Musical II', 1, 1),
	('Música y Artes Escénicas: Artes Escénicas II', 1, 1),
	('Ciencia y Tecnología: Matemáticas II', 1, 1),
	('Ciencia y Tecnología: Matemáticas aplicadas a las Ciencias Sociales II', 1, 1), --TRIPLE
	('General: Ciencias Generales',1 , 1),
	('Humanidades y Ciencias Sociales: Latín II',1 , 1),
	('Humanidades y Ciencias Sociales: Matemáticas aplicadas a las Ciencias Sociales II',c1,1), --TRIPLE
	*/
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
	('Matemáticas aplicadas a las Ciencias Sociales II', 1, 1), --TRIPLE
	('Ciencias Generales',1 , 1),
	('Latín II',1 , 1),
	('Matemáticas aplicadas a las Ciencias Sociales II',c1,1), --TRIPLE

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

insert into Diagnostico(nombreDiagnostico) values
	('Discapacidad Motriz'),
	('Discapacidad Visual'),
	('Discapacidad Auditiva'),
	('Trastorno por Déficit de Atención e Hiperactividad(TDAH)'),
	('Dificultades Específicas de Aprendizaje (Dislexia, Disgrafía, etc.)'),
	('Trastorno del Espectro Autista (TEA)'),
	('Otras necesidades específicas debidas a problemas de salud mental'),
	('Otras necesidades específicas debidas a problemas de salud física (permanentes o temporales sobrevenidos)')
go

insert into Adaptacion(nombreAdaptacion) values
	('Adaptación de textos: fuente'),
	('Adaptación de textos: tamaño'),
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

insert into CEDisponible (nombreCED) values
	('COLEGIO CASTROVERDE'),
	('COLEGIO SAN AGUSTÍN'),
	('IES LA GRANJA'),
	('IES RICARDO BERNARDO'),
	('COLEGIO TORREANAZ'),
	('IES SANTA CRUZ'),
	('IES SANTA CLARA'),
	('IES RÍA DEL CARMEN'),
	('IES EL ASTILLERO'),
	('IES MURIEDAS'),
	('IES VALLE DE CAMARGO'),
	('IES LAS LLAMAS'),
	('IES LOPE DE VEGA'),
	('COLEGIO ESCLAVAS SCK'),
	('COLEGIO LA SALLE'),
	('IES TORRES QUEVEDO'),
	('IES ALBERTO PICO'),
	('IES JOSÉ MARÍA PEREDA'),
	('COLEGIO TORREVELO-PEÑALABRA'),
	('COLEGIO KOSTKA'),
	('IES A. GLEZ. LINARES'),
	('IES ALISAL'),
	('IES CANTABRIA'),
	('IES LA ALBERICIA'),
	('IES PEÑACASTILLO'),
	('FP Y OTROS DISTRITOS'),
	('COLEGIO MARÍA AUXILIADORA (SALESIANOS)'),
	('IES LA MARINA'),
	('IES NTRA. SRA. REMEDIOS'),
	('COLEGIO CALASANZ (ESCOLAPIOS)'),
	('IES VILLAJUNCO'),
	('IES ESTELAS DE CANTABRIA'),
	('IES GARCILASO DE LA VEGA'),
	('IES MARÍA TELO'),
	('IES MARQUÉS DE SANTILLANA'),
	('IES ZAPATÓN'),
	('COLEGIO NTRA. SRA. LA PAZ'),
	('IES BESAYA'),
	('IES M. GUTIÉRREZ ARAGÓN'),
	('IES M. HERRERO PEREDA'),
	('IES VALLE DE PIÉLAGOS'),
	('IES BERNARDINO ESCALANTE'),
	('IES FUENTE FRESNEDO'),
	('IES JOSÉ DEL CAMPO'),
	('IES MARISMAS'),
	('IES MARQUÉS DE MANZANEDO'),
	('IES SAN MIGUEL DE MERUELO'),
	('IES VALENTÍN TURIENZO'),
	('IES ATAÚLFO ARGENTA'),
	('IES JOSÉ ZAPATERO'),
	('IES OCHO DE MARZO'),
	('IES JESÚS DE MONASTERIO'),
	('IES JOSÉ HIERRO'),
	('COLEGIO SAN JOSÉ DE REINOSA'),
	('IES MONTESCLAROS'),
	('IES FORAMONTANOS'),
	('IES NUEVE VALLES'),
	('IES VALLE DEL SAJA')
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

--FALTA ASOCIARLO A LA ADAPTACIÓN EN CONCRETO
insert into AdaptacionTipoLetra (idATipoL, tipoLetra) values 
	(1, 'Georgia'),
	(1, 'Garamond'),
	(1, 'Helvetica'),
	(1, 'Times New Roman'),
	(1, 'Trajan Pro'),
	(1, 'Calibri'),
	(1, 'Impact'),
	(1, 'Gill Sans'),
	(1, 'Arial'),
	(1, 'Verdana'),
	(1, 'Tahoma'),
	(1, 'Trebuchet MS')
go

insert into AdaptacionTamanhoLetra (idATamL, tamanhoLetra) values
	(2, '10'),
	(2, '11'),
	(2, '12'),
	(2, '13'),
	(2, '14'),
	(2, '15'),
	(2, '16'),
	(2, '17'),
	(2, '18'),
	(2, '19'),
	(2, '20')
go