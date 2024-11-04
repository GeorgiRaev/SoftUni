

CREATE TABLE Countries (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(10) NOT NULL
);

CREATE TABLE Addresses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StreetName NVARCHAR(20) NOT NULL,
    StreetNumber INT NULL,
    PostCode INT NOT NULL,
    City NVARCHAR(25) NOT NULL,
    CountryId INT NOT NULL,
    FOREIGN KEY (CountryId) REFERENCES Countries(Id)
);

CREATE TABLE Vendors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(25) NOT NULL,
    NumberVAT NVARCHAR(15) NOT NULL,
    AddressId INT NOT NULL,
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

CREATE TABLE Clients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(25) NOT NULL,
    NumberVAT NVARCHAR(15) NOT NULL,
    AddressId INT NOT NULL,
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(10) NOT NULL
);

CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(35) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    CategoryId INT NOT NULL,
    VendorId INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY (VendorId) REFERENCES Vendors(Id)
);

CREATE TABLE Invoices (
    Id INT IDENTITY(1,1) PRIMARY KEY,                
    Number INT NOT NULL UNIQUE,                      
    IssueDate DATETIME2 NOT NULL,                    
    DueDate DATETIME2 NOT NULL,                      
    Amount DECIMAL(18, 2) NOT NULL,                  
    Currency NVARCHAR(5) NOT NULL,                   
    ClientId INT NOT NULL,                           
    FOREIGN KEY (ClientId) REFERENCES Clients(Id)    
);

CREATE TABLE ProductsClients (
    ProductId INT NOT NULL,                           
    ClientId INT NOT NULL,                            
    PRIMARY KEY (ProductId, ClientId),                
    FOREIGN KEY (ProductId) REFERENCES Products(Id),  
    FOREIGN KEY (ClientId) REFERENCES Clients(Id)     
);


--02.Insert
INSERT INTO Products([Name], Price, CategoryId,VendorId)
VALUES
	('SCANIA Oil Filter XD01', 78.69, 1, 1),
	('MAN Air Filter XD01', 97.38, 1, 5),
	('DAF Light Bulb 05FG87', 55.00, 2, 13),
	('ADR Shoes 47-47.5', 49.85, 3, 5),
	('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO Invoices (Number, IssueDate, DueDate, Amount, Currency, ClientId)
VALUES
	(1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
	(1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
	(1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19)



--03.--Update
UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE MONTH(IssueDate) = 11  
  AND YEAR(IssueDate) = 2022; 

UPDATE Addresses
SET StreetName = 'Industriestr',
    StreetNumber = 79,
    PostCode = 2353,
    City = 'Guntramsdorf',
    CountryId = (SELECT Id FROM Countries WHERE Name = 'Austria')
WHERE Id IN (
    SELECT AddressId
    FROM Clients
    WHERE Name LIKE '%CO%'
);


--04.DELETE 
SELECT Id
INTO #ClientsToDelete
FROM Clients
WHERE NumberVAT LIKE 'IT%';

DELETE pc
FROM ProductsClients pc
JOIN #ClientsToDelete c ON pc.ClientId = c.Id;

-- Delete from Invoices table (if applicable)
DELETE i
FROM Invoices i
JOIN #ClientsToDelete c ON i.ClientId = c.Id;

-- Delete from Clients table
DELETE c
FROM Clients c
JOIN #ClientsToDelete d ON c.Id = d.Id;


--05. Invoices by Amount and Date
SELECT Number, Currency
FROM Invoices
ORDER BY Amount DESC, DueDate ASC;


--06.
SELECT 
    C.Id,
    C.Name AS Client,
    CONCAT(A.StreetName, ' ', A.StreetNumber, ', ', A.City, ', ', A.PostCode, ', ', CO.Name) AS Address
FROM 
    Clients C
JOIN 
    Addresses A ON C.AddressId = A.Id
JOIN 
    Countries CO ON A.CountryId = CO.Id
WHERE 
    C.Id NOT IN (SELECT DISTINCT PC.ClientId FROM ProductsClients PC)
ORDER BY 
    C.Name ASC;

--08. First 7 Invoices
WITH ClientExpensiveProducts AS (
    SELECT
        C.Name AS Client,
        P.Name AS ProductName,
        P.Price AS Price,
        V.NumberVAT AS VATNumber,
        ROW_NUMBER() OVER (PARTITION BY C.Id ORDER BY P.Price DESC) AS RN
    FROM
        Clients C
    JOIN
        ProductsClients PC ON C.Id = PC.ClientId
    JOIN
        Products P ON PC.ProductId = P.Id
    JOIN
        Vendors V ON P.VendorId = V.Id
    JOIN
        Categories Cat ON P.CategoryId = Cat.Id
    WHERE
        NOT (C.Name LIKE '%KG')
        AND (Cat.Name = 'ADR' OR Cat.Name = 'Others')
)
SELECT
    Client,
    Price,
    VATNumber
FROM
    ClientExpensiveProducts
WHERE
    RN = 1
ORDER BY
    Price DESC;

--10. Clients by Price
WITH ClientsAveragePrice AS (
    SELECT
        C.Name AS Client,
        FLOOR(AVG(P.Price)) AS AveragePrice,
        ROW_NUMBER() OVER (ORDER BY FLOOR(AVG(P.Price)) ASC, C.Name DESC) AS RN
    FROM
        Clients C
    JOIN
        ProductsClients PC ON C.Id = PC.ClientId
    JOIN
        Products P ON PC.ProductId = P.Id
    JOIN
        Vendors V ON P.VendorId = V.Id
    WHERE
        SUBSTRING(V.NumberVAT, 1, 2) = 'FR'
    GROUP BY
        C.Name
    HAVING
        AVG(P.Price) > 0 -- Ensures only clients who have bought products are selected
)
SELECT
    Client,
    AveragePrice
FROM
    ClientsAveragePrice
ORDER BY
    AveragePrice ASC,
    Client DESC;

--11. Product with Clients
CREATE FUNCTION udf_ProductWithClients (@productName NVARCHAR(35))
RETURNS INT
AS
BEGIN
    DECLARE @clientCount INT;

    SELECT @clientCount = COUNT(DISTINCT ClientId)
    FROM Products P
    JOIN ProductsClients PC ON P.Id = PC.ProductId
    WHERE P.Name = @productName;

    RETURN @clientCount;
END;


--12. Search for Vendors from a Specific Country

