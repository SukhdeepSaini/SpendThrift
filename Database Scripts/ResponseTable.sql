SELECT * FROM FEEDBACK;
GO

Create Table FeedbackResponse
(ID int identity(1,1) primary key,
 ResponseFor int not null foreign key references FeedBack(ID),
 Response varchar(max),
 RespondedOn datetime default getdate()
);
go
