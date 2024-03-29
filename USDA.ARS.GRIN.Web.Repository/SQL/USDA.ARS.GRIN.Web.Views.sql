USE [gringlobal]
GO
/****** Object:  View [dbo].[vw_pvp_applications_by_expiration]    Script Date: 4/15/2021 11:36:00 AM ******/
DROP VIEW IF EXISTS [dbo].[vw_pvp_applications_by_expiration]
GO
/****** Object:  View [dbo].[vw_lookup_code_value]    Script Date: 4/15/2021 11:36:00 AM ******/
DROP VIEW IF EXISTS [dbo].[vw_lookup_code_value]
GO
/****** Object:  View [dbo].[vw_ars_grin_pvp_recently_available]    Script Date: 4/15/2021 11:36:00 AM ******/
DROP VIEW IF EXISTS [dbo].[vw_ars_grin_pvp_recently_available]
GO
/****** Object:  View [dbo].[vw_ars_grin_pvp_recent_applications]    Script Date: 4/15/2021 11:36:00 AM ******/
DROP VIEW IF EXISTS [dbo].[vw_ars_grin_pvp_recent_applications]
GO
/****** Object:  View [dbo].[vw_ars_grin_pvp_expired_this_week]    Script Date: 4/15/2021 11:36:00 AM ******/
DROP VIEW IF EXISTS [dbo].[vw_ars_grin_pvp_expired_this_week]
GO
/****** Object:  View [dbo].[vw_ars_grin_pvp_available]    Script Date: 4/15/2021 11:36:00 AM ******/
DROP VIEW IF EXISTS [dbo].[vw_ars_grin_pvp_available]
GO
/****** Object:  View [dbo].[vw_pvp_application_accession_map]    Script Date: 4/15/2021 11:36:00 AM ******/
DROP VIEW IF EXISTS [dbo].[vw_pvp_application_accession_map]
GO
/****** Object:  View [dbo].[vw_pvp_application_accession_map]    Script Date: 4/15/2021 11:36:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vw_pvp_application_accession_map]
AS
SELECT  
	pa.pvp_application_number,
	ai.ipr_number,
	ai.accession_ipr_id,
	ai.accession_id
FROM
	pvp_application pa
JOIN
	accession_ipr ai
ON
	pa.pvp_application_number = dbo.fn_extract_integer(ipr_number)
WHERE type_code = 'PVP'  
	and ipr_number not like '%MP'
    and ipr_number not like '%FP'
	and ipr_number not like '%P1'
	and ipr_number not like '%P2'
	and ipr_number not like '%P3'
	and dbo.get_avstat(ai.accession_id) = 'Y'

--,cast(substring(ipr_number,5,20) as int) AS pv_number
--,[accession_ipr_id]
--      ,ai.accession_id
--      ,[type_code]
--      ,[ipr_number]
--      ,[ipr_crop_name]
--      ,[ipr_full_name]
--      ,[issued_date]
--      ,[expired_date]
--      ,[cooperator_id]
--      --,[note]
--      ,[accepted_date]
--      ,[expected_date]
--      --,[created_date]
--      --,[created_by]
--      --,[modified_date]
--      --,[modified_by]
--      --,[owned_date]
--      --,[owned_by]
--  FROM [gringlobal].[dbo].[accession_ipr] ai
--  JOIN
--	accession a
--	ON 
--	ai.accession_id = a.accession_id
--	LEFT JOIN
--	pvp_application pa
--ON
--	pa.pvp_application_number = cast(substring(ipr_number,5,20) as int)
--  WHERE type_code = 'PVP'  
--	and ipr_number not like '%MP'
--    and ipr_number not like '%FP'
--	and ipr_number not like '%P1'
--	and ipr_number not like '%P2'
--	and ipr_number not like '%P3'
GO
/****** Object:  View [dbo].[vw_ars_grin_pvp_available]    Script Date: 4/15/2021 11:36:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ars_grin_pvp_available]
AS
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
GO
/****** Object:  View [dbo].[vw_ars_grin_pvp_expired_this_week]    Script Date: 4/15/2021 11:36:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ars_grin_pvp_expired_this_week]
AS
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
	WHERE (convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) >= DATEADD(day, -7, GETDATE())
	AND (convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) < GETDATE()
GO
/****** Object:  View [dbo].[vw_ars_grin_pvp_recent_applications]    Script Date: 4/15/2021 11:36:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_ars_grin_pvp_recent_applications]
AS
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
GO
/****** Object:  View [dbo].[vw_ars_grin_pvp_recently_available]    Script Date: 4/15/2021 11:36:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_ars_grin_pvp_recently_available]
AS
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
		pas.pvp_application_status_id != 18
	AND
		DATEDIFF(month,status_date,GETDATE()) < 6
	AND 
		status_date < getdate()
GO


USE [gringlobal]
GO
/****** Object:  View [dbo].[vw_cgc_lookup_document_categories]    Script Date: 4/22/2021 10:27:59 AM ******/
DROP VIEW IF EXISTS [dbo].[vw_cgc_lookup_document_categories]
GO
/****** Object:  View [dbo].[vw_cgc_lookup_document_categories]    Script Date: 4/22/2021 10:27:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_cgc_lookup_document_categories]
AS
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
		cv.group_name = 'CGC_DOCUMENT_CATEGORY'
	AND
		cvl.sys_lang_id = 1
GO



/****** Object:  View [dbo].[vw_lookup_code_value]    Script Date: 4/15/2021 11:36:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW
	[dbo].[vw_lookup_code_value]
AS
SELECT
	cv.code_value_id,
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
	cvl.sys_lang_id = 1
GO
/****** Object:  View [dbo].[vw_pvp_applications_by_expiration]    Script Date: 4/15/2021 11:36:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_pvp_applications_by_expiration]
AS
	SELECT 
		1 AS sort_order,
	'Expiring Within 6 Months' AS category
	,[pvp_application_number]
    ,[cultivar_name]
    ,[experimental_name]
    ,pa.pvp_common_name_id
	,pc.name AS common_name
   ,scientific_name
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
	 ,DATEDIFF(month,GETDATE(),convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101))  AS months_remaining
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
	WHERE
	  certificate_issued_date IS NOT NULL
	AND
		pa.pvp_application_status_id = 18
	AND		
		convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) >= GETDATE()
	AND
		DATEDIFF(month,GETDATE(),convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) <=6

		UNION

		SELECT 
		2 AS sort_order,
	'Expiring Within 1 Year' AS category
	,[pvp_application_number]
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
	 ,DATEDIFF(month,GETDATE(),convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) AS months_remaining
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
	WHERE
	  certificate_issued_date IS NOT NULL
	AND
		pa.pvp_application_status_id = 18
	AND		
		convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101) >= GETDATE()
	AND
		DATEDIFF(month,GETDATE(),convert(nvarchar(12),dateadd(year,years_protected,cast(certificate_issued_date as date)),101)) <=12
GO
