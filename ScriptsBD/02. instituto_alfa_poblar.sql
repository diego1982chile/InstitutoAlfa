USE instituto_alfa
GO

--Poblar anyos
insert into anyo values (2011);
insert into anyo values (2012);
insert into anyo values (2013);
insert into anyo values (2014);
insert into anyo values (2015);
insert into anyo values (2016);
insert into anyo values (2017);
insert into anyo values (2018);
insert into anyo values (2019);
insert into anyo values (2020);
insert into anyo values (2021);

--Poblar bimestres
insert into bimestre values (1, '1° Bimestre');
insert into bimestre values (2, '2° Bimestre');
insert into bimestre values (3, '3° Bimestre');
insert into bimestre values (4, '4° Bimestre');

--Poblar asignaturas
insert into asignatura values ('C112', 'UML');
insert into asignatura values ('C114', 'EJB');
insert into asignatura values ('C121', '.NET');
insert into asignatura values ('C136', 'Angular');
insert into asignatura values ('C141', 'ReactJS');
insert into asignatura values ('C152', 'SQL Server');

--Poblar salas
insert into sala values ('A1', 10);
insert into sala values ('A2', 10);
insert into sala values ('A3', 10);
insert into sala values ('A4', 10);
insert into sala values ('A5', 10);
insert into sala values ('A6', 20);
insert into sala values ('A7', 20);
insert into sala values ('A8', 20);
insert into sala values ('A9', 20);
insert into sala values ('A10', 30);
insert into sala values ('A11', 30);
insert into sala values ('A12', 30);
insert into sala values ('A13', 30);
insert into sala values ('A14', 30);
insert into sala values ('A15', 30);
insert into sala values ('A16', 40);
insert into sala values ('A17', 40);
insert into sala values ('A18', 40);
insert into sala values ('A19', 40);
insert into sala values ('A20', 40);

--Poblar Profesores
insert into profesor values ('9407106-2', 'Belen Olmo');
insert into profesor values ('14373896-5', 'Angelina Castello');
insert into profesor values ('11592322-6', 'Juan Jose Arteaga');
insert into profesor values ('15290743-5', 'Mohammed Moreno');
insert into profesor values ('9564261-6', 'Brian Garriga');
insert into profesor values ('13015311-9', 'Micaela Ferreiro');
insert into profesor values ('12819682-k', 'Elvira Enriquez');
insert into profesor values ('13461510-9', 'Axel Carmona');
insert into profesor values ('15942685-8', 'Eleuterio Suarez');
insert into profesor values ('16131907-4', 'Ikram Capdevila');

--Poblar Alumnos
insert into alumno values ('21469987-7', 'Judith Arnaiz', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('12172751-k', 'Youssef Ramon', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('14613497-1', 'Anas Boix', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('17172260-8', 'Yurena Granado', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('16728304-7', 'Eusebia Rial', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('23649675-9', 'Georgina Collado', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('15125892-1', 'Marc Carmona', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('11864391-7', 'Claudia Padron', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('8196909-4', 'Gloria Manzano', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('6529213-0', 'Cecilia Quiles', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('24179182-3', 'Edurne Luque', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('19204341-7', 'Fermin Frances', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('19177763-8', 'Roberto Novo', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('5268493-5', 'Teofilo Gabarri', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('9121357-5', 'Victoriano Marquez', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('23903858-1', 'Samara Gamero', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('9102175-7', 'Yassin Figueras', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('5023968-3', 'Jana Nogales', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('6011606-7', 'Celestino Matos', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('23589761-k', 'Faustina Ferre', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('15283020-3', 'Noelia Velazquez', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('23525406-9', 'Valeriano Zheng', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('13191502-0', 'Paz Solano', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('17147107-9', 'Manolo Castells', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('8741614-3', 'Gregorio Valero', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('22645999-5', 'Aquilino Suarez', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('8931708-8', 'Marcial Ortega', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('14718880-3', 'Bruno Bernabeu', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('24130771-9', 'Angelica Pereira', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('5535761-7', 'Esteban Wang', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('15611550-9', 'John Alvarez', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('22313026-7', 'Myriam Mata', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('21294240-5', 'Sandra Sastre', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('15101839-4', 'Dionisio Barbero', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('8913916-3', 'Teresa Mosquera', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('12224328-1', 'Desiree Carrillo', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('19762866-9', 'Gema Quintana', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('20531879-8', 'Cintia Escobar', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('19716486-7', 'Clara Capdevila', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('23803243-1', 'Paulino Roman', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('19362433-2', 'Tamara del Valle', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('22338664-4', 'Oliver Angulo', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('12739346-k', 'Candela Ribes', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('22717117-0', 'Marcos Sousa', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('8941881-k', 'Laila Zambrano', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('19382528-1', 'Violeta Sala', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('16472349-6', 'Rosa Bolaños', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('5852235-k', 'Gerard Ayuso', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('20045791-9', 'Nicole Portillo', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('18236068-6', 'Noa Carrera', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('17778622-5', 'Nacho Herranz', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('9495227-1', 'Aurelia de La Cruz', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('11708433-7', 'Evangelina Tena', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('11119881-0', 'Nahia Bartolome', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('21016145-7', 'Jaume Carrascosa', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('20385245-2', 'Henar Rico', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('7107523-0', 'Erica Alemany', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('15490089-6', 'Daniel Roldan', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('18887549-1', 'Inocencia Diallo', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('16803931-k', 'Maximiliano Canto', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('7130173-7', 'Amalia Parrilla', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('24477841-0', 'Carmelo Abril', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('18972793-3', 'Gonzalo Ortega', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('12937651-1', 'Nuria Casanova', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('6338205-1', 'Eduard Ferreira', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('14137671-3', 'Estela Ahmed', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('22762127-3', 'Pascuala Valles', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('20492782-0', 'Daniel Mas', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('14193800-2', 'Luis Trujillo', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('16854430-8', 'Abril Linares', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('14656765-7', 'Nayra Contreras', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('11218506-2', 'Arsenio Muñiz', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('14381994-9', 'Lia Vasquez', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('8993223-8', 'Anibal Tapia', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('10422933-6', 'Leo Camino', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('10911639-4', 'Haizea Puerta', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('6903839-5', 'Alain Garriga', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('24296135-8', 'Andrea Lorenzo', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('11869344-2', 'Luciano Quintana', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('23589888-8', 'Sandra Montoro', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('7298605-9', 'Anne Cid', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('5084185-5', 'Julio Garzon', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('11765083-9', 'Omar Moral', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('9723297-0', 'Graciela Mestre', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('16126773-2', 'Simon Valle', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('15708116-0', 'Abderrahim Agullo', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('15574583-5', 'Ibrahim Monzon', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('13516253-1', 'Marina Lema', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('16089691-4', 'Aina Raya', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('24686761-5', 'Teresa Echevarria', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('24979788-k', 'Oier Guzman', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('20378615-8', 'Maider Peinado', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('22846303-5', 'Jone Zapata', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'M');
insert into alumno values ('17437803-7', 'Piedad Carranza', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('14431727-0', 'Felipa Sevilla', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('18070944-4', 'Aitana Mercado', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('18459338-6', 'Dani Cebrian', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('22747180-8', 'Luciana Mariscal', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('15288221-1', 'Cynthia Calle', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');
insert into alumno values ('11149824-5', 'Esperanza Sierra', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 10000), '1980-01-01'), 'F');


--Poblar profesor_asignatura
begin

	declare 
	@id_profesor int, 
	@id_asignatura int;

	declare cursor_profesores cursor for 
	select id from profesor;

	declare cursor_asignaturas cursor for 
	select id from asignatura;

	open cursor_profesores
	fetch next from cursor_profesores into @id_profesor;

	while @@fetch_status = 0
	begin
		open cursor_asignaturas
		fetch next from cursor_asignaturas into @id_asignatura

		while @@fetch_status = 0
		begin
			if rand() > 0.6
			begin
				--print 'voy a insertar asignatura: ' + convert(varchar, @id_asignatura)  + ' para profesor: ' + convert(varchar, @id_profesor)
				insert into profesor_asignatura values (@id_profesor, @id_asignatura)
			end
			fetch next from cursor_asignaturas into @id_asignatura
		end

		fetch next from cursor_profesores into @id_profesor

		close cursor_asignaturas
		
	end

	deallocate cursor_asignaturas

	close cursor_profesores
	deallocate cursor_profesores

end

--Chequear profesor_asignatura
select p.*, a.* from profesor p inner join profesor_asignatura pa
on p.id = pa.id_profesor
inner join asignatura a
on pa.id_asignatura = a.id;

--Poblar sala_asignatura
begin

	declare 
	@id_sala int;
	--@id_asignatura int;

	declare cursor_salas cursor for 
	select id from sala;

	declare cursor_asignaturas cursor for 
	select id from asignatura;

	open cursor_salas
	fetch next from cursor_salas into @id_sala;

	while @@fetch_status = 0
	begin
		open cursor_asignaturas
		fetch next from cursor_asignaturas into @id_asignatura

		while @@fetch_status = 0
		begin
			if rand() > 0.6
			begin
				--print 'voy a insertar asignatura: ' + convert(varchar, @id_asignatura)  + ' para sala: ' + convert(varchar, @id_sala)
				insert into sala_asignatura values (@id_sala, @id_asignatura)
			end
			fetch next from cursor_asignaturas into @id_asignatura
		end

		fetch next from cursor_salas into @id_sala

		close cursor_asignaturas
		
	end

	deallocate cursor_asignaturas

	close cursor_salas
	deallocate cursor_salas

end

--Chequear sala_asignatura
select s.*, a.* from sala s inner join sala_asignatura sa
on s.id = sa.id_sala
inner join asignatura a
on sa.id_asignatura = a.id;

delete from curso

--Poblar cursos
begin

	declare 
	@id_anyo int, 
	@id_bimestre int, 
	--@id_asignatura int, 
	--@id_sala int, 
	--@id_profesor int, 
	@codigo_curso nvarchar(50);

	declare cursor_anyos cursor for 
	select id from anyo;

	declare cursor_bimestres cursor for 
	select id from bimestre;

	declare cursor_cursos cursor for
	select a.id, s.id, p.id 
	from sala s inner join sala_asignatura sa
	on s.id = sa.id_sala
	inner join asignatura a
	on sa.id_asignatura = a.id
	inner join profesor_asignatura pa
	on a.id = pa.id_asignatura
	inner join profesor p
	on pa.id_profesor = p.id;

	open cursor_anyos
	fetch next from cursor_anyos into @id_anyo;

	while @@fetch_status = 0
	begin
		open cursor_bimestres
		fetch next from cursor_bimestres into @id_bimestre

		while @@fetch_status = 0
		begin

			open cursor_cursos
			fetch next from cursor_cursos into @id_asignatura, @id_sala, @id_profesor		

			while @@fetch_status = 0
			begin
				if rand() > 0.9
				begin try
					set @codigo_curso = 'C' + convert(varchar, @id_anyo) + convert(varchar, @id_bimestre) +  convert(varchar, @id_asignatura) + convert(varchar, @id_sala) + convert(varchar, @id_profesor)
					--print 'voy a insertar curso: ' + @codigo_curso
					insert into curso values (@id_anyo, @id_bimestre, @id_asignatura, @id_sala, @id_profesor, @codigo_curso, 'Abierto')
				end try
				begin catch
					print ERROR_MESSAGE()
				end catch
				fetch next from cursor_cursos into @id_asignatura, @id_sala, @id_profesor
			end

			close cursor_cursos

			fetch next from cursor_bimestres into @id_bimestre

		end

		close cursor_bimestres

		fetch next from cursor_anyos into @id_anyo		
		
	end

	close cursor_anyos

	deallocate cursor_cursos
	deallocate cursor_bimestres	
	deallocate cursor_anyos

end

--Chequear cursos
select a.anyo, b.bimestre, c.codigo, r.nombre, p.nombre, s.codigo
from curso c inner join anyo a
on c.id_anyo = a.id
inner join bimestre b
on c.id_bimestre = b.id
inner join asignatura r
on c.id_asignatura = r.id
inner join profesor p
on c.id_profesor = p.id
inner join sala s
on c.id_sala = s.id
order by a.anyo, b.bimestre, r.nombre, p.nombre, s.codigo;

--Setear estado cursos
update curso
set estado = 'Abierto';

update curso
set estado = 'Cerrado'
where id_anyo in (select id from anyo where anyo < 2021);

select count(1) from curso;

--Poblar matriculas
begin

	declare @id_alumno int, @id_curso int, @nota decimal, @codigo varchar(50);

	declare cursor_alumnos cursor for 
	select id from alumno;

	declare cursor_cursos cursor for 
	select id from curso where estado = 'Cerrado';

	open cursor_alumnos
	fetch next from cursor_alumnos into @id_alumno;

	while @@fetch_status = 0
	begin
		open cursor_cursos
		fetch next from cursor_cursos into @id_curso

		--if rand() > 0.5
		--begin
			while @@fetch_status = 0
			begin
				if rand() > 0.97
				begin try
					set @nota = round(ABS(CHECKSUM(NEWID()) % 4) + 3 + rand(),1)
					set @codigo = 'M' + convert(varchar, @id_alumno) + convert(varchar, @id_curso)
					print 'voy a insertar alumno: ' + convert(varchar, @id_alumno)  + ' para curso: ' + convert(varchar, @id_curso)
					insert into matricula values (@id_alumno, @id_curso, @nota, @codigo)
				end try
				begin catch
					print ERROR_MESSAGE()
				end catch
				fetch next from cursor_cursos into @id_curso
			end

		--end

		fetch next from cursor_alumnos into @id_alumno

		close cursor_cursos
		
	end

	deallocate cursor_cursos

	close cursor_alumnos
	deallocate cursor_alumnos

end

--Chequear matriculas
select a.anyo, b.bimestre, c.codigo, r.nombre, p.nombre, s.codigo, e.nombre, m.nota
from curso c inner join anyo a
on c.id_anyo = a.id
inner join bimestre b
on c.id_bimestre = b.id
inner join asignatura r
on c.id_asignatura = r.id
inner join profesor p
on c.id_profesor = p.id
inner join sala s
on c.id_sala = s.id
inner join matricula m
on m.id_curso = c.id
inner join alumno e
on m.id_alumno = e.id
order by a.anyo, b.bimestre, r.nombre, c.codigo, p.nombre, s.codigo, e.nombre;



