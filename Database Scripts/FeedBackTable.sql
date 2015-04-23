Create Table Feedback
(ID int identity(1,1) primary key,
 Subject varchar(100) not null,
 Name varchar(40) not null,
 ContactNumber int not null,
 email varchar(40) not null,
 Message varchar(max) not null,
);
go

Select * from feedback;
go