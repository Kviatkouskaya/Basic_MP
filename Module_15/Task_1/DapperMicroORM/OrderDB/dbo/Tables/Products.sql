CREATE TABLE [dbo].[Products] (
    [product_id]  INT           IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50) NOT NULL,
    [description] NCHAR (100)   NOT NULL,
    [weight]      INT           NULL,
    [height]      INT           NULL,
    [width]       INT           NULL,
    [length]      INT           NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([product_id] ASC)
);

