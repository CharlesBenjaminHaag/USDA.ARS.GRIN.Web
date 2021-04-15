USE [gringlobal]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentlyExpired_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPRecentlyExpired_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentlyAvailable_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPRecentlyAvailable_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentApplications_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPRecentApplications_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPExpiring6Months_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_PVPExpiring6Months_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommittees_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommittees_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocumentsRecent_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocumentsRecent_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_SelectAll]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_SelectAll]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Update]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Update]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Insert]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Insert]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Delete]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Delete]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeCropDescriptors_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeCropDescriptors_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeApplicationStatuses_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommitteeApplicationStatuses_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommittee_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[usp_ARS_CropGermplasmCommittee_Select]
GO
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommittee_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeApplicationStatuses_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeCropDescriptors_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Delete]    Script Date: 4/15/2021 1:14:13 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Insert]    Script Date: 4/15/2021 1:14:13 PM ******/
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
			 title,
			 document_year,
			 category_code,
			 url,
			 created_by,
			 created_date)
		VALUES
			(
			@crop_germplasm_committee_id,
			@title,
			@document_year,
			@category_code,
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocument_Update]    Script Date: 4/15/2021 1:14:13 PM ******/
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
			title = @title,
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
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
		title,
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocuments_SelectAll]    Script Date: 4/15/2021 1:14:13 PM ******/
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
		title,
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommitteeDocumentsRecent_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
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
		title,
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_CropGermplasmCommittees_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPExpiring6Months_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentApplications_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentlyAvailable_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_ARS_PVPRecentlyExpired_Select]    Script Date: 4/15/2021 1:14:13 PM ******/
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
