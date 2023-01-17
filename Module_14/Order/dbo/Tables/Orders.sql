CREATE TABLE [dbo].[Orders] (
    [order_id]     INT      IDENTITY (1, 1) NOT NULL,
    [status]       INT      NOT NULL,
    [created_date] DATETIME NOT NULL,
    [updated_date] DATETIME NOT NULL,
    [product_id]   INT      NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([order_id] ASC),
    CONSTRAINT [FK_order_product] FOREIGN KEY ([product_id]) REFERENCES [dbo].[Products] ([product_id])
);

