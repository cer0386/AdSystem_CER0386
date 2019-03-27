CREATE TABLE WebPage 
    (
     URL VARCHAR (895) NOT NULL , 
     category VARCHAR (50) NOT NULL , 
     product VARCHAR (100) 
    )
    ON "default"
GO
ALTER TABLE WebPage ADD CONSTRAINT WebPage_PK PRIMARY KEY CLUSTERED (URL)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default"