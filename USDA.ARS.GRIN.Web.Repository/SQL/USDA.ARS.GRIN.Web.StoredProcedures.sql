USE [gringlobal]
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPSearch]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_PVPSearch]
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPExpirationPeriods_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_PVPExpirationPeriods_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPCommonNames_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_PVPCommonNames_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationStatuses_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_PVPApplicationStatuses_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsByScientificName_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_PVPApplicationsByScientificName_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsByExpiration_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_PVPApplicationsByExpiration_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsByCrop_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_PVPApplicationsByCrop_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsByCommonName_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_PVPApplicationsByCommonName_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsByApplicationStatus_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_PVPApplicationsByApplicationStatus_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsAvailable_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_PVPApplicationsAvailable_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplication_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_PVPApplication_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CGCDocuments_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_CGCDocuments_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CGCDocument_Update]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_CGCDocument_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_CGCDocument_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_CGCDocument_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CGCDocument_Insert]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_CGCDocument_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_CGCDocument_Delete]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_CGCDocument_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_CGCCommittees_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_CGCCommittees_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_CGCCommittees_Select]    Script Date: 10/15/2020 2:37:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CGCCommittees_Select] 
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
/****** Object:  StoredProcedure [dbo].[usp_CGCDocument_Delete]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CGCDocument_Delete]
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
/****** Object:  StoredProcedure [dbo].[usp_CGCDocument_Insert]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CGCDocument_Insert]
	@out_error_number INT = 0 OUTPUT,
	@out_crop_germplasm_committee_document_id INT = 0 OUTPUT,
	@crop_germplasm_committee_id INT,
	@title NVARCHAR(250),
	@url NVARCHAR(120)
AS
BEGIN
	BEGIN TRY
		INSERT INTO
			crop_germplasm_committee_document
			(crop_germplasm_committee_id,
			 title,
			 url,
			 created_by,
			 created_date)
		VALUES
			(
			@crop_germplasm_committee_id,
			@title,
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
/****** Object:  StoredProcedure [dbo].[usp_CGCDocument_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[usp_CGCDocument_Select]
	@crop_germplasm_committee_document_id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		cgc.crop_germplasm_committee_name,
		crop_germplasm_committee_document_id,
		cgcd.crop_germplasm_committee_id,
		title,
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
		crop_germplasm_committee_document_id = @crop_germplasm_committee_document_id
	ORDER BY
		title DESC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CGCDocument_Update]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CGCDocument_Update]
	@out_error_number INT = 0 OUTPUT,
	@crop_germplasm_committee_document_id INT,
	@crop_germplasm_committee_id INT,
	@title NVARCHAR(250),
	@url NVARCHAR(120)
AS
BEGIN
	BEGIN TRY
		UPDATE
			crop_germplasm_committee_document
		SET
			crop_germplasm_committee_id = @crop_germplasm_committee_id, 
			title = @title,
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
/****** Object:  StoredProcedure [dbo].[usp_CGCDocuments_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[usp_CGCDocuments_Select]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		cgc.crop_germplasm_committee_name,
		crop_germplasm_committee_document_id,
		cgcd.crop_germplasm_committee_id,
		title,
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
/****** Object:  StoredProcedure [dbo].[usp_PVPApplication_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PVPApplication_Select]
	@pvp_application_number INT
AS
BEGIN
	SELECT 
		pa.pvp_application_number
		,[cultivar_name]
		,[experimental_name]
		,pa.pvp_common_name_id
		,pa.scientific_name
		,pc.name AS common_name
		,pa.pvp_applicant_id
		,papp.name AS applicant_name
		,[application_date]
		,[is_certified_seed]
		,pas.pvp_application_status_id
		,pas.description AS application_status
		,[status_date]
		,[certificate_issued_date]
		,[years_protected]
		 ,CONVERT(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) AS expiration_date
		,vi.accession_id
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
		vw_accession_ipr vi
	ON
		pa.pvp_application_number = vi.pv_number
WHERE
	 pa.pvp_application_number = @pvp_application_number
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsAvailable_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PVPApplicationsAvailable_Select]
AS
BEGIN

--SELECT
--pvnumber, status, statusdate,
--       applicantowner, isnull(variety,EXPERMENTALNAMESYNONYMS) variety,accession_id
--FROM pvpo_catalog c,accession_ipr i where  i.type_code = 'PVP'  
--		and ipr_number not like '%MP'
--    	and ipr_number not like '%FP'
--and ipr_number not like '%P1'
--and ipr_number not like '%P2'
--and ipr_number not like '%P3'
--and	cast(substring(ipr_number,5,20) as int) = c.pvnumber
--and dbo.get_avstat(accession_id) = 'Y'
--              --and c.crop = '$crop'   
--ORDER BY cast(statusdate as date) desc

SELECT 
	 [pvp_application_number]
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
	FROM 
		[gringlobal].[dbo].[pvp_application] pa
	JOIN
		accession_ipr ai
	ON
		pa.pvp_application_number = CAST(SUBSTRING(ipr_number,5,20) AS INT)
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
	WHERE
		ai.type_code = 'PVP'  
	AND
		ipr_number not like '%MP'
    AND 
		ipr_number not like '%FP'
	AND 
		ipr_number not like '%P1'
	AND 
		ipr_number not like '%P2'
	AND 
		ipr_number not like '%P3'
	AND	
		dbo.get_avstat(accession_id) = 'Y'


	--	certificate_issued_date IS NOT NULL
	--AND
	--	DATEADD(year, Years_Protected, certificate_issued_date)
	--BETWEEN
	--	CAST(DATEADD(month,-1,GETDATE()) AS DATE)
	--AND
	--	CAST(DATEADD(month,6,GETDATE()) AS DATE)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsByApplicationStatus_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_PVPApplicationsByApplicationStatus_Select]
	@pvp_application_status_id INT
AS
BEGIN

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
	 pa.pvp_application_status_id = @pvp_application_status_id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsByCommonName_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PVPApplicationsByCommonName_Select]
	@pvp_common_name_id INT
AS
BEGIN

SELECT 
	 pa.pvp_application_number
     ,[cultivar_name]
     ,[experimental_name]
     ,pa.pvp_common_name_id
	 ,pa.scientific_name
	 ,pc.name AS common_name
     ,pa.pvp_applicant_id
	 ,papp.name AS applicant_name
     ,[application_date]
     ,[is_certified_seed]
     ,pas.pvp_application_status_id
	 ,pas.description AS application_status
     ,[status_date]
     ,[certificate_issued_date]
     ,[years_protected]
	 ,convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) AS expiration_date
	 ,CASE
		WHEN (convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)  > GETDATE())
		THEN DATEDIFF(month,GETDATE(),convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) 
	 END AS months_remaining
	 ,vi.accession_id
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
		vw_accession_ipr vi
	ON
		pa.pvp_application_number = vi.pv_number
WHERE
	 pa.pvp_common_name_id = @pvp_common_name_id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsByCrop_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PVPApplicationsByCrop_Select]
	@pvp_common_name_id INT
AS
BEGIN

SELECT 
	 pa.pvp_application_number
     ,[cultivar_name]
     ,[experimental_name]
     ,pa.pvp_common_name_id
	 ,pa.scientific_name
	 ,pc.name AS common_name
     ,pa.pvp_applicant_id
	 ,papp.name AS applicant_name
     ,[application_date]
     ,[is_certified_seed]
     ,pas.pvp_application_status_id
	 ,pas.description AS application_status
     ,[status_date]
     ,[certificate_issued_date]
     ,[years_protected]
	 ,convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) AS expiration_date
	 ,CASE
		WHEN (convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)  > GETDATE())
		THEN DATEDIFF(month,GETDATE(),convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) 
	 END AS months_remaining
	 ,vi.accession_id
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
		vw_accession_ipr vi
	ON
		pa.pvp_application_number = vi.pv_number
WHERE
	 pa.pvp_common_name_id = @pvp_common_name_id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsByExpiration_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PVPApplicationsByExpiration_Select]
	@expiration_period_id INT
AS
BEGIN

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
	 ,convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) AS expiration_date
	 ,CASE
		WHEN (convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)  > GETDATE())
		THEN DATEDIFF(month,GETDATE(),convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) 
	 END AS months_remaining
	 ,vpam.accession_id
	FROM 
		vw_pvp_applications_by_expiration pa
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
	 pa.sort_order = @expiration_period_id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationsByScientificName_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PVPApplicationsByScientificName_Select]
	@pvp_common_name_id INT
AS
BEGIN

SELECT 
	 pa.pvp_application_number
     ,[cultivar_name]
     ,[experimental_name]
     ,pa.pvp_common_name_id
	 ,pa.scientific_name
     ,PC.name AS common_name
     ,pa.pvp_applicant_id
	 ,papp.name AS applicant_name
     ,[application_date]
     ,[is_certified_seed]
     ,pas.pvp_application_status_id
	 ,pas.description AS application_status
     ,[status_date]
     ,[certificate_issued_date]
     ,[years_protected]
	 ,convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) AS expiration_date
	 ,CASE
		WHEN (convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)  > GETDATE())
		THEN DATEDIFF(month,GETDATE(),convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) 
	 END AS months_remaining
	 ,vpam.accession_id
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
	 pa.pvp_common_name_id = @pvp_common_name_id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPApplicationStatuses_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_PVPApplicationStatuses_Select]
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
/****** Object:  StoredProcedure [dbo].[usp_PVPCommonNames_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_PVPCommonNames_Select]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		pvp_common_name_id AS id,
		name AS title,
		(SELECT COUNT(*) FROM pvp_application WHERE pvp_common_name_id = c.pvp_common_name_id) AS count
	FROM
		pvp_common_name c
	ORDER BY name
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPExpirationPeriods_Select]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_PVPExpirationPeriods_Select]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT DISTINCT 
		sort_order, 
		category,
		(SELECT COUNT(*) FROM vw_pvp_applications_by_expiration WHERE sort_order = vpae.sort_order) AS count
	FROM 
		vw_pvp_applications_by_expiration vpae
	ORDER BY
		sort_order
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PVPSearch]    Script Date: 10/15/2020 2:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_PVPSearch] 
	@sql_where_clause NVARCHAR(MAX) = ''
AS
BEGIN
	SET NOCOUNT ON;
	SET FMTONLY OFF;
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
	 ,vi.accession_id
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
		vw_accession_ipr vi
	ON
		pa.pvp_application_number = vi.pv_number'

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

	SELECT *
	FROM @Results
END
GO
