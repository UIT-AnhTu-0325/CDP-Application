Set DateFormat DMY
use Employee

create table Employees
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255) NOT NULL, 
	Address varchar(255) NOT NULL, 
	Email varchar(255) NOT NULL,
	PhoneNumber varchar(255) NOT NULL,
	Gender varchar(255) NOT NULL,
	--ImageUrl varchar(255) NOT NULL,
	Role varchar(255) NOT NULL,
	Dob Datetime NOT NULL,
	CreatedAt Datetime NOT NULL,
	UpdatedAt Datetime NOT NULL,
)

Insert into Employees (Name, Address, Email, PhoneNumber, Gender, Role, Dob, CreatedAt, UpdatedAt)
Values ('Anh Tu', 'Nghi Xuan - Ha Tinh', 'at@gmail.com','094445556','Male','Admin','2/12/2001','6/1/2022','6/1/2022')
Insert into Employees (Name, Address, Email, PhoneNumber, Gender, Role, Dob, CreatedAt, UpdatedAt)
Values ('Jett', 'Ba Dinh - Ha Noi', 'jett@gmail.com','022333444','Female','User','3/1/2012','6/1/2022','6/1/2022'),
('Brimstone', 'Quan 1 - HCM', 'brim@gmail.com','038776557','Male','User','4/1/2012','6/1/2022','6/1/2022')
	
create table Users
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	IdEmployee int,
	Username varchar(255),
	Password varchar(255)
	FOREIGN KEY (IdEmployee) REFERENCES Employees(Id)
)
Insert into Users (IdEmployee, Username, Password)
Values (1, 'admin', 1), (2,'user',1), (3,'user2',1)


Select *
From Employees

Select *
From Users