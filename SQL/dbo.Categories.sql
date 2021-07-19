CREATE TABLE [dbo].[Categories] (
    [Id]           INT          NOT NULL IDENTITY(1,1),
    [CategoryName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);