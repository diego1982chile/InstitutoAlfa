USE master;
GO
IF DB_ID (N'instituto_alfa') IS NOT NULL
DROP DATABASE instituto_alfa;
GO
CREATE DATABASE instituto_alfa;
GO
-- Verify the database files and sizes
SELECT name, size, size*1.0/128 AS [Size in MBs]
FROM sys.master_files
WHERE name = N'instituto_alfa';
GO

USE instituto_alfa
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_curso_anyo]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [curso] DROP CONSTRAINT [FK_curso_anyo]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_curso_asignatura]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [curso] DROP CONSTRAINT [FK_curso_asignatura]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_curso_bimestre]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [curso] DROP CONSTRAINT [FK_curso_bimestre]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_curso_profesor]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [curso] DROP CONSTRAINT [FK_curso_profesor]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_curso_sala]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [curso] DROP CONSTRAINT [FK_curso_sala]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_matricula_alumno]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [matricula] DROP CONSTRAINT [FK_matricula_alumno]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_matricula_curso]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [matricula] DROP CONSTRAINT [FK_matricula_curso]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[alumno]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [alumno]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[anyo]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [anyo]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[asignatura]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [asignatura]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[bimestre]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [bimestre]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[curso]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [curso]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[matricula]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [matricula]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[profesor]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [profesor]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[profesor_asignatura]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [profesor_asignatura]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[sala]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sala]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[sala_asignatura]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sala_asignatura]
;

CREATE TABLE [alumno]
(
	[id] int IDENTITY(1,1) NOT NULL,
	[rut] varchar(10),
	[nombre] varchar(50),
	[nacimiento] datetime,
	[genero] varchar(50)
)
;

CREATE TABLE [anyo]
(
	[id] int IDENTITY(1,1) NOT NULL,
	[anyo] int
)
;

CREATE TABLE [asignatura]
(
	[id] int IDENTITY(1,1) NOT NULL,
	[codigo] varchar(50),
	[nombre] varchar(50)
)
;

CREATE TABLE [bimestre]
(
	[id] int IDENTITY(1,1) NOT NULL,
	[bimestre] int,
	[nombre] varchar(50)
)
;

CREATE TABLE [curso]
(
	[id] int IDENTITY(1,1) NOT NULL,
	[id_anyo] int,
	[id_bimestre] int,
	[id_asignatura] int,
	[id_sala] int,
	[id_profesor] int,
	[codigo] varchar(50),
	[estado] varchar(50)
)
;

CREATE TABLE [matricula]
(
	[id] int IDENTITY(1,1) NOT NULL,
	[id_alumno] int,
	[id_curso] int,
	[nota] decimal(18),
	[codigo] varchar(50)
)
;

CREATE TABLE [profesor]
(
	[id] int IDENTITY(1,1) NOT NULL,
	[rut] varchar(10),
	[nombre] varchar(50)
)
;

CREATE TABLE [profesor_asignatura]
(
	[id] int IDENTITY(1,1) NOT NULL,
	[id_profesor] int,
	[id_asignatura] int
)
;

CREATE TABLE [sala]
(
	[id] int IDENTITY(1,1) NOT NULL,
	[codigo] varchar(50),
	[capacidad] int
)
;

CREATE TABLE [sala_asignatura]
(
	[id] int IDENTITY(1,1) NOT NULL,
	[id_sala] int,
	[id_asignatura] int
)
;

ALTER TABLE [alumno] 
 ADD CONSTRAINT [PK_alumno]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [alumno] 
 ADD CONSTRAINT [UNIQ_rut_alumno] UNIQUE NONCLUSTERED ([rut])
;

ALTER TABLE [anyo] 
 ADD CONSTRAINT [PK_anyo]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [anyo] 
 ADD CONSTRAINT [UNIQ_anyo] UNIQUE NONCLUSTERED ([anyo])
;

ALTER TABLE [asignatura] 
 ADD CONSTRAINT [PK_asignatua]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [asignatura] 
 ADD CONSTRAINT [UNIQ_codigo_asignatura] UNIQUE NONCLUSTERED ([codigo])
;

ALTER TABLE [asignatura] 
 ADD CONSTRAINT [UNIQ_nombre_asignatura] UNIQUE NONCLUSTERED ([nombre])
;

ALTER TABLE [bimestre] 
 ADD CONSTRAINT [PK_bimestre]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [bimestre] 
 ADD CONSTRAINT [CHECK_bimestre] CHECK (bimestre <= 4)
;

ALTER TABLE [bimestre] 
 ADD CONSTRAINT [UNIQ_bimestre] UNIQUE NONCLUSTERED ([bimestre])
;

CREATE INDEX [IXFK_curso_anyo] 
 ON [curso] ([id_anyo] ASC)
;

CREATE INDEX [IXFK_curso_asignatura] 
 ON [curso] ([id_asignatura] ASC)
;

CREATE INDEX [IXFK_curso_bimestre] 
 ON [curso] ([id_bimestre] ASC)
;

CREATE INDEX [IXFK_curso_profesor] 
 ON [curso] ([id_profesor] ASC)
;

CREATE INDEX [IXFK_curso_sala] 
 ON [curso] ([id_sala] ASC)
;

ALTER TABLE [curso] 
 ADD CONSTRAINT [PK_curso]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [curso] 
 ADD CONSTRAINT [UNIQ_curso_bimestre_prof] UNIQUE NONCLUSTERED ([id_anyo],[id_bimestre],[id_profesor])
;

CREATE INDEX [IXFK_matricula_alumno] 
 ON [matricula] ([id_alumno] ASC)
;

CREATE INDEX [IXFK_matricula_curso] 
 ON [matricula] ([id] ASC)
;

ALTER TABLE [matricula] 
 ADD CONSTRAINT [PK_matricula]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [matricula] 
 ADD CONSTRAINT [UNIQ_alumno_curso] UNIQUE NONCLUSTERED ([id_alumno],[id_curso])
;

ALTER TABLE [profesor] 
 ADD CONSTRAINT [PK_profesor]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [profesor] 
 ADD CONSTRAINT [UNIQ_rut_profesor] UNIQUE NONCLUSTERED ([rut])
;

CREATE INDEX [IXFK_profesor_asignatura_asignatura] 
 ON [profesor_asignatura] ([id_asignatura] ASC)
;

CREATE INDEX [IXFK_profesor_asignatura_profesor] 
 ON [profesor_asignatura] ([id_profesor] ASC)
;

ALTER TABLE [profesor_asignatura] 
 ADD CONSTRAINT [PK_profesor_asignatura]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [profesor_asignatura] 
 ADD CONSTRAINT [UNIQ_profesor_asignatura] UNIQUE NONCLUSTERED ([id_profesor],[id_asignatura])
;

ALTER TABLE [sala] 
 ADD CONSTRAINT [PK_sala]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [sala] 
 ADD CONSTRAINT [UNIQ_codigo_sala] UNIQUE NONCLUSTERED ([codigo])
;

CREATE INDEX [IXFK_sala_asignatura_asignatura] 
 ON [sala_asignatura] ([id_asignatura] ASC)
;

CREATE INDEX [IXFK_sala_asignatura_sala] 
 ON [sala_asignatura] ([id_sala] ASC)
;

ALTER TABLE [sala_asignatura] 
 ADD CONSTRAINT [PK_sala_asignatura]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [sala_asignatura] 
 ADD CONSTRAINT [UNIQ_sala_asignatura] UNIQUE NONCLUSTERED ([id_sala],[id_asignatura])
;

ALTER TABLE [curso] ADD CONSTRAINT [FK_curso_anyo]
	FOREIGN KEY ([id_anyo]) REFERENCES [anyo] ([id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [curso] ADD CONSTRAINT [FK_curso_asignatura]
	FOREIGN KEY ([id_asignatura]) REFERENCES [asignatura] ([id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [curso] ADD CONSTRAINT [FK_curso_bimestre]
	FOREIGN KEY ([id_bimestre]) REFERENCES [bimestre] ([id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [curso] ADD CONSTRAINT [FK_curso_profesor]
	FOREIGN KEY ([id_profesor]) REFERENCES [profesor] ([id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [curso] ADD CONSTRAINT [FK_curso_sala]
	FOREIGN KEY ([id_sala]) REFERENCES [sala] ([id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [matricula] ADD CONSTRAINT [FK_matricula_alumno]
	FOREIGN KEY ([id_alumno]) REFERENCES [alumno] ([id]) ON DELETE CASCADE ON UPDATE No Action
;

ALTER TABLE [matricula] ADD CONSTRAINT [FK_matricula_curso]
	FOREIGN KEY ([id_curso]) REFERENCES [curso] ([id]) ON DELETE CASCADE ON UPDATE No Action
;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER dbo.trg_cursos
   ON dbo.curso
   INSTEAD OF INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @id_anyo int, @id_bimestre int, @id_asignatura int, @id_sala int, @id_profesor int, @codigo varchar(50), @estado varchar(50), @num_cursos int, @message varchar(50)

	select 
	@id_anyo = inserted.id_anyo, 
	@id_bimestre = inserted.id_bimestre,
	@id_asignatura = inserted.id_asignatura,
	@id_sala = inserted.id_sala,
	@id_profesor = inserted.id_profesor,
	@codigo = inserted.codigo,
	@estado = inserted.estado
	from inserted;

	select @num_cursos = count(1) 
	from curso
	where id_anyo = @id_anyo
	and id_bimestre = @id_bimestre
	group by id_anyo, id_bimestre;

	if(@num_cursos >= 20)
	begin
        set @message = 'En un bimestre dado se dictan hasta un m??ximo de 20 cursos!'
        RAISERROR(@message, 16 ,1)
        ROLLBACK
    end
	else
	begin
		insert into curso values(@id_anyo, @id_bimestre, @id_asignatura, @id_sala, @id_profesor, @codigo, @estado);
	end

END
GO

ALTER TABLE [dbo].[curso] ENABLE TRIGGER [trg_cursos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_matriculas]
   ON [dbo].[matricula]
   INSTEAD OF INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @id_alumno int, @id_curso int, @nota decimal, @codigo varchar(50), @num_alumnos int, @id_sala int, @capacidad int, @message varchar(50)

	select 
	@id_alumno = inserted.id_alumno, 
	@id_curso = inserted.id_curso,
	@nota = inserted.nota,	
	@codigo = inserted.codigo
	from inserted;

	select 
	@num_alumnos = count(1),
	@id_sala = c.id_sala
	from matricula m inner join curso c	
	on m.id_curso = c.id
	and m.id_curso = @id_curso		
	group by id_anyo, id_bimestre, id_sala;

	select
	@capacidad = capacidad
	from sala where id = @id_sala;

	if(@num_alumnos > @capacidad)
	begin
        set @message = 'La cantidad de alumnos no puede exceder la capacidad de la sala!'
        RAISERROR(@message, 16 ,1)
        ROLLBACK
    end
	else
	begin
		insert into matricula values(@id_alumno, @id_curso, @nota, @codigo);
	end

END
GO

ALTER TABLE [dbo].[matricula] ENABLE TRIGGER [trg_matriculas]
GO


