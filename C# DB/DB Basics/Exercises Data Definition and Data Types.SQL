-- PROBLEM 1
CREATE DATABASE Minions

-- PROBLEM 2
CREATE TABLE Minions(
	ID INT NOT NULL,
	Name VARCHAR(50),
	Age INT,
	CONSTRAINT PK_Minions PRIMARY KEY (ID)
	)

CREATE TABLE Towns(
	ID INT NOT NULL,
	Name VARCHAR(50),
	CONSTRAINT PK_Towns PRIMARY KEY (ID)
	)

-- PROBLEM 3
ALTER TABLE Minions
ADD TownId INT CONSTRAINT FK_TOWNS FOREIGN KEY (TownID) REFERENCES Towns(ID)

-- PROBLEM 4
INSERT INTO Towns VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO Minions VALUES
(1,'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3,'Steward', NULL, 2)

-- PROBLEM 5
TRUNCATE TABLE Minions

-- PROBLEM 6
DROP TABLE Minions

DROP TABLE Towns

--PROBLEM 7
CREATE TABLE People(
	ID INT UNIQUE IDENTITY,
	Name VARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(15, 2),
	Weight DECIMAL(15, 2),
	Gender VARCHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography VARCHAR(MAX),
	CONSTRAINT PK_People PRIMARY KEY (ID),
	CONSTRAINT CHECK_Gender CHECK (Gender = 'm' OR Gender = 'f'),
	CONSTRAINT CHECK_PictureSize CHECK (DATALENGTH(Picture) <= 2024*1024)
	)

INSERT INTO People VALUES
('GOSHO', NULL, NULL, NULL, 'm', '01-01-2001', NULL),
('PESHO', NULL, NULL, NULL, 'm', '01-01-2001', NULL),
('DANCHO', NULL, NULL, NULL, 'm', '01-01-2001', NULL),
('VANCHO', NULL, NULL, NULL, 'm', '01-01-2001', NULL),
('KOCE', NULL, NULL, NULL, 'm', '01-01-2001', NULL)

-- PROBLEM 8
CREATE TABLE Users(
	Id BIGINT UNIQUE IDENTITY NOT NULL,
	Username NVARCHAR(30) NOT NULL,
	Password VARCHAR(26) NOT NULL, 
	ProfilePicture VARBINARY,
	LastLoginTime DATETIME,
	IsDeleted BIT,
	CONSTRAINT PK_Users PRIMARY KEY (ID),
	CONSTRAINT CHECK_PictureSize CHECK (DATALENGTH(ProfilePicture)<900*1024)
)

INSERT INTO Users VALUES
('USER1', 'PASSWORD', NULL, NULL, 0),
('USER2', 'PASSWORD', NULL, NULL, 0),
('USER3', 'PASSWORD', NULL, NULL, 0),
('USER4', 'PASSWORD', NULL, NULL, 0),
('USER5', 'PASSWORD', NULL, NULL, 0)

-- PROBLEM 9
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (ID, Username)

-- PROBLEM 10
ALTER TABLE Users
ADD CONSTRAINT CHECK_PASSWORD CHECK (LEN(Password)>=5)

-- PROBLEM 11
ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

-- PROBLEM 12
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(ID)

ALTER TABLE Users
ADD CONSTRAINT UNIQUE_USERNAME UNIQUE(Username)

ALTER TABLE Users
ADD CONSTRAINT CHECK_Username CHECK(LEN(Username) >=3)

-- PROBLEM 13
CREATE DATABASE Movies

CREATE TABLE Directors(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	DirectorName VARCHAR(200) NOT NULL,
	Notes VARCHAR(500) 
)

CREATE TABLE Genres(
	Id INT IDENTITY PRIMARY KEY NOT NULL, 
	GenreName VARCHAR(200) NOT NULL, 
	Notes VARCHAR(500) 
)

CREATE TABLE Categories(
	id INT IDENTITY PRIMARY KEY NOT NULL, 
	CategoryName VARCHAR(200) NOT NULL,
	Notes VARCHAR(500) 
)

CREATE TABLE Movies(
	Id INT IDENTITY PRIMARY KEY NOT NULL, 
	Title VARCHAR(200) NOT NULL, 
	DirectorId INT NOT NULL, 
	CopyrightYear DATE, 
	Length INT, 
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL, 
	Rating INT, 
	Notes VARCHAR(500)
)

INSERT INTO Directors VALUES
('Director1', 'NOTES'),
('Director2', 'NOTES'),
('Director3', 'NOTES'),
('Director4', 'NOTES'),
('Director5', 'NOTES')


INSERT INTO Genres VALUES
('Genre1', 'NOTES'),
('Genre2', 'NOTES'),
('Genre3', 'NOTES'),
('Genre4', 'NOTES'),
('Genre5', 'NOTES')

INSERT INTO Categories VALUES
('Categorie1', 'NOTES'),
('Categorie2', 'NOTES'),
('Categorie3', 'NOTES'),
('Categorie4', 'NOTES'),
('Categorie5', 'NOTES')

INSERT INTO Movies VALUES
('Movie1', 1, '01-01-2001', 90, 1, 1, 5, 'NOTES'),
('Movie2', 2, '01-01-2001', 90, 2, 2, 5, 'NOTES'),
('Movie3', 3, '01-01-2001', 90, 3, 3, 5, 'NOTES'),
('Movie4', 4, '01-01-2001', 90, 4, 4, 5, 'NOTES'),
('Movie1', 5, '01-01-2001', 90, 5, 5, 5, 'NOTES')

-- PROBLEM 14
CREATE DATABASE CarRental 

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(50),
	DailyRate DECIMAL(5, 2) NOT NULL,
	WeeklyRate DECIMAL(5, 2) NOT NULL,
	MonthlyRate DECIMAL(5, 2) NOT NULL,
	WeekendRate DECIMAL(5, 2) NOT NULL
)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber VARCHAR(8),
	Manufacturer VARCHAR(30),
	Model VARCHAR(30),
	CarYear DATE,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors REAL,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(100),
	Available BIT
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(30),
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber NVARCHAR(15) NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	Address NVARCHAR(500),
	City NVARCHAR(50),
	ZIPCode NVARCHAR(10),
	Notes NVARCHAR(200)
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT,
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE,
	EndDate DATE,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied INT,
	TaxRate DECIMAL(5, 2),
	OrderStatus NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories VALUES
('INTO Categorie1', 1.23, 23.4, 34.5, 45.6),
('INTO Categorie2', 1.23, 23.4, 34.5, 45.6),
('INTO Categorie3', 1.23, 23.4, 34.5, 45.6)

INSERT INTO Cars VALUES
('B 0525 A', 'Opel', 'Astra', '01-01-1994', 3, 4, NULL, 'CONDITION', 1),
('A 0525 C', 'Opel', 'Astra', '01-01-1994', 3, 4, NULL,'CONDITION', 1),
('C 0525 A', 'Opel', 'Astra', '01-01-1994', 3, 4, NULL,'CONDITION', 1)

INSERT INTO Employees VALUES
('PESHO', 'PESHOV','SELLER', 'NOTE'),
('GOSHO', 'GOSHOV','SELLER', 'NOTE'),
('MITKO', 'MITKOV','SELLER', 'NOTE')

INSERT INTO Customers (DriverLicenceNumber, FullName) VALUES
('123548', 'MITKO MITKOV'),
('123548', 'PGOSHO GOSHEV'),
('123548', 'NIKI NIKOLOV')

INSERT INTO RentalOrders (EmployeeId, CustomerId, StartDate, EndDate) VALUES
(1, 1, '05-05-2005', '05-10-2005'),
(2, 1, '10-10-2010', '12-12-2012'),
(3, 3, '01-01-2017', '07-07-2017')

--PROBLEM 15
CREATE DATABASE Hotel

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(100),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName) VALUES
('EMP1', 'EMP1'),
('EMP2', 'EMP2'),
('EMP3', 'EMP3')

CREATE TABLE Customers (
	AccountNumber INT UNIQUE IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber INT,
	EmergencyName NVARCHAR(100),
	EmergencyNumber INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers (FirstName, LastName) VALUES
('CUST1', 'CUST1'),
('CUST2', 'CUST2'),
('CUST3', 'CUST3')

CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus) VALUES
('Occupied'),
('Available'),
('Cleaning')

CREATE TABLE RoomTypes (
	RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes (RoomType) VALUES
('4 person'),
('2 person'),
('6 person')

CREATE TABLE BedTypes (
	BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes (BedType) VALUES
('King'),
('Queen'),
('Midget')

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY IDENTITY NOT NULL,
	RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL(6,2),
	RoomStatus NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms (Rate) VALUES
(12.55),
(43.99),
(60.33)

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT,
	PaymentDate DATE,
	AccountNumber INT,
	FirstDateOccipied DATE,
	LastDateOccupied DATE,
	TotalDays AS DATEDIFF(DAY, FirstDateOccipied, LastDateOccupied),
	AmountCharged DECIMAL(10, 2),
	TaxRate DECIMAL(6, 2),
	TaxAmount DECIMAL(6, 2),
	PaymentTotal DECIMAL(12, 2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, AmountCharged) VALUES
(1, GETDATE(), 60.25),
(2, GETDATE(), 160.25),
(3, GETDATE(), 460.25)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT,
	DateOccipied DATE,
	AccountNumber INT,
	RoomNumber INT,
	RateApplied DECIMAL(6, 2),
	PhoneCharge DECIMAL(10, 2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, RateApplied, Notes) VALUES
(1, 55.55, 'enough is enough'),
(2, 15.55, 'now I know how the typewriters feel'),
(3, 35.55, 'these exercises are obsolete')

-- PROBLEM 16
CREATE DATABASE SoftUni

CREATE TABLE Towns (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50)
)

CREATE TABLE Addresses (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AddressText NVARCHAR(100),
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50)
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50),
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50),
	JobTitle NVARCHAR(35),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE,
	Salary DECIMAL(10,2),
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

-- PROBLEM 17
BACKUP DATABASE SoftUni
	TO DISK = 'D:\softuni-backup.bak' 
		WITH FORMAT,
			MEDIANAME = 'DB Back up',
			NAME = 'SoftUni DataBase 2017-09-22';

RESTORE DATABASE SoftUni
FROM DISK = 'D:\softuni-backup.bak'

-- PROBLEM 18
INSERT INTO Towns VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '01/02/2013', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '28/08/2016', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '09/12/2007', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '28/08/2016', 599.88)

-- PROBLEM 19
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

-- PROBLEM 20
SELECT * FROM Towns
ORDER BY NAME ASC

SELECT * FROM Departments
ORDER BY NAME ASC

SELECT * FROM Employees
ORDER BY Salary DESC

-- PROBLEM 21
SELECT Name FROM Towns
ORDER BY NAME ASC

SELECT Name FROM Departments
ORDER BY NAME ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

-- PROBLEM 22
UPDATE Employees
SET Salary += Salary * 0.1  

SELECT Salary FROM Employees

-- PROBLEM 23
UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments

-- PROBLEM 24
DELETE FROM Occupancies
SELECT * FROM Occupancies