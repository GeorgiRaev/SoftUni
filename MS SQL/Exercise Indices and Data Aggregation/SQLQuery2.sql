--01
SELECT COUNT(Id) FROM WizzardDeposits

--02
SELECT MAX(MagicWandSize) AS LongestMagicWandSize
FROM WizzardDeposits

--03
SELECT 
	DepositGroup,
	MAX(MagicWandSize) AS LongestMagicWandSize
FROM WizzardDeposits
GROUP BY DepositGroup

--04 
SELECT TOP 2
	DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)


--05
SELECT  
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup


--06
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum 
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup


--07
SELECT 
	DepositGroup, SUM(DepositAmount) AS TotalDepositAmount
FROM WizzardDeposits
WHERE 
	MagicWandCreator = 'Ollivander family'
GROUP BY 
	DepositGroup
HAVING
	SUM(DepositAmount) < 150000
ORDER BY
	TotalDepositAmount DESC


--08
SELECT 
	DepositGroup, MagicWandCreator, 
	MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY 
	MagicWandCreator, DepositGroup 
ORDER BY
	MagicWandCreator, DepositGroup 

--09
SELECT 
	AgeCategory, COUNT(*) AS WizzardCount
FROM
(
        SELECT
        	CASE
        		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
        		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
        		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
        		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
        		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
        		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
        		WHEN Age > 60 THEN '[61+]'   
        	END AS AgeCategory
        		FROM WizzardDeposits
) AS NestedQuery
GROUP BY AgeCategory

--10
SELECT FirstLetter FROM
(
        SELECT 
            SUBSTRING(FirstName, 1, 1) AS FirstLetter
        FROM 
            WizzardDeposits
        WHERE 
            DepositGroup = 'Troll Chest'
) AS SubQuery
GROUP BY FirstLetter

--11
SELECT 
    DepositGroup, IsDepositExpired,
	AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate>'1985-01-01'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC,IsDepositExpired

--13
USE SoftUni
GO

SELECT
	DepartmentID,
	SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID


--14

SELECT 
	DepartmentID,
	MIN(Salary) AS MinSalary
FROM Employees
WHERE
	DepartmentID IN (2,5,7) AND
	HireDate > '2000-01-01'
GROUP BY DepartmentID

--15
SELECT * INTO EmployeesWithHighSalary
FROM Employees
WHERE Salary> 30000
DELETE FROM EmployeesWithHighSalary
WHERE ManagerID= '42'
UPDATE EmployeesWithHighSalary
SET Salary = Salary+5000
WHERE DepartmentID ='1'
SELECT DepartmentId,
	AVG(Salary) AS AverageSalary
FROM EmployeesWithHighSalary
GROUP BY DepartmentID


--16
SELECT 
	DepartmentID,
	MAX(Salary)AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING
	MAX(Salary) NOT BETWEEN 30000 AND 70000

--17
SELECT 
	COUNT(Salary) AS SelaryCount
FROM Employees
WHERE ManagerID IS NULL