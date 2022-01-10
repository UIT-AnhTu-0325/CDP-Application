create database Connection
use Connection
Set DateFormat DMY

create table Sources
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar (255),
	Link varchar(255),
	CreateAt datetime,
	UpdateAt datetime,
	IsActive varchar(10)
)

Insert into Sources (Name,Link, CreateAt, UpdateAt, IsActive)
Values ('Facebook','Facebook.com', '4/1/2012', '4/1/2012', 'YES'),
('MyCDPApp','MyCDPApp.org', '4/1/2012', '4/1/2012', 'YES'),
('Tiki','Tiki.com.vn', '4/1/2012', '4/1/2012', 'YES')

create table Destinations 
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar (255),
	Link varchar (255),
	CreateAt datetime,
	UpdateAt datetime,
	IsActive varchar(10)
)

Insert into Destinations(Name, Link, CreateAt, UpdateAt, IsActive)
Values ('FacebookAds','Facebook.com/Ads', '4/1/2012', '4/1/2012', 'YES'),
('TwitterAds','Twitter.com/Ads', '4/1/2012', '4/1/2012', 'YES'),
('GoogleAds','Google.com/Ads', '4/1/2012', '4/1/2012', 'YES')

