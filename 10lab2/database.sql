create database TUTOR;
go
use TUTOR;
go
create table USER_ROLE(
  RoleId int primary key identity(1,1),
  RoleName varchar(20) not null,
)
go 
create table USERS(
 UserId int primary key identity(1,1),
 UserEmail varchar(50) not null,
 UserPassword varchar(20) not null,
 RoleId int constraint FK_USER_ROLE foreign key references USER_ROLE(RoleId),
 UserName varchar(50) not null,
 UserSurname varchar(50) not null,
 UserDescription varchar(200) not null,
 UserAge int not null,
 UserImage varchar(100) not null,
)