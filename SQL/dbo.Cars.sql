CREATE TABLE [dbo].[Cars] (
    [Id]           INT          NOT NULL IDENTITY(1,1),
    [CategoryId]   INT          NOT NULL,
    [Manufacturer] VARCHAR (50) NOT NULL,
    [CarName]      VARCHAR (50) NOT NULL,
    [PricePerDay]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cars_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id])
);