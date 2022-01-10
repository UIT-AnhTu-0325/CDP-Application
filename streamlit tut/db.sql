CREATE DATABASE TEST;
USE TEST;

DROP TABLE Persons;

CREATE TABLE Persons (
    PersonID int NOT NULL PRIMARY KEY,
    LastName varchar(255),
    FirstName varchar(255),
	Gender varchar(10),
	ContactNumber varchar(22),
    EmailAddress varchar(255),
    City varchar(255)
);

INSERT INTO Persons (PersonID, LastName, FirstName, Gender, ContactNumber, EmailAddress, City)
VALUES ('1', 'Nguyen', 'A', 'Nam','123456789','anguyen@gmail.com', 'Ho Chi Minh');
INSERT INTO Persons (PersonID, LastName, FirstName, Gender, ContactNumber, EmailAddress, City)
VALUES ('2', 'Nguyen', 'B', 'Nam','123456789','bnguyen@gmail.com', 'Dong Thap');
INSERT INTO Persons (PersonID, LastName, FirstName, Gender, ContactNumber, EmailAddress, City)
VALUES ('3', 'Tran', 'C', 'Nam','123456789','ctran@gmail.com', 'Nghe An');
INSERT INTO Persons (PersonID, LastName, FirstName, Gender, ContactNumber, EmailAddress, City)
VALUES ('4', 'Nguyen', 'D', 'Nu','123456789','dnguyen@gmail.com', 'Ha Noi');


CREATE TABLE Events (
    EventID int,
    Event varchar(255),
    CreateAt varchar(255),
	Gender varchar(10),
	ContactNumber varchar(22),
    EmailAddress varchar(255),
    City varchar(255)
);



select * from Persons;