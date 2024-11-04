
--01. DDL
CREATE TABLE Passengers
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
);

CREATE TABLE Towns
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
);

CREATE TABLE RailwayStations
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	TownId INT NOT NULL,
	FOREIGN KEY (TownId) REFERENCES Towns (Id)
);

CREATE TABLE Trains
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	HourOfDeparture VARCHAR(5) NOT NULL,
	HourOfArrival VARCHAR(5) NOT NULL,
	DepartureTownId INT NOT NULL FOREIGN KEY (DepartureTownId) REFERENCES Towns(Id),
	ArrivalTownId INT NOT NULL FOREIGN KEY (ArrivalTownId) REFERENCES Towns(Id)
);

CREATE TABLE TrainsRailwayStations
(
	TrainId INT NOT NULL,
	RailwayStationId INT NOT NULL,
	PRIMARY KEY (TrainId,RailwayStationId),
	FOREIGN KEY (TrainId) REFERENCES Trains (Id),
	FOREIGN KEY (RailwayStationId) REFERENCES RailwayStations(Id)
);

CREATE TABLE MaintenanceRecords
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DateOfMaintenance DATE NOT NULL,
	Details VARCHAR(2000) NOT NULL,
	TrainId INT FOREIGN KEY (TrainId) REFERENCES Trains(Id)
);

CREATE TABLE Tickets
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Price DECIMAL(2) NOT NULL,
	DateOfDeparture DATE NOT NULL,
	DateOfArrival DATE NOT NULL,
	TrainId INT  FOREIGN KEY (TrainId) REFERENCES Trains(Id) NOT NULL,
	PassengerId INT  FOREIGN KEY (PassengerId) REFERENCES Passengers(Id) NOT NULL
);

--02. Insert
-- Вмъкване на данни в таблица Trains
INSERT INTO Trains (HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES
('07:00', '19:00', 1, 3),
('08:30', '20:30', 5, 6),
('09:00', '21:00', 4, 8),
('06:45', '03:55', 27, 7),
('10:15', '12:15', 15, 5);

-- Вмъкване на данни в таблица TrainsRailwayStations
INSERT INTO TrainsRailwayStations (TrainId, RailwayStationId)
VALUES
(36, 1),
(36, 4),
(36, 31),
(36, 57),
(36, 7),
(37, 60),
(37, 16),
(37, 13),
(37, 54),
(38, 10),
(38, 50),
(38, 52),
(38, 22),
(39, 3),
(39, 31),
(39, 19),
(39, 68),
(40, 41),
(40, 7),
(40, 52),
(40, 13);

-- Вмъкване на данни в таблица Tickets
INSERT INTO Tickets (Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES
(90.00, '2023-12-01', '2023-12-01', 36, 1),
(115.00, '2023-08-02', '2023-08-02', 37, 2),
(160.00, '2023-08-03', '2023-08-03', 38, 3),
(255.00, '2023-09-01', '2023-09-02', 39, 21),
(95.00, '2023-09-02', '2023-09-03', 40, 22);


--03. Update
UPDATE Tickets
SET 
    DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture),
    DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
WHERE
    DateOfDeparture > '2023-10-31';


--04. Delete
-- Стъпка 1: Намери идентификатора на града Берлин
DECLARE @BerlinTownId INT;
SELECT @BerlinTownId = Id
FROM Towns
WHERE [Name] = 'Berlin';

-- Стъпка 2: Намери идентификатора на влака, който тръгва от Берлин
DECLARE @TrainId INT;
SELECT @TrainId = Id
FROM Trains
WHERE DepartureTownId = @BerlinTownId;

-- Стъпка 3: Изтрий свързаните записи в таблиците TrainsRailwayStations, MaintenanceRecords и Tickets
DELETE FROM TrainsRailwayStations
WHERE TrainId = @TrainId;

DELETE FROM MaintenanceRecords
WHERE TrainId = @TrainId;

DELETE FROM Tickets
WHERE TrainId = @TrainId;

-- Стъпка 4: Изтрий записа за влака в таблицата Trains
DELETE FROM Trains
WHERE Id = @TrainId;


--05. Tickets by Price and Date Departure
SELECT 
    DateOfDeparture,
    Price AS TicketPrice
FROM 
    Tickets
ORDER BY 
    Price ASC,
    DateOfDeparture DESC;


--06. Passengers with their Tickets
SELECT 
    p.[Name] AS PassengerName,
    t.Price AS TicketPrice,
    t.DateOfDeparture,
    t.TrainId
FROM 
    Tickets t
JOIN 
    Passengers p ON t.PassengerId = p.Id
ORDER BY 
    t.Price DESC,
    p.[Name] ASC;


--07. Railway Stations without Passing Trains
SELECT 
    t.[Name] AS Town,
    rs.[Name] AS RailwayStation
FROM 
    RailwayStations rs
JOIN 
    Towns t ON rs.TownId = t.Id
LEFT JOIN 
    TrainsRailwayStations trs ON rs.Id = trs.RailwayStationId
WHERE 
    trs.RailwayStationId IS NULL
ORDER BY 
    t.[Name] ASC, 
    rs.[Name] ASC;


--08. First 3 Trains Between 08:00 and 08:59
SELECT TOP 3
    Trains.Id AS TrainId,
    Trains.HourOfDeparture,
    Tickets.Price AS TicketPrice,
    ArrivalTown.[Name] AS Destination
FROM
    Trains
INNER JOIN
    Tickets ON Trains.Id = Tickets.TrainId
INNER JOIN
    Towns AS DepartureTown ON Trains.DepartureTownId = DepartureTown.Id
INNER JOIN
    Towns AS ArrivalTown ON Trains.ArrivalTownId = ArrivalTown.Id
WHERE
    CONVERT(TIME, Trains.HourOfDeparture) >= '08:00' AND
    CONVERT(TIME, Trains.HourOfDeparture) < '09:00' AND
    Tickets.Price > 50.00
ORDER BY
    Tickets.Price ASC;


--09. Count of Passengers Paid More Than Average
WITH PassengersAboveAverage AS (
    SELECT
        p.Id AS PassengerId,
        t.ArrivalTownId
    FROM
        Tickets tk
    JOIN
        Passengers p ON tk.PassengerId = p.Id
    JOIN
        Trains t ON tk.TrainId = t.Id
    WHERE
        tk.Price > 76.99
)
SELECT
    town.Name AS TownName,
    COUNT(paa.PassengerId) AS PassengersCount
FROM
    PassengersAboveAverage paa
JOIN
    Towns town ON paa.ArrivalTownId = town.Id
GROUP BY
    town.Name
ORDER BY
    town.Name ASC;



--10.Maintenance Inspection with Town
SELECT
    t.Id AS TrainID,
    departureTown.Name AS DepartureTown,
    mr.Details
FROM
    Trains t
JOIN
    Towns departureTown ON t.DepartureTownId = departureTown.Id
JOIN
    MaintenanceRecords mr ON t.Id = mr.TrainId
WHERE
    mr.Details LIKE '%inspection%'
ORDER BY
    t.Id;


--11. Towns with Trains
CREATE FUNCTION dbo.udf_TownsWithTrains (@name VARCHAR(30))
RETURNS INT
AS
BEGIN
    DECLARE @totalTrains INT;

    SELECT @totalTrains = COUNT(*)
    FROM Trains t
    JOIN Towns depTown ON t.DepartureTownId = depTown.Id
    JOIN Towns arrTown ON t.ArrivalTownId = arrTown.Id
    WHERE depTown.Name = @name OR arrTown.Name = @name;

    RETURN @totalTrains;
END;


--12. Search Passengers travelling to Specific Town
CREATE PROCEDURE usp_SearchByTown
    @townName VARCHAR(50)
AS
BEGIN
    SELECT 
        P.[Name] AS PassengerName,
        T.DateOfDeparture,
        Tr.HourOfDeparture
    FROM 
        Tickets AS T
    INNER JOIN 
        Trains AS Tr ON T.TrainId = Tr.Id
    INNER JOIN 
        Passengers AS P ON T.PassengerId = P.Id
    INNER JOIN 
        Towns AS DepTown ON Tr.DepartureTownId = DepTown.Id
    INNER JOIN 
        Towns AS ArrTown ON Tr.ArrivalTownId = ArrTown.Id
    WHERE 
        ArrTown.[Name] = @townName
    ORDER BY 
        T.DateOfDeparture DESC,
        P.[Name] ASC;
END;
