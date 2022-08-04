CREATE TABLE Customers 
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](max) NOT NULL
)
INSERT INTO Customers VALUES ('Alexey'), ('Ivan'), ('Galina'), ('Petr')

CREATE TABLE Orders 
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CustomerId] [int] NOT NULL FOREIGN KEY (CustomerId) REFERENCES Customers (Id)
)
INSERT INTO Orders VALUES (2), (4)

SELECT 	Customers.Name 
FROM 	Customers 
LEFT JOIN 
	Orders 
ON 
	Customers.Id = Orders.CustomerId 
WHERE NOT EXISTS 
(
	SELECT 	* 
	FROM 	Customers 
	WHERE 	Customers.Id = Orders.CustomerId
)
