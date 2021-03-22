USE [master]
GO
/****** Object:  Database [session1]    Script Date: 3/15/2021 7:47:38 PM ******/
CREATE DATABASE [session1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'session1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\session1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'session1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\session1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE Cyrillic_General_100_CS_AS
GO
ALTER DATABASE [session1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [session1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [session1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [session1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [session1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [session1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [session1] SET ARITHABORT OFF 
GO
ALTER DATABASE [session1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [session1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [session1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [session1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [session1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [session1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [session1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [session1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [session1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [session1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [session1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [session1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [session1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [session1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [session1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [session1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [session1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [session1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [session1] SET  MULTI_USER 
GO
ALTER DATABASE [session1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [session1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [session1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [session1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [session1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [session1] SET QUERY_STORE = OFF
GO
USE [session1]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 3/15/2021 7:47:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CrashTypes]    Script Date: 3/15/2021 7:47:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CrashTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
 CONSTRAINT [PK_CrashTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginHistories]    Script Date: 3/15/2021 7:47:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginHistories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[LoginDateTime] [datetime] NOT NULL,
	[LogoutDateTime] [datetime] NULL,
	[CrashTypeID] [int] NULL,
	[CrashReason] [nvarchar](max) COLLATE Cyrillic_General_100_CS_AS NULL,
 CONSTRAINT [PK_LoginHistories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offices]    Script Date: 3/15/2021 7:47:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offices](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[Title] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[Phone] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[Contact] [nvarchar](250) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
 CONSTRAINT [PK_Office] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/15/2021 7:47:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/15/2021 7:47:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Email] [nvarchar](150) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[FirstName] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NULL,
	[LastName] [nvarchar](50) COLLATE Cyrillic_General_100_CS_AS NOT NULL,
	[OfficeID] [int] NULL,
	[Birthdate] [date] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([ID], [Name]) VALUES (1, N'Afghanistan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (2, N'Albania')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (3, N'Algeria')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (4, N'Andorra')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (5, N'Angola')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (6, N'Antigua & Deps')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (7, N'Argentina')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (8, N'Armenia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (9, N'Australia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (10, N'Austria')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (11, N'Azerbaijan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (12, N'Bahamas')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (13, N'Bahrain')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (14, N'Bangladesh')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (15, N'Barbados')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (16, N'Belarus')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (17, N'Belgium')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (18, N'Belize')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (19, N'Benin')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (20, N'Bhutan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (21, N'Bolivia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (22, N'Bosnia Herzegovina')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (23, N'Botswana')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (24, N'Brazil')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (25, N'Brunei')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (26, N'Bulgaria')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (27, N'Burkina')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (28, N'Burundi')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (29, N'Cambodia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (30, N'Cameroon')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (31, N'Canada')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (32, N'Cape Verde')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (33, N'Central African Rep')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (34, N'Chad')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (35, N'Chile')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (36, N'China')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (37, N'Colombia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (38, N'Comoros')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (39, N'Congo')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (40, N'Congo {Democratic Rep}')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (41, N'Costa Rica')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (42, N'Croatia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (43, N'Cuba')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (44, N'Cyprus')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (45, N'Czech Republic')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (46, N'Denmark')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (47, N'Djibouti')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (48, N'Dominica')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (49, N'Dominican Republic')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (50, N'East Timor')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (51, N'Ecuador')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (52, N'Egypt')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (53, N'El Salvador')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (54, N'Equatorial Guinea')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (55, N'Eritrea')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (56, N'Estonia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (57, N'Ethiopia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (58, N'Fiji')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (59, N'Finland')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (60, N'France')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (61, N'Gabon')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (62, N'Gambia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (63, N'Georgia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (64, N'Germany')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (65, N'Ghana')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (66, N'Greece')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (67, N'Grenada')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (68, N'Guatemala')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (69, N'Guinea')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (70, N'Guinea-Bissau')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (71, N'Guyana')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (72, N'Haiti')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (73, N'Honduras')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (74, N'Hungary')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (75, N'Iceland')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (76, N'India')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (77, N'Indonesia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (78, N'Iran')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (79, N'Iraq')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (80, N'Ireland {Republic}')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (81, N'Israel')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (82, N'Italy')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (83, N'Ivory Coast')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (84, N'Jamaica')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (85, N'Japan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (86, N'Jordan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (87, N'Kazakhstan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (88, N'Kenya')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (89, N'Kiribati')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (90, N'Korea North')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (91, N'Korea South')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (92, N'Kosovo')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (93, N'Kuwait')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (94, N'Kyrgyzstan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (95, N'Laos')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (96, N'Latvia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (97, N'Lebanon')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (98, N'Lesotho')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (99, N'Liberia')
GO
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (100, N'Libya')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (101, N'Liechtenstein')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (102, N'Lithuania')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (103, N'Luxembourg')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (104, N'Macedonia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (105, N'Madagascar')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (106, N'Malawi')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (107, N'Malaysia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (108, N'Maldives')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (109, N'Mali')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (110, N'Malta')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (111, N'Marshall Islands')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (112, N'Mauritania')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (113, N'Mauritius')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (114, N'Mexico')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (115, N'Micronesia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (116, N'Moldova')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (117, N'Monaco')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (118, N'Mongolia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (119, N'Montenegro')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (120, N'Morocco')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (121, N'Mozambique')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (122, N'Myanmar, {Burma}')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (123, N'Namibia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (124, N'Nauru')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (125, N'Nepal')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (126, N'Netherlands')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (127, N'New Zealand')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (128, N'Nicaragua')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (129, N'Niger')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (130, N'Nigeria')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (131, N'Norway')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (132, N'Oman')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (133, N'Pakistan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (134, N'Palau')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (135, N'Panama')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (136, N'Papua New Guinea')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (137, N'Paraguay')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (138, N'Peru')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (139, N'Philippines')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (140, N'Poland')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (141, N'Portugal')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (142, N'Qatar')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (143, N'Romania')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (144, N'Russian Federation')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (145, N'Rwanda')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (146, N'St Kitts & Nevis')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (147, N'St Lucia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (148, N'Saint Vincent & the Grenadines')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (149, N'Samoa')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (150, N'San Marino')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (151, N'Sao Tome & Principe')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (152, N'Saudi Arabia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (153, N'Senegal')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (154, N'Serbia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (155, N'Seychelles')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (156, N'Sierra Leone')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (157, N'Singapore')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (158, N'Slovakia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (159, N'Slovenia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (160, N'Solomon Islands')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (161, N'Somalia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (162, N'South Africa')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (163, N'South Sudan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (164, N'Spain')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (165, N'Sri Lanka')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (166, N'Sudan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (167, N'Suriname')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (168, N'Swaziland')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (169, N'Sweden')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (170, N'Switzerland')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (171, N'Syria')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (172, N'Taiwan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (173, N'Tajikistan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (174, N'Tanzania')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (175, N'Thailand')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (176, N'Togo')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (177, N'Tonga')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (178, N'Trinidad & Tobago')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (179, N'Tunisia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (180, N'Turkey')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (181, N'Turkmenistan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (182, N'Tuvalu')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (183, N'Uganda')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (184, N'Ukraine')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (185, N'United Arab Emirates')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (186, N'United Kingdom')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (187, N'United States')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (188, N'Uruguay')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (189, N'Uzbekistan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (190, N'Vanuatu')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (191, N'Vatican City')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (192, N'Venezuela')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (193, N'Vietnam')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (194, N'Yemen')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (195, N'Zambia')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (196, N'Zimbabwe')
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[CrashTypes] ON 

INSERT [dbo].[CrashTypes] ([ID], [Name]) VALUES (1, N'Software Crash')
INSERT [dbo].[CrashTypes] ([ID], [Name]) VALUES (2, N'System Crash')
SET IDENTITY_INSERT [dbo].[CrashTypes] OFF
SET IDENTITY_INSERT [dbo].[LoginHistories] ON 

INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (51, 1, CAST(N'2021-03-15T15:49:44.817' AS DateTime), CAST(N'2021-03-15T15:50:13.610' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (52, 1, CAST(N'2021-03-15T15:52:50.800' AS DateTime), CAST(N'2021-03-15T15:53:13.830' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (53, 1, CAST(N'2021-03-15T15:53:16.010' AS DateTime), NULL, 2, N'не важно')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (54, 1, CAST(N'2021-03-15T15:54:29.730' AS DateTime), NULL, 2, N'asd')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (55, 1, CAST(N'2021-03-15T15:55:35.977' AS DateTime), NULL, 2, N'asd')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (56, 1, CAST(N'2021-03-15T15:57:11.383' AS DateTime), NULL, 2, N'123')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (57, 1, CAST(N'2021-03-15T15:59:46.673' AS DateTime), NULL, 2, N'asd')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (58, 1, CAST(N'2021-03-15T16:00:54.663' AS DateTime), CAST(N'2021-03-15T16:01:32.080' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (59, 13, CAST(N'2021-03-15T16:02:46.440' AS DateTime), NULL, 2, N'123')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (60, 13, CAST(N'2021-03-15T16:09:03.253' AS DateTime), NULL, 2, N'123')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (61, 13, CAST(N'2021-03-15T16:10:48.343' AS DateTime), NULL, 2, N'1123123')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (62, 13, CAST(N'2021-03-15T16:12:39.677' AS DateTime), CAST(N'2021-03-15T16:14:09.007' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (63, 13, CAST(N'2021-03-15T16:44:52.150' AS DateTime), NULL, 1, N'asd')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (64, 13, CAST(N'2021-03-15T16:47:08.513' AS DateTime), NULL, 1, N'asd')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (65, 13, CAST(N'2021-03-15T16:49:19.947' AS DateTime), NULL, 2, N'asd')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (66, 13, CAST(N'2021-03-15T16:50:40.217' AS DateTime), NULL, 2, N'asdasd')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (67, 13, CAST(N'2021-03-15T16:52:06.320' AS DateTime), NULL, 2, N'ASDASD')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (68, 13, CAST(N'2021-03-15T16:53:37.530' AS DateTime), NULL, 2, N'ASDASD')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (69, 13, CAST(N'2021-03-15T16:54:21.160' AS DateTime), NULL, 2, N'ADASDASD')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (70, 13, CAST(N'2021-03-15T16:57:17.400' AS DateTime), CAST(N'2021-03-15T16:57:33.010' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (71, 13, CAST(N'2021-03-15T16:57:37.467' AS DateTime), CAST(N'2021-03-15T16:57:41.380' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (72, 13, CAST(N'2021-03-15T16:58:01.630' AS DateTime), CAST(N'2021-03-15T16:58:04.220' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (73, 13, CAST(N'2021-03-15T16:59:23.467' AS DateTime), CAST(N'2021-03-15T16:59:26.253' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (74, 13, CAST(N'2021-03-15T17:00:19.527' AS DateTime), CAST(N'2021-03-15T17:00:22.127' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (76, 13, CAST(N'2021-03-15T17:04:00.597' AS DateTime), CAST(N'2021-03-15T17:04:00.677' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (77, 13, CAST(N'2021-03-15T17:05:16.870' AS DateTime), NULL, 2, N'123123')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (78, 13, CAST(N'2021-03-15T17:07:18.190' AS DateTime), CAST(N'2021-03-15T17:07:21.427' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (79, 13, CAST(N'2021-03-15T17:12:13.733' AS DateTime), CAST(N'2021-03-15T17:12:16.227' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (80, 13, CAST(N'2021-03-15T17:16:24.173' AS DateTime), CAST(N'2021-03-15T17:16:26.443' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (81, 13, CAST(N'2021-03-15T17:18:03.330' AS DateTime), CAST(N'2021-03-15T17:18:05.800' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (82, 13, CAST(N'2021-03-15T17:18:28.727' AS DateTime), CAST(N'2021-03-15T17:18:31.107' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (83, 13, CAST(N'2021-03-15T17:18:44.950' AS DateTime), CAST(N'2021-03-15T17:18:53.833' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (84, 13, CAST(N'2021-03-15T17:19:03.867' AS DateTime), CAST(N'2021-03-15T17:19:05.947' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (85, 13, CAST(N'2021-03-15T17:20:00.373' AS DateTime), CAST(N'2021-03-15T17:20:02.723' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (86, 13, CAST(N'2021-03-15T17:20:14.533' AS DateTime), CAST(N'2021-03-15T17:20:17.073' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (87, 13, CAST(N'2021-03-15T17:22:43.127' AS DateTime), CAST(N'2021-03-15T17:22:45.297' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (88, 13, CAST(N'2021-03-15T17:22:54.657' AS DateTime), CAST(N'2021-03-15T17:22:57.370' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (89, 13, CAST(N'2021-03-15T17:24:03.423' AS DateTime), CAST(N'2021-03-15T17:24:05.713' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (90, 13, CAST(N'2021-03-15T17:25:39.677' AS DateTime), CAST(N'2021-03-15T17:25:41.947' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (91, 13, CAST(N'2021-03-15T17:26:36.277' AS DateTime), CAST(N'2021-03-15T17:26:38.487' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (92, 13, CAST(N'2021-03-15T17:35:45.187' AS DateTime), CAST(N'2021-03-15T17:35:47.113' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (93, 13, CAST(N'2021-03-15T17:36:02.383' AS DateTime), CAST(N'2021-03-15T17:36:04.767' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (94, 13, CAST(N'2021-03-15T17:36:12.100' AS DateTime), CAST(N'2021-03-15T17:36:14.023' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (95, 13, CAST(N'2021-03-15T17:36:32.527' AS DateTime), CAST(N'2021-03-15T17:36:34.890' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (96, 13, CAST(N'2021-03-15T17:36:45.970' AS DateTime), CAST(N'2021-03-15T17:36:50.120' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (97, 13, CAST(N'2021-03-15T17:38:34.390' AS DateTime), CAST(N'2021-03-15T17:38:36.943' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (98, 13, CAST(N'2021-03-15T17:38:53.473' AS DateTime), CAST(N'2021-03-15T17:38:59.733' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (99, 13, CAST(N'2021-03-15T17:44:10.907' AS DateTime), CAST(N'2021-03-15T17:44:13.630' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (100, 13, CAST(N'2021-03-15T17:44:23.187' AS DateTime), CAST(N'2021-03-15T17:44:26.157' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (101, 13, CAST(N'2021-03-15T17:45:39.847' AS DateTime), CAST(N'2021-03-15T17:45:41.693' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1050, 13, CAST(N'2021-03-15T18:13:23.427' AS DateTime), CAST(N'2021-03-15T18:13:25.250' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1051, 13, CAST(N'2021-03-15T18:13:26.100' AS DateTime), CAST(N'2021-03-15T18:13:28.090' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1052, 13, CAST(N'2021-03-15T18:13:28.957' AS DateTime), CAST(N'2021-03-15T18:13:30.960' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1053, 13, CAST(N'2021-03-15T18:13:31.817' AS DateTime), CAST(N'2021-03-15T18:14:12.230' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1054, 13, CAST(N'2021-03-15T18:26:26.010' AS DateTime), CAST(N'2021-03-15T18:26:28.777' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1055, 13, CAST(N'2021-03-15T18:31:19.970' AS DateTime), CAST(N'2021-03-15T18:31:22.713' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1056, 13, CAST(N'2021-03-15T18:31:47.817' AS DateTime), CAST(N'2021-03-15T18:31:50.267' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1057, 13, CAST(N'2021-03-15T18:40:59.167' AS DateTime), CAST(N'2021-03-15T18:41:05.707' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1058, 13, CAST(N'2021-03-15T18:41:53.150' AS DateTime), CAST(N'2021-03-15T18:41:56.843' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1059, 13, CAST(N'2021-03-15T18:43:46.367' AS DateTime), CAST(N'2021-03-15T18:43:51.540' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1060, 13, CAST(N'2021-03-15T18:47:08.907' AS DateTime), NULL, 2, N'123')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1061, 13, CAST(N'2021-03-15T18:47:26.857' AS DateTime), CAST(N'2021-03-15T18:47:29.460' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1062, 13, CAST(N'2021-03-15T18:47:51.580' AS DateTime), CAST(N'2021-03-15T18:47:53.803' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1063, 13, CAST(N'2021-03-15T18:49:46.140' AS DateTime), NULL, 2, N'123')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1064, 13, CAST(N'2021-03-15T18:49:56.287' AS DateTime), CAST(N'2021-03-15T18:50:28.477' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1065, 13, CAST(N'2021-03-15T18:50:49.533' AS DateTime), CAST(N'2021-03-15T18:50:51.860' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1066, 13, CAST(N'2021-03-15T18:52:16.807' AS DateTime), CAST(N'2021-03-15T18:52:19.230' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1067, 13, CAST(N'2021-03-15T18:52:39.960' AS DateTime), CAST(N'2021-03-15T18:52:43.010' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1068, 13, CAST(N'2021-03-15T18:52:49.157' AS DateTime), CAST(N'2021-03-15T18:52:51.410' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1069, 13, CAST(N'2021-03-15T18:52:56.413' AS DateTime), NULL, 2, N'123')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1070, 13, CAST(N'2021-03-15T18:53:04.280' AS DateTime), CAST(N'2021-03-15T18:53:07.830' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1071, 13, CAST(N'2021-03-15T18:53:13.270' AS DateTime), CAST(N'2021-03-15T18:53:26.243' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1072, 13, CAST(N'2021-03-15T18:55:29.873' AS DateTime), CAST(N'2021-03-15T18:55:33.220' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1073, 13, CAST(N'2021-03-15T18:55:55.730' AS DateTime), CAST(N'2021-03-15T18:56:01.970' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1074, 13, CAST(N'2021-03-15T18:56:08.797' AS DateTime), CAST(N'2021-03-15T18:56:11.890' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1075, 13, CAST(N'2021-03-15T18:57:01.700' AS DateTime), CAST(N'2021-03-15T18:57:04.037' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1076, 13, CAST(N'2021-03-15T18:57:11.517' AS DateTime), NULL, 2, N'123')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1077, 13, CAST(N'2021-03-15T18:57:22.593' AS DateTime), CAST(N'2021-03-15T18:57:23.780' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1078, 13, CAST(N'2021-03-15T18:57:51.487' AS DateTime), NULL, 2, N'asd')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1079, 13, CAST(N'2021-03-15T18:59:01.377' AS DateTime), CAST(N'2021-03-15T18:59:07.273' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1080, 13, CAST(N'2021-03-15T18:59:15.783' AS DateTime), CAST(N'2021-03-15T18:59:18.100' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1081, 13, CAST(N'2021-03-15T18:59:21.663' AS DateTime), CAST(N'2021-03-15T18:59:24.357' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1082, 13, CAST(N'2021-03-15T18:59:47.830' AS DateTime), CAST(N'2021-03-15T18:59:49.733' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1083, 13, CAST(N'2021-03-15T18:59:52.183' AS DateTime), CAST(N'2021-03-15T18:59:55.413' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1084, 13, CAST(N'2021-03-15T18:59:57.440' AS DateTime), CAST(N'2021-03-15T18:59:59.357' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1085, 13, CAST(N'2021-03-15T19:00:00.533' AS DateTime), CAST(N'2021-03-15T19:00:02.397' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1086, 13, CAST(N'2021-03-15T19:00:03.760' AS DateTime), CAST(N'2021-03-15T19:00:09.840' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1087, 13, CAST(N'2021-03-15T19:03:26.543' AS DateTime), CAST(N'2021-03-15T19:03:29.150' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1088, 13, CAST(N'2021-03-15T19:04:02.797' AS DateTime), CAST(N'2021-03-15T19:04:05.150' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1089, 13, CAST(N'2021-03-15T19:20:43.697' AS DateTime), NULL, 2, N'asd')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1090, 13, CAST(N'2021-03-15T19:22:23.520' AS DateTime), NULL, 2, N'asd')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1091, 13, CAST(N'2021-03-15T19:24:39.353' AS DateTime), NULL, 2, N'asd')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1092, 13, CAST(N'2021-03-15T19:25:42.273' AS DateTime), NULL, 2, N'123')
INSERT [dbo].[LoginHistories] ([ID], [UserID], [LoginDateTime], [LogoutDateTime], [CrashTypeID], [CrashReason]) VALUES (1093, 13, CAST(N'2021-03-15T19:28:00.297' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[LoginHistories] OFF
SET IDENTITY_INSERT [dbo].[Offices] ON 

INSERT [dbo].[Offices] ([ID], [CountryID], [Title], [Phone], [Contact]) VALUES (1, 185, N'Abu dhabi', N'638-757-8582
', N'MIchael Malki')
INSERT [dbo].[Offices] ([ID], [CountryID], [Title], [Phone], [Contact]) VALUES (3, 52, N'Cairo', N'252-224-8525', N'David Johns')
INSERT [dbo].[Offices] ([ID], [CountryID], [Title], [Phone], [Contact]) VALUES (4, 13, N'Bahrain', N'542-227-5825', N'Katie Ballmer')
INSERT [dbo].[Offices] ([ID], [CountryID], [Title], [Phone], [Contact]) VALUES (5, 142, N'Doha', N'758-278-9597', N'Ariel Levy')
INSERT [dbo].[Offices] ([ID], [CountryID], [Title], [Phone], [Contact]) VALUES (6, 152, N'Riyadh', N'285-285-1474', N'Andrew Hobart')
SET IDENTITY_INSERT [dbo].[Offices] OFF
INSERT [dbo].[Roles] ([ID], [Title]) VALUES (1, N'Administrator')
INSERT [dbo].[Roles] ([ID], [Title]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [RoleID], [Email], [Password], [FirstName], [LastName], [OfficeID], [Birthdate], [Active]) VALUES (1, 1, N'j.doe@amonic.com', N'123', N'John', N'Doe', 1, CAST(N'1983-01-13' AS Date), 1)
INSERT [dbo].[Users] ([ID], [RoleID], [Email], [Password], [FirstName], [LastName], [OfficeID], [Birthdate], [Active]) VALUES (2, 2, N'k.omar@amonic.com', N'4258', N'Karim', N'Omar', 1, CAST(N'1980-03-19' AS Date), 1)
INSERT [dbo].[Users] ([ID], [RoleID], [Email], [Password], [FirstName], [LastName], [OfficeID], [Birthdate], [Active]) VALUES (3, 2, N'h.saeed@amonic.com', N'2020', N'Hannan', N'Saeed', 3, CAST(N'1989-12-20' AS Date), 1)
INSERT [dbo].[Users] ([ID], [RoleID], [Email], [Password], [FirstName], [LastName], [OfficeID], [Birthdate], [Active]) VALUES (4, 2, N'a.hobart@amonic.com', N'6996', N'Andrew', N'Hobart', 6, CAST(N'1990-01-30' AS Date), 1)
INSERT [dbo].[Users] ([ID], [RoleID], [Email], [Password], [FirstName], [LastName], [OfficeID], [Birthdate], [Active]) VALUES (5, 2, N'k.anderson@amonic.com', N'4570', N'Katrin', N'Anderson', 5, CAST(N'1992-11-10' AS Date), 1)
INSERT [dbo].[Users] ([ID], [RoleID], [Email], [Password], [FirstName], [LastName], [OfficeID], [Birthdate], [Active]) VALUES (6, 2, N'h.wyrick@amonic.com', N'1199', N'Hava', N'Wyrick', 1, CAST(N'1988-08-08' AS Date), 1)
INSERT [dbo].[Users] ([ID], [RoleID], [Email], [Password], [FirstName], [LastName], [OfficeID], [Birthdate], [Active]) VALUES (7, 2, N'marie.horn@amonic.com', N'55555', N'Marie', N'Horn', 4, CAST(N'1981-04-06' AS Date), 1)
INSERT [dbo].[Users] ([ID], [RoleID], [Email], [Password], [FirstName], [LastName], [OfficeID], [Birthdate], [Active]) VALUES (8, 2, N'm.osteen@amonic.com', N'9800', N'Milagros', N'Osteen', 1, CAST(N'1991-02-03' AS Date), 0)
INSERT [dbo].[Users] ([ID], [RoleID], [Email], [Password], [FirstName], [LastName], [OfficeID], [Birthdate], [Active]) VALUES (13, 1, N'1', N'1', N'Admin', N'Admin', 1, CAST(N'2002-01-12' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[LoginHistories]  WITH CHECK ADD  CONSTRAINT [FK_LoginHistories_CrashTypes] FOREIGN KEY([CrashTypeID])
REFERENCES [dbo].[CrashTypes] ([ID])
GO
ALTER TABLE [dbo].[LoginHistories] CHECK CONSTRAINT [FK_LoginHistories_CrashTypes]
GO
ALTER TABLE [dbo].[LoginHistories]  WITH CHECK ADD  CONSTRAINT [FK_LoginHistories_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[LoginHistories] CHECK CONSTRAINT [FK_LoginHistories_Users]
GO
ALTER TABLE [dbo].[Offices]  WITH CHECK ADD  CONSTRAINT [FK_Office_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID])
GO
ALTER TABLE [dbo].[Offices] CHECK CONSTRAINT [FK_Office_Country]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Offices] FOREIGN KEY([OfficeID])
REFERENCES [dbo].[Offices] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Offices]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [session1] SET  READ_WRITE 
GO
