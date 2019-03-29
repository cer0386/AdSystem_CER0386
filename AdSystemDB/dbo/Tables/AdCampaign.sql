CREATE TABLE AdCampaign 
    (
     campaignID INTEGER NOT NULL , 
     type VARCHAR (50) NOT NULL , 
     status smallint NOT NULL , 
     budget DECIMAL (2) NOT NULL , 
     cpm DECIMAL (2) NOT NULL , 
     start DATETIME NOT NULL , 
     "end" DATETIME , 
     companyID INTEGER NOT NULL 
    )
    ON "default"
GO
ALTER TABLE AdCampaign 
    ADD CONSTRAINT AdCampaign_Company_FK FOREIGN KEY 
    ( 
     companyID
    ) 
    REFERENCES Company 
    ( 
     companyID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION
GO
ALTER TABLE AdCampaign ADD CONSTRAINT AdCampaign_PK PRIMARY KEY CLUSTERED (campaignID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default"