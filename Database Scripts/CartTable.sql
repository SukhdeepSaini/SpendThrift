/****** Script for SelectTopNRows command from SSMS  ******/
Create Table Cart
(ID int identity(1,1) primary key,
CustUserName varchar(40) foreign key references Customer(USERNAME)
on delete set null,
ProductID int foreign key references Product(product_ID)
on delete set null,
ProductCount int not null,
DateCreated datetime default getdate()
);
go

select * from cart;
go

select * from Feedback;
go

delete from cart;
go

select * from address_book;
go

Create table Orders
(ID int identity(1,1) primary key,
 CustUsername varchar(40) foreign key references Customer(USERNAME) on delete set null,
 CustomerName varchar(40) not null,
 Street_Address varchar(40) not null,
 Apartment int not null,
 State varchar(32) not null,
 Country varchar(32) not null,
 ZipCode varchar(32) not null,
 OrderStatus varchar(10)
);
go

Create table OrderProducts
(OrderProductsID int identity(1,1) primary key,
OrdersID int foreign key references Orders(ID),
ProductsID int foreign key references Product(Product_ID) on delete set null,
ProductName varchar(50) not null,
ProductPrice int not null,
ProductQuantity int not null
);
go
go
