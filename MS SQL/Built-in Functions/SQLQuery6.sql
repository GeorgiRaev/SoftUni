USE SoftUni

--01
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%'


--02
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%';


--03
SELECT FirstName
From Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10)
AND YEAR(HireDate) BETWEEN 1995 AND 2005


--04
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'


--05
SELECT [Name]
FROM Towns
WHERE LEN([Name]) =5 OR LEN([Name]) = 6
ORDER BY [Name]


--06
SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE 'M%' OR [Name] LIKE 'K%' OR [Name] LIKE 'B%' OR [Name] LIKE 'E%'
ORDER BY [Name]


--07
SELECT TownID,[Name]
FROM Towns
WHERE [Name] NOT LIKE 'R%' AND [Name] NOT LIKE 'B%' AND [Name] NOT LIKE 'D%'
ORDER BY [Name]


--08
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,LastName
FROM Employees
WHERE YEAR(HireDate)>2000


--09
SELECT FirstName,LastName
FROM Employees
WHERE LEN(LastName)=5


--10
WITH CTE_RankedEmployees AS
(
	SELECT EmployeeID, FirstName, LastName, Salary,
		DENSE_RANK() OVER
		(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000 
)

SELECT * 
	FROM CTE_RankedEmployees
	WHERE [Rank] = 2
	ORDER BY Salary DESC

--11
-- Common table expression
WITH CTE_RankedEmployees AS
(
	SELECT EmployeeID, FirstName, LastName, Salary,
		DENSE_RANK() OVER
		(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000 
)

SELECT * 
FROM CTE_RankedEmployees 
WHERE [Rank] = 2
ORDER BY Salary DESC

USE Geography
GO
--12
SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode


--13
SELECT PeakName, RiverName,
LOWER(CONCAT(SUBSTRING(PeakName, 1, LEN(PeakName)-1), RiverName)) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix


--14
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]


--18
SELECT 
    ProductName,
    OrderDate,
    DATEADD(day, 3, OrderDate) AS PayDueDate,
    DATEADD(month, 1, OrderDate) AS DeliverDueDate
FROM 
    Orders;
