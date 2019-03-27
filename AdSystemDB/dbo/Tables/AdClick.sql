CREATE TABLE AdClick 
    (
     AdID INTEGER NOT NULL , 
     visitorID INTEGER NOT NULL , 
     Clicked DATETIME NOT NULL 
    )
    ON "default"
GO
ALTER TABLE AdClick 
    ADD CONSTRAINT Click_Ad_FK FOREIGN KEY 
    ( 
     AdID
    ) 
    REFERENCES Ad 
    ( 
     AdID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION
GO
ALTER TABLE AdClick 
    ADD CONSTRAINT Click_Visitor_FK FOREIGN KEY 
    ( 
     visitorID
    ) 
    REFERENCES Visitor 
    ( 
     visitorID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION
GO
ALTER TABLE AdClick ADD CONSTRAINT Click_PK PRIMARY KEY CLUSTERED (AdID, visitorID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default"