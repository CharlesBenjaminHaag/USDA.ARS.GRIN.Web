USE [gringlobal]
GO
/****** Object:  StoredProcedure [dbo].[usp_CodeValuesByGroupName_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_CodeValuesByGroupName_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CodeValues_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_CodeValues_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CodesByGroup_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_CodesByGroup_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CodeDetail_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_CodeDetail_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentlyExpired_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPRecentlyExpired_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentlyAvailable_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPRecentlyAvailable_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentApplications_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPRecentApplications_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPExpiring6Months_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPExpiring6Months_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPApplicationStatuses_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPApplicationStatuses_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPApplications_Search]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPApplications_Search]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPApplicationAvailableAccession_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPApplicationAvailableAccession_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPApplication_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPApplication_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommittees_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommittees_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocumentsRecent_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocumentsRecent_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_SelectAll]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Update]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Insert]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Delete]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeCropDescriptors_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeCropDescriptors_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeApplicationStatuses_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeApplicationStatuses_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommittee_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommittee_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommittee_Select]    Script Date: 4/16/2021 12:20:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_CropGermplasmCommittee_Select] 
	@crop_germplasm_committee_id INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		[crop_germplasm_committee_id], 
		[crop_germplasm_committee_name],
		[roster_url],
		[created_date],
		[created_by],
		[modified_date],
		[modified_by]
	FROM
		crop_germplasm_committee CGC
	WHERE
		CGC.crop_germplasm_committee_id = @crop_germplasm_committee_id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeApplicationStatuses_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_CropGermplasmCommitteeApplicationStatuses_Select] 
AS
BEGIN
	SELECT 
		status_id,
		description
	FROM 
		pvp_status
	ORDER BY
		description ASC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeCropDescriptors_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_CropGermplasmCommitteeCropDescriptors_Select] 
	@crop_germplasm_committee_id INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		CD.crop_germplasm_committee_id,
		C.crop_id,
		C.name
	FROM
		dbo.crop_germplasm_committee_crop_descriptor CD
	JOIN
		dbo.crop C
	ON
		CD.crop_id = C.crop_id
	WHERE
		crop_germplasm_committee_id = @crop_germplasm_committee_id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Delete]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Delete]
	@out_error_number INT = 0 OUTPUT,
	@crop_germplasm_committee_document_id INT
AS
BEGIN
	BEGIN TRY
		DELETE FROM
			crop_germplasm_committee_document
		WHERE
			@crop_germplasm_committee_document_id = @crop_germplasm_committee_document_id
	END TRY
	BEGIN CATCH
		SELECT @out_error_number=ERROR_NUMBER()
	END CATCH	
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Insert]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Insert]
	@out_error_number INT = 0 OUTPUT,
	@out_crop_germplasm_committee_document_id INT = 0 OUTPUT,
	@crop_germplasm_committee_id INT,
	@title NVARCHAR(250),
	@document_year INT,
	@category_code NVARCHAR(4),
	@url NVARCHAR(120)
AS
BEGIN
	BEGIN TRY
		INSERT INTO
			crop_germplasm_committee_document
			(crop_germplasm_committee_id,
			 document_title,
			 category_code,
			 document_year,
			 url,
			 created_by,
			 created_date)
		VALUES
			(
			@crop_germplasm_committee_id,
			@title,
			@category_code,
			@document_year,
			@url,
			48,
			GETDATE()
			)
			SELECT @out_crop_germplasm_committee_document_id = CAST(SCOPE_IDENTITY() AS INT)
	END TRY
	BEGIN CATCH
		SELECT @out_error_number=ERROR_NUMBER()
	END CATCH	
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Select]
	@crop_germplasm_committee_document_id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		cgc.crop_germplasm_committee_name,
		crop_germplasm_committee_document_id,
		cgcd.crop_germplasm_committee_id,
		cgcd.document_title,
		cgcd.category_code,
		cgcd.document_year,
		vlcv.title,
		url,
		cgcd.created_date,
		cgcd.created_by,
		cgcd.modified_date,
		cgcd.modified_by
	FROM 
		crop_germplasm_committee_document cgcd
	JOIN
		vw_lookup_code_value vlcv
	ON
		cgcd.category_code = vlcv.value
	LEFT OUTER JOIN
		crop_germplasm_committee cgc
	ON
		cgcd.crop_germplasm_committee_id = cgc.crop_germplasm_committee_id
	WHERE
		crop_germplasm_committee_document_id = @crop_germplasm_committee_document_id
	ORDER BY
		title DESC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Update]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Update]
	@out_error_number INT = 0 OUTPUT,
	@crop_germplasm_committee_document_id INT,
	@crop_germplasm_committee_id INT,
	@title NVARCHAR(250),
	@document_year INT,
	@category_code NVARCHAR(4),
	@url NVARCHAR(120)
AS
BEGIN
	BEGIN TRY
		UPDATE
			crop_germplasm_committee_document
		SET
			crop_germplasm_committee_id = @crop_germplasm_committee_id, 
			document_title = @title,
			document_year = @document_year,
			category_code = @category_code,
			url = @url,
			modified_by = 48,
			modified_date = GETDATE()
		WHERE
			crop_germplasm_committee_document_id = @crop_germplasm_committee_document_id
	END TRY
	BEGIN CATCH
		SELECT @out_error_number=ERROR_NUMBER()
	END CATCH	
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_Select]
	@crop_germplasm_committee_id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		cgc.crop_germplasm_committee_name,
		crop_germplasm_committee_document_id,
		cgcd.crop_germplasm_committee_id,
		document_title,
		category_code,
		document_year,
		(SELECT title FROM vw_cgc_lookup_document_categories WHERE value = cgcd.category_code) AS category,
		url,
		cgcd.created_date,
		cgcd.created_by,
		cgcd.modified_date,
		cgcd.modified_by
	FROM 
		crop_germplasm_committee_document cgcd
	JOIN
		crop_germplasm_committee cgc
	ON
		cgcd.crop_germplasm_committee_id = cgc.crop_germplasm_committee_id
	WHERE
		cgcd.crop_germplasm_committee_id = @crop_germplasm_committee_id
	ORDER BY
		created_date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_SelectAll]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_SelectAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		cgc.crop_germplasm_committee_name,
		crop_germplasm_committee_document_id,
		cgcd.crop_germplasm_committee_id,
		document_title,
		category_code,
		document_year,
		(SELECT title FROM vw_cgc_lookup_document_categories WHERE value = cgcd.category_code) AS category,
		url,
		cgcd.created_date,
		cgcd.created_by,
		cgcd.modified_date,
		cgcd.modified_by
	FROM 
		crop_germplasm_committee_document cgcd
	JOIN
		crop_germplasm_committee cgc
	ON
		cgcd.crop_germplasm_committee_id = cgc.crop_germplasm_committee_id
	ORDER BY
		created_date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocumentsRecent_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[usp_ARS_CropGermplasmCommitteeDocumentsRecent_Select]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		cgc.crop_germplasm_committee_name,
		crop_germplasm_committee_document_id,
		cgcd.crop_germplasm_committee_id,
		document_title,
		category_code,
		document_year,
		(SELECT title FROM vw_cgc_lookup_document_categories WHERE value = cgcd.category_code) AS category,
		url,
		cgcd.created_date,
		cgcd.created_by,
		cgcd.modified_date,
		cgcd.modified_by
	FROM 
		crop_germplasm_committee_document cgcd
	JOIN
		crop_germplasm_committee cgc
	ON
		cgcd.crop_germplasm_committee_id = cgc.crop_germplasm_committee_id
	WHERE
		cgcd.modified_date >= DATEADD(day,-120, GETDATE())
	ORDER BY
		created_date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommittees_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_CropGermplasmCommittees_Select] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		 [crop_germplasm_committee_id]
		,[crop_germplasm_committee_name]
		,[roster_url]
		,[created_date]
		,[created_by]
		,[modified_date]
		,[modified_by]
  FROM 
	crop_germplasm_committee
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPApplication_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_PVPApplication_Select]
	@crop_description NVARCHAR(60)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		[pvpo_catalog_id] ,
		[PVNUMBER] ,
		[VARIETY],
		[EXPERMENTALNAMESYNONYMS] ,
		T.description AS TAXON,
		crop_id ,
		pc.pvp_crop_desc AS CROP,
		pa.name AS APPLICANTOWNER,
		[APPLICATIONDATE] ,
		[CERTIFIEDSEED],
		ps.status_id,
		ps.description AS STATUS,
		[STATUSDATE] ,
		[DATEISSUED],
		[YEARSPROTECTED] ,
		[PAGES],
		[REFILEDUNDER1994PVPA] ,
		[AMENDMENTS] 
	FROM 
		pvpo_catalog pt
	JOIN
		pvp_crop pc
	ON
		pt.crop_id  = pc.pvp_crop_id
	JOIN
		pvp_applicant pa
	ON
		pt.applicant_id = pa.applicant_id
	JOIN 
		pvp_status ps
	ON
		pt.status_id = ps.status_id
	JOIN
		pvp_taxonomy T
	ON
		pt.taxonomy_id = T.taxonomy_id
	WHERE
		pc.pvp_crop_desc = @crop_description
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPApplicationAvailableAccession_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_PVPApplicationAvailableAccession_Select] 
AS
BEGIN
	SET NOCOUNT ON;
SELECT 
	[pvpo_catalog_id] ,
	[PVNUMBER] ,
	[EXPERMENTALNAMESYNONYMS] ,
	[TAXON] ,
	crop_id ,
	applicant_id ,
	[APPLICATIONDATE] ,
	[CERTIFIEDSEED] ,
	status_id,
	[STATUSDATE] ,
	[DATEISSUED],
	[YEARSPROTECTED] ,
	[PAGES],
	[REFILEDUNDER1994PVPA] ,
	[AMENDMENTS], 
	ISNULL(VARIETY, EXPERMENTALNAMESYNONYMS) AS VARIETY,
	accession_id
FROM 
	pvpo_catalog c
JOIN	
	accession_ipr i
ON
	CAST(SUBSTRING(ipr_number,5,20) AS INT) = c.pvnumber
WHERE  
	i.type_code = 'PVP'  
and 
	ipr_number not like '%MP'
and 
	ipr_number not like '%FP'
and 
	ipr_number not like '%P1'
and 
	ipr_number not like '%P2'
and 
	ipr_number not like '%P3'
and 
	dbo.get_avstat(accession_id) = 'Y'
--and 
	--c.crop = '$crop'   
ORDER BY 
	cast(statusdate as date) desc 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPApplications_Search]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_PVPApplications_Search] 
	@sql_where_clause NVARCHAR(MAX) = ''
AS
BEGIN
	SET NOCOUNT ON;
	--SET FMTONLY OFF;
	DECLARE @sqlStatement NVARCHAR(2000)
	SET @sqlStatement = 'SELECT 
	 pa.pvp_application_number
     ,cultivar_name
     ,experimental_name
     ,pa.pvp_common_name_id
	 ,pa.scientific_name
	 ,pc.name AS common_name
     ,pa.pvp_applicant_id
	 ,papp.name
     ,application_date
     ,is_certified_seed
     ,pas.pvp_application_status_id
	 ,pas.description AS application_status
     ,status_date
     ,certificate_issued_date
     ,years_protected
	 ,convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) AS expiration_date
	 ,CASE
		WHEN (convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)  > GETDATE())
		THEN DATEDIFF(month,GETDATE(),convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) 
	 END AS months_remaining
	 ,paam.accession_id
	FROM 
		pvp_application pa
	JOIN
		pvp_common_name pc
	ON
		pa.pvp_common_name_id = pc.pvp_common_name_id
	JOIN
		pvp_application_status pas
	ON
		pa.pvp_application_status_id = pas.pvp_application_status_id
	JOIN
		pvp_applicant papp
	ON
		pa.pvp_applicant_id = papp.pvp_applicant_id
	LEFT JOIN
		pvp_application_accession_map paam
	ON
		pa.pvp_application_number = paam.pvp_application_number'

	IF (LEN(LTRIM(RTRIM(@sql_where_clause))) > 0)
	BEGIN
		SET @sqlStatement = @sqlStatement + ' ' + @sql_where_clause
	END
	
	DECLARE @Results TABLE
	(pvp_application_number INT,
	 cultivar_name NVARCHAR(150),
     experimental_name NVARCHAR(150),
     pvp_crop_id INT,
	 scientific_name NVARCHAR(150),
	 common_name NVARCHAR(150),
     pvp_applicant_id INT,
	 applicant_name NVARCHAR(150),
     application_date DATETIME2(7),
     is_certified_seed BIT,
     pvp_application_status_id INT,
	 application_status NVARCHAR(120),
     status_date DATETIME2(7),
     certificate_issued_date DATETIME2(7),
     years_protected INT,
	 expiration_date DATETIME2(7),
	 months_remaining INT,
	 accession_id INT)

	INSERT INTO @Results
	EXECUTE sp_executesql @sqlStatement

	SELECT 
		pvp_application_number,
		cultivar_name,
		experimental_name,
		pvp_crop_id,
		scientific_name,
		common_name,
		pvp_applicant_id,
		applicant_name,
		application_date,
		is_certified_seed,
		pvp_application_status_id,
		application_status,
		status_date,
		certificate_issued_date,
		years_protected,
		expiration_date,
		months_remaining,
		accession_id
	FROM @Results
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPApplicationStatuses_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_PVPApplicationStatuses_Select]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		pvp_application_status_id AS id,
		description AS title,
		(SELECT COUNT(*) FROM pvp_application WHERE pvp_application_status_id = s.pvp_application_status_id) AS count
	FROM
		pvp_application_status s
	ORDER BY title
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPExpiring6Months_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_PVPExpiring6Months_Select]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	 pa.pvp_application_number
     ,[cultivar_name]
     ,[experimental_name]
     ,pa.pvp_common_name_id
	 ,pc.name AS common_name
     ,pa.scientific_name
     ,pa.pvp_applicant_id
	 ,papp.name AS applicant_name
     ,[application_date]
     ,[is_certified_seed]
     ,pas.pvp_application_status_id
	 ,pas.description AS application_status
     ,[status_date]
     ,[certificate_issued_date]
     ,[years_protected]
	 ,vpam.accession_id
	 ,convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) AS expiration_date
	FROM 
		[gringlobal].[dbo].[pvp_application] pa
	JOIN
		pvp_common_name pc
	ON
		pa.pvp_common_name_id = pc.pvp_common_name_id
	JOIN
		pvp_application_status pas
	ON
		pa.pvp_application_status_id = pas.pvp_application_status_id
	JOIN
		pvp_applicant papp
	ON
		pa.pvp_applicant_id = papp.pvp_applicant_id
	LEFT JOIN
		vw_pvp_application_accession_map vpam
	ON
		pa.pvp_application_number = vpam.pvp_application_number
	WHERE 
		convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) < (DATEADD(month,6,GETDATE()))
	AND
		convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) > GETDATE()
	AND
		pas.pvp_application_status_id = 18
	ORDER BY
		convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) ASC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentApplications_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_PVPRecentApplications_Select]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	 pa.pvp_application_number
     ,[cultivar_name]
     ,[experimental_name]
     ,pa.pvp_common_name_id
	 ,pc.name AS common_name
     ,pa.scientific_name
     ,pa.pvp_applicant_id
	 ,papp.name AS applicant_name
     ,[application_date]
     ,[is_certified_seed]
     ,pas.pvp_application_status_id
	 ,pas.description AS application_status
     ,[status_date]
     ,[certificate_issued_date]
     ,[years_protected]
	 ,vpam.accession_id
	 ,convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) AS expiration_date
	FROM 
		[gringlobal].[dbo].[pvp_application] pa
	JOIN
		pvp_common_name pc
	ON
		pa.pvp_common_name_id = pc.pvp_common_name_id
	JOIN
		pvp_application_status pas
	ON
		pa.pvp_application_status_id = pas.pvp_application_status_id
	JOIN
		pvp_applicant papp
	ON
		pa.pvp_applicant_id = papp.pvp_applicant_id
	LEFT JOIN
		vw_pvp_application_accession_map vpam
	ON
		pa.pvp_application_number = vpam.pvp_application_number
	
	WHERE
	 DATEDIFF(month,cast(application_date as date),GETDATE()) BETWEEN 1 AND 3
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentlyAvailable_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_PVPRecentlyAvailable_Select]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	  pa.pvp_application_number
     ,[cultivar_name]
     ,[experimental_name]
     ,pa.pvp_common_name_id
	 ,pc.name AS common_name
     ,pa.scientific_name
     ,pa.pvp_applicant_id
	 ,papp.name AS applicant_name
     ,[application_date]
     ,[is_certified_seed]
     ,pas.pvp_application_status_id
	 ,pas.description AS application_status
     ,[status_date]
     ,[certificate_issued_date]
     ,[years_protected]
	 ,vpam.accession_id
	 ,convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) AS expiration_date
	FROM 
		[gringlobal].[dbo].[pvp_application] pa
	JOIN
		pvp_common_name pc
	ON
		pa.pvp_common_name_id = pc.pvp_common_name_id
	JOIN
		pvp_application_status pas
	ON
		pa.pvp_application_status_id = pas.pvp_application_status_id
	JOIN
		pvp_applicant papp
	ON
		pa.pvp_applicant_id = papp.pvp_applicant_id
	LEFT JOIN
		vw_pvp_application_accession_map vpam
	ON
		pa.pvp_application_number = vpam.pvp_application_number
	WHERE
		vpam.accession_id IS NOT NULL
	AND
		DATEDIFF(month,status_date,GETDATE()) < 6
	AND 
		status_date < getdate()
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentlyExpired_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ARS_PVPRecentlyExpired_Select]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	 pa.pvp_application_number
     ,[cultivar_name]
     ,[experimental_name]
     ,pa.pvp_common_name_id
	 ,pc.name AS common_name
     ,pa.scientific_name
     ,pa.pvp_applicant_id
	 ,papp.name AS applicant_name
     ,[application_date]
     ,[is_certified_seed]
     ,pas.pvp_application_status_id
	 ,pas.description AS application_status
     ,[status_date]
     ,[certificate_issued_date]
     ,[years_protected]
	 ,vpam.accession_id
	 ,convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) AS expiration_date
	FROM 
		[gringlobal].[dbo].[pvp_application] pa
	JOIN
		pvp_common_name pc
	ON
		pa.pvp_common_name_id = pc.pvp_common_name_id
	JOIN
		pvp_application_status pas
	ON
		pa.pvp_application_status_id = pas.pvp_application_status_id
	JOIN
		pvp_applicant papp
	ON
		pa.pvp_applicant_id = papp.pvp_applicant_id
	LEFT JOIN
		vw_pvp_application_accession_map vpam
	ON
		pa.pvp_application_number = vpam.pvp_application_number
	WHERE (convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) >= DATEADD(day, -30, GETDATE())
	AND (convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) < GETDATE()
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CodeDetail_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CodeDetail_Select]
	@value NVARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @CONST_SYS_LANG_ID INT = 1
	DECLARE @CONST_GROUP_NAME NVARCHAR(20) = 'TAXONOMY'

	SELECT  
		cv.code_value_id,
		group_name,
		value,
		cvl.title,
		cvl.description
	FROM 
		code_value cv
	JOIN
		code_value_Lang cvl
	ON
		cv.code_value_id = cvl.code_value_id
	WHERE 
		value = @value
	AND
		cvl.sys_lang_id = 1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CodesByGroup_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CodesByGroup_Select]
	@group_name nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		cv.code_value_id,
		cvl.code_value_lang_id,
		cv.group_name,
		cv.value,
		cvl.title,
		cvl.description,
		cv.created_date,
		cv.modified_date
	FROM
		code_value cv
	JOIN
		code_value_lang cvl
	ON
		cv.code_value_id = cvl.code_value_id
	WHERE
		cv.group_name = @group_name
	AND
		cvl.sys_lang_id = 1
	ORDER BY cv.created_date DESC
	
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CodeValues_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CodeValues_Select]
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @CONST_SYS_LANG_ID INT = 1
	DECLARE @CONST_GROUP_NAME NVARCHAR(20) = 'TAXONOMY'

	SELECT  
		cv.code_value_id,
		group_name,
		value,
		cvl.title,
		cvl.description
	FROM 
		code_value cv
	JOIN
		code_value_Lang cvl
	ON
		cv.code_value_id = cvl.code_value_id
	WHERE 
		(group_name LIKE '%' + @CONST_GROUP_NAME + '%'
	OR
		group_name LIKE '%CWR%')
	AND
		cvl.sys_lang_id = @CONST_SYS_LANG_ID
	ORDER BY 
		group_name, value
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CodeValuesByGroupName_Select]    Script Date: 4/16/2021 12:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CodeValuesByGroupName_Select]
	@group_name NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @CONST_SYS_LANG_ID INT = 1

	SELECT  
		cv.code_value_id,
		group_name,
		value,
		cvl.title,
		cvl.description
	FROM 
		code_value cv
	JOIN
		code_value_Lang cvl
	ON
		cv.code_value_id = cvl.code_value_id
	WHERE 
		group_name LIKE '%' + @group_name + '%'
	AND
		cvl.sys_lang_id = @CONST_SYS_LANG_ID
	ORDER BY 
		group_name ASC, value ASC
END
GO
