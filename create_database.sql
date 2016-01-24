
CREATE TABLE Clients (
    ID INT NOT NULL AUTO_INCREMENT,
    Email VARCHAR(255) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    JoinDate DATETIME NOT NULL,
    Nip VARCHAR(255),
    PRIMARY KEY (ID)
);
CREATE TABLE Orders (
    ID INT NOT NULL AUTO_INCREMENT,
    PackageID INT NOT NULL REFERENCES Packages (ID),
    ClientID INT NOT NULL REFERENCES Clients (ID),
    Price DECIMAL(5 , 2 ) NOT NULL,
    Status INT REFERENCES OrderStatus(Name),
    OrderDate DATETIME,
    PRIMARY KEY (ID)
);
CREATE TABLE Products (
    ID INT NOT NULL AUTO_INCREMENT,
    Price DECIMAL(5 , 2 ) NOT NULL,
    Name VARCHAR(255) NOT NULL UNIQUE,
    InOffer BIT NOT NULL,
    PRIMARY KEY (ID)
);
CREATE TABLE Employees (
    ID INT NOT NULL AUTO_INCREMENT,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    JoinDate DATETIME NOT NULL,
    Indeks VARCHAR(255) NOT NULL,
    Position INT references positions(Name),
    Status INT null REFERENCES ManagerStatus(Name),
    PRIMARY KEY (ID)
);
CREATE TABLE Packages (
    ID INT NOT NULL AUTO_INCREMENT,
    Price DECIMAL(5 , 2 ) NOT NULL,
    Adres VARCHAR(255) NOT NULL,
    AssemblyDate DATETIME NOT NULL,
    PRIMARY KEY (ID)
);
CREATE TABLE Invoices (
    ID INT NOT NULL AUTO_INCREMENT,
    ClientID INT NOT NULL REFERENCES Clients (ID),
    OrderID INT NOT NULL REFERENCES Orders (ID),
    Date DATETIME NOT NULL,
    PRIMARY KEY (ID)
);
CREATE TABLE Order_Product (
    OrderID INT NOT NULL REFERENCES Orders (ID),
    ProductID INT NOT NULL REFERENCES Products (ID),
    PRIMARY KEY (OrderID , ProductID)
);
CREATE TABLE Contains (
    ID INT NOT NULL AUTO_INCREMENT,
    Quantity DECIMAL(5 , 2 ) NOT NULL,
    Price DECIMAL(5 , 2 ) NOT NULL,
    ProductID INT NOT NULL REFERENCES Products (ID),
    OrderID INT NOT NULL REFERENCES Orders (ID),
    PRIMARY KEY (ID)
);
CREATE TABLE RecipeDrug (
    ID INT NOT NULL,
    EvaluatedByID INT NOT NULL REFERENCES Employees (ID),
    MadeByID INT NOT NULL REFERENCES Employees (ID),
    CreationDate DATETIME NOT NULL,
    EvaluationDate DATETIME NOT NULL,
    PRIMARY KEY (ID)
);
CREATE TABLE Managers (
    ID INT NOT NULL,
    status VARCHAR(255) REFERENCES ManagerStatus (Name),
    PRIMARY KEY (ID)
);
CREATE INDEX Client_ID 
  ON Clients(ID);
CREATE INDEX Order_ID 
  ON Orders(ID);
CREATE INDEX Product_ID 
  ON Products(ID);
CREATE INDEX Employee_ID 
  ON Employees(ID);
CREATE INDEX Package_ID 
  ON Packages(ID);
CREATE INDEX Invoice_ID 
  ON Invoices(ID);
CREATE INDEX Contains_ID 
  ON Contains(ID);
CREATE INDEX RecipeDrug_ID 
  ON RecipeDrug(ID);
CREATE INDEX Manager_ID 
  ON Managers(ID);
  
CREATE TABLE ManagerStatus (
    Name VARCHAR(30) UNIQUE
);
  Insert into managerstatus values ('regular');
  
CREATE TABLE PackageStatus (
    Name VARCHAR(30) UNIQUE
);
  Insert into managerstatus values ('empty');
  Insert into managerstatus values ('readyToShip');
  Insert into managerstatus values ('shipped');
  
CREATE TABLE OrderStatus (
    Name VARCHAR(30) UNIQUE
);
  Insert into managerstatus values ('notPaid');
  Insert into managerstatus values ('canceled');
  Insert into managerstatus values ('paid');
  Insert into managerstatus values ('onDelivery');
  Insert into managerstatus values ('finished');
  Insert into managerstatus values ('packageReady');
  
CREATE TABLE Positions (
    Name VARCHAR(30) UNIQUE
);
  Insert into managerstatus values ('manager');
  Insert into managerstatus values ('seller');
  Insert into managerstatus values ('storeman');
  Insert into managerstatus values ('pharmacist');
  
CREATE TABLE Addresses (
    City VARCHAR(100),
    Street VARCHAR(100),
    ZipCode VARCHAR(10),
    HouseNumber VARCHAR(10),
    ApartmentNumber VARCHAR(10)
);
  
