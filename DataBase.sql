create database Trip
go
use Trip
--טבלת סוגי טיולים
create table TypeTrips(
--קוד סוג
TypeId int IDENTITY(1,1) not null primary key,
--שם סוג
TypeName nvarchar (50) not null
) 
--טבלת משתמשים
create table Users(
UserId int IDENTITY(1,1) not null primary key,
FirstName nvarchar (50) not null,
LastName nvarchar (50) not null,
Phone nvarchar (15) not null,
Email nvarchar (50) not null,
Password nvarchar (50) not null,
IsFirstAid bit not null
) 
--טבלת טיולים
create table Trips(
TripId int IDENTITY(1,1) not null primary key,
Yhad nvarchar (50) not null,
TripTypeId int not null FOREIGN KEY REFERENCES TypeTrips(TypeId),
TripDate Date not null,
TripTime int not null,
TripDuration int not null,
TripEmptyPlace int not null,
Price int not null,
Picture nvarchar (50) not null
)
--טבלת הזמנת מקומות
create table Invitation(
InvitationId int IDENTITY(1,1) not null primary key,
InvitationUserId int not null FOREIGN KEY REFERENCES Users(UserId),
InvitationDate Date not null,
InvitationTime int not null,
InvitationTripId int not null FOREIGN KEY REFERENCES Trips(TripId),
TripDuration int not null,
PlaceNumber int not null,
) 