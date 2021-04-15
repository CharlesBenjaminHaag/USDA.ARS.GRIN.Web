USE [gringlobal]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crop_germplasm_committee_document]') AND type in (N'U'))
ALTER TABLE [dbo].[crop_germplasm_committee_document] DROP CONSTRAINT IF EXISTS [DF_crop_germplasm_committee_document_modified_date]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crop_germplasm_committee_document]') AND type in (N'U'))
ALTER TABLE [dbo].[crop_germplasm_committee_document] DROP CONSTRAINT IF EXISTS [DF_crop_germplasm_committee_document_created_date]
GO
/****** Object:  Table [dbo].[crop_germplasm_committee_meeting]    Script Date: 9/8/2020 12:58:45 PM ******/
DROP TABLE IF EXISTS [dbo].[crop_germplasm_committee_meeting]
GO
/****** Object:  Table [dbo].[crop_germplasm_committee_document]    Script Date: 9/8/2020 12:58:45 PM ******/
DROP TABLE IF EXISTS [dbo].[crop_germplasm_committee_document]
GO
/****** Object:  Table [dbo].[crop_germplasm_committee_crop_descriptor]    Script Date: 9/8/2020 12:58:45 PM ******/
DROP TABLE IF EXISTS [dbo].[crop_germplasm_committee_crop_descriptor]
GO
/****** Object:  Table [dbo].[crop_germplasm_committee]    Script Date: 9/8/2020 12:58:45 PM ******/
DROP TABLE IF EXISTS [dbo].[crop_germplasm_committee]
GO
/****** Object:  Table [dbo].[crop_germplasm_committee]    Script Date: 9/8/2020 12:58:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[crop_germplasm_committee](
	[crop_germplasm_committee_id] [int] IDENTITY(1,1) NOT NULL,
	[crop_germplasm_committee_name] [nvarchar](80) NOT NULL,
	[roster_url] [varchar](120) NULL,
	[created_date] [datetime2](7) NULL,
	[created_by] [int] NULL,
	[modified_date] [datetime2](7) NULL,
	[modified_by] [int] NULL,
 CONSTRAINT [PK_crop_germplasm_committee] PRIMARY KEY CLUSTERED 
(
	[crop_germplasm_committee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[crop_germplasm_committee_crop_descriptor]    Script Date: 9/8/2020 12:58:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[crop_germplasm_committee_crop_descriptor](
	[crop_germplasm_committee_id] [int] NOT NULL,
	[crop_id] [int] NOT NULL,
 CONSTRAINT [PK_crop_germplasm_committee_crop_descriptor] PRIMARY KEY CLUSTERED 
(
	[crop_germplasm_committee_id] ASC,
	[crop_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[crop_germplasm_committee_document]    Script Date: 9/8/2020 12:58:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[crop_germplasm_committee_document](
	[crop_germplasm_committee_document_id] [int] IDENTITY(1,1) NOT NULL,
	[crop_germplasm_committee_id] [int] NULL,
	[url] [nvarchar](120) NOT NULL,
	[created_date] [datetime2](7) NULL,
	[created_by] [int] NULL,
	[modified_date] [datetime2](7) NULL,
	[modified_by] [int] NULL,
	[title] [varchar](250) NULL,
 CONSTRAINT [PK_document] PRIMARY KEY CLUSTERED 
(
	[crop_germplasm_committee_document_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[crop_germplasm_committee_meeting]    Script Date: 9/8/2020 12:58:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[crop_germplasm_committee_meeting](
	[crop_germplasm_committee_meeting_id] [int] IDENTITY(1,1) NOT NULL,
	[crop_germplasm_committee_id] [int] NOT NULL,
	[title] [nvarchar](80) NOT NULL,
	[url] [varchar](120) NULL,
	[created_date] [datetime2](7) NULL,
	[created_by] [int] NULL,
	[modified_date] [datetime2](7) NULL,
	[modified_by] [int] NULL,
 CONSTRAINT [PK_crop_germplasm_committee_meeting] PRIMARY KEY CLUSTERED 
(
	[crop_germplasm_committee_meeting_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
