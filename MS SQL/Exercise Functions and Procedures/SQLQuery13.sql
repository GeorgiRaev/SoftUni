--01
USE SoftUni
GO
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS 
SELECT FirstName
	  ,LastName
FROM Employees
WHERE Salary > 35000

EXEC dbo.usp_GetEmployeesSalaryAbove35000

--02
CREATE PROC usp_GetEmployeesSalaryAboveNumber @minSalary DECIMAL(18,4)
AS
BEGIN
	SELECT FirstName,
			LastName
		FROM Employees
		WHERE Salary>= @minSalary
	END
EXEC dbo.usp_GetEmployeesSalaryAboveNumber 60500

--03
CREATE OR ALTER PROC usp_GetTownsStartingWith @startWith VARCHAR(50)
AS
	BEGIN
		SELECT [Name] AS [Towns]
		FROM Towns
		WHERE SUBSTRING([Name], 1, LEN(@startWith)) = @startWith
	END
EXEC usp_GetTownsStartingWith b

--04
CREATE PROCEDURE usp_GetEmployeesFromTown @townName VARCHAR(20)
AS
	BEGIN
		SELECT FirstName,
				LastName
		FROM Employees AS e
		JOIN Addresses AS a ON e.AddressID = a.AddressID
		JOIN Towns AS t ON a.TownID = t.TownID
		WHERE t.[Name] = @townName
	END
EXEC usp_GetEmployeesFromTown 'Sofia'

--05
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
	RETURNS NVARCHAR(20)
	AS 
	BEGIN
		IF @salary<30000
		RETURN 'Low'
		ELSE IF @salary<=50000
		RETURN 'Average'
		RETURN 'High'
	END;

--06
CREATE OR ALTER PROC usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(20))
	AS
	BEGIN
		SELECT 
		FirstName AS [First Name]
		,LastName AS [Last Name]
		FROM Employees
		WHERE dbo.ufn_GetSalaryLevel(Salary)=@salaryLevel

	END;

	--07. Define Function

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50) , @word NVARCHAR(200)) 
RETURNS BIT 
AS 
BEGIN
	DECLARE @i INT=1
	WHILE  @i<= LEN (@word)
	BEGIN
		DECLARE @ch NVARCHAR(1)= SUBSTRING(@word,@i,1)
		IF CHARINDEX(@ch, @setOfLetters)=0
		RETURN 0
		SET @i+=1
	END
	RETURN 1
END;

SELECT dbo.ufn_IsWordComprised('ABV','c' ) AS Result

--10
CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan @parameter DECIMAL(20,6)
AS
BEGIN
	SELECT 
	ah.FirstName AS [First Name]
	,ah.LastName AS [Last Name]
	
	FROM AccountHolders AS ah
	JOIN (
	SELECT 
	AccountHolderId
	,SUM(Balance) AS TotalSum
	FROM Accounts
	GROUP BY AccountHolderId
	) AS sas ON ah.Id=sas.AccountHolderId
	WHERE TotalSum>@parameter
	ORDER BY ah.FirstName,ah.LastName

END;