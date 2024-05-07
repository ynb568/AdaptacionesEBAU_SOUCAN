use AdaptacionesEBAU_SOUCAN;
go

-----------------------------------------------------------------
-----------------------------------------------------------------
----------------- MAPEADOS DE OBJETOS ---------------------------
-----------------------------------------------------------------
-----------------------------------------------------------------
create or alter procedure sp_obtenPlazoRegistroActivo
as
	begin
		select top(1)* from PlazosRegistro where activo = 1
	end
go

create or alter procedure sp_obtenMunicipioDireccion @idD int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from Direccion where idDireccion = @idD))
			begin
				select * from Municipio m
					inner join Direccion d on m.idMunicipio = d.idMunicipio
					where d.idDireccion = @idD
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				set @Mensaje = ('No existe la direccion asociada');
				set @Completado = 0;
			end
	end;
go	

create or alter procedure sp_obtenDireccionCentro @idCE int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from CentroEducativo where idCE = @idCE))
			begin
				select * from Direccion d
					inner join CentroEducativo ce on d.idDireccion = ce.idDireccion
					where ce.idCE = @idCE
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				set @Mensaje = ('No existe el centro educativo asociado');
				set @Completado = 0;
			end
	end;
go	

create or alter procedure sp_obtenSedeCentro @idCE int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from CentroEducativo where idCE = @idCE))
			begin
				select * from Sede d
					inner join CentroEducativo ce on d.idSede = ce.idSede
					where ce.idCE = @idCE
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				set @Mensaje = ('No existe el centro educativo asociado');
				set @Completado = 0;
			end
	end;
go	



create or alter procedure sp_obtenAdaptacionDiagnostico @idD int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from Diagnostico where idDiagnostico = @idD))
			begin
				select * from Adaptacion a
					inner join AdaptacionDiagnostico ad on a.idAdaptacion = ad.idDiagnostico
					where ad.idDiagnostico = @idD
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				set @Mensaje = ('No existe el diagnostico asociado');
				set @Completado = 0;
			end
	end;
go	

create or alter procedure sp_listaDiagnosticosEstudiante @idE int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from AdaptacionDiagnosticoEstudiante where idEstudiante = @idE))
			begin
				select d.* from Diagnostico d
					inner join AdaptacionDiagnosticoEstudiante ade on d.idDiagnostico = ade.idDiagnostico
					where ade.idEstudiante = @idE
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				set @Mensaje = ('No existe el diagnostico asociado');
				set @Completado = 0;
			end
	end;
go

create or alter procedure sp_listaAdaptacionesDiagnosticoEstudiante @idE int, @idD int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from Estudiante where idEstudiante = @idE))
			begin
				if (exists (select * from AdaptacionDiagnosticoEstudiante where idDiagnostico = @idD and idEstudiante = @idE))
					begin
						select a.*, ade.* from Adaptacion a
							inner join AdaptacionDiagnosticoEstudiante ade on a.idAdaptacion = ade.idAdaptacion
							where ade.idDiagnostico = @idD and ade.idEstudiante = @idE
						set @Mensaje = ('Procedimiento correcto');
						set @Completado = 1;
					end
				else
					begin
						set @Mensaje = ('No existe el diagnostico asociado');
						set @Completado = 0;
					end
			end
		else
			begin
				set @Mensaje = ('No existe el estudiante asociado');
				set @Completado = 0;
			end
	end;
go	

create or alter procedure sp_obtenAsignaturasPrevistasEstudiante @idE int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from Estudiante where idEstudiante = @idE))
			begin
				select aep.idAsignatura, a.nombreAsignatura, a.activo, aep.fase1, aep.fase2 from Asignatura a
					inner join AsignaturaEstudiantePrevista aep on a.idAsignatura = aep.idAsignatura
					where aep.idEstudiante = @idE
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				set @Mensaje = ('No existe el estudiante asociado');
				set @Completado = 0;
			end
	end;
go	


create or alter procedure sp_obtenAsignaturasMatriculadasEstudiante @idE int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from Estudiante where idEstudiante = @idE))
			begin
				select aem.idAsignatura, a.nombreAsignatura, a.activo, aem.fase1, aem.fase2 from Asignatura a
					inner join AsignaturaEstudianteMatriculada aem on a.idAsignatura = aem.idAsignatura
					where aem.idEstudiante = @idE
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				set @Mensaje = ('No existe el estudiante asociado');
				set @Completado = 0;
			end
	end;
go

create or alter procedure sp_obtenCentro @idCE int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from CentroEducativo where idCE = @idCE))
			begin
				select top(1) u.correo, u.contrasenha , ce.* from CentroEducativo ce
					inner join Usuario u on ce.idCE = u.idUsuario
					where idCE = @idCE 
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				set @Mensaje = ('No existe el centro educativo asociado');
				set @Completado = 0;
			end
	end;
go	

create or alter procedure sp_obtenApunteEstudiante @idE int, @idA int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from Estudiante where idEstudiante = @idE))
			begin
				if (exists (select * from Apunte where @idA = idApunte))
					begin
						select * from Asignatura a
							inner join AsignaturaEstudianteMatriculada aem on a.idAsignatura = aem.idAsignatura
							where aem.idEstudiante = @idE
						set @Mensaje = ('Procedimiento correcto');
						set @Completado = 1;
					end
				else
					begin
						set @Mensaje = ('No existe apunte asociado');
						set @Completado = 0;
					end
			end
		else
			begin
				set @Mensaje = ('No existe el estudiante asociado');
				set @Completado = 0;
			end
	end;
go

create or alter procedure sp_obtenEstudianteCentro @idCE int, @idE int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from CentroEducativo where idCE = @idCE))
			begin
				if (exists(select * from Estudiante where idEstudiante = @idE))
					begin
						select top(1) * from Estudiante where idEstudiante= @idE
						set @Mensaje = ('Procedimiento correcto');
						set @Completado = 1;
					end
				else
					begin
						set @Mensaje = ('No existe el estudiante asociado');
						set @Completado = 0;
					end
			end
		else
			begin
				set @Mensaje = ('No existe el centro educativo asociado');
				set @Completado = 0;
			end
	end;
go

create or alter procedure sp_listaAdaptacionesDiagnostico @idD int
as
	begin
		select a.* from Adaptacion a 
			inner join AdaptacionDiagnostico ad on a.idAdaptacion = ad.idAdaptacion
			inner join Diagnostico d on ad.idDiagnostico = d.idDiagnostico
			where a.activo = 1 and d.activo = 1 and d.idDiagnostico = @idD
	end;
go

create or alter procedure sp_obtenDiagnostico @idD int,
	@Mensaje varchar(50) output, @Completado bit output
as
	begin
		if (exists (select * from Diagnostico where idDiagnostico = @idD))
			begin
				select top(1)* from Diagnostico
					where idDiagnostico = @idD
				set @Mensaje = 'Procedimiento completado'
				set @Completado = 1
			end
		else
			begin
				set @Mensaje = 'No existe el diagnostico'
				set @Completado = 0
			end
	end;
go

create or alter procedure sp_obtenAdaptacion @idA int,
	@Mensaje varchar(50) output, @Completado bit output
as
	begin
		if (exists (select * from Adaptacion where idAdaptacion = @idA))
			begin
				select top(1)* from Adaptacion
					where idAdaptacion = @idA
				set @Mensaje = 'Procedimiento completado'
				set @Completado = 1
			end
		else
			begin
				set @Mensaje = 'No existe la adaptacion'
				set @Completado = 0
			end
	end;
go

-----------------------------------------------------------------
-----------------------------------------------------------------
----------------- INSERCION DE OBJETOS --------------------------
-----------------------------------------------------------------
-----------------------------------------------------------------

create or alter procedure sp_registraCentroEducativo
	@nombreCE varchar(100), @telefonoCE varchar(9),
	@nombreOrientador varchar(50), @apellidosOrientador varchar(100), @telefonoOrientador varchar(9) , @correoOrientador varchar(100), 
	@nombreEquipoDirectivo varchar(50), @apellidosEquipoDirectivo varchar(100), @telefonoEquipoDirectivo varchar(9),
	@direccion varchar(100), @idMunicipio int, @idSede int,
	@correo varchar(100), @contrasenha varchar(500), @repetirContrasenha varchar(500),
	@Mensaje varchar(50) output, @Registrado bit output
as
	begin 
		declare @idUsuarioNuevo int;
		declare @idDireccionNueva int;
		begin try
			begin transaction
				if (not exists(select * from CentroEducativo ce
									inner join Usuario u on ce.idCE = u.idUsuario
									where u.correo = @correo and u.contrasenha = @contrasenha and ce.nombreCE = @nombreCE))
				begin
					insert into Usuario (correo, contrasenha)
						values (@correo, @contrasenha)

					set @idUsuarioNuevo = (select idUsuario from Usuario where correo = @correo and contrasenha = @contrasenha)

					insert into Direccion (nombreDireccion, idMunicipio)
						values (@direccion, @idMunicipio)

					set @idDireccionNueva = (select idDireccion from Direccion where nombreDireccion = @direccion and idMunicipio = @idMunicipio);

					insert into CentroEducativo (idCE, idSede, nombreCE, telefonoCE, nombreOrientador, apellidosOrientador, telefonoOrientador, correoOrientador,
						nombreEquipoDirectivo, apellidosEquipoDirectivo, telefonoEquipoDirectivo, idDireccion)
						values (@idUsuarioNuevo, @idSede, @nombreCE, @telefonoCE, @nombreOrientador, @apellidosOrientador, @telefonoOrientador, @correoOrientador,
							@nombreEquipoDirectivo, @apellidosEquipoDirectivo, @telefonoEquipoDirectivo, @idDireccionNueva)

					set @Mensaje = ('Procedimiento correcto');
					set @Registrado = 1;
				end
				else
				begin
					if @@trancount > 0
					rollback transaction
					set @Mensaje = 'El correo y la contraseï¿½a ya estï¿½n registrados';
					set @Registrado = 0;
				end

			commit transaction
		end try

		begin catch
		if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Registrado = 0;
		end catch
	end;
go

/*
EXEC sp_registraCentroEducativo 
    @nombreCE = 'Centro Educativo Prueba', 
    @telefonoCE = '123456789',
    @nombreOrientador = 'Nombre Orientador', 
    @apellidosOrientador = 'Apellidos Orientador', 
    @telefonoOrientador = '987654321', 
    @correoOrientador = 'orientador@prueba.com', 
    @nombreEquipoDirectivo = 'Nombre Directivo', 
    @apellidosEquipoDirectivo = 'Apellidos Directivo', 
    @telefonoEquipoDirectivo = '123456789',
    @direccion = 'Calle Prueba, 123', 
    @idMunicipio = 1, 
    @idSede = 1,
    @correo = 'centro@prueba.com', 
    @contrasenha = 'contraseñaPrueba', 
    @repetirContrasenha = 'contraseñaPrueba',
    @Mensaje = '', 
    @Registrado = 0
go

select * from CentroEducativo;
go
*/



create or alter procedure sp_registraEstudiante @dniE varchar(20),
	@nombreE varchar(50), @ap1E varchar(50), @ap2E varchar(50),
	@nombreT1 varchar(100), @telefonoT1 varchar(9), @nombreT2 varchar(100), @telefonoT2 varchar(9),
	@ordinaria bit, @extraordinaria bit, @idCE int, @observaciones varchar(500),
	@Mensaje varchar(50) output, @registrado bit output, @idE int output
as
	begin
		declare @curso varchar(10);
		begin try
			begin transaction
				--Comprobar existencia centroEducativo y que estï¿½ validado
				--REVISAR
				if (exists(select * from CentroEducativo
								where idCE = @idCE))
					begin
						if (exists (select * from PlazosRegistro where activo = 1))
							begin
								set @curso = (select top(1) cursoConvocatoria from PlazosRegistro where activo = 1) 
								insert into Estudiante (dniEstudiante, nombreEstudiante, ap1Estudiante, ap2Estudiante, 
									nombreCompletoTutor1, telefonoTutor1,  nombreCompletoTutor2, telefonoTutor2, 
										ordinaria, extraordinaria, cursoConvocatoria, idCE, observaciones)
									values (@dniE, @nombreE, @ap1E, @ap2E, 
										@nombreT1, @telefonoT1, @nombreT2, @telefonoT2, 
										@ordinaria, @extraordinaria, @curso, @idCE, @observaciones)
		
								set @Mensaje = ('Procedimiento correcto');
								set @Registrado = 1;

								set @idE = SCOPE_IDENTITY(); --OBTIENE LA PK DEL ÚLTIMO REGISTRO INSERTADO
								
								commit transaction
							end
						else
							begin
								if @@trancount > 0
								rollback transaction
								set @Mensaje = 'No hay un curso académico activo';
								set @Registrado = 0;
							end
					end
				else
					begin
						if @@trancount > 0
						rollback transaction
						set @Mensaje = 'Centro educativo no existente';
						set @Registrado = 0;
					end		
		end try

		begin catch
			if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Registrado = 0;
		end catch
	end;
go

/*
EXEC sp_registraEstudiante 
    @dniE = 'dniEstudiante_REG', 
    @nombreE = 'nombreEstudiante_REG', 
    @ap1E = 'ap1Estudiante_REG', 
    @ap2E = 'ap2Estudiante_REG',
    @nombreT1 = 'nombreCompletoT1_REG', 
    @telefonoT1 = '999888777', 
    @nombreT2 = 'nombreCompletoT2_REG', 
    @telefonoT2 = '888777666',
    @ordinaria = 1, 
    @extraordinaria = 0, 
    @idCE = 1, 
    @observaciones = 'observaciones_REG',
    @Mensaje = '',
    @Registrado = 0
GO

SELECT * FROM Estudiante;
GO
*/

create or alter procedure sp_registraAsignaturaPrevistaEstudiante @idE int, @idA int, @fase1 bit, @fase2 bit,
@Mensaje varchar(50) output, @registrado bit output
as
	begin 
		begin try
			begin transaction
				if (exists(select * from Estudiante where idEstudiante = @idE))
					begin
						if (exists (select * from Asignatura where idAsignatura = @idA and activo = 1))
							begin
								insert into AsignaturaEstudiantePrevista(idEstudiante, idAsignatura, fase1, fase2)
									values (@idE, @idA, @fase1, @fase2)
								set @Mensaje = ('Procedimiento correcto');
								set @Registrado = 1;
							end
						else 
							begin 
								rollback transaction
								set @Mensaje = 'No existe el asignatura activa asociada';
								set @Registrado = 0;
							end
					end
				else
					begin
						if @@trancount > 0
						rollback transaction
						set @Mensaje = 'No existe el estudiante asociado';
						set @Registrado = 0;
					end
			commit transaction
		end try

		begin catch
			if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Registrado = 0;
		end catch
	end;
go
/*
EXEC sp_registraAsignaturaPrevistaEstudiante 
    @idE = 1, 
    @idA = 1, 
    @fase1 = 1, 
    @fase2 = 0,
    @Mensaje = '', 
    @Registrado = 0
GO

SELECT * FROM AsignaturaEstudiantePrevista;
GO
*/

create or alter procedure sp_registraDocumentoEstudiante @idE int, @idD int, @rutaD varchar(MAX),
@Mensaje varchar(50) output, @registrado bit output
as
	begin
		begin try
			begin transaction
				if (exists (select * from Estudiante where idEstudiante = @idE))
					begin
						if (exists (select * from Documento
										where idDocumento = @idD))
							begin
								insert into DocumentoEstudiante(idEstudiante, idDocumento, rutaDocumento)
									values (@idE, @idD, @rutaD);
								set @Mensaje = 'Procedimiento Correcto';
								set @Registrado = 1;

							end
						else
							begin
								if @@trancount > 0
								rollback transaction
								set @Mensaje = 'No existe el documento solicitado asociado';
								set @Registrado = 0;
							end	
					end
				else
					begin
						if @@trancount > 0
						rollback transaction
						set @Mensaje = 'No existe el estudiante asociadoe';
						set @Registrado = 0;
					end	
			commit transaction
		end try

		begin catch
			if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

/*
EXEC sp_registraDocumentoEstudiante 
    @idE = 1, 
    @idD = 1, 
    @rutaD = 'rutaDocumento_REG',
    @Mensaje = '', 
    @Registrado = 0
GO

SELECT * FROM DocumentoEstudiante;
GO
*/

create or alter procedure sp_registraAdaptacionDiagnosticoEstudiante @idE int, @idD int, @idA int, @observaciones varchar(500),
@Mensaje varchar(50) output, @Registrado bit output
as
	begin
		begin try
			begin transaction
				if (exists (select * from Estudiante where idEstudiante = @idE))
					begin
						if (exists (select * from Diagnostico where idDiagnostico = @idD and activo = 1))
							begin
								if (exists (select * from Adaptacion a
												inner join AdaptacionDiagnostico ad on a.idAdaptacion = ad.idAdaptacion 
												where a.idAdaptacion = @idA and a.activo = 1 and ad.idDiagnostico = @idD))
									begin
										insert into AdaptacionDiagnosticoEstudiante (idEstudiante, idDiagnostico, idAdaptacion, observaciones)
											values (@idE, @idD, @idA, @observaciones);
										set @Mensaje = 'Procedimiento Correcto';
										set @Registrado = 1;
									end
								else
									begin
										if @@trancount > 0
											rollback transaction
										set @Mensaje = 'No existe el adaptacion activa asociado';
										set @Registrado = 0;
									end	
							end
						else
							begin
								if @@trancount > 0
									rollback transaction
								set @Mensaje = 'No existe el diagnostico activo asociado';
								set @Registrado = 0;
							end	
					end
				else
					begin
						if @@trancount > 0
							rollback transaction
						set @Mensaje = 'No existe el estudiante asociado';
						set @Registrado = 0;
					end	
			commit transaction
		end try

		begin catch
			if @@trancount > 0
				rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Registrado = 0;
		end catch
	end;
GO


/*
EXEC sp_registraAdaptacionDiagnosticoEstudiante 
    @idE = 1, 
    @idD = 1, 
    @idA = 1, 
    @observaciones = 'observaciones_REG',
    @Mensaje = '', 
    @Registrado = 0
GO

SELECT * FROM AdaptacionDiagnosticoEstudiante;
GO
*/

-----------------------------------------------------------------
-----------------------------------------------------------------
----------------- ELIMINACION DE OBJETOS ------------------------
-----------------------------------------------------------------
-----------------------------------------------------------------

create or alter procedure sp_eliminaDiagnosticoEstudiante @idE int, @idD int,
@Mensaje varchar(50) output, @Eliminado bit output
as
	begin
		begin try
			begin transaction
				if (exists (select * from Estudiante where idEstudiante = @idE))
					begin
						if (exists (select * from AdaptacionDiagnosticoEstudiante 
								where idEstudiante = @idE and idDiagnostico = @idD))
							begin
								delete from AdaptacionDiagnosticoEstudiante 
									where idEstudiante = @idE and idDiagnostico = @idD;
								set @Mensaje = 'Procedimiento Correcto';
								set @Eliminado = 1;	
							end
						else
							begin
								if @@trancount > 0
								rollback transaction
								set @Mensaje = 'No existe el estudiante asociado';
								set @Eliminado = 0;
							end
					end
				else
					begin
						if @@trancount > 0
							rollback transaction
						set @Mensaje = 'No existe el estudiante asociado';
						set @Eliminado = 0;
					end	
			commit transaction
		end try

		begin catch
			if @@trancount > 0
				rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Eliminado = 0;
		end catch
	end;
go

create or alter procedure sp_eliminaAsignaturasPrevistasEstudiante @idE int,
@Mensaje varchar(50) output, @Eliminado bit output
as
	begin
		begin try
			begin transaction
				if (exists (select * from Estudiante where idEstudiante = @idE))
					begin
							delete AsignaturaEstudiantePrevista
								where idEstudiante = @idE
							set @Mensaje = 'Procedimiento Correcto';
							set @Eliminado = 1;
					end
				else
					begin
						if @@trancount > 0
							rollback transaction
						set @Mensaje = 'No existe el estudiante asociado';
						set @Eliminado = 0;
					end	
			commit transaction
		end try

		begin catch
			if @@trancount > 0
				rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Eliminado = 0;
		end catch
	end;
go

create or alter procedure sp_eliminaDocumentosEstudiante @idE int,
@Mensaje varchar(50) output, @Eliminado bit output
as
	begin
		begin try
			begin transaction
				if (exists (select * from Estudiante where idEstudiante = @idE))
					begin
							delete DocumentoEstudiante
								where idEstudiante = @idE
							set @Mensaje = 'Procedimiento Correcto';
							set @Eliminado = 1;
					end
				else
					begin
						if @@trancount > 0
							rollback transaction
						set @Mensaje = 'No existe el estudiante asociado';
						set @Eliminado = 0;
					end	
			commit transaction
		end try

		begin catch
			if @@trancount > 0
				rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Eliminado = 0;
		end catch
	end;
go
-----------------------------------------------------------------
-----------------------------------------------------------------
--------------- MODIFICACION DE OBJETOS -------------------------
-----------------------------------------------------------------
-----------------------------------------------------------------

create or alter procedure sp_modificaDatosCentro @idCE int,
@telefonoCE varchar(9), @nomO varchar(50), @apO varchar(100), @telefonoO varchar(9), @correoO varchar(100),
@nomED varchar(50), @apED varchar(100), @telefonoED varchar(9),
@Mensaje varchar(50) output, @Modificado bit output
as
	begin 
		begin try
			begin transaction
				if (exists(select * from CentroEducativo
								where idCE = @idCE))
					begin
						update CentroEducativo set telefonoCE = @telefonoCE, nombreOrientador = @nomO, apellidosOrientador = @apO,
							correoOrientador = @correoO, nombreEquipoDirectivo = @nomED, apellidosEquipoDirectivo = @apED, telefonoEquipoDirectivo = @telefonoED
							where idCE = @idCE;
						set @Mensaje = 'Procedimiento Correcto';
						set @Modificado = 1;	
					end
				else
					begin
						if @@trancount > 0
						rollback transaction
						set @Mensaje = 'No existe centro educativo asociado';
						set @Modificado = 0;
					end

			commit transaction
		end try

		begin catch
		if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Modificado = 0;
		end catch
	end;
go
/*
exec sp_modificaDatosCentro 1, '345678923', 'Juan', 'Perez', '987654321', 'juan.perez@example.com', 'Ana', 'Gomez', '987987987', '', 0
go
select * from CentroEducativo;
go
*/
--select * from CentroEducativo

--SUGERENCIA: CUANDO SE MODIFICA EL ESTUDIANTE, EL ESTADO DE VALIDADO CAMBIA A PENDIENTE
create or alter procedure sp_modificaDatosEstudiante @idE int,
@ordinaria bit, @extraordinaria bit, @observaciones varchar(500),
@Mensaje varchar(50) output, @Modificado bit output
as
	begin 
		begin try
			begin transaction
				if (exists(select * from Estudiante
								where idEstudiante = @idE))
					begin
						update Estudiante set ordinaria = @ordinaria, extraordinaria = @extraordinaria, observaciones = @observaciones
							where idEstudiante = @idE;
						set @Mensaje = 'Procedimiento Correcto';
						set @Modificado = 1;	
					end
				else
					begin
						if @@trancount > 0
						rollback transaction
						set @Mensaje = 'No existe estudiante asociado';
						set @Modificado = 0;
					end

			commit transaction
		end try

		begin catch
		if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error' + ERROR_MESSAGE());
			set @Modificado = 0;
		end catch
	end;
go

/*
exec sp_modificaDatosEstudiante 
	@idE = 1, 
	@ordinaria = 1, 
	@extraordinaria = 0, 
	@observaciones = 'Nuevas observaciones estudiante', 
	@Mensaje = '', 
	@Modificado = 0
go

select * from Estudiante
*/
-----------------------------------------------------------------
-----------------------------------------------------------------
--------- SECCION FUNCIONALIDADES CENTRO EDUCATIVO --------------
-----------------------------------------------------------------
-----------------------------------------------------------------

--REVISADO






--REVISADO
create or alter procedure sp_listaEstudiantesCentro @idCE int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from CentroEducativo where idCE = @idCE))
			begin
				select * from Estudiante where idCE = @idCE
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				set @Mensaje = ('No existe el centro educativo asociado');
				set @Completado = 0;
			end
	end;
go

/*
create or alter procedure sp_validarCentroEducativo @correo varchar(100), @contrasenha varchar(500),
@Completado bit output

as
	begin
		if (exists(select * from CentroEducativo ce
						inner join Usuario u on ce.idCE = u.idUsuario
							where u.correo = @correo and u.contrasenha = @contrasenha))
			begin				
				select idCE from CentroEducativo ce
						inner join Usuario u on ce.idCE = u.idUsuario
							where u.correo = @correo and u.contrasenha = @contrasenha;
				set @Completado = 1;
			end
		else 
			begin
				set @Completado = 0;
			end	end;
go
*/

create or alter procedure sp_validarCentroEducativo @correo varchar(100), @contrasenha varchar(500),
@idCE int output

as
    begin
        if (exists(select * from CentroEducativo ce
                        inner join Usuario u on ce.idCE = u.idUsuario
                            where u.correo = @correo and u.contrasenha = @contrasenha))
            begin                
                select @idCE = idCE from CentroEducativo ce
                        inner join Usuario u on ce.idCE = u.idUsuario
                            where u.correo = @correo and u.contrasenha = @contrasenha;
            end
        else 
            begin
                set @idCE = -1;
            end
    end;
go

--REVISADO
create or alter procedure sp_cambiaContrasenha @idCE int, @contrasenha varchar(500), @nuevaContrasenha varchar(500),
@Mensaje varchar(50) output, @Completado bit output
as
	begin
		begin try
			begin transaction	
				if (exists (select * from CentroEducativo where idCE = @idCE))
					begin
						if (exists (select * from CentroEducativo ce
										inner join Usuario u on ce.idCE = u.idUsuario
										where u.contrasenha = @contrasenha))
							begin
								update Usuario set contrasenha = @nuevaContrasenha
									where idUsuario = @idCE;
								set @Mensaje = ('Cambio contrasenha correcto');
								set @Completado = 1;
								commit transaction					
							end
						else
							begin
								rollback transaction
								set @Mensaje = ('La contraseï¿½a anterior no es correcta');
								set @Completado = 0;
							end
					end
				else
					begin
						rollback transaction
						set @Mensaje = ('No existe el centro educativo asociado');
						set @Completado = 0;
					end
		end try
		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

--ABARCA LISTA SEDES Y LISTA SEDES ACTIVAS
create or alter procedure sp_listaSedes
as
	begin
		select * from Sede
	end;
go




--REVISADO
create or alter procedure sp_muestraInfoCentroEducativo @idCE int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from CentroEducativo where idCE = @idCE))
			begin		
				select top(1) * from CentroEducativo where idCE = @idCE
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				set @Mensaje = ('No existe el centro educativo asociado');
				set @Completado = 0;
			end
	end;
go

create or alter procedure sp_cambiaInfoCentro @idCE int, @nuevoTelefono varchar(9), 
	@nuevoNombreO varchar(50), @nuevosApellidosO varchar(100), @nuevoCorreoO varchar(100), @nuevoTelefonoO varchar(9),
	@nuevoNombreED varchar(50), @nuevosApellidosED varchar(100), @nuevoTelefonoED varchar(9)
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		begin try
			begin transaction	
				if (exists (select * from CentroEducativo where idCE = @idCE))
					begin
						update CentroEducativo
							set telefonoCE = @nuevoTelefono, 
								nombreOrientador = @nuevoNombreO, apellidosOrientador = @nuevosApellidosO, correoOrientador = @nuevoCorreoO, telefonoOrientador = @nuevoTelefonoO,
								nombreEquipoDirectivo = @nuevoNombreED, apellidosEquipoDirectivo = @nuevosApellidosED, telefonoEquipoDirectivo = @nuevoTelefonoED
							where idCE = @idCE
						set @Mensaje = ('Procedimiento correcto');
						set @Completado = 1;
						commit transaction
					end
				else
					begin
						rollback transaction
						set @Mensaje = ('No existe el centro educativo asociado');
						set @Completado = 0;
					end
		end try
		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go


create or alter procedure sp_listaAsignaturasPrevistasEstudianteF1 @idE int
as
	begin
		select * from Asignatura a
			inner join AsignaturaEstudiantePrevista aep on a.idAsignatura = aep.idAsignatura
			where aep.idEstudiante = @idE and a.fase1 = 1
	end;
go

create or alter procedure sp_listaAsignaturasPrevistasEstudianteF2 @idE int
as
	begin
		select * from Asignatura a
			inner join AsignaturaEstudiantePrevista aep on a.idAsignatura = aep.idAsignatura
			where aep.idEstudiante = @idE and a.fase2 = 1
	end;
go

create or alter procedure sp_listaDocumentosEstudiante @idE int
as
	begin
		select de.idDocumento, d.nombreDocumento, de.rutaDocumento, de.validado from Documento d
			inner join DocumentoEstudiante de on d.idDocumento = de.idDocumento
			where de.idEstudiante = @idE
	end;
go



create or alter procedure sp_listaDiagnosticosEstudiante @idE int
as
	begin
		select * from Diagnostico d
			inner join AdaptacionDiagnosticoEstudiante ade on d.idDiagnostico = ade.idDiagnostico
			where ade.idEstudiante = @idE
	end;
go


--create or alter procedure sp_listaAdaptacionesDiagnosticoEstudiante @id


----------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------
-------------- SECCION FUNCIONALIDADES SOUCAN ------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------

--REVISADO
create or alter procedure sp_inicioSesionSoucan @correo varchar(100), @contrasenha varchar(500)
as
	begin 
		if (exists (select * from Soucan s 
						inner join Usuario u on s.idSoucan = u.idUsuario
							where u.correo = @correo and u.contrasenha = @contrasenha))
			select idSoucan from Soucan s 
				inner join Usuario u on s.idSoucan = u.idUsuario
					where u.correo = @correo and u.contrasenha = @contrasenha
		else
			select '0'
	end;
go



--LISTADO DE OBJETOS


create or alter procedure sp_listaMunicipios 
as
	begin
		select * from Municipio
	end;
go

create or alter procedure sp_listaDiagnosticos
as
	begin
		select * from Diagnostico
	end;
go

create or alter procedure sp_listaAdaptaciones
as
	begin
		select * from Adaptacion
	end;
go

create or alter procedure sp_listaAsignaturas
as
	begin 
		select * from Asignatura
	end;
go

create or alter procedure sp_listaDocumentos
as
	begin
		select * from Documento
	end;
go



--GESTION DE ACTIVOS

create or alter procedure sp_gestionaEstadoDiagnostico @idDiagnostico int, @activo bit,
@Mensaje varchar(50) output, @Completado bit output 
as
	begin
		begin try
			begin transaction
				--Comprobar que idAdaptacion existe
				update Diagnostico set activo = @activo where idDiagnostico = @idDiagnostico 
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			commit transaction
		end try

		begin catch
			if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Completado = 0;
		end catch
	end;
go

create or alter procedure sp_gestionaEstadoAdaptacion @idAdaptacion int, @activo bit,
@Mensaje varchar(50) output, @Completado bit output
as
	begin
		begin try
			begin transaction
				--Comprobar que idAdaptacion existe
				update Adaptacion set activo = @activo where idAdaptacion = @idAdaptacion 
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			commit transaction
		end try

		begin catch
			if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Completado = 0;
		end catch
	end;
go

create or alter procedure sp_gestionaEstadoAsignatura @idAsignatura int, @activo bit,
@Mensaje varchar(50) output, @Completado bit output

as
	begin
		begin try
			begin transaction
				update Asignatura set activo = @activo where idAsignatura = @idAsignatura 
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			commit transaction
		end try

		begin catch
			if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Completado = 0;
		end catch
	end;
go

create or alter procedure sp_gestionaEstadoSede @idS int, @activo bit,
@Mensaje varchar(50) output, @Completado bit output

as
	begin
		begin try
			begin transaction
				update Sede set activo = @activo where idSede = @idS;
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			commit transaction
		end try

		begin catch
			if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Completado = 0;
		end catch
	end;
go

--ASOCIAR ADAPTACION A DIAGNOSTICO
create or alter procedure sp_asociaAdaptacionADiagnostico @idA int, @idD int,
@Mensaje varchar(50) output, @Completado bit output
as
	begin
		begin try
			begin transaction
				if (exists (select * from Diagnostico where idDiagnostico = @idD))
					begin
						if (exists (select * from Adaptacion where idAdaptacion = @idA))
							begin
								if (not exists (select * from AdaptacionDiagnostico where idDiagnostico = @idD and idAdaptacion = @idA))
									begin
										insert into AdaptacionDiagnostico (idDiagnostico, idAdaptacion)
											values (@idD, @idA);
										set @Mensaje = 'Procedimiento Correcto';
										set @Completado = 1;
										commit transaction;
									end
								else
									begin
										if @@trancount > 0
										rollback transaction
										set @Mensaje = 'Adaptacion ya asociada a diagnostico';
										set @Completado = 0;
									end
							end
						else
							begin
								if @@trancount > 0
								rollback transaction
								set @Mensaje = 'No existe adaptacion asociada';
								set @Completado = 0;
							end
					end
				else
					begin
						if @@trancount > 0
						rollback transaction
						set @Mensaje = 'No existe diagnostico asociado';
						set @Completado = 0;
					end
		end try
		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

--ANHADIR ELEMENTOS A LISTAS
create or alter procedure sp_anhadeDiagnostico @nombreDiagnostico varchar(100), @descripcion varchar(500),
@Mensaje varchar(50) output, @Completado bit output
as
	begin
		begin try
			begin transaction
				if (not exists (select * from Diagnostico where nombreDiagnostico = @nombreDiagnostico))
					begin
						insert into Diagnostico (nombreDiagnostico, descripcion) values (@nombreDiagnostico, @descripcion)
						set @Mensaje = ('Procedimiento correcto');
						set @Completado = 1;
						commit transaction;
					end
				else
					begin
						if @@trancount > 0
						rollback transaction
						set @Mensaje = ('Diagnostico ya existente');
						set @Completado = 0
					end
			
		end try

		begin catch
			if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create or alter procedure sp_anhadeAdaptacion @nombreAdaptacion varchar(100), @descipcion varchar(500), 
@excepcional bit, @descipcionExcepcional varchar(500),
@Mensaje varchar(50) output, @Completado bit output
as
	begin
		begin try
			begin transaction
				if (not exists (select * from Adaptacion where nombreAdaptacion = @nombreAdaptacion))
					begin
						if (not (@excepcional = 0 and @descipcion != null))
							begin
								insert into Adaptacion (nombreAdaptacion, descripcion, excepcional, descripcionExcepcional)
									values (@nombreAdaptacion, @descipcion, @excepcional, @descipcionExcepcional);
								set @Mensaje = ('Procedimiento correcto');
								set @Completado = 1;
								commit transaction;
							end
						else
							begin
								if @@trancount > 0
								rollback transaction
								set @Mensaje = ('Si no es excepciopnal no puyede tener descripcion expcepcional');
								set @Completado = 0
							end
					end
				else
					begin
						if @@trancount > 0
						rollback transaction
						set @Mensaje = ('Adaptacion ya existente');
						set @Completado = 0
					end
			
		end try

		begin catch
			if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create or alter procedure sp_anhadeAsigantura @nombreAsignatura varchar(100), @fase1 bit, @fase2 bit,
@Mensaje varchar(50) output, @Completado bit output
as
	begin 
		begin try
			begin transaction
				if (not exists (select * from Asignatura where nombreAsignatura = @nombreAsignatura))
					begin
						insert into Asignatura(nombreAsignatura, fase1, fase2) values (@nombreAsignatura, @fase1, @fase2)
						set @Mensaje = ('Procedimiento correcto');
						set @Completado = 1;
						commit transaction
					end
				else
					begin
						if @@trancount > 0
						rollback transaction
						set @Mensaje = ('La asignatura ya existe');
						set @Completado = 0;
					end
		end try

		begin catch
			if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go




------------------------------------------------------------------------------------------------------------------

--REVISADO
create or alter procedure sp_anhadeApunteEstudiante @descripcion varchar(5000), @idEstudiante int,
@Mensaje varchar(50) output, @Completado bit output
as
	begin
		begin try
			begin transaction
				if (exists (select * from Estudiante where idEstudiante = @idEstudiante))
					begin
						if (@descripcion = '')
							begin
								insert into Apunte(descripcion, idEstudiante) values (@descripcion, @idEstudiante) 
								set @Mensaje = ('Procedimiento correcto');
								set @Completado = 1;
								commit transaction
							end
						else
							begin
							rollback transaction
							set @Mensaje = ('Campo de texto vacï¿½o');
							set @Completado = 0;

						end
					end
				else
					begin
						if @@trancount > 0
						rollback transaction
						set @Mensaje = ('No existe el estudiante asociado');
						set @Completado = 0;
					end
		end try

		begin catch
			if @@trancount > 0
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create or alter procedure sp_listaApuntesEstudiante @idE int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from Estudiante where idEstudiante = @idE))
			begin
				select * from Apunte where idEstudiante = @idE
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				rollback transaction
				set @Mensaje = ('No existe el estudiante asociado');
				set @Completado = 0;
			end
	end;
go

--REVISADO
create or alter procedure sp_muestraInfoEstudiante @idEstudiante int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		if (exists (select * from Estudiante where idEstudiante = @idEstudiante))
			begin
				select top(1) * from Estudiante where idEstudiante = @idEstudiante
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			end
		else
			begin
				rollback transaction
				set @Mensaje = ('No existe el estudiante asociado');
				set @Completado = 0;
			end
	end;
go

/*
insert into Usuario(correo, contrasenha) values ('test1@gmail.com', '1B4F0E9851971998E732078544C96B36C3D01CEDF7CAA332359D6F1D83567014'); --contrasenha: test1
declare @idCE
set @idCE = (select idU from Usuario where correo = 'test1@gmail.com' and contrasenha = '1B4F0E9851971998E732078544C96B36C3D01CEDF7CAA332359D6F1D83567014');
insert into CentroEducativo (idCE) values 

go
*/




create or alter procedure sp_registraAsignaturaMatriculadaEstudiante @idE int, @idA int, @fase1 bit, @fase2 bit
as
	begin 
		declare @Mensaje varchar(50);
		declare @Registrado bit;

		declare @idUsuarioNuevo int;
		declare @idDireccionNueva int;
		begin try
			begin transaction
				if (exists(select * from Estudiante where idEstudiante = @idE))
					begin
						if (exists (select * from Asignatura where idAsignatura = @idA and activo = 1))
							begin
								insert into AsignaturaEstudianteMatriculada(idEstudiante, idAsignatura, fase1, fase2)
									values (@idE, @idA, @fase1, @fase2)
								set @Mensaje = ('Procedimiento correcto');
								set @Registrado = 1;
							end
						else 
							begin 
								rollback transaction
								set @Mensaje = 'No existe el asignatura activa asociada';
								set @Registrado = 0;
							end
					end
				else
					begin
						rollback transaction
						set @Mensaje = 'No existe el estudiante asociado';
						set @Registrado = 0;
					end
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Registrado = 0;
		end catch
	end;
go