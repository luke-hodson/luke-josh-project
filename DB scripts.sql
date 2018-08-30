CREATE TABLE Users (
    Id int IDENTITY(1,1) PRIMARY KEY,
    FirstName varchar(255),
    LastName varchar(255),
    Email varchar(255),
	Password varchar(255)
);

CREATE TABLE Teams (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255),
    Logo varchar(max),    
	UserId int FOREIGN KEY REFERENCES Users(Id),	
);

CREATE TABLE TeamUsers (
    Id int IDENTITY(1,1) PRIMARY KEY,
	UserId int FOREIGN KEY REFERENCES Users(Id),
	TeamId int FOREIGN KEY REFERENCES Teams(Id)    
);

CREATE TABLE Activities (
    Id int IDENTITY(1,1) PRIMARY KEY,
	Title varchar(255),
	HasBeenUsed bit,
	TeamId int FOREIGN KEY REFERENCES Teams(Id)   
);

CREATE TABLE ResultOption (
    Id int IDENTITY(1,1) PRIMARY KEY,
	Options varchar(255)  
);

CREATE TABLE ActivityHistory (
    Id int IDENTITY(1,1) PRIMARY KEY,
	TeamId int FOREIGN KEY REFERENCES Teams(Id),
	ActivityId int FOREIGN KEY REFERENCES Activities(Id),
	ResultOptionId int FOREIGN KEY REFERENCES ResultOption(Id)   
);




