CREATE TABLE Visitor 
    (
     visitorID INTEGER NOT NULL , 
     name VARCHAR (50) , 
     location VARCHAR (50) 
    )
    ON "default"
GO
ALTER TABLE Visitor ADD CONSTRAINT Visitor_PK PRIMARY KEY CLUSTERED (visitorID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default"