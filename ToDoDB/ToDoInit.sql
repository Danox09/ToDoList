--If it does not exist, the database is created
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ToDoDB')
BEGIN 
	CREATE DATABASE ToDoDB;
END 
GO
USE ToDoDB;
GO

--If it does not exist, the Person table is created
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'Person')
BEGIN 
	CREATE TABLE Person (
	Id INT IDENTITY(1,1) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE,
	CONSTRAINT PKPerson PRIMARY KEY(Id),
);
END
GO

--If it does not exist, the AssignmentStatus table is created
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'AssignmentStatus')
BEGIN
	CREATE TABLE AssignmentStatus(
	Id INT IDENTITY (1,1) NOT NULL,
	Status VARCHAR(20) NOT NULL,
	CONSTRAINT PKStatus PRIMARY KEY(Id) 
);	
END
GO

--If it does not exist, the Assignment table is created
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'Assignment')
BEGIN
	CREATE TABLE Assignment (
	Id INT IDENTITY (1,1) NOT NULL,
	AssignmentName VARCHAR(50) NOT NULL,
	AssignmentDescription VARCHAR (300) NOT NULL,
	AssignmentDate DATETIME2 NOT NULL,
	StatusId INT NOT NULL,
	PersonId INT NOT NULL,
	CONSTRAINT PKAssignments PRIMARY KEY(Id),
	CONSTRAINT FKPersonAssignmentPersonId FOREIGN KEY (PersonId) REFERENCES Person(Id),
	CONSTRAINT FKAssignmentStatusAssignmentStatusId FOREIGN KEY (StatusId) REFERENCES AssignmentStatus(Id)	
);
END
GO

--If they do not exist, the status data is added to the AssignmentStatus table
IF NOT EXISTS (SELECT * FROM AssignmentStatus WHERE Status = 'Active')
BEGIN
	INSERT INTO AssignmentStatus(Status) VALUES ('Active')
END 

IF NOT EXISTS (SELECT * FROM AssignmentStatus WHERE Status = 'Completed')
BEGIN
	INSERT INTO AssignmentStatus(Status) VALUES ('Completed')
END

IF NOT EXISTS (SELECT * FROM AssignmentStatus WHERE Status = 'Warning')
BEGIN
	INSERT INTO AssignmentStatus(Status) VALUES ('Warning')
END 
GO