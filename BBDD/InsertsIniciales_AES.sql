use AdaptacionesEBAU_SOUCAN;
go


--INSERTS INICIALES
--Asignaturas
insert into Asignatura(nombreAsignatura, fase1, fase2) values
	/*
	('Lengua Castellana y Literatura II', 1, 1),
	('Primera Lengua Extranjera II: Ingl�s', 1, 1),
	('Primera Lengua Extranjera II: Franc�s', 1, 1),
	('Primera Lengua Extranjera II: Alem�n', 1, 1),
	('Historia de Espa�a', 1, 1),
	('Historia de la Filosof�a', 1, 1),
	('Artes Pl�sticas, Imagen y Dise�o: Dibujo Art�stico II', 1, 1),
	('M�sica y Artes Esc�nicas: An�lisis Musical II', 1, 1),
	('M�sica y Artes Esc�nicas: Artes Esc�nicas II', 1, 1),
	('Ciencia y Tecnolog�a: Matem�ticas II', 1, 1),
	('Ciencia y Tecnolog�a: Matem�ticas aplicadas a las Ciencias Sociales II', 1, 1), --TRIPLE
	('General: Ciencias Generales',1 , 1),
	('Humanidades y Ciencias Sociales: Lat�n II',1 , 1),
	('Humanidades y Ciencias Sociales: Matem�ticas aplicadas a las Ciencias Sociales II',c1,1), --TRIPLE
	*/
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
	('Matem�ticas aplicadas a las Ciencias Sociales II', 1, 1), --TRIPLE
	('Ciencias Generales',1 , 1),
	('Lat�n II',1 , 1),
	('Matem�ticas aplicadas a las Ciencias Sociales II',c1,1), --TRIPLE

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

insert into Diagnostico(nombreDiagnostico) values
	('Discapacidad Motriz'),
	('Discapacidad Visual'),
	('Discapacidad Auditiva'),
	('Trastorno por D�ficit de Atenci�n e Hiperactividad(TDAH)'),
	('Dificultades Espec�ficas de Aprendizaje (Dislexia, Disgraf�a, etc.)'),
	('Trastorno del Espectro Autista (TEA)'),
	('Otras necesidades espec�ficas debidas a problemas de salud mental'),
	('Otras necesidades espec�ficas debidas a problemas de salud f�sica (permanentes o temporales sobrevenidos)')
go

insert into Adaptacion(nombreAdaptacion) values
	('Adaptaci�n de textos: fuente'),
	('Adaptaci�n de textos: tama�o'),
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

insert into CEDisponible (nombreCED) values
	('COLEGIO CASTROVERDE'),
	('COLEGIO SAN AGUST�N'),
	('IES LA GRANJA'),
	('IES RICARDO BERNARDO'),
	('COLEGIO TORREANAZ'),
	('IES SANTA CRUZ'),
	('IES SANTA CLARA'),
	('IES R�A DEL CARMEN'),
	('IES EL ASTILLERO'),
	('IES MURIEDAS'),
	('IES VALLE DE CAMARGO'),
	('IES LAS LLAMAS'),
	('IES LOPE DE VEGA'),
	('COLEGIO ESCLAVAS SCK'),
	('COLEGIO LA SALLE'),
	('IES TORRES QUEVEDO'),
	('IES ALBERTO PICO'),
	('IES JOS� MAR�A PEREDA'),
	('COLEGIO TORREVELO-PE�ALABRA'),
	('COLEGIO KOSTKA'),
	('IES A. GLEZ. LINARES'),
	('IES ALISAL'),
	('IES CANTABRIA'),
	('IES LA ALBERICIA'),
	('IES PE�ACASTILLO'),
	('FP Y OTROS DISTRITOS'),
	('COLEGIO MAR�A AUXILIADORA (SALESIANOS)'),
	('IES LA MARINA'),
	('IES NTRA. SRA. REMEDIOS'),
	('COLEGIO CALASANZ (ESCOLAPIOS)'),
	('IES VILLAJUNCO'),
	('IES ESTELAS DE CANTABRIA'),
	('IES GARCILASO DE LA VEGA'),
	('IES MAR�A TELO'),
	('IES MARQU�S DE SANTILLANA'),
	('IES ZAPAT�N'),
	('COLEGIO NTRA. SRA. LA PAZ'),
	('IES BESAYA'),
	('IES M. GUTI�RREZ ARAG�N'),
	('IES M. HERRERO PEREDA'),
	('IES VALLE DE PI�LAGOS'),
	('IES BERNARDINO ESCALANTE'),
	('IES FUENTE FRESNEDO'),
	('IES JOS� DEL CAMPO'),
	('IES MARISMAS'),
	('IES MARQU�S DE MANZANEDO'),
	('IES SAN MIGUEL DE MERUELO'),
	('IES VALENT�N TURIENZO'),
	('IES ATA�LFO ARGENTA'),
	('IES JOS� ZAPATERO'),
	('IES OCHO DE MARZO'),
	('IES JES�S DE MONASTERIO'),
	('IES JOS� HIERRO'),
	('COLEGIO SAN JOS� DE REINOSA'),
	('IES MONTESCLAROS'),
	('IES FORAMONTANOS'),
	('IES NUEVE VALLES'),
	('IES VALLE DEL SAJA')
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

--FALTA ASOCIARLO A LA ADAPTACI�N EN CONCRETO
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