use AdaptacionesEBAU_SOUCAN;
go

-----------------------------------------------------------------
-----------------------------------------------------------------
----------------- MAPEADOS DE OBJETOS ---------------------------
-----------------------------------------------------------------
-----------------------------------------------------------------
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
						select a.* from Adaptacion a
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
				select * from Asignatura a
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
				select * from Asignatura a
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

create or alter procedure obtenApunteEstudiante @idE int, @idA int
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

-----------------------------------------------------------------
-----------------------------------------------------------------
----------------- INSERCION DE OBJETOS ---------------------------
-----------------------------------------------------------------
-----------------------------------------------------------------

create or alter procedure sp_registraCentroEducativo
	@nombreCE varchar(100), @telefonoCE varchar(9),
	@nombreOrientador varchar(50), @apellidosOrientador varchar(100), @telefonoOrientador varchar(9) , @correoOrientador varchar(100), 
	@nombreEquipoDirectivo varchar(50), @apellidosEquipoDirectivo varchar(100), @telefonoEquipoDirectivo varchar(9),
	@direccion varchar(100), @idMunicipio int, @idSede int,
	@correo varchar(100), @contrasenha varchar(500), @repetirContrasenha varchar(500)
as
	begin 
		declare @Mensaje varchar(50);
		declare @Registrado bit;

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

					set @idDireccionNueva = (select top(1) idDireccion from Direccion where nombreDireccion = @direccion and idMunicipio = @idMunicipio);

					insert into CentroEducativo (idCE, nombreCE, telefonoCE, nombreOrientador, apellidosOrientador, telefonoOrientador, correoOrientador,
						nombreEquipoDirectivo, apellidosEquipoDirectivo, telefonoEquipoDirectivo, idDireccion)
						values (@idUsuarioNuevo, @nombreCE, @telefonoCE, @nombreOrientador, @apellidosOrientador, @telefonoOrientador, @correoOrientador,
							@nombreEquipoDirectivo, @apellidosEquipoDirectivo, @telefonoEquipoDirectivo, @idDireccionNueva)

					set @Mensaje = ('Procedimiento correcto');
					set @Registrado = 1;
				end
				else
				begin
					rollback transaction
					set @Mensaje = 'El correo y la contrase�a ya est�n registrados';
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


create or alter procedure sp_registraEstudiante @dniEstudiante varchar(20),
	@nombreEstudiante varchar(50), @ap1Estudiante varchar(50), @ap2Estudiante varchar(50),
	@nombreCompletoT1 varchar(100), @telefonoT1 varchar(9), @nombreCompletoT2 varchar(100), @telefonoT2 varchar(9),
	@ordinaria bit, @extraordinaria bit, @idCE int, @observaciones varchar(500)
as
	begin
		declare @Mensaje varchar(50);
		declare @registrado bit;
		declare @curso varchar(10);
		begin try
			begin transaction
				--Comprobar existencia centroEducativo y que est� validado
				--REVISAR
				if (exists(select * from CentroEducativo
								where idCE = @idCE))
					begin
						if (exists (select * from PlazosRegistro where activo = 1))
							begin
								--TODO: asegurar que �nicamente haya 1 plazo activo
								set @curso = (select top(1) cursoConvocatoria from PlazosRegistro where activo = 1) 
								insert into Estudiante (dniEstudiante, nombreEstudiante, ap1Estudiante, ap2Estudiante, 
									nombreCompletoTutor1, telefonoTutor1,  nombreCompletoTutor2, telefonoTutor2, 
										ordinaria, extraordinaria, cursoConvocatoria, idCE, observaciones)
									values (@dniEstudiante, @nombreEstudiante, @ap1Estudiante, @ap2Estudiante, 
										@nombreCompletoT1, @telefonoT1, @nombreCompletoT2, @telefonoT2, 
										@ordinaria, @extraordinaria, @curso, @idCE, @observaciones)
		
								set @Mensaje = ('Procedimiento correcto');
								set @Registrado = 1;
								commit transaction
							end
						else
							begin
								rollback transaction
								set @Mensaje = 'No hay un curso acad�mico activo';
								set @Registrado = 0;
							end
					end
				else
					begin
						rollback transaction
						set @Mensaje = 'Centro educativo no existente';
						set @Registrado = 0;
					end		
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create or alter procedure sp_registraAsignaturaPrevistaEstudiante @idE int, @idA int, @fase1 bit, @fase2 bit
as
	begin 
		declare @Mensaje varchar(50);
		declare @Registrado bit;
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


create or alter procedure sp_registraDocumentoEstudiante @idE int, @idD int, @rutaD varchar(MAX)
as
	begin
		declare @Mensaje varchar(50);
		declare @registrado bit;
		begin try
			begin transaction
				if (exists (select * from Estudiante where idEstudiante = @idE))
					begin
						if (exists (select * from Documento
										where idDocumento = @idD))
							begin
								insert into DocumentoEstudiante(idEstudiante, idDocumento, rutaDocumento)
									values (@idE, @idD, @rutaD)
							end
						else
							begin
								rollback transaction
								set @Mensaje = 'No existe el documento solicitado asociado';
								set @Registrado = 0;
							end	
					end
				else
					begin
						rollback transaction
						set @Mensaje = 'No existe el estudiante asociadoe';
						set @Registrado = 0;
					end	
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create or alter procedure sp_registraAdaptacionDiagnosticoEstudiante @idE int, @idD int, @idA int, @observaciones varchar(500)
as
	begin
		declare @Mensaje varchar(50);
		declare @registrado bit;
		begin try
			begin transaction
				if (exists (select * from Estudiante where idEstudiante = @idE))
					begin
						if (exists (select * from Diagnostico where idDiagnostico = @idD and activo = 1))
							begin
								if (exists (select * from Adaptacion a
												inner join AdaptacionDiagnostico ad on a.idAdaptacion = ad.idAdaptacion 
												where a.idAdaptacion = @idD and a.activo = 1 and ad.idDiagnostico = @idD))
									begin
										insert into AdaptacionDiagnosticoEstudiante (idEstudiante, idDiagnostico, idAdaptacion, observaciones)
											values (@idE, @idD, @idA, @observaciones);
									end
						else
							begin
								rollback transaction
								set @Mensaje = 'No existe el adaptacion activa asociado';
								set @Registrado = 0;
							end	
						end
					else
						begin
							rollback transaction
							set @Mensaje = 'No existe el diagnostico activo asociado';
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
		end catch
	end;
go



-----------------------------------------------------------------
-----------------------------------------------------------------
--------- SECCION FUNCIONALIDADES CENTRO EDUCATIVO --------------
-----------------------------------------------------------------
-----------------------------------------------------------------

--REVISADO
create or alter procedure sp_inicioSesionCentroEducativo @correo varchar(100), @contrasenha varchar(500)
as
	begin
		if (exists(select * from CentroEducativo ce
						inner join Usuario u on ce.idCE = u.idUsuario
							where u.correo = @correo and u.contrasenha = @contrasenha))
			select idCE from CentroEducativo ce
						inner join Usuario u on ce.idCE = u.idUsuario
							where u.correo = @correo and u.contrasenha = @contrasenha 
		else 
			select '0'
	end;
go

--REVISADO

--ARREGLAR: lo mejor va a ser eliminar todas las asignaturas previas y despues ir a�adiendo una a una las nuevas
/*
create type AsignaturaType as table (idA int);
go


create or alter procedure sp_modificaEstudiante 
	@idE int, @idCE int, @idA int
	@nuevasAsignaturas AsignaturaType READONLY
as
	begin
		declare @Mensaje varchar(50);
		declare @registrado bit;
		declare @curso varchar(10);
		begin try
			begin transaction
				--Comprobar existencia centroEducativo y que est� validado
				--REVISAR
				if (exists(select * from CentroEducativo
								where idCE = @idCE))
					begin
						if (exists (select * from Estudiante where idEstudiante = @idE))
							begin
								
								set @Mensaje = ('Procedimiento correcto');
								set @Registrado = 1;
								commit transaction
							end
						else
							begin
								rollback transaction
								set @Mensaje = 'Estudiante no existente';
								set @Registrado = 0;
							end
					end
				else
					begin
						rollback transaction
						set @Mensaje = 'Centro educativo no existente';
						set @Registrado = 0;
					end		
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go
*/



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

--REVISADO
create or alter procedure sp_cambiaContrasenhaCentro @idCE int, @contrasenhaPrevia varchar(500), @contrasenhaNueva varchar(500)
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		begin try
			begin transaction	
				if (exists (select * from CentroEducativo where idCE = @idCE))
					begin
						if (exists (select * from CentroEducativo ce
										inner join Usuario u on ce.idCE = u.idUsuario
										where u.contrasenha = @contrasenhaPrevia))
							begin
								update Usuario set contrasenha = @contrasenhaNueva
									where idUsuario = @idCE;
								set @Mensaje = ('Procedimiento correcto');
								set @Completado = 1;
								commit transaction					
							end
						else
							begin
								rollback transaction
								set @Mensaje = ('La contrase�a anterior no es correcta');
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



create or alter procedure sp_eliminaDiagnosticoEstudiante @idE int, @idDiagnostico int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		begin try
			begin transaction	
				if (exists (select * from Estudiante where idEstudiante = @idE))
					begin
						if (exists(select * from AdaptacionDiagnosticoEstudiante))
							begin
								delete from AdaptacionDiagnosticoEstudiante
									where idEstudiante = @idE and idDiagnostico = @idDiagnostico
								set @Mensaje = ('Procedimiento correcto');
								set @Completado = 1;
								commit transaction
							end
						else
							begin
								rollback transaction
								set @Mensaje = ('Adaptaci�n no asignada a estudiante previamente');
								set @Completado = 0;
							end
					end
				else 
					begin
						rollback transaction
						set @Mensaje = ('No existe el estudiante asociado');
						set @Completado = 0;
					end
		end try
		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go
-----------------------------------------------------------------
-----------------------------------------------------------------
-------------- SECCION FUNCIONALIDADES SOUCAN -------------------
-----------------------------------------------------------------
-----------------------------------------------------------------

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




--REVISADO


create or alter procedure sp_listaMunicipios 
as
	begin
		select * from Municipio
	end;
go



--REVISADO
create or alter procedure sp_anhadeApunteEstudiante @descripcion varchar(5000), @idEstudiante int
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit
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
							set @Mensaje = ('Campo de texto vac�o');
							set @Completado = 0;

						end
					end
				else
					begin
						rollback transaction
						set @Mensaje = ('No existe el estudiante asociado');
						set @Completado = 0;
					end
		end try

		begin catch
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

--REVISADO
create or alter procedure sp_listaCentrosEducativos
as
	begin
		select u.correo, u.contrasenha, ce.* from CentroEducativo ce
			inner join Usuario u on ce.idCE = u.idUsuario
	end;
go


--REVISADO
create or alter procedure sp_anhadeAsigantura @nombreAsignatura varchar(100), @fase1 bit, @fase2 bit
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit 
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
						rollback transaction
						set @Mensaje = ('La asignatura ya existe');
						set @Completado = 0;
					end
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

--REVISADO
create or alter procedure sp_gestionaEstadoAsignatura @idAsignatura int, @activo bit
as
	begin
		declare @Mensaje varchar(50);
		declare @Completado bit;
		begin try
			begin transaction
				update Asignatura set activo = @activo where idAsignatura = @idAsignatura 
				set @Mensaje = ('Procedimiento correcto');
				set @Completado = 1;
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Completado = 0;
		end catch
	end;
go

--REVISADO
create or alter procedure sp_listaAsignaturas
as
	begin 
		select * from Asignatura
	end;
go

--RETOCAR PARA ADAPTACIONES DETALLE
create or alter procedure sp_anhadeAdaptacion @nombreAdaptacion varchar(100)
as
	begin
		declare @Mensaje varchar(50);
		begin try
			begin transaction
				--Comprobar que no existe un diagnostico con el mismo nombre
				insert into Adaptacion(nombreAdaptacion) values (@nombreAdaptacion)
				set @Mensaje = ('Procedimiento correcto');
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create or alter procedure sp_gestionaEstadoAdaptacion @idAdaptacion int, @activo bit
as
	begin
		declare @Mensaje varchar(50);
		begin try
			begin transaction
				--Comprobar que idAdaptacion existe
				update Adaptacion set activo = @activo where idAdaptacion = @idAdaptacion 
				set @Mensaje = ('Procedimiento correcto');
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create or alter procedure sp_listaAdaptaciones
as
	begin
		select * from Adaptacion
	end;
go



create or alter procedure sp_anhadeDiagnostico @nombreDiagnostico varchar(100)
as
	begin
		declare @Mensaje varchar(50);
		begin try
			begin transaction
				--Comprobar que no existe un diagnostico con el mismo nombre
				insert into Diagnostico (nombreDiagnostico) values (@nombreDiagnostico)
				set @Mensaje = ('Procedimiento correcto');
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create or alter procedure sp_gestionaEstadoDiagnostico @idDiagnostico int, @activo bit
as
	begin
		declare @Mensaje varchar(50);
		begin try
			begin transaction
				--Comprobar que idAdaptacion existe
				update Diagnostico set activo = @activo where idDiagnostico = @idDiagnostico 
				set @Mensaje = ('Procedimiento correcto');
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create or alter procedure sp_listaDiagnosticos
as
	begin
		select * from Diagnostico
	end;
go

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