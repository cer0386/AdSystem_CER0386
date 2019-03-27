CREATE TABLE Image 
    (
     imageID INTEGER NOT NULL , 
     image IMAGE NOT NULL , 
     description VARCHAR (30) 
    )
    ON "default"
GO
ALTER TABLE Image ADD CONSTRAINT Image_PK PRIMARY KEY CLUSTERED (imageID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
     ON "default"