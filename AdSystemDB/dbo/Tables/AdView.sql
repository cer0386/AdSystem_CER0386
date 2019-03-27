CREATE TABLE AdView 
    (
     AdID INTEGER NOT NULL , 
     visitorID INTEGER NOT NULL , 
     viewed DATETIME NOT NULL 
    )
    ON "default"
GO
ALTER TABLE AdView 
    ADD CONSTRAINT View_Ad_FK FOREIGN KEY 
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
ALTER TABLE AdView 
    ADD CONSTRAINT View_Visitor_FK FOREIGN KEY 
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
ALTER TABLE AdView ADD CONSTRAINT View_PK PRIMARY KEY CLUSTERED (AdID, visitorID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default"