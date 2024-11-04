CREATE DATABASE Boardgames
USE Boardgames;

-- Create the Categories table
CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

-- Create the Addresses table
CREATE TABLE Addresses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StreetName NVARCHAR(100) NOT NULL,
    StreetNumber INT NOT NULL,
    Town NVARCHAR(30) NOT NULL,
    Country NVARCHAR(50) NOT NULL,
    ZIP INT NOT NULL
);

-- Create the Publishers table
CREATE TABLE Publishers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(30) UNIQUE NOT NULL,
    AddressId INT NOT NULL,
    Website NVARCHAR(40),
    Phone NVARCHAR(20),
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

-- Create the PlayersRanges table
CREATE TABLE PlayersRanges (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PlayersMin INT NOT NULL,
    PlayersMax INT NOT NULL
);

-- Create the Boardgames table
CREATE TABLE Boardgames (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL,
    YearPublished INT NOT NULL,
    Rating DECIMAL(5,2) NOT NULL,
    CategoryId INT NOT NULL,
    PublisherId INT NOT NULL,
    PlayersRangeId INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY (PublisherId) REFERENCES Publishers(Id),
    FOREIGN KEY (PlayersRangeId) REFERENCES PlayersRanges(Id)
);

-- Create the Creators table
CREATE TABLE Creators (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Email NVARCHAR(30) NOT NULL
);

-- Create the CreatorsBoardgames table
CREATE TABLE CreatorsBoardgames (
    CreatorId INT NOT NULL,
    BoardgameId INT NOT NULL,
    PRIMARY KEY (CreatorId, BoardgameId),
    FOREIGN KEY (CreatorId) REFERENCES Creators(Id),
    FOREIGN KEY (BoardgameId) REFERENCES Boardgames(Id)
);

--02.Insert
-- Вмъкване на данни в таблицата Publishers
INSERT INTO Publishers (Name, AddressId, Website, Phone)
VALUES 
    ('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
    ('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
    ('BattleBooks', 13, 'www.battlebooks.com', '+12345678907');

	-- Вмъкване на данни в таблицата Boardgames
INSERT INTO Boardgames (Name, YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES
    ('Deep Blue', 2019, 5.67, 1, 15, 7),
    ('Paris', 2016, 9.78, 7, 1, 5),
    ('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
    ('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
    ('One Small Step', 2019, 5.75, 5, 9, 2);

--03.Update
-- Увеличаване на максималния брой играчи за рейндж [2, 2] в таблица PlayersRanges
UPDATE PlayersRanges
SET PlayersMax = PlayersMax + 1
WHERE PlayersMin = 2 AND PlayersMax = 2;

-- Промяна на имената на игрите издадени след 2020 година
UPDATE Boardgames
SET Name = CONCAT(Name, ' V2')
WHERE YearPublished >= 2020;

--04.Delete


--05. Boardgames by Year of Publication
SELECT Name, Rating
FROM Boardgames
ORDER BY YearPublished ASC, Name DESC;

--06. Boardgames by Category
SELECT bg.Id, bg.Name, bg.YearPublished, c.Name AS CategoryName
FROM Boardgames bg
JOIN Categories c ON bg.CategoryId = c.Id
WHERE c.Name IN ('Strategy Games', 'Wargames')
ORDER BY bg.YearPublished DESC;


--07. Creators without Boardgames
SELECT
    c.Id,
    CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName,
    c.Email
FROM
    Creators c
WHERE
    c.Id NOT IN (
        SELECT DISTINCT cb.CreatorId
        FROM CreatorsBoardgames cb
    )
ORDER BY
    CreatorName ASC;



--08. First 5 Boardgames
SELECT TOP 5
    b.Name,
    b.Rating,
    c.Name AS CategoryName
FROM
    Boardgames b
JOIN
    Categories c ON b.CategoryId = c.Id
JOIN
    PlayersRanges pr ON b.PlayersRangeId = pr.Id
WHERE
    (b.Rating > 7.00 AND (b.Name LIKE '%a%' OR b.Name LIKE '%A%'))
    OR (b.Rating > 7.50 AND pr.PlayersMin >= 2 AND pr.PlayersMax <= 5)
ORDER BY
    b.Name ASC,
    b.Rating DESC;



--09. Creators with Emails
WITH RankedBoardgames AS (
    SELECT
        cb.CreatorId,
        bg.Name,
        bg.Rating,
        ROW_NUMBER() OVER (PARTITION BY cb.CreatorId ORDER BY bg.Rating DESC) AS Rank
    FROM
        CreatorsBoardgames cb
    JOIN
        Boardgames bg ON cb.BoardgameId = bg.Id
)
SELECT
    CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
    c.Email,
    rb.Rating
FROM
    Creators c
JOIN
    RankedBoardgames rb ON c.Id = rb.CreatorId AND rb.Rank = 1
WHERE
    c.Email LIKE '%.com'
ORDER BY
    FullName ASC;



--10. Creators by Rating



--11. Creator with Boardgames
CREATE FUNCTION udf_CreatorWithBoardgames (@firstName NVARCHAR(30))
RETURNS INT
AS
BEGIN
    DECLARE @creatorId INT;

    -- Get the CreatorId based on the provided first name
    SELECT @creatorId = Id
    FROM Creators
    WHERE FirstName = @firstName;

    -- Return the count of boardgames created by the creator
    RETURN (
        SELECT COUNT(*)
        FROM CreatorsBoardgames
        WHERE CreatorId = @creatorId
    );
END;


--12. Search for Boardgame with Specific Category
CREATE PROCEDURE usp_SearchByCategory
    @category VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        bg.[Name] AS Name,
        bg.YearPublished AS YearPublished,
        bg.Rating AS Rating,
        c.[Name] AS CategoryName,
        p.[Name] AS PublisherName,
        CONCAT(pr.PlayersMin, ' people') AS MinPlayers,
        CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
    FROM
        Boardgames bg
    INNER JOIN
        Categories c ON bg.CategoryId = c.Id
    INNER JOIN
        Publishers p ON bg.PublisherId = p.Id
    INNER JOIN
        PlayersRanges pr ON bg.PlayersRangeId = pr.Id
    WHERE
        c.[Name] = @category
    ORDER BY
        p.[Name] ASC,
        bg.YearPublished DESC;

    SET NOCOUNT OFF;
END;

