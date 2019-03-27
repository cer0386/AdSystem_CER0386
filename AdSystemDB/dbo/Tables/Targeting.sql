CREATE TABLE Targeting 
    (
     targetingID INTEGER NOT NULL , 
     interest VARCHAR (50) , 
     kategory VARCHAR (50) , 
     product VARCHAR (30) 
    )
    ON "default"
GO
ALTER TABLE Targeting ADD CONSTRAINT Targeting_PK PRIMARY KEY CLUSTERED (targetingID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default"