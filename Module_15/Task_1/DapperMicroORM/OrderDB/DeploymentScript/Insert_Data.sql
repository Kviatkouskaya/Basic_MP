PRINT 'Insert data into Products table'

INSERT [dbo].[Products]
       ([name],
       [description],
       [weight],
       [height],
       [width],
       [length])
VALUES ('Apples', 'Three red apples', 250, NULL, NULL, NULL),
        ('Tomato', 'Three red tomatoes', 300, NULL, NULL, NULL),
        ('Banana', 'Green banana', 400, NULL, NULL, NULL),
        ('Tea', 'Tea box', 80, 10, 10, 10),
        ('Zefir', 'Sweet things', 280, 10, 20, 5),
        ('Chicken', 'One dead chicken', 1400, NULL, NULL, NULL),
        ('Milk', 'One bottle of milk, 20%', 800, NULL, NULL, NULL)

PRINT 'Insert data into Orders table'

INSERT INTO [dbo].[Orders]
			([status],
            [created_date],
            [updated_date],
            [product_id])
VALUES (0, GETDATE(), GETDATE(), 1),
        (1, GETDATE(), GETDATE(), 2),
        (2, GETDATE(), GETDATE(), 3),
        (3, GETDATE(), GETDATE(), 4),
        (4, GETDATE(), GETDATE(), 5),
        (5, GETDATE(), GETDATE(), 6),
        (6, GETDATE(), GETDATE(), 7)