CREATE TABLE [dbo].[Users] (
    [Id]       INT          NOT NULL IDENTITY(1,1),
    [UserName] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);