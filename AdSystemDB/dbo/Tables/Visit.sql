CREATE TABLE Visit 
    (
     visitorID INTEGER NOT NULL , 
     url VARCHAR (895) NOT NULL , 
     visited DATETIME 
    )
    ON "default"
GO
ALTER TABLE Visit 
    ADD CONSTRAINT Visit_Visitor_FK FOREIGN KEY 
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
ALTER TABLE Visit 
    ADD CONSTRAINT Visit_WebPage_FK FOREIGN KEY 
    ( 
     url
    ) 
    REFERENCES WebPage 
    ( 
     URL 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION
GO
ALTER TABLE Visit ADD CONSTRAINT Visit_PK PRIMARY KEY CLUSTERED (visitorID, url)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default"