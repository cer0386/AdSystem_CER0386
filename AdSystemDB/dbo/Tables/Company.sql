CREATE TABLE Company 
    (
     companyID INTEGER NOT NULL , 
     companyName VARCHAR (100) NOT NULL , 
     VIP BIT NOT NULL 
    )
    ON "default"
GO
ALTER TABLE Company ADD CONSTRAINT Company_PK PRIMARY KEY CLUSTERED (companyID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default"