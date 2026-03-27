/*
  Ayora - main.sql
  This file ALWAYS represents the full current schema.
*/

SET NOCOUNT ON;
GO

IF SCHEMA_ID(N'dbo') IS NULL
    EXEC(N'CREATE SCHEMA [dbo]');
GO

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
        Email NVARCHAR(320) NOT NULL,
        PasswordHash NVARCHAR(255) NOT NULL,
        IsActive BIT NOT NULL CONSTRAINT DF_Users_IsActive DEFAULT (1),
        CreatedAt DATETIMEOFFSET(7) NOT NULL CONSTRAINT DF_Users_CreatedAt DEFAULT (SYSUTCDATETIME())
    );

    ALTER TABLE dbo.Users
        ADD CONSTRAINT UQ_Users_Email UNIQUE (Email);
END
GO

IF OBJECT_ID(N'dbo.Roles', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Roles
    (
        Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_Roles PRIMARY KEY,
        Name NVARCHAR(64) NOT NULL
    );

    ALTER TABLE dbo.Roles
        ADD CONSTRAINT UQ_Roles_Name UNIQUE (Name);
END
GO

IF OBJECT_ID(N'dbo.UserRoles', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.UserRoles
    (
        UserId UNIQUEIDENTIFIER NOT NULL,
        RoleId UNIQUEIDENTIFIER NOT NULL,
        CONSTRAINT PK_UserRoles PRIMARY KEY (UserId, RoleId),
        CONSTRAINT FK_UserRoles_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(Id) ON DELETE CASCADE,
        CONSTRAINT FK_UserRoles_Roles FOREIGN KEY (RoleId) REFERENCES dbo.Roles(Id) ON DELETE CASCADE
    );
END
GO

IF OBJECT_ID(N'dbo.RefreshTokens', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.RefreshTokens
    (
        Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_RefreshTokens PRIMARY KEY,
        UserId UNIQUEIDENTIFIER NOT NULL,
        Token NVARCHAR(512) NOT NULL,
        ExpiryDate DATETIMEOFFSET(7) NOT NULL,
        IsRevoked BIT NOT NULL CONSTRAINT DF_RefreshTokens_IsRevoked DEFAULT (0),
        CreatedAt DATETIMEOFFSET(7) NOT NULL CONSTRAINT DF_RefreshTokens_CreatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_RefreshTokens_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(Id) ON DELETE CASCADE
    );

    CREATE UNIQUE INDEX IX_RefreshTokens_Token ON dbo.RefreshTokens(Token);
    CREATE INDEX IX_RefreshTokens_UserId ON dbo.RefreshTokens(UserId);
    CREATE INDEX IX_RefreshTokens_ExpiryDate ON dbo.RefreshTokens(ExpiryDate);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Users_Email' AND object_id = OBJECT_ID(N'dbo.Users', N'U'))
BEGIN
    CREATE UNIQUE INDEX IX_Users_Email ON dbo.Users(Email);
END
GO

/*
  Seed Roles (idempotent)
*/
MERGE dbo.Roles AS target
USING (VALUES
    (N'Admin'),
    (N'User')
) AS source([Name])
ON target.[Name] = source.[Name]
WHEN NOT MATCHED THEN
    INSERT (Id, [Name]) VALUES (NEWID(), source.[Name]);
GO

