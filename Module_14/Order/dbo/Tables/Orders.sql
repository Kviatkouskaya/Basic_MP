CREATE TABLE [dbo].[Orders] (
    [order_id]     INT      IDENTITY (1, 1) NOT NULL,
    [status]       INT      NULL,
    [created_date] DATETIME NULL,
    [updated_date] DATETIME NULL,
    [product_id]   INT      NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([order_id] ASC),
    CONSTRAINT [FK_order_product] FOREIGN KEY ([product_id]) REFERENCES [dbo].[Products] ([product_id])
);

