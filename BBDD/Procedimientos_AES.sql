use AdaptacionesEBAU_SOUCAN;
go


create procedure sp_inicioSesionSoucan @correo varchar(100), @contrasenha varchar(500)
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

create procedure sp_inicioSesionCentroEducativo @correo varchar(100), @contrasenha varchar(500)
as
	begin
		if (exists(select * from CentroEducativo ce
						inner join Usuario u on ce.idCE = u.idUsuario
							where u.correo = @correo and u.contrasenha = @contrasenha and ce.validado = 1))
			select idCE from CentroEducativo ce
						inner join Usuario u on ce.idCE = u.idUsuario
							where u.correo = @correo and u.contrasenha = @contrasenha 
		else 
			select '0'
	end;
go



--¿QUÉ CORREO VA A ESTAR ASOCIADO AL USUARIO DEL CENTRO EDUCATIVO?
create procedure sp_registraCentroEducativo
	@correo varchar(100), @contrasenha varchar(500),
	@idCED int, @telefonoCE varchar(9), @nombreOrientador varchar(50), @apellidosOrientador varchar(100),
	@telefonoOrientador varchar (9) , @correoOrientador varchar(100), @nombreEquipoDirectivo varchar(50), 
	@apellidosEquipoDirectivo varchar(100), @telefonoEquipoDirectivo varchar(9), @correoEquipoDirectivo varchar(100),
	@direccion varchar(100), @idMunicipio int
as
	begin 
		declare @Mensaje varchar(50);
		declare @Registrado bit;

		declare @idUsuarioNuevo int;
		declare @idDireccionNueva int;
		begin try
			begin transaction
				--Comprobar existencia de iDMunicipio
				--Comprobar existencia del nombre del centro educativo disponible
				insert into Usuario (correo, contrasenha)
					values (@correo, @contrasenha)

				set @idUsuarioNuevo = (select idUsuario from Usuario where correo = @correo and contrasenha = @contrasenha)

				insert into Direccion (direccion, idMunicipio)
					values (@direccion, @idMunicipio)

				set @idDireccionNueva = (select idDireccion from Direccion where direccion = @direccion and idMunicipio = @idMunicipio);

				insert into CentroEducativo (idCE, idCED, telefonoCE, nombreOrientador, apellidosOrientador, telefonoOrientador, correoOrientador,
					nombreEquipoDirectivo, apellidosEquipoDirectivo, telefonoEquipoDirectivo, correoEquipoDirectivo, idDireccion)
					values (@idUsuarioNuevo, @idCED, @telefonoCE, @nombreOrientador, @apellidosOrientador, @telefonoOrientador, @correoOrientador,
								@nombreEquipoDirectivo, @apellidosEquipoDirectivo, @telefonoEquipoDirectivo, @correoEquipoDirectivo, @idDireccionNueva)

				set @Mensaje = ('Procedimiento correcto');
				set @Registrado = 1;
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
			set @Registrado = 0;
		end catch
	end;
go

create procedure sp_registraEstudiante 
	@nombreEstudiante varchar(50), @ap1Estudiante varchar(50), @ap2Estudiante varchar(50), @convocatoria varchar(20), @documentos varchar(MAX),
	@direccion varchar(100), @idMunicipio int,
	@idCE int
as
	begin
		declare @Mensaje varchar(50);
		declare @idDireccionNueva int;
		begin try
			begin transaction
				--Comprobar existencia municipio
				--Comprobar existencia centroEducativo y que esté validado
				--Comprobar que no exista con mismo nombre y apellidos
				insert into Direccion (direccion, idMunicipio)
					values (@direccion, @idMunicipio)

				set @idDireccionNueva = (select idDireccion from Direccion where direccion = @direccion and idMunicipio = @idMunicipio);

				insert into Estudiante (nombreEstudiante, ap1Estudiante, ap2Estudiante, convocatoria, documentos, idDireccion, idCE)
					values (@nombreEstudiante, @ap1Estudiante, @ap2Estudiante, @convocatoria, @documentos, @idDireccionNueva, @idCE)
				
				set @Mensaje = ('Procedimiento correcto');
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create procedure sp_anhadeApunteEstudiante @descripcion varchar(500), @idEstudiante int
as
	begin
		declare @Mensaje varchar(50)
		begin try
			begin transaction
				--Comprobar existencia de estudiante
				insert into Apunte(descripcion, idEstudiante) values (@descripcion, @idEstudiante) 
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create procedure sp_listaApuntesEstudiante @idEstudiante int
as
	begin
		--Comprobar existencia de estudiante
		select * from Apunte where idEstudiante = @idEstudiante
	end
go;

create procedure sp_muestraInfoEstudiante @idEstudiante int
as
	begin
		--Comprobar existencia de estudiante
		select top(1) * from Estudiante where idEstudiante = @idEstudiante
	end
go;

create procedure sp_muestraInfoCentroEducativo @idCE int
as
	begin
		--Comprobar existencia de centro educativo
		select top(1) * from CentroEducativo where idCE = @idCE
	end
go;


create procedure sp_validaCentroEducativo @idCE int, @idSede int
as
	begin
		declare @Mensaje varchar(50)
		begin try
			begin transaction
				--Comprobar que la sede existe
				--Comprobar que no esté validado ya
				update CentroEducativo set validado = 1, idSede = @idSede where idCE = @idCE
				set @Mensaje = ('Procedimiento correcto');
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go
--Se puede filtrar la informacion
create procedure sp_listaCentrosEducativos
as
	begin
		select * from CentroEducativo
	end
go

create procedure sp_listaEstudiantesCentro @idCE int
as
	begin
		select * from Estudiante where idCE = @idCE
	end
go

create procedure sp_anhadeAsigantura @nombreAsignatura varchar(100), @fase1 bit, @fase2 bit
as
	begin
		declare @Mensaje varchar(50);
		begin try
			begin transaction
				--Comprobar que no existe un diagnostico con el mismo nombre
				insert into Asignatura(nombreAsignatura, fase1, fase2) values (@nombreAsignatura, @fase1, @fase2)
				set @Mensaje = ('Procedimiento correcto');
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create procedure sp_gestionaEstadoAsignatura @idAsignatura int, @activo bit
as
	begin
		declare @Mensaje varchar(50);
		begin try
			begin transaction
				--Comprobar que idAdaptacion existe
				update Asignatura set activo = @activo where idAsignatura = @idAsignatura 
				set @Mensaje = ('Procedimiento correcto');
			commit transaction
		end try

		begin catch
			rollback transaction
			set @Mensaje = ('Se ha producido un error');
		end catch
	end;
go

create procedure sp_listaAsignaturasSoucan
as
	begin 
		select * from Asignatura
	end
go

create procedure sp_listaAsignaturasCE
as
	begin 
		select * from Asignatura where activo = 1
	end
go

--RETOCAR PARA ADAPTACIONES DETALLE
create procedure sp_anhadeAdaptacion @nombreAdaptacion varchar(100)
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

create procedure sp_gestionaEstadoAdaptacion @idAdaptacion int, @activo bit
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

create procedure sp_listaAdaptacionesSoucan
as
	begin
		select * from Adaptacion
	end
go

create procedure sp_listaAdaptacionesPorDiagnosticoCE @idDiagnostico int
as
	begin
		select a.* from Adaptacion a 
			inner join AdaptacionDiagnostico ad on a.idAdaptacion = ad.idAdaptacion
			inner join Diagnostico d on ad.idDiagnostico = d.idDiagnostico
			where a.activo = 1 and d.activo = 1 and d.idDiagnostico = @idDiagnostico
	end
go

create procedure sp_anhadeDiagnostico @nombreDiagnostico varchar(100)
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

create procedure sp_gestionaEstadoDiagnostico @idDiagnostico int, @activo bit
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

create procedure sp_listaDiagnosticosSoucan
as
	begin
		select * from Diagnostico
	end
go

create procedure sp_listaDiagnosticosCE
as
	begin
		select * from Diagnostico where activo = 1
	end
go