USE SoftUni
GO
--02
SELECT * FROM Departments
--03
SELECT [Name] FROM Departments

--04
SELECT FirstName, LastName, Salary FROM Employees

--05
SELECT FirstName, MiddleName, LastName FROM Employees

--06
Select FirstName + '.' + LastName + '@softuni.bg' FROM Employees

--07
SELECT DISTINCT salary FROM employees;

--08
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative';

--09
SELECT FirstName, LastName, JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000;

--10
SELECT 
    FirstName + ' ' + MiddleName + ' ' + LastName AS "Full Name"
FROM 
    Employees
WHERE 
    Salary IN (25000, 14000, 12500, 23600);

--11
SELECT FirstName, LastName
FROM Employees
WHERE ManagerID IS NULL;

--12
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--13
SELECT TOP 5 FirstName, LastName
FROM Employees
ORDER BY Salary DESC;

--14
SELECT FirstName, LastName
FROM Employees
WHERE DepartmentID <> 4;

--15
SELECT *
FROM Employees
ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC;


--16
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
FROM Employees;
-- Извличане на данни от изгледа V_EmployeesSalaries
SELECT * FROM V_EmployeesSalaries;

--17
-- Създаване на изглед V_EmployeeNameJobTitle, който включва пълното име на служителя и неговата работна позиция
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT 
    CONCAT(FirstName, ' ', ISNULL(MiddleName, ''), ' ', LastName) AS FullName,
    JobTitle
FROM Employees;

-- Извличане на данни от изгледа V_EmployeeNameJobTitle
SELECT * FROM V_EmployeeNameJobTitle;

--18
SELECT DISTINCT JobTitle
FROM Employees;

--19
SELECT TOP 10 *
FROM Projects
WHERE StartDate IS NOT NULL
ORDER BY StartDate, ProjectName;
SELECT * FROM Projects

--20
SELECT TOP(10) * 
  FROM Projects 
 WHERE StartDate <= GETDATE() 
 ORDER BY StartDate, [Name]

 --21
 SELECT TOP(7) FirstName, LastName, HireDate
FROM Employees
ORDER BY HireDate DESC;

USE Geography
Go

--22
SELECT PeakName 
 FROM Peaks
ORDER BY PeakName





