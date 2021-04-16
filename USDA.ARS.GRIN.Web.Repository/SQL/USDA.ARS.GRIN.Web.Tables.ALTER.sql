ALTER TABLE crop_germplasm_committee_document
ADD document_title NVARCHAR(250) 

UPDATE 
crop_germplasm_committee_document
SET 
document_title = title

ALTER TABLE crop_germplasm_committee_document
DROP COLUMN title 
