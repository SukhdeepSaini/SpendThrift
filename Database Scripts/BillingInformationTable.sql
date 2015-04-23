Select * from ADDRESS_BOOK;
go

select * from CUSTOMER;
go

select * from Orders;
go

select * from OrderProducts;
go

select * from Review;
go

delete from cart;
go

select * from Product;
go


Create Table BillingInformation
(CustUserName varchar(40) primary key 
foreign key references Customer(Username) on delete cascade,
 NameOnCard varchar(50) not null,
 CardType varchar(20) not null,
 CardNumber varchar(32) not null,
 Cvv int not null,
 ZipCode int not null
);
go

select * from BillingInformation;
go
