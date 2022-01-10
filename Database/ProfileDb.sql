create database Profile
use Profile
Set DateFormat DMY

create table Profiles
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255) NOT NULL, 
	Address varchar(255) NOT NULL, 
	Email varchar(255) NOT NULL,
	PhoneNumber varchar(255) NOT NULL,
	Gender varchar(255) NOT NULL,
	--ImageUrl varchar(255) NOT NULL,
	Dob Datetime NOT NULL,
	CreatedAt Datetime NOT NULL,
	UpdatedAt Datetime NOT NULL,

	FirstActivity Datetime,
	LastActivity Datetime
)

Insert into Profiles(Name, Address, Email, PhoneNumber, Gender, Dob, CreatedAt, UpdatedAt, FirstActivity, LastActivity)
Values ('Anh Tu', 'Nghi Xuan - Ha Tinh', 'at@gmail.com','094445556','Male','2/12/2001','6/1/2022','6/1/2022','6/1/2022','6/1/2022')
Insert into Profiles (Name, Address, Email, PhoneNumber, Gender, Dob, CreatedAt, UpdatedAt, FirstActivity, LastActivity)
Values ('Jett', 'Ba Dinh - Ha Noi', 'jett@gmail.com','022333444','Female','3/1/2012','6/1/2022','6/1/2022','6/1/2022','6/1/2022'),
('Brimstone', 'Quan 1 - HCM', 'brim@gmail.com','038776557','Male','4/1/2012','6/1/2022','6/1/2022','6/1/2022','6/1/2022')

create table Events
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Type varchar(255),
	TimeOfEvent Datetime,
	ActionOfEvent varchar(255),
	IdProfile int,
	SourceOfEvent int,
)

Insert into Events(Type, TimeOfEvent, ActionOfEvent, IdProfile, SourceOfEvent)
Values ('PAGE', '6/1/2022', 'checkout/success', 1, 1),
('PAGE', '6/1/2022', 'checkout/success', 1, 1),
('TRACK', '6/1/2022', 'Payment info entered', 1, 1),
('TRACK', '6/1/2022', 'Checkout step completed', 1, 1),
('TRACK', '6/1/2022', 'Add to cart iphone 12', 1, 1),
('TRACK', '6/1/2022', 'Add to cart iphone 12', 1, 1),
('TRACK', '6/1/2022', 'Add to cart iphone 12', 1, 1),
('TRACK', '6/1/2022', 'Add to cart iphone 12', 1, 1),
('TRACK', '6/1/2022', 'Add to cart iphone 12', 1, 1),
('IDENTITY', '6/1/2022', 'e:da@gmail.com, p:1122', 1, 1)