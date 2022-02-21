use master;
go

-- create db if not exists
if db_id('dotnetcd') is null
  create database dotnetcd;
go

-- switch to db
use dotnetcd;

-- create tables

if not exists (select * from sysobjects where name='Users' and xtype='U')
  create table Users (
    Id bigint primary key identity,
    Handle varchar(30) not null unique,
    Name varchar(100) not null,
    Avatar varchar(300) not null
  )
go

-- populate sample data

if not exists (select 1 from Users where Handle='john')
    insert into Users (Handle, Name, Avatar) values
        ('john', 'John Doe', 'https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp&f=y')
go

if not exists (select 1 from Users where Handle='jane')
    insert into Users (Handle, Name, Avatar) values
        ('jane', 'Jane Smith', 'https://www.gravatar.com/avatar/00000000000000000000000000000000?d=wavatar&f=y')
go

if not exists (select 1 from Users where Handle='zachary')
    insert into Users (Handle, Name, Avatar) values
        ('zachary', 'Zachary Thomas', 'https://www.gravatar.com/avatar/00000000000000000000000000000000?d=robohash&f=y')
go

if not exists (select 1 from Users where Handle='paul')
    insert into Users (Handle, Name, Avatar) values
        ('paul', 'Paul Clayton', 'https://www.gravatar.com/avatar/00000000000000000000000000000000?d=identicon&f=y')
go
