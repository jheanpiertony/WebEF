IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Actor] (
    [Id] int NOT NULL IDENTITY,
    [Nombres] nvarchar(max) NULL,
    [Apellidos] nvarchar(max) NULL,
    [UrlFoto] nvarchar(max) NULL,
    [FechaNacimiento] datetime2 NOT NULL,
    [Genero] bit NOT NULL,
    [EstaBorrado] bit NOT NULL,
    CONSTRAINT [PK_Actor] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Pelicula] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NULL,
    [UrlFoto] nvarchar(max) NULL,
    [FechaEstreno] datetime2 NOT NULL,
    [EstaCartelera] bit NOT NULL,
    [PrecioTicket] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Pelicula] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Direccion] (
    [Id] int NOT NULL IDENTITY,
    [StringDireccion] nvarchar(max) NULL,
    [ActorId] int NOT NULL,
    CONSTRAINT [PK_Direccion] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Direccion_Actor_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [Actor] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [TarjetaCredito] (
    [Id] int NOT NULL,
    [CodigoTarjeta] nvarchar(450) NOT NULL,
    [Nrotarjeta] nchar(16) NULL,
    [ActorId] int NOT NULL,
    CONSTRAINT [PK_TarjetaCredito] PRIMARY KEY ([Id], [CodigoTarjeta]),
    CONSTRAINT [FK_TarjetaCredito_Actor_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [Actor] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ActorPelicula] (
    [ActorId] int NOT NULL,
    [PeliculaId] int NOT NULL,
    CONSTRAINT [PK_ActorPelicula] PRIMARY KEY ([ActorId], [PeliculaId]),
    CONSTRAINT [FK_ActorPelicula_Actor_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [Actor] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ActorPelicula_Pelicula_PeliculaId] FOREIGN KEY ([PeliculaId]) REFERENCES [Pelicula] ([Id]) ON DELETE NO ACTION
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellidos', N'EstaBorrado', N'FechaNacimiento', N'Genero', N'Nombres', N'UrlFoto') AND [object_id] = OBJECT_ID(N'[Actor]'))
    SET IDENTITY_INSERT [Actor] ON;
INSERT INTO [Actor] ([Id], [Apellidos], [EstaBorrado], [FechaNacimiento], [Genero], [Nombres], [UrlFoto])
VALUES (1, N'Schwarzenegger', CAST(0 AS bit), '1947-07-30T00:00:00.0000000', CAST(1 AS bit), N'Arnold Alois', N'');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellidos', N'EstaBorrado', N'FechaNacimiento', N'Genero', N'Nombres', N'UrlFoto') AND [object_id] = OBJECT_ID(N'[Actor]'))
    SET IDENTITY_INSERT [Actor] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellidos', N'EstaBorrado', N'FechaNacimiento', N'Genero', N'Nombres', N'UrlFoto') AND [object_id] = OBJECT_ID(N'[Actor]'))
    SET IDENTITY_INSERT [Actor] ON;
INSERT INTO [Actor] ([Id], [Apellidos], [EstaBorrado], [FechaNacimiento], [Genero], [Nombres], [UrlFoto])
VALUES (2, N'Gardenzio Stallone', CAST(0 AS bit), '1946-07-06T00:00:00.0000000', CAST(1 AS bit), N'Michael Sylvester', N'');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Apellidos', N'EstaBorrado', N'FechaNacimiento', N'Genero', N'Nombres', N'UrlFoto') AND [object_id] = OBJECT_ID(N'[Actor]'))
    SET IDENTITY_INSERT [Actor] OFF;

GO

CREATE INDEX [IX_ActorPelicula_PeliculaId] ON [ActorPelicula] ([PeliculaId]);

GO

CREATE INDEX [IX_Direccion_ActorId] ON [Direccion] ([ActorId]);

GO

CREATE UNIQUE INDEX [IX_TarjetaCredito_ActorId] ON [TarjetaCredito] ([ActorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201113230352_Inicio', N'3.1.9');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Actor]') AND [c].[name] = N'Genero');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Actor] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Actor] ALTER COLUMN [Genero] int NOT NULL;

GO

UPDATE [Actor] SET [Genero] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Actor] SET [Genero] = 1
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201114031015_InicioDos', N'3.1.9');

GO

IF SCHEMA_ID(N'Bdo') IS NULL EXEC(N'CREATE SCHEMA [Bdo];');

GO

ALTER SCHEMA [Bdo] TRANSFER [Actor];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201114035226_InicioTres', N'3.1.9');

GO

ALTER SCHEMA [dbo] TRANSFER [Bdo].[Actor];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[Actor]') AND [c].[name] = N'EstaBorrado');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[Actor] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [dbo].[Actor] ALTER COLUMN [EstaBorrado] bit NOT NULL;
ALTER TABLE [dbo].[Actor] ADD DEFAULT CAST(0 AS bit) FOR [EstaBorrado];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201114043837_InicioCuatro', N'3.1.9');

GO

