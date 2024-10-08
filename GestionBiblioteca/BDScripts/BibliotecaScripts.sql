USE [Biblioteca]
GO
/****** Object:  Table [dbo].[AUTOR]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTOR](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LIBRO]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIBRO](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](200) NOT NULL,
	[Descripcion] [nvarchar](1000) NOT NULL,
	[FechaPublicacion] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__LIBRO__3214EC07F19BE49F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LIBRO_AUTOR]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIBRO_AUTOR](
	[IdLibro] [int] NOT NULL,
	[IdAutor] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_LIBRO_AUTOR] PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC,
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LIBRO_CATEGORIA]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIBRO_CATEGORIA](
	[IdLibro] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Activo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROLES]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [nvarchar](100) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK__ROLES__3214EC07DED4B448] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Clave] [nvarchar](200) NOT NULL,
	[IdRol] [int] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__USUARIO__3214EC07D2B90120] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AUTOR] ON 

INSERT [dbo].[AUTOR] ([Id], [Nombre], [Activo]) VALUES (1, N'Gabriel García Marquez Rijo', 0)
INSERT [dbo].[AUTOR] ([Id], [Nombre], [Activo]) VALUES (2, N'Mario Vargas Llosa', 1)
SET IDENTITY_INSERT [dbo].[AUTOR] OFF
GO
SET IDENTITY_INSERT [dbo].[CATEGORIA] ON 

INSERT [dbo].[CATEGORIA] ([Id], [Nombre], [Activo]) VALUES (1, N'Novelas', 1)
SET IDENTITY_INSERT [dbo].[CATEGORIA] OFF
GO
SET IDENTITY_INSERT [dbo].[LIBRO] ON 

INSERT [dbo].[LIBRO] ([Id], [Titulo], [Descripcion], [FechaPublicacion], [Activo]) VALUES (1, N'El coronel no tiene quien le escriba', N'El coronel no tiene quien le escriba', CAST(N'2024-10-08T17:56:15.390' AS DateTime), 1)
INSERT [dbo].[LIBRO] ([Id], [Titulo], [Descripcion], [FechaPublicacion], [Activo]) VALUES (2, N'La Fiesta del Chivo', N'Libro de Mario Vargas LLosa', CAST(N'2014-08-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[LIBRO] OFF
GO
INSERT [dbo].[LIBRO_AUTOR] ([IdLibro], [IdAutor], [Activo]) VALUES (1, 1, 1)
INSERT [dbo].[LIBRO_AUTOR] ([IdLibro], [IdAutor], [Activo]) VALUES (2, 2, 1)
GO
INSERT [dbo].[LIBRO_CATEGORIA] ([IdLibro], [IdCategoria], [Activo]) VALUES (1, 1, 1)
INSERT [dbo].[LIBRO_CATEGORIA] ([IdLibro], [IdCategoria], [Activo]) VALUES (2, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[ROLES] ON 

INSERT [dbo].[ROLES] ([Id], [Rol], [Activo]) VALUES (1, N'Administrador', 1)
INSERT [dbo].[ROLES] ([Id], [Rol], [Activo]) VALUES (2, N'Bibliotecario', 1)
SET IDENTITY_INSERT [dbo].[ROLES] OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIO] ON 

INSERT [dbo].[USUARIO] ([Id], [Email], [Clave], [IdRol], [Activo]) VALUES (1, N'j@mail.com', N'PovLnackR6lk49ZYJxd3KA==', 1, 1)
INSERT [dbo].[USUARIO] ([Id], [Email], [Clave], [IdRol], [Activo]) VALUES (2, N'm@mail.com', N'EmYytSRJAe2CPCnacTy3Ug==', 2, 1)
INSERT [dbo].[USUARIO] ([Id], [Email], [Clave], [IdRol], [Activo]) VALUES (3, N'g@mail.com', N'xM6vKBXkP6kUAoTSpbz1jQ==', 2, 1)
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
GO
/****** Object:  Index [UQ__LIBRO_AU__33D872AF7EFE36DE]    Script Date: 10/10/2024 12:07:07 PM ******/
ALTER TABLE [dbo].[LIBRO_AUTOR] ADD  CONSTRAINT [UQ__LIBRO_AU__33D872AF7EFE36DE] UNIQUE NONCLUSTERED 
(
	[IdLibro] ASC,
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__LIBRO_CA__24374B0DFA16F1BD]    Script Date: 10/10/2024 12:07:07 PM ******/
ALTER TABLE [dbo].[LIBRO_CATEGORIA] ADD UNIQUE NONCLUSTERED 
(
	[IdLibro] ASC,
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__USUARIO__A9D105341F01C4BB]    Script Date: 10/10/2024 12:07:07 PM ******/
ALTER TABLE [dbo].[USUARIO] ADD  CONSTRAINT [UQ__USUARIO__A9D105341F01C4BB] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AUTOR] ADD  CONSTRAINT [DF_AUTOR_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[CATEGORIA] ADD  CONSTRAINT [DF_CATEGORIA_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[LIBRO] ADD  CONSTRAINT [DF_LIBRO_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[LIBRO_AUTOR] ADD  CONSTRAINT [DF_LIBRO_AUTOR_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[LIBRO_CATEGORIA] ADD  CONSTRAINT [DF_LIBRO_CATEGORIA_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[ROLES] ADD  CONSTRAINT [DF_ROLES_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[USUARIO] ADD  CONSTRAINT [DF_USUARIO_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[LIBRO_AUTOR]  WITH CHECK ADD  CONSTRAINT [FK_LIBRO_AUTOR_AUTOR] FOREIGN KEY([IdAutor])
REFERENCES [dbo].[AUTOR] ([Id])
GO
ALTER TABLE [dbo].[LIBRO_AUTOR] CHECK CONSTRAINT [FK_LIBRO_AUTOR_AUTOR]
GO
ALTER TABLE [dbo].[LIBRO_AUTOR]  WITH CHECK ADD  CONSTRAINT [FK_LIBRO_AUTOR_LIBRO] FOREIGN KEY([IdLibro])
REFERENCES [dbo].[LIBRO] ([Id])
GO
ALTER TABLE [dbo].[LIBRO_AUTOR] CHECK CONSTRAINT [FK_LIBRO_AUTOR_LIBRO]
GO
ALTER TABLE [dbo].[LIBRO_CATEGORIA]  WITH CHECK ADD  CONSTRAINT [FK_LIBRO_CATEGORIA_CATEGORIA] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CATEGORIA] ([Id])
GO
ALTER TABLE [dbo].[LIBRO_CATEGORIA] CHECK CONSTRAINT [FK_LIBRO_CATEGORIA_CATEGORIA]
GO
ALTER TABLE [dbo].[LIBRO_CATEGORIA]  WITH CHECK ADD  CONSTRAINT [FK_LIBRO_CATEGORIA_LIBRO] FOREIGN KEY([IdLibro])
REFERENCES [dbo].[LIBRO] ([Id])
GO
ALTER TABLE [dbo].[LIBRO_CATEGORIA] CHECK CONSTRAINT [FK_LIBRO_CATEGORIA_LIBRO]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_ROLES] FOREIGN KEY([IdRol])
REFERENCES [dbo].[ROLES] ([Id])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_ROLES]
GO
/****** Object:  StoredProcedure [dbo].[GetLibros]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLibros]
(
	@Titulo VARCHAR(100) = NULL,
	@FechaDesde DATETIME = NULL,
	@FechaHasta DATETIME = NULL,
	@IdCategoria INT = NULL,
	@IdAutor INT = NULL
)
AS
BEGIN
	SELECT 
		L.Id IdLibro
		,L.Titulo
		,L.Descripcion
		,CAST(L.FechaPublicacion AS DATE) FechaPublicacion
		,A.Nombre Autor
		,C.Nombre Categoria
		,CASE WHEN L.ACTIVO = 1 THEN 'Activo' ELSE 'Inactivo' END Estatus
	FROM LIBRO L
	INNER JOIN LIBRO_AUTOR LA ON LA.IdLibro = L.Id
	INNER JOIN AUTOR A ON A.ID = LA.IdAutor
	INNER JOIN LIBRO_CATEGORIA LC ON LC.IdLibro = L.Id
	INNER JOIN CATEGORIA C ON C.Id = LC.IdCategoria
	WHERE 
		(L.Titulo = @Titulo OR @Titulo IS NULL)
	AND
		(CAST(L.FechaPublicacion AS DATE) BETWEEN @FechaDesde AND @FechaHasta OR (@FechaDesde IS NULL OR @FechaHasta IS NULL))
	AND
		(LC.IdCategoria = @IdCategoria OR @IdCategoria IS NULL)
	AND 
		(LA.IdAutor = @IdAutor OR @IdAutor IS NULL)
END

GO
/****** Object:  StoredProcedure [dbo].[GetUsuarios]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- GetUsuarios 'j@email.com'

CREATE PROCEDURE [dbo].[GetUsuarios]
(
	@email VARCHAR(100) = NULL
)
AS
BEGIN
	SELECT 
		U.Id
		,Email
		,Clave
		,R.Id IdRol
		,R.Rol
	FROM [Biblioteca].[dbo].[USUARIO] U
	INNER JOIN ROLES R ON R.Id = U.IDROL
	WHERE (Email = @email OR @email IS NULL)
	AND u.Activo = 1
END
GO
/****** Object:  StoredProcedure [dbo].[SetLibro]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetLibro]
(
	@Titulo VARCHAR(200),
	@Descripcion VARCHAR(1000),
	@FechaPublicacion VARCHAR(1000),
	@IdLibro INT OUT
)
AS
BEGIN
	INSERT INTO LIBRO
	(Titulo,Descripcion,FechaPublicacion)
	VALUES
	(@Titulo,@Descripcion,@FechaPublicacion)

	SELECT @IdLibro = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[SetLibroAutor]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetLibroAutor]
(
	@IdLibro INT,
	@IdAutor INT,
	@Activo BIT
)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM LIBRO_AUTOR WHERE IdLibro = @IdLibro AND IdAutor = @IdAutor AND Activo = @Activo)
		BEGIN
			INSERT INTO LIBRO_AUTOR
			(IdLibro,IdAutor)
			VALUES
			(@IdLibro,@IdAutor)
		END
	ELSE
		BEGIN
			UPDATE LIBRO_AUTOR SET Activo = @Activo WHERE IdLibro = @IdLibro AND IdAutor = @IdAutor
		END
END

GO
/****** Object:  StoredProcedure [dbo].[SetLibroCategoria]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetLibroCategoria]
(
	@IdLibro INT,
	@IdCategoria INT,
	@Activo INT
)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM LIBRO_CATEGORIA WHERE IdLibro = @IdLibro AND IdCategoria = @IdCategoria AND Activo = @Activo)
		BEGIN
			INSERT INTO LIBRO_CATEGORIA
			(IdLibro,IdCategoria)
			VALUES
			(@IdLibro,@IdCategoria)
		END
	ELSE
		BEGIN
			UPDATE LIBRO_CATEGORIA SET Activo = @Activo WHERE IdLibro = @IdLibro AND IdCategoria = @IdCategoria
		END
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateLibro]    Script Date: 10/10/2024 12:07:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateLibro]
(
	@Accion INT,
	@Id INT,
	@Titulo VARCHAR(200) = NULL,
	@Descripcion VARCHAR(1000) = NULL,
	@FechaPublicacion VARCHAR(1000) = NULL
)
AS
BEGIN
	IF(@Accion = 1)
		BEGIN--ACTUALIZAR
			UPDATE LIBRO 
			SET
				Titulo = @Titulo
				,Descripcion = @Descripcion
				,FechaPublicacion = @FechaPublicacion
			WHERE
				Id = @Id
		END--ACTUALIZAR
	IF(@Accion = 2)
		BEGIN--INACTIVAR
			UPDATE LIBRO 
			SET
				Activo = 0
			WHERE
				Id = @Id
		END--INACTIVAR
END

GO
