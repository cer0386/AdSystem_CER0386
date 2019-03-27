CREATE TABLE AdGroup 
    (
     AdGroupID INTEGER NOT NULL , 
     adGroupName VARCHAR (50) NOT NULL , 
     adGroupStatus BIT NOT NULL , 
     adGroupBudget DECIMAL (2) , 
     maxCPM DECIMAL (2) , 
     requiredViews INTEGER NOT NULL , 
     campaignID INTEGER NOT NULL , 
     targetingID INTEGER 
    )
    ON "default"
GO
ALTER TABLE AdGroup 
    ADD CONSTRAINT AdGroup_AdCampaign_FK FOREIGN KEY 
    ( 
     campaignID
    ) 
    REFERENCES AdCampaign 
    ( 
     campaignID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION
GO
ALTER TABLE AdGroup 
    ADD CONSTRAINT AdGroup_Targeting_FK FOREIGN KEY 
    ( 
     targetingID
    ) 
    REFERENCES Targeting 
    ( 
     targetingID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION
GO
ALTER TABLE AdGroup ADD CONSTRAINT AdGroup_PK PRIMARY KEY CLUSTERED (AdGroupID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default"