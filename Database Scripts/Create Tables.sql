USE SPENDTHRIFTDATABASE;
GO

--CREATING CUSTOMER TABLE

--CREATE TABLE CUSTOMER
--(USERNAME VARCHAR(40) PRIMARY KEY,
--FIRSTNAME VARCHAR(50) NOT NULL,
--LASTNAME VARCHAR(50),
--DOB DATETIME NOT NULL,
--EMAIL VARCHAR(40) NOT NULL,
--PHONE_NUMBER INTEGER NOT NULL,
--PASSWORD VARCHAR(40)
--);
--GO

---- CREATE TABLE ADDRESS BOOK
--CREATE TABLE ADDRESS_BOOK
--(CUSTOMER VARCHAR(40) FOREIGN KEY REFERENCES CUSTOMER(USERNAME),
-- ADDRESS_BOOK_ID INTEGER IDENTITY(1,1),
-- STREET_ADDRESS VARCHAR(40) NOT NULL,
-- APARTMENT INTEGER NOT NULL,
-- STATE VARCHAR(32) NOT NULL,
-- COUNTRY VARCHAR(32) NOT NULL,
-- ZIPCODE VARCHAR(20) NOT NULL,
-- CONSTRAINT PK PRIMARY KEY(CUSTOMER,ADDRESS_BOOK_ID)
--);
--GO

-- Category Table
Create Table Category
(
	CategoryName varchar(50) primary key
);
go

--Products Table
CREATE TABLE Product
(Product_ID int identity(1,1) primary key,
 Name varchar(50) not null,
 Quantity int not null,
 Price int not null,
 Status int check(Status in (0,1)),
 Description varchar(max),
 ImageUrl varchar(max),
);
go


--Category Table
Create Table Product_And_Category
(
	ProductID int foreign key references Product(Product_ID),
	ProductCategory varchar(50) foreign key references Category(CategoryName),
	Constraint productPK primary key(ProductID,ProductCategory)

);
go


--Reviews Table
Create Table Review
(ID int identity(1,1) primary key,
 ProductID int foreign key references Product(Product_ID),
 CustUserName varchar(40) foreign key references Customer(USERNAME),
 Rating int not null,
 DateAdded datetime default(getdate()),
 Description varchar(max)
);
go


--INSERT STATEMENTS

--CATEGORY
INSERT INTO Category VALUES('Electronics');
INSERT INTO Category VALUES('Proteins');
INSERT INTO Category VALUES('Watches');
go

--PRODUCT
--Electronics
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Electronic1',10,50,1,'This is an Electronic Item','Content/Images/Electronics/electronic1.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Electronic2',20,60,1,'This is an Electronic Item','Content/Images/Electronics/electronic2.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Electronic3',30,70,1,'This is an Electronic Item','Content/Images/Electronics/electronic3.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Electronic4',20,20,1,'This is an Electronic Item','Content/Images/Electronics/electronic4.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Electronic5',5,40,1,'This is an Electronic Item','Content/Images/Electronics/electronic5.jpeg');
go

--Proteins
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Protein1',10,50,1,'This is an Protein Item','Content/Images/Proteins/protein1.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Protein2',20,60,1,'This is an Protein Item','Content/Images/Proteins/protein2.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Protein3',30,70,1,'This is an Protein Item','Content/Images/Proteins/protein3.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Protein4',20,20,1,'This is an Protein Item','Content/Images/Proteins/protein4.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Protein5',5,40,1,'This is an Protein Item','Content/Images/Proteins/protein5.jpeg');
go

--Watches
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Watch1',10,50,1,'This is an Watch','Content/Images/watches/watch1.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Watch2',20,60,1,'This is an Watch','Content/Images/watches/watch2.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Watch3',30,70,1,'This is an Watch','Content/Images/watches/watch3.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Watch4',20,20,1,'This is an Watch','Content/Images/watches/watch4.jpeg');
INSERT INTO PRODUCT(Name,Quantity,Price,Status,Description,ImageUrl) VALUES
('Watch5',5,40,1,'This is an Watch','Content/Images/watches/watch5.jpeg');
go

--PRODUCT AND CATEGORIES
--Electronics
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(1,'Electronics');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(2,'Electronics');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(3,'Electronics');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(4,'Electronics');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(5,'Electronics');
go


--Proteins
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(6,'Proteins');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(7,'Proteins');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(8,'Proteins');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(9,'Proteins');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(10,'Proteins');
go

--Watches
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(1002,'Watches');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(1003,'Watches');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(1004,'Watches');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(1005,'Watches');
INSERT INTO Product_And_Category(ProductID,ProductCategory) VALUES
(1006,'Watches');
go

-- Test Queries
SELECT * FROM CUSTOMER;
SELECT * FROM ADDRESS_BOOK;
SELECT * FROM Category
SELECT * FROM Product
SELECT * FROM Product_And_Category
GO

DELETE FROM CUSTOMER;
DELETE FROM ADDRESS_BOOK;
GO