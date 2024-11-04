USE SoftUni

--01
SELECT TOP (5) 
e.EmployeeId, e.JobTitle, e.AddressId, AddressText
FROM Employees AS e 
JOIN Addresses AS a ON a.AddressID = e.AddressId
ORDER BY AddressId


--02
SELECT TOP (50)
    e.FirstName, 
    e.LastName, 
    t.[Name], 
    a.AddressText
FROM 
    Employees AS e
JOIN 
    Addresses AS a ON e.AddressID = a.AddressID 
JOIN
	Towns AS t ON a.TownID = t.TownID
ORDER BY 
    e.FirstName ASC, 
    e.LastName ASC


--03
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name] AS DepartmentName
FROM Employees AS e
JOIN 
	Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE 
	d.[Name] = 'Sales'
ORDER BY
	e.EmployeeID ASC

--04
SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID ASC


--05
SELECT TOP (3)
	e.EmployeeID,
	e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY E.EmployeeID


--06
SELECT
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS [DeptName]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales' OR d.[Name] = 'Finance' AND HireDate > '01.01.1991'
ORDER BY HireDate


--07
SELECT TOP (5)
	e.EmployeeID,
	e.FirstName,
	p.[Name] AS ProjectName
FROM EmployeesProjects AS ep
JOIN Employees AS e ON e.EmployeeID = Ep.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE StartDate > '2002-08-13' AND EndDate IS NULL
ORDER BY e.EmployeeID ASC

--08
SELECT 
    e.EmployeeID,
    e.FirstName,
    CASE 
        WHEN p.StartDate >= '2005-01-01' THEN NULL 
        ELSE p.[Name] 
    END AS ProjectName
FROM 
    Employees AS e
JOIN 
    EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN 
    Projects AS p ON ep.ProjectID = p.ProjectID
WHERE 
    e.EmployeeID = 24;


--09
SELECT 
    e.EmployeeID,
    e.FirstName,
    e.ManagerID,
    m.FirstName AS ManagerName
FROM 
    Employees AS e
JOIN 
    Employees AS m ON e.ManagerID = m.EmployeeID
WHERE 
    e.ManagerID = 3 OR e.ManagerID = 7
ORDER BY 
    e.EmployeeID ASC;


--10
SELECT TOP (50)
    e.EmployeeID,
    e.FirstName + ' ' + e.LastName AS EmployeeName,
    m.FirstName + ' ' + m.LastName AS ManagerName,
	d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY 
    e.EmployeeID ASC

--11
SELECT 
MIN(avs.MinAVG) AS MinAverageSalary 
FROM
(
	SELECT AVG(Salary) AS MinAVG
	FROM Employees
	GROUP BY DepartmentID
) AS avs

USE Geography

--12
SELECT
	c.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON p.MountainId = mc.MountainId
WHERE c.CountryCode = 'BG' AND p.Elevation> 2835
ORDER BY p.Elevation DESC

--13
SELECT 
	mc.CountryCode,
	COUNT(m.MountainRange)
FROM Mountains AS m
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE mc.CountryCode IN ('US','RU','BG')
GROUP BY mc.CountryCode

--14
SELECT TOP 5
	   c.CountryName
	  ,r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
LEFT JOIN Continents AS cn ON cn.ContinentCode = c.ContinentCode
WHERE cn.ContinentName = 'Africa'
ORDER BY c.CountryName

--16
SELECT 
	COUNT(c.CountryCode) AS [Count]

FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL


--17
SELECT	TOP 5
		c.CountryName
	  ,MAX(p.Elevation) AS HighestPeakElevation
	  ,MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
WHERE p.Elevation IS NOT NULL AND r.[Length] IS NOT NULL
GROUP BY c.CountryName 
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC