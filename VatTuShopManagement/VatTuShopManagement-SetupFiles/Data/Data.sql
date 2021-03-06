USE [master]
GO
/****** Object:  Database [QLSatThep]    Script Date: 8/24/2019 1:20:26 PM ******/
CREATE DATABASE [QLSatThep] ON  PRIMARY 
( NAME = N'QLSatThep', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLSatThep.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLSatThep_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLSatThep_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLSatThep].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLSatThep] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLSatThep] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLSatThep] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLSatThep] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLSatThep] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLSatThep] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLSatThep] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLSatThep] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLSatThep] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLSatThep] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLSatThep] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLSatThep] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLSatThep] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLSatThep] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLSatThep] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLSatThep] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLSatThep] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLSatThep] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLSatThep] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLSatThep] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLSatThep] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLSatThep] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLSatThep] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLSatThep] SET  MULTI_USER 
GO
ALTER DATABASE [QLSatThep] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLSatThep] SET DB_CHAINING OFF 
GO
USE [QLSatThep]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 8/24/2019 1:20:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] 
( @strInput NVARCHAR(4000) ) 
RETURNS NVARCHAR(4000) 
AS 
BEGIN 
IF @strInput IS NULL 
	RETURN @strInput 
IF @strInput = '' 
	RETURN @strInput 
DECLARE @RT NVARCHAR(4000) 
DECLARE @SIGN_CHARS NCHAR(136) 
DECLARE @UNSIGN_CHARS NCHAR (136) 
SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) 
SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
DECLARE @COUNTER int 
DECLARE @COUNTER1 int 
SET @COUNTER = 1 
WHILE (@COUNTER <=LEN(@strInput)) 
BEGIN 
	SET @COUNTER1 = 1 
	WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
	BEGIN 
		IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
		BEGIN 
			IF @COUNTER=1 
				SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
			ELSE 
				SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
				BREAK 
		END 
		SET @COUNTER1 = @COUNTER1 +1 
	END 
	SET @COUNTER = @COUNTER +1 
END SET @strInput = replace(@strInput,' ','-') 
RETURN @strInput 
END
GO
/****** Object:  Table [dbo].[ACCOUNT]    Script Date: 8/24/2019 1:20:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACCOUNT](
	[Username] [varchar](25) NOT NULL,
	[Password] [varchar](1000) NOT NULL,
	[First_Name] [nvarchar](100) NULL,
	[Last_Name] [nvarchar](100) NULL,
	[Phone_Number] [char](11) NULL,
	[Address] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 8/24/2019 1:20:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[ID_CTHD] [int] IDENTITY(1,1) NOT NULL,
	[ID_PHIEU] [int] NOT NULL,
	[ID_VATTU] [int] NOT NULL,
	[SO_LUONG] [int] NOT NULL DEFAULT ((0)),
	[THANH_TIEN] [money] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_CTHD] PRIMARY KEY CLUSTERED 
(
	[ID_CTHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHITIETPHIEUNHAP]    Script Date: 8/24/2019 1:20:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETPHIEUNHAP](
	[ID_CTPN] [int] IDENTITY(1,1) NOT NULL,
	[ID_PHIEU] [int] NOT NULL,
	[ID_VATTU] [int] NOT NULL,
	[SO_LUONG] [int] NOT NULL DEFAULT ((0)),
	[THANH_TIEN] [money] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_CTPN] PRIMARY KEY CLUSTERED 
(
	[ID_CTPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DINHMUCVATTU]    Script Date: 8/24/2019 1:20:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DINHMUCVATTU](
	[ID_DINHMUC] [int] IDENTITY(1,1) NOT NULL,
	[ID_PHIEU] [int] NOT NULL,
	[ID_VATTU] [int] NOT NULL,
	[SO_LUONG] [int] NOT NULL,
	[THANH_TIEN] [money] NOT NULL,
 CONSTRAINT [PK_DINHMUCVATTU] PRIMARY KEY CLUSTERED 
(
	[ID_DINHMUC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 8/24/2019 1:20:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOADON](
	[ID_HD] [int] IDENTITY(1,1) NOT NULL,
	[ID_PHIEU] [int] NOT NULL,
	[TEN_KH] [nvarchar](55) NOT NULL,
	[SDT_KH] [char](11) NOT NULL,
	[NGAYXUATHD] [date] NOT NULL DEFAULT (getdate()),
	[THANHTIEN] [money] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[ID_HD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAIVATTU]    Script Date: 8/24/2019 1:20:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOAIVATTU](
	[MALOAI] [char](5) NOT NULL,
	[TENLOAI] [nvarchar](55) NOT NULL,
 CONSTRAINT [PK_LOAIVATTU] PRIMARY KEY CLUSTERED 
(
	[MALOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 8/24/2019 1:20:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MA_NCC] [char](15) NOT NULL,
	[TENNHACC] [nvarchar](55) NOT NULL,
	[SDT_NCC] [char](11) NOT NULL,
	[EMAIL] [char](100) NOT NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY CLUSTERED 
(
	[MA_NCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHIEU]    Script Date: 8/24/2019 1:20:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEU](
	[ID_PHIEU] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PHIEU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 8/24/2019 1:20:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[ID_PHIEUNHAP] [int] IDENTITY(1,1) NOT NULL,
	[MA_NCC] [char](15) NOT NULL,
	[ID_PHIEU] [int] NOT NULL,
	[NGAYNHAP] [date] NOT NULL DEFAULT (getdate()),
	[TONGGIATRI] [money] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_PHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[ID_PHIEUNHAP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TAMTINH]    Script Date: 8/24/2019 1:20:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAMTINH](
	[ID_TT] [int] IDENTITY(1,1) NOT NULL,
	[ID_PHIEU] [int] NOT NULL,
	[TEN_KH] [nvarchar](55) NOT NULL,
	[SDT_KH] [char](11) NOT NULL,
	[NGAYTAMTINH] [date] NOT NULL,
	[THANHTIEN] [money] NOT NULL,
 CONSTRAINT [PK_TAMTINH] PRIMARY KEY CLUSTERED 
(
	[ID_TT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VATTU]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VATTU](
	[ID_VATTU] [int] IDENTITY(1,1) NOT NULL,
	[MALOAI] [char](5) NOT NULL,
	[TENVATTU] [nvarchar](55) NOT NULL,
	[DVT] [nvarchar](5) NOT NULL,
	[DONGIA] [money] NOT NULL DEFAULT ((0)),
	[SOLUONGTON] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_VATTU] PRIMARY KEY CLUSTERED 
(
	[ID_VATTU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ACCOUNT] ([Username], [Password], [First_Name], [Last_Name], [Phone_Number], [Address]) VALUES (N'linhnguyen', N'2251022057731868917119086224872421513662', N'', N'', N'           ', N'')
INSERT [dbo].[ACCOUNT] ([Username], [Password], [First_Name], [Last_Name], [Phone_Number], [Address]) VALUES (N'linhvip', N'2522341461511618181218123224207661842015589', N'', N'', N'           ', N'')
SET IDENTITY_INSERT [dbo].[CHITIETHOADON] ON 

INSERT [dbo].[CHITIETHOADON] ([ID_CTHD], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (1, 7, 1, 20, 2000000.0000)
INSERT [dbo].[CHITIETHOADON] ([ID_CTHD], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (3, 7, 3, 10, 1200000.0000)
INSERT [dbo].[CHITIETHOADON] ([ID_CTHD], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (4, 8, 6, 10, 120000.0000)
INSERT [dbo].[CHITIETHOADON] ([ID_CTHD], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (7, 11, 1, 1, 100000.0000)
INSERT [dbo].[CHITIETHOADON] ([ID_CTHD], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (8, 12, 1, 1, 100000.0000)
INSERT [dbo].[CHITIETHOADON] ([ID_CTHD], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (14, 41, 1, 13, 1300000.0000)
INSERT [dbo].[CHITIETHOADON] ([ID_CTHD], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (15, 41, 3, 10, 1200000.0000)
INSERT [dbo].[CHITIETHOADON] ([ID_CTHD], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (16, 43, 1, 1, 100000.0000)
INSERT [dbo].[CHITIETHOADON] ([ID_CTHD], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (17, 43, 11, 2, 24000.0000)
SET IDENTITY_INSERT [dbo].[CHITIETHOADON] OFF
SET IDENTITY_INSERT [dbo].[CHITIETPHIEUNHAP] ON 

INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (1, 2, 6, 6, 72000.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (2, 2, 7, 100, 3000000.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (3, 2, 8, 15, 225.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (4, 3, 8, 5, 150.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (7, 6, 1, 50, 5000000.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (8, 6, 3, 50, 6000000.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (9, 18, 1, 1, 100000.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (10, 19, 8, 1, 30.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (11, 20, 9, 1, 5.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (12, 21, 9, 2, 10.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (13, 22, 9, 1, 5.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (14, 23, 9, 2, 10.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (15, 24, 9, 1, 5.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (17, 28, 9, 1, 5.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (18, 42, 11, 100, 1200000.0000)
INSERT [dbo].[CHITIETPHIEUNHAP] ([ID_CTPN], [ID_PHIEU], [ID_VATTU], [SO_LUONG], [THANH_TIEN]) VALUES (19, 42, 10, 3, 36.0000)
SET IDENTITY_INSERT [dbo].[CHITIETPHIEUNHAP] OFF
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([ID_HD], [ID_PHIEU], [TEN_KH], [SDT_KH], [NGAYXUATHD], [THANHTIEN]) VALUES (1, 7, N'Linh Nguyễn ', N'0374451155 ', CAST(N'2019-08-21' AS Date), 3200000.0000)
INSERT [dbo].[HOADON] ([ID_HD], [ID_PHIEU], [TEN_KH], [SDT_KH], [NGAYXUATHD], [THANHTIEN]) VALUES (2, 8, N'AAAAAa', N'124445     ', CAST(N'2019-08-22' AS Date), 120000.0000)
INSERT [dbo].[HOADON] ([ID_HD], [ID_PHIEU], [TEN_KH], [SDT_KH], [NGAYXUATHD], [THANHTIEN]) VALUES (3, 11, N'ee', N'ee         ', CAST(N'2020-01-21' AS Date), 100000.0000)
INSERT [dbo].[HOADON] ([ID_HD], [ID_PHIEU], [TEN_KH], [SDT_KH], [NGAYXUATHD], [THANHTIEN]) VALUES (4, 12, N'ggg', N'hhh        ', CAST(N'2019-06-21' AS Date), 100000.0000)
INSERT [dbo].[HOADON] ([ID_HD], [ID_PHIEU], [TEN_KH], [SDT_KH], [NGAYXUATHD], [THANHTIEN]) VALUES (10, 41, N'Linh', N'12345678   ', CAST(N'2019-07-22' AS Date), 2500000.0000)
INSERT [dbo].[HOADON] ([ID_HD], [ID_PHIEU], [TEN_KH], [SDT_KH], [NGAYXUATHD], [THANHTIEN]) VALUES (11, 43, N'nhut cho', N'0987654321 ', CAST(N'2019-08-22' AS Date), 124000.0000)
SET IDENTITY_INSERT [dbo].[HOADON] OFF
INSERT [dbo].[LOAIVATTU] ([MALOAI], [TENLOAI]) VALUES (N'1    ', N'3')
INSERT [dbo].[LOAIVATTU] ([MALOAI], [TENLOAI]) VALUES (N'H    ', N'Chữ nhật')
INSERT [dbo].[LOAIVATTU] ([MALOAI], [TENLOAI]) VALUES (N'T    ', N'Tròn')
INSERT [dbo].[LOAIVATTU] ([MALOAI], [TENLOAI]) VALUES (N'V    ', N'Vuông')
INSERT [dbo].[NHACUNGCAP] ([MA_NCC], [TENNHACC], [SDT_NCC], [EMAIL]) VALUES (N'N001           ', N'Hòa Phát', N'0123456789 ', N'linhvip1998vl@gmail.com                                                                             ')
INSERT [dbo].[NHACUNGCAP] ([MA_NCC], [TENNHACC], [SDT_NCC], [EMAIL]) VALUES (N'N002           ', N'Cát Đằng', N'085379829  ', N'catdang@satthep.vn                                                                                  ')
SET IDENTITY_INSERT [dbo].[PHIEU] ON 

INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (2)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (3)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (6)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (7)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (8)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (11)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (12)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (13)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (14)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (15)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (16)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (17)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (18)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (19)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (20)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (21)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (22)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (23)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (24)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (25)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (26)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (27)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (28)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (29)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (30)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (31)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (32)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (33)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (34)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (35)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (36)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (37)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (38)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (39)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (40)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (41)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (42)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (43)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (44)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (45)
INSERT [dbo].[PHIEU] ([ID_PHIEU]) VALUES (46)
SET IDENTITY_INSERT [dbo].[PHIEU] OFF
SET IDENTITY_INSERT [dbo].[PHIEUNHAP] ON 

INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (1, N'N002           ', 2, CAST(N'2019-08-21' AS Date), 100000.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (2, N'N001           ', 3, CAST(N'2019-08-21' AS Date), 51000.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (3, N'N001           ', 6, CAST(N'2019-08-21' AS Date), 230000.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (4, N'N001           ', 18, CAST(N'2019-08-22' AS Date), 1223333.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (5, N'N001           ', 19, CAST(N'2019-08-22' AS Date), 123.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (6, N'N001           ', 20, CAST(N'2019-08-22' AS Date), 123.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (7, N'N001           ', 21, CAST(N'2019-08-22' AS Date), 123.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (8, N'N001           ', 22, CAST(N'2019-08-22' AS Date), 555.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (9, N'N001           ', 23, CAST(N'2019-08-22' AS Date), 123.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (10, N'N001           ', 24, CAST(N'2019-08-22' AS Date), 123456.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (11, N'N002           ', 25, CAST(N'2019-08-22' AS Date), 123.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (13, N'N001           ', 27, CAST(N'2019-08-22' AS Date), 1233.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (14, N'N001           ', 28, CAST(N'2019-08-22' AS Date), 12.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (15, N'N001           ', 29, CAST(N'2019-08-22' AS Date), 12.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (16, N'N002           ', 30, CAST(N'2019-08-22' AS Date), 12.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (17, N'N001           ', 32, CAST(N'2019-08-22' AS Date), 12.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (18, N'N002           ', 33, CAST(N'2019-08-22' AS Date), 12.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (19, N'N002           ', 34, CAST(N'2019-08-22' AS Date), 12.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (20, N'N001           ', 35, CAST(N'2019-08-22' AS Date), 12.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (21, N'N002           ', 36, CAST(N'2019-08-22' AS Date), 1333.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (22, N'N002           ', 37, CAST(N'2019-08-22' AS Date), 33333.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (23, N'N002           ', 38, CAST(N'2019-08-22' AS Date), 33333.0000)
INSERT [dbo].[PHIEUNHAP] ([ID_PHIEUNHAP], [MA_NCC], [ID_PHIEU], [NGAYNHAP], [TONGGIATRI]) VALUES (26, N'N001           ', 42, CAST(N'2019-08-22' AS Date), 12000.0000)
SET IDENTITY_INSERT [dbo].[PHIEUNHAP] OFF
SET IDENTITY_INSERT [dbo].[VATTU] ON 

INSERT [dbo].[VATTU] ([ID_VATTU], [MALOAI], [TENVATTU], [DVT], [DONGIA], [SOLUONGTON]) VALUES (1, N'T    ', N'T02x02 2mmx2mm', N'cây', 100000.0000, 108)
INSERT [dbo].[VATTU] ([ID_VATTU], [MALOAI], [TENVATTU], [DVT], [DONGIA], [SOLUONGTON]) VALUES (3, N'V    ', N'V12x12', N'cây', 120000.0000, 130)
INSERT [dbo].[VATTU] ([ID_VATTU], [MALOAI], [TENVATTU], [DVT], [DONGIA], [SOLUONGTON]) VALUES (6, N'T    ', N'r', N'r', 12000.0000, 8)
INSERT [dbo].[VATTU] ([ID_VATTU], [MALOAI], [TENVATTU], [DVT], [DONGIA], [SOLUONGTON]) VALUES (7, N'H    ', N'P29', N'súng', 30000.0000, 100)
INSERT [dbo].[VATTU] ([ID_VATTU], [MALOAI], [TENVATTU], [DVT], [DONGIA], [SOLUONGTON]) VALUES (8, N'1    ', N'ffff', N'fff', 30.0000, 21)
INSERT [dbo].[VATTU] ([ID_VATTU], [MALOAI], [TENVATTU], [DVT], [DONGIA], [SOLUONGTON]) VALUES (9, N'H    ', N'g', N'r', 5.0000, 14)
INSERT [dbo].[VATTU] ([ID_VATTU], [MALOAI], [TENVATTU], [DVT], [DONGIA], [SOLUONGTON]) VALUES (10, N'1    ', N'ggg', N'gg', 12.0000, 15)
INSERT [dbo].[VATTU] ([ID_VATTU], [MALOAI], [TENVATTU], [DVT], [DONGIA], [SOLUONGTON]) VALUES (11, N'H    ', N'súng', N'cây', 12000.0000, 98)
SET IDENTITY_INSERT [dbo].[VATTU] OFF
ALTER TABLE [dbo].[DINHMUCVATTU] ADD  DEFAULT ((0)) FOR [SO_LUONG]
GO
ALTER TABLE [dbo].[DINHMUCVATTU] ADD  DEFAULT ((0)) FOR [THANH_TIEN]
GO
ALTER TABLE [dbo].[TAMTINH] ADD  DEFAULT (getdate()) FOR [NGAYTAMTINH]
GO
ALTER TABLE [dbo].[TAMTINH] ADD  DEFAULT ((0)) FOR [THANHTIEN]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [fk_PHIEU_maPHIEU_CTHD] FOREIGN KEY([ID_PHIEU])
REFERENCES [dbo].[PHIEU] ([ID_PHIEU])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [fk_PHIEU_maPHIEU_CTHD]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [fk_VATTU_maVATTU_CTHD] FOREIGN KEY([ID_VATTU])
REFERENCES [dbo].[VATTU] ([ID_VATTU])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [fk_VATTU_maVATTU_CTHD]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [fk_PHIEU_maPHIEU_CTPN] FOREIGN KEY([ID_PHIEU])
REFERENCES [dbo].[PHIEU] ([ID_PHIEU])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [fk_PHIEU_maPHIEU_CTPN]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [fk_VATTU_maVATTU_CTPN] FOREIGN KEY([ID_VATTU])
REFERENCES [dbo].[VATTU] ([ID_VATTU])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [fk_VATTU_maVATTU_CTPN]
GO
ALTER TABLE [dbo].[DINHMUCVATTU]  WITH CHECK ADD  CONSTRAINT [fk_PHIEU_maPHIEU_DMVT] FOREIGN KEY([ID_PHIEU])
REFERENCES [dbo].[PHIEU] ([ID_PHIEU])
GO
ALTER TABLE [dbo].[DINHMUCVATTU] CHECK CONSTRAINT [fk_PHIEU_maPHIEU_DMVT]
GO
ALTER TABLE [dbo].[DINHMUCVATTU]  WITH CHECK ADD  CONSTRAINT [fk_VATTU_maVATTU_DMVT] FOREIGN KEY([ID_VATTU])
REFERENCES [dbo].[VATTU] ([ID_VATTU])
GO
ALTER TABLE [dbo].[DINHMUCVATTU] CHECK CONSTRAINT [fk_VATTU_maVATTU_DMVT]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [fk_PHIEU_maPHIEU_HOADON] FOREIGN KEY([ID_PHIEU])
REFERENCES [dbo].[PHIEU] ([ID_PHIEU])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [fk_PHIEU_maPHIEU_HOADON]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [fk_NCC_maNCC_PHIEUNHAP] FOREIGN KEY([MA_NCC])
REFERENCES [dbo].[NHACUNGCAP] ([MA_NCC])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [fk_NCC_maNCC_PHIEUNHAP]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [fk_PHIEU_maPHIEU_PHIEUNHAP] FOREIGN KEY([ID_PHIEU])
REFERENCES [dbo].[PHIEU] ([ID_PHIEU])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [fk_PHIEU_maPHIEU_PHIEUNHAP]
GO
ALTER TABLE [dbo].[TAMTINH]  WITH CHECK ADD  CONSTRAINT [fk_PHIEU_maPHIEU_TAMTINH] FOREIGN KEY([ID_PHIEU])
REFERENCES [dbo].[PHIEU] ([ID_PHIEU])
GO
ALTER TABLE [dbo].[TAMTINH] CHECK CONSTRAINT [fk_PHIEU_maPHIEU_TAMTINH]
GO
ALTER TABLE [dbo].[VATTU]  WITH CHECK ADD  CONSTRAINT [fk_Loaivt_maloai_vattu] FOREIGN KEY([MALOAI])
REFERENCES [dbo].[LOAIVATTU] ([MALOAI])
GO
ALTER TABLE [dbo].[VATTU] CHECK CONSTRAINT [fk_Loaivt_maloai_vattu]
GO
/****** Object:  StoredProcedure [dbo].[Add_ChiTietPhieuNhap]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Add_ChiTietPhieuNhap]
@soluong int, @dongia money
as
begin
	declare @idphieu int, @thanhtien money, @idvattu int
	set @idphieu = (SELECT top 1 * FROM PHIEU order by ID_PHIEU desc);
	set @idvattu = (SELECT top 1 ID_VATTU FROM VATTU order by ID_VATTU desc);
	set @thanhtien = @dongia * @soluong
		insert into CHITIETPHIEUNHAP
		values(@idphieu, @idvattu, @soluong, @thanhtien)
end


-----------------------------------------Thủ tục thêm vật tư-----------------------------------------
-----------------------------------------------------------------------------------------------------

GO
/****** Object:  StoredProcedure [dbo].[BaoCaoDoanhThu]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[BaoCaoDoanhThu]
@bcntn nvarchar(25), @ngay int, @thang int , @nam int
as
begin
	if @bcntn = N'Ngày'
		select  ID_PHIEU, TEN_KH, SDT_KH, NGAYXUATHD, PARSENAME(convert(varchar,convert(money,THANHTIEN),1),2 ) as THANHTIEN from HOADON where Day(NGAYXUATHD) = @ngay and Month(NGAYXUATHD) = @thang and Year(NGAYXUATHD) = @nam
	if @bcntn = N'Tháng'
		select ID_PHIEU, TEN_KH, SDT_KH, NGAYXUATHD, PARSENAME(convert(varchar,convert(money,THANHTIEN),1),2 ) as THANHTIEN from HOADON where Month(NGAYXUATHD) = @thang and Year(NGAYXUATHD) = @nam
	if @bcntn = N'Năm'
		select ID_PHIEU, TEN_KH, SDT_KH, NGAYXUATHD, PARSENAME(convert(varchar,convert(money,THANHTIEN),1),2 ) as THANHTIEN from HOADON where Year(NGAYXUATHD) = @nam
end
GO
/****** Object:  StoredProcedure [dbo].[DoanhThuChart]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DoanhThuChart]
@nam int
as
begin
	select format(SUM(THANHTIEN), '###,###,###') AS DOANHTHU, Month(NGAYXUATHD) as THANG from HOADON where Year(NGAYXUATHD) = @nam group by MONTH(NGAYXUATHD) 
end

GO
/****** Object:  StoredProcedure [dbo].[Insert_DinhMuc]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Insert_DinhMuc] 
@id_Vattu int, @Soluong int   
as
begin
declare @id_Phieu int
declare @isExistVatTu int
declare @isExistVatTuCTHD int	
--Lấy id phiếu tạo gần nhất--
set @id_Phieu = (SELECT top 1 * FROM PHIEU order by ID_PHIEU desc);
--Đơn giá * số lượng
declare @ThanhTien money
--Liệt kê ra những vật tư đã tồn tại
select @isExistVatTu = ID_DINHMUC from DINHMUCVATTU where ID_VATTU = @id_Vattu and ID_PHIEU = @id_Phieu
select @isExistVatTuCTHD = ID_CTHD from CHITIETHOADON where ID_VATTU = @id_Vattu and ID_PHIEU = @id_Phieu
set @ThanhTien = (select DONGIA FROM VATTU WHERE ID_VATTU = @id_Vattu)  * @Soluong
if(@isExistVatTu > 0)
begin 
	declare @SoLuongMoi int = @Soluong
	declare @ThanhTienMoi money
	if (@SoLuongMoi > 0)
	begin
		set @ThanhTienMoi = (select DONGIA FROM VATTU WHERE ID_VATTU = @id_Vattu)  * @SoLuongMoi
		update DINHMUCVATTU set SO_LUONG = @SoLuongMoi, THANH_TIEN = @ThanhTienMoi where ID_PHIEU = @id_Phieu and ID_VATTU = @id_Vattu
	end
	else
		delete DINHMUCVATTU where ID_PHIEU = @id_Phieu and ID_VATTU = @id_Vattu
end
else
begin
	insert into DINHMUCVATTU
	VALUES(@id_Phieu, @id_Vattu, @Soluong, @ThanhTien)
END

if(@isExistVatTuCTHD > 0)
begin 
	declare @SoLuongMoiCTHD int = @Soluong
	declare @ThanhTienMoiCTHD money
	if (@SoLuongMoiCTHD > 0)
	begin
		set @ThanhTienMoiCTHD = (select DONGIA FROM VATTU WHERE ID_VATTU = @id_Vattu)  * @SoLuongMoiCTHD
		update CHITIETHOADON set SO_LUONG = @SoLuongMoiCTHD, THANH_TIEN = @ThanhTienMoiCTHD where ID_PHIEU = @id_Phieu and ID_VATTU = @id_Vattu
	end
	else
		delete CHITIETHOADON where ID_PHIEU = @id_Phieu and ID_VATTU = @id_Vattu
end
else
begin
	insert into CHITIETHOADON
	VALUES(@id_Phieu, @id_Vattu, @Soluong, @ThanhTien)
END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertVatTu]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertVatTu]
@maloai char(5), @tenvt nvarchar(55), @dvt nvarchar(5), @dongia money, @soluong int
as
begin
		IF(SELECT COUNT(TENVATTU) FROM VATTU WHERE TENVATTU = @tenvt) > 0
			print N'Tên vật tư đã tồn tại'
		else
			insert into VATTU values(@maloai, @tenvt, @dvt, @dongia, @soluong)
end

GO
/****** Object:  StoredProcedure [dbo].[LoginManage]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LoginManage]
@username nvarchar(25), @password varchar(1000)
as
begin
	select * from ACCOUNT where Username = @username COLLATE SQL_Latin1_General_CP1_CS_AS and Password = @password COLLATE SQL_Latin1_General_CP1_CS_AS
end

GO
/****** Object:  StoredProcedure [dbo].[PhanTrangHoaDon]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PhanTrangHoaDon]
@page int
as
begin
	declare @pageRows int = 11
	declare @selectRows int = @pageRows  
	declare @exceptRows int = @pageRows * (@page -1) 
	select TOP (@selectRows) ID_HD, ID_PHIEU, TEN_KH, SDT_KH, NGAYXUATHD, PARSENAME(convert(varchar,convert(money,THANHTIEN),1),2 ) as THANHTIEN  from HOADON  where ID_HD not in (select TOP (@exceptRows) ID_HD from HOADON)

END
GO
/****** Object:  StoredProcedure [dbo].[PhanTrangPhieuNhap]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PhanTrangPhieuNhap]
@page int
as
begin
	declare @pageRows int = 11
	declare @selectRows int = @pageRows  
	declare @exceptRows int = @pageRows * (@page -1) 
	select TOP (@selectRows) ID_PHIEUNHAP, PHIEUNHAP.MA_NCC, TENNHACC, ID_PHIEU, NGAYNHAP, PARSENAME(convert(varchar,convert(money,TONGGIATRI),1),2 ) as TONGGIATRI  from PHIEUNHAP, NHACUNGCAP where PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC AND PHIEUNHAP.ID_PHIEUNHAP not in (select TOP (@exceptRows) ID_PHIEUNHAP from PHIEUNHAP)

END
GO
/****** Object:  StoredProcedure [dbo].[Remove_VatTu]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Remove_VatTu]
@ten_vattu nvarchar(55)
as
begin
declare @id_vt int
select @id_vt = ID_VATTU from VATTU where TENVATTU = @ten_vattu 
delete from DINHMUCVATTU where ID_VATTU = @id_vt;
delete from CHITIETHOADON where ID_VATTU = @id_vt; 
end
----------------------------------------------------------------------------
----------------------------------------------------------------------------

-----------------Thủ tục thanh toán tạm tính--------------
-------------------------------------------------

GO
/****** Object:  StoredProcedure [dbo].[Show_DinhMuc]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Show_DinhMuc]
as
begin 
declare @id_Phieu int 
set @id_Phieu = (SELECT top 1 * FROM PHIEU order by ID_PHIEU desc);
select TENVATTU, DVT, DONGIA, SO_LUONG, THANH_TIEN from DINHMUCVATTU, VATTU, PHIEU where VATTU.ID_VATTU = DINHMUCVATTU.ID_VATTU and PHIEU.ID_PHIEU = @id_Phieu
end
GO
/****** Object:  StoredProcedure [dbo].[ShowChiTietPhieuNhap]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ShowChiTietPhieuNhap]
as
begin
	declare @id_phieu int
	set @id_phieu = (select top 1 * from PHIEU order by ID_PHIEU desc) 
	select vt.TENVATTU, vt.DVT, PARSENAME(convert(varchar,convert(money,DONGIA),1),2 ) as DONGIA  , pn.SO_LUONG, PARSENAME(convert(varchar,convert(money,THANH_TIEN),1),2 ) THANH_TIEN  from VATTU as vt, CHITIETPHIEUNHAP as pn where vt.ID_VATTU=pn.ID_VATTU and pn.ID_PHIEU = @id_phieu
end
-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------

GO
/****** Object:  StoredProcedure [dbo].[ShowOrderDetail]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ShowOrderDetail]
as
begin
	declare @id_phieu int
	set @id_phieu = (select top 1 * from PHIEU order by ID_PHIEU desc) 
	select vt.TENVATTU, vt.DVT,  vt.DONGIA  , ct.SO_LUONG, ct.THANH_TIEN  from VATTU as vt, CHITIETHOADON as ct where vt.ID_VATTU=ct.ID_VATTU and ct.ID_PHIEU = @id_phieu
end
-----------------------------------------------

GO
/****** Object:  StoredProcedure [dbo].[ThanhToanHoaDon]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThanhToanHoaDon]
@Ten_kh nvarchar(55), @Sdt_kh char(11), @TongCong money 
as
begin 
declare @id_Phieu int 
set @id_Phieu = (SELECT top 1 * FROM PHIEU order by ID_PHIEU desc);
if @TongCong > 0 
begin
insert into HOADON
values(@id_Phieu, @Ten_kh, @Sdt_kh, getdate(), @TongCong);
end
else
begin   
PRINT N'Lỗi không thể thêm dữ liệu'
end	
--------Xử lý số lượng tồn kho----------------
declare @SoLuong int
declare @idVattu int
declare @MyCursor Cursor
set @MyCursor = CURSOR FAST_FORWARD
FOR
select ID_VATTU, SO_LUONG FROM CHITIETHOADON WHERE ID_PHIEU = @id_Phieu
OPEN @MyCursor
Fetch next from @MyCursor
into @idVattu, @Soluong
while @@FETCH_STATUS = 0
begin

	update VATTU set SOLUONGTON = SOLUONGTON - @SoLuong where ID_VATTU = @idVattu

fetch next from @MyCursor
into @idVattu, @Soluong
end
close @MyCursor
deallocate @MyCursor
-------------------------------
delete from DINHMUCVATTU 

end
----------------------------------------------------------------------------------------------------
--------------------------------------------------Kết thúc thủ tục thanh toán-----------------------

---------------------------------------Xóa vật 1 vật tư ra khỏi định mục-----
-----------------------------------------------------------------------------

GO
/****** Object:  StoredProcedure [dbo].[ThanhToanTamTinh]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThanhToanTamTinh]
@Ten_kh nvarchar(55), @Sdt_kh char(11), @TongCong money 
as
begin 
declare @id_Phieu int 
set @id_Phieu = (SELECT top 1 * FROM PHIEU order by ID_PHIEU desc);
if @TongCong > 0 
begin
insert into TAMTINH
values(@id_Phieu, @Ten_kh, @Sdt_kh, getdate(), @TongCong);
end
else
begin   
PRINT N'Lỗi không thể thêm dữ liệu'
end	
--------Xử lý số lượng tồn kho----------------
declare @SoLuong int
declare @idVattu int
declare @MyCursor Cursor
set @MyCursor = CURSOR FAST_FORWARD
FOR
select ID_VATTU, SO_LUONG FROM CHITIETHOADON WHERE ID_PHIEU = @id_Phieu 
OPEN @MyCursor
Fetch next from @MyCursor
into @idVattu, @Soluong
while @@FETCH_STATUS = 0
begin

update VATTU set SOLUONGTON = SOLUONGTON - @SoLuong where ID_VATTU = @idVattu

fetch next from @MyCursor
into @idVattu, @Soluong
end
close @MyCursor
deallocate @MyCursor
-------------------------------
delete from DINHMUCVATTU 

end
-------------------------------------------------------------------------------------------------------------
--------------------------------------------------Kết thúc thủ tục thanh toán tạm tính-----------------------



--------------------------------------------------Thủ tục Hiển thị chi tiết hóa đơn--------------------------
-------------------------------------------------------------------------------------------------------------

GO
/****** Object:  StoredProcedure [dbo].[TongDoanhThu]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TongDoanhThu]
@bcntn nvarchar(25), @ngay int, @thang int , @nam int
as
begin
	if @bcntn = N'Ngày'
	begin
		select PARSENAME(convert(varchar,convert(money,sum(THANHTIEN)),1),2 ) as THANHTIEN from HOADON where Day(NGAYXUATHD) = @ngay and Month(NGAYXUATHD) = @thang and Year(NGAYXUATHD) = @nam
	end
	if @bcntn = N'Tháng'
	begin
		select PARSENAME(convert(varchar,convert(money,sum(THANHTIEN)),1),2 ) as THANHTIEN from HOADON where Month(NGAYXUATHD) = @thang and Year(NGAYXUATHD) = @nam
	end
	if @bcntn = N'Năm'
	begin
		select PARSENAME(convert(varchar,convert(money,sum(THANHTIEN)),1),2 ) as THANHTIEN from HOADON where Year(NGAYXUATHD) = @nam
	end
end

GO
/****** Object:  StoredProcedure [dbo].[Update_ChiTietNhap]    Script Date: 8/24/2019 1:20:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Update_ChiTietNhap]
@idvattu varchar(55), @soluong int
as
begin
	declare @dongia money, @idphieu int, @thanhtien money, @slhientai int, @isExist int, @soluongmoi int
	set @idphieu = (SELECT top 1 * FROM PHIEU order by ID_PHIEU desc);
	select @dongia = DONGIA from VATTU where ID_VATTU = @idvattu
	select @isExist = count(ID_VATTU) from CHITIETPHIEUNHAP where ID_PHIEU = @idphieu and ID_VATTU = @idvattu
	set @slhientai =  (select SO_LUONG from CHITIETPHIEUNHAP where ID_PHIEU = @idphieu and ID_VATTU = @idvattu)
	if @isExist > 0
	begin
		set @soluongmoi = @soluong + @slhientai
		set @thanhtien = @dongia * @soluongmoi
		update CHITIETPHIEUNHAP set SO_LUONG = @soluongmoi, THANH_TIEN = @thanhtien where ID_PHIEU = @idphieu and ID_VATTU = @idvattu
	end
	else
	begin
		set @thanhtien = @dongia * @soluong
		insert into CHITIETPHIEUNHAP
		values(@idphieu, @idvattu, @soluong, @thanhtien)
	end
end



GO
USE [master]
GO
ALTER DATABASE [QLSatThep] SET  READ_WRITE 
GO
