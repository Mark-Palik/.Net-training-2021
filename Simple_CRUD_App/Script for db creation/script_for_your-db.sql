USE [Employees_db]
GO

/****** Object:  Table [dbo].[Emp_Table]    Script Date: 10.05.2021 21:56:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Emp_Table](
	[Emp_id] [int] NOT NULL,
	[Emp_first_name] [nvarchar](50) NULL,
	[Emp_last_name] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[gender] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
 CONSTRAINT [PK_Emp_Table] PRIMARY KEY CLUSTERED 
(
	[Emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

