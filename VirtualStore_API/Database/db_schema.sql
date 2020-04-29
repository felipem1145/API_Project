CREATE DATABASE db_VirtualStore
GO

CREATE TABLE Customer(

CustomerID INT IDENTITY(1,1) PRIMARY KEY,
Username VARCHAR(100),
CustomerPass VARCHAR(100),
Email VARCHAR(100),
Fullname VARCHAR(100),
CustomerAddress VARCHAR(100),
Phone VARCHAR(100),
Gender VARCHAR(8),
BirthDate VARCHAR(12)
);
GO



CREATE TABLE Product(

ProductID INT IDENTITY(1,1) PRIMARY KEY,
ProductName VARCHAR(100),
ProductType VARCHAR(100),
ProductDescription VARCHAR(200),
Stock INT,
Price INT,

);
GO




CREATE TABLE Transactions(

TransactionID INT IDENTITY(1,1) PRIMARY KEY,
CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID),
ProductID INT FOREIGN KEY REFERENCES Product(ProductID),
Quantity INT

);
GO

CREATE TABLE Comment(

CommentID INT IDENTITY(1,1) PRIMARY KEY,
CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID),
ProductID INT FOREIGN KEY REFERENCES Product(ProductID),
CommentMessage VARCHAR(200),
Rating INT,

);
GO

CREATE TABLE Cart(

CartID INT IDENTITY(1,1) PRIMARY KEY,
CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID),
ProductID INT FOREIGN KEY REFERENCES Product(ProductID),
Quantity INT,

);
GO

