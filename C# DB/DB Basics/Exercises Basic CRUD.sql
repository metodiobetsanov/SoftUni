-- PROBLEM 1
-- CREATE DATABASES FROM FILES
USE SoftUni
GO

-- PROBLEM 2
SELECT * FROM Departments
GO

-- PROBLEM 3
SELECT Name FROM Departments
GO

-- PROBLEM 4
SELECT FirstName, LastName, Salary FROM Employees
GO 

-- PROBLEM 5
SELECT FirstName, MiddleName, LastName FROM Employees
GO

-- PROBLEM 6
SELECT  FirstName + '.' + LastName + '@softuni.bg' AS 'Full Email Address' FROM Employees
GO

-- PROBLEM 7
SELECT DISTINCT SALARY FROM Employees
GO

-- PROBLEM 8
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'
GO

-- PROBLEM 9
SELECT FirstName, LastName, JobTitle FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
GO

-- PROBLEM 10
SELECT FirstName + ' ' + MiddleName + ' ' +  LastName FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)
GO

-- PROBLEM 11
SELECT FirstName, LastName FROM Employees
WHERE Managerid IS NULL
GO

-- PROBLEM 12
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC
GO

-- PROBLEM 13
SELECT TOP(5) FirstName, LastName FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC
GO

-- PROBLEM 14
SELECT FirstName, LastName FROM Employees
WHERE NOT DepartmentId = 4
GO

-- PROBLEM 15
SELECT * FROM Employees
ORDER BY Salary DESC, 
			FirstName, 
			LastName DESC, 
			MiddleName
GO

-- PROBLEM 16
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary FROM Employees
GO 

-- PROBLEM 17
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' +  LastName AS 'Full Name', JobTitle FROM Employees
GO

-- PROBLEM 18
SELECT DISTINCT JobTitle FROM Employees
GO

-- PROBLEM 19
SELECT TOP(10) * FROM Projects
ORDER BY StartDate, Name
GO

-- PROBLEM 20
SELECT TOP(7) FirstName, LastName, HireDate FROM Employees
ORDER BY HireDate DESC
GO

-- PROBLEM 21
UPDATE Employees
SET Salary += Salary * 0.12
WHERE DepartmentId IN (1, 2, 4, 11)
GO

SELECT Salary FROM Employees
GO

-- PROBLEM 22
USE Geography
GO

SELECT PeakName FROM Peaks
ORDER BY PeakName
GO

-- PROBLEM 23
SELECT TOP(30) CountryName, Population FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY Population DESC
GO

-- PROBLEM 24
SELECT CountryName, CountryCode,(CASE CurrencyCode WHEN 'EUR' THEN 'Euro' ELSE 'Not Euro' END) AS Currency FROM Countries
ORDER BY CountryName

-- PROBLEM 25
USE DIABLO
GO

SELECT Name FROM Characters
ORDER BY Name