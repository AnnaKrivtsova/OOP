
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/13/2021 12:48:24
-- Generated from EDMX file: D:\4 sem\ООП\11lab\Model First\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [userstore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[UsersModel] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserEmail] nvarchar(max)  NOT NULL,
    [UserPassword] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [UserSurname] nvarchar(max)  NOT NULL,
    [UserDescriotion] nvarchar(max)  NOT NULL,
    [UserAge] nvarchar(max)  NOT NULL,
    [UserImage] nvarchar(max)  NOT NULL,
    [RoleId] nvarchar(max)  NOT NULL,
    [RolesRoleId] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[RolesModel] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[UsersModel]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[RolesModel]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RolesRoleId] in table 'Users'
ALTER TABLE [dbo].[UsersModel]
ADD CONSTRAINT [FK_RolesUser]
    FOREIGN KEY ([RolesRoleId])
    REFERENCES [dbo].[RolesModel]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolesUser'
CREATE INDEX [IX_FK_RolesUser]
ON [dbo].[UsersModel]
    ([RolesRoleId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------