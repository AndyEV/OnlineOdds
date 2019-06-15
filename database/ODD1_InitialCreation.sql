CREATE DATABASE [OddsManagement_db];

IF SERVERPROPERTY('EngineEdition') <> 5
BEGIN
    ALTER DATABASE [OddsManagement_db] SET READ_COMMITTED_SNAPSHOT ON;
END;

CREATE TABLE [__EFMigrationsHistory] (
    [MigrationId] nvarchar(150) NOT NULL,
    [ProductVersion] nvarchar(32) NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
);

SELECT OBJECT_ID(N'[__EFMigrationsHistory]');

SELECT [MigrationId], [ProductVersion]
FROM [__EFMigrationsHistory]
ORDER BY [MigrationId];

CREATE TABLE [Team] (
    [Id] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [IsDeleted] bit NOT NULL,
    [HomeTeam] nvarchar(50) NOT NULL,
    [AwayTeam] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Team] PRIMARY KEY ([Id])
);

CREATE TABLE [Odds] (
    [Id] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [IsDeleted] bit NOT NULL,
    [HomeOdd] decimal(18,2) NOT NULL,
    [DrawOdd] decimal(18,2) NOT NULL,
    [AwayOdd] decimal(18,2) NOT NULL,
    [TeamId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Odds] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Odds_Team_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Team] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Odds_TeamId] ON [Odds] ([TeamId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190615133847_Initial', N'2.2.4-servicing-10062');
