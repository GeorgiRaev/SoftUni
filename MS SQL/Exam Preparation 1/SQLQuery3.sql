CREATE DATABASE TouristAgency
GO

-- Use the TouristAgency database
USE TouristAgency;
GO

-- Create the Countries table
CREATE TABLE Countries (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

-- Create the Destinations table
CREATE TABLE Destinations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    CountryId INT NOT NULL,
    FOREIGN KEY (CountryId) REFERENCES Countries(Id)
);

-- Create the Rooms table
CREATE TABLE Rooms (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Type NVARCHAR(40) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    BedCount INT NOT NULL CHECK (BedCount > 0 AND BedCount <= 10)
);

-- Create the Hotels table
CREATE TABLE Hotels (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    DestinationId INT NOT NULL,
    FOREIGN KEY (DestinationId) REFERENCES Destinations(Id)
);

-- Create the Tourists table
CREATE TABLE Tourists (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(80) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(80),
    CountryId INT NOT NULL,
    FOREIGN KEY (CountryId) REFERENCES Countries(Id)
);

-- Create the Bookings table
CREATE TABLE Bookings (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ArrivalDate DATETIME2 NOT NULL,
    DepartureDate DATETIME2 NOT NULL,
    AdultsCount INT NOT NULL CHECK (AdultsCount >= 1 AND AdultsCount <= 10),
    ChildrenCount INT NOT NULL CHECK (ChildrenCount >= 0 AND ChildrenCount <= 9),
    TouristId INT NOT NULL,
    HotelId INT NOT NULL,
    RoomId INT NOT NULL,
    FOREIGN KEY (TouristId) REFERENCES Tourists(Id),
    FOREIGN KEY (HotelId) REFERENCES Hotels(Id),
    FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
);

-- Create the HotelsRooms table
CREATE TABLE HotelsRooms (
    HotelId INT NOT NULL,
    RoomId INT NOT NULL,
    PRIMARY KEY (HotelId, RoomId),
    FOREIGN KEY (HotelId) REFERENCES Hotels(Id),
    FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
);











-----------------------------------------------------------------------------------------------------------------------
--02. Insert
-- Insert sample data into the Tourists table
INSERT INTO Tourists (Name, PhoneNumber, Email, CountryId)
VALUES 
('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6);

-- Insert sample data into the Bookings table
INSERT INTO Bookings (ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES 
('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6);


--03. Update
-- Update departure dates for bookings arriving in December 2023
UPDATE Bookings
SET DepartureDate = DATEADD(day, 1, DepartureDate)
WHERE ArrivalDate >= '2023-12-01' AND ArrivalDate < '2024-01-01';

-- Update email addresses of tourists whose names contain "MA"
UPDATE Tourists
SET Email = NULL
WHERE Name LIKE '%MA%';


--04. Delete
-- Delete bookings associated with tourists whose names contain "Smith"
DELETE FROM Bookings
WHERE TouristId IN (
    SELECT Id
    FROM Tourists
    WHERE Name LIKE '%Smith%'
);

-- Delete tourists whose names contain "Smith"
DELETE FROM Tourists
WHERE Name LIKE '%Smith%';


--05. Bookings by Price of Room and Arrival Date
SELECT 
    CONVERT(VARCHAR(10), b.ArrivalDate, 120) AS ArrivalDate,
    b.AdultsCount,
    b.ChildrenCount
FROM 
    Bookings b
JOIN 
    Rooms r ON b.RoomId = r.Id
ORDER BY 
    r.Price DESC, 
    b.ArrivalDate ASC;


--06.Hotels by Count of Bookings
SELECT 
    H.Id,
    H.Name
FROM 
    Hotels H
JOIN 
    HotelsRooms HR ON H.Id = HR.HotelId
JOIN 
    Rooms R ON HR.RoomId = R.Id
WHERE 
    R.Type = 'VIP Apartment'
ORDER BY 
    (SELECT COUNT(*) 
     FROM Bookings B 
     WHERE B.HotelId = H.Id) DESC;


--07. Tourists without Bookings
SELECT 
    T.Id,
    T.Name,
    T.PhoneNumber
FROM 
    Tourists T
LEFT JOIN 
    Bookings B ON T.Id = B.TouristId
WHERE 
    B.Id IS NULL
ORDER BY 
    T.Name ASC;


--08. First 10 Bookings
SELECT TOP 10
    H.Name AS HotelName,
    D.Name AS DestinationName,
    C.Name AS CountryName
FROM 
    Bookings B
INNER JOIN 
    Hotels H ON B.HotelId = H.Id
INNER JOIN 
    Destinations D ON H.DestinationId = D.Id
INNER JOIN 
    Countries C ON D.CountryId = C.Id
WHERE 
    B.ArrivalDate < '2023-12-31'
    AND H.Id % 2 <> 0 -- Select hotels with odd-numbered IDs
ORDER BY 
    C.Name ASC, B.ArrivalDate ASC;



--09. Tourists booked in Hotels
SELECT
    H.Name AS HotelName,
    R.Price AS RoomPrice
FROM 
    Tourists T
INNER JOIN 
    Bookings B ON T.Id = B.TouristId
INNER JOIN 
    Hotels H ON B.HotelId = H.Id
INNER JOIN 
    Rooms R ON B.RoomId = R.Id
WHERE 
    T.Name NOT LIKE '%EZ'
ORDER BY 
    R.Price DESC;


--10. Hotels Revenue
SELECT
    H.Name AS HotelName,
    SUM(DATEDIFF(DAY, B.ArrivalDate, B.DepartureDate) * R.Price) AS TotalRevenue
FROM
    Bookings B
INNER JOIN
    Hotels H ON B.HotelId = H.Id
INNER JOIN
    Rooms R ON B.RoomId = R.Id
GROUP BY
    H.Name
ORDER BY
    TotalRevenue DESC;



--11. Rooms with Tourists
CREATE FUNCTION udf_RoomsWithTourists(@name NVARCHAR(40))
RETURNS INT
AS
BEGIN
    DECLARE @TotalTourists INT;

    SELECT @TotalTourists = SUM(AdultsCount + ChildrenCount)
    FROM Bookings B
    INNER JOIN Rooms R ON B.RoomId = R.Id
    WHERE R.Type = @name;

    RETURN ISNULL(@TotalTourists, 0);
END;


--12. Search for Tourists from a Specific Country
CREATE PROCEDURE usp_SearchByCountry
    @country NVARCHAR(50)
AS
BEGIN
    SELECT t.Name, t.PhoneNumber, t.Email, COUNT(b.Id) AS CountOfBookings
    FROM Tourists AS t
    JOIN Bookings AS b ON t.Id = b.TouristId
    JOIN Countries AS c ON t.CountryId = c.Id
    WHERE c.[Name] = @country
    GROUP BY t.Name, t.PhoneNumber, t.Email
    ORDER BY t.Name ASC, CountOfBookings DESC;
END;















