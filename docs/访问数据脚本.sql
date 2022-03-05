
/****** Object:  Table [dbo].[TypeTags]    Script Date: 12/17/2019 16:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeTags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeid] [int] NOT NULL,
	[groupname] [nvarchar](max) NULL,
	[tagname] [nvarchar](max) NULL,
	[orderno] [int] NOT NULL,
	[crtdate] [datetime] NOT NULL,
	[updatetime] [datetime] NOT NULL,
	[deleteflag] [bit] NOT NULL,
	[pid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TypeTags] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypePics]    Script Date: 12/17/2019 16:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypePics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeid] [int] NOT NULL,
	[orderno] [int] NOT NULL,
	[groupname] [nvarchar](max) NULL,
	[crtdate] [datetime] NOT NULL,
	[updatetime] [datetime] NOT NULL,
	[deleteflag] [bit] NOT NULL,
	[mediatypeid] [int] NOT NULL,
	[mediatypename] [nvarchar](max) NULL,
	[pid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TypePics] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeInfoes]    Script Date: 12/17/2019 16:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeInfoes](
	[typeid] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NOT NULL,
	[orderno] [int] NOT NULL,
	[typename] [nvarchar](max) NULL,
	[editurl] [nvarchar](max) NULL,
	[showurl] [nvarchar](max) NULL,
	[deleteflag] [bit] NOT NULL,
	[crtdate] [datetime] NOT NULL,
	[updatetime] [datetime] NOT NULL,
	[ptypeid] [int] NOT NULL,
	[mobilememo] [nvarchar](max) NULL,
	[isshow] [bit] NOT NULL,
	[existschild] [bit] NOT NULL,
	[existsroom] [bit] NOT NULL,
	[existsscenic] [bit] NOT NULL,
	[wapshowimg] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TypeInfoes] PRIMARY KEY CLUSTERED 
(
	[typeid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeFields]    Script Date: 12/17/2019 16:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeFields](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeid] [int] NOT NULL,
	[fieldname] [nvarchar](max) NULL,
	[groupname] [nvarchar](max) NULL,
	[customname] [nvarchar](max) NULL,
	[isedit] [bit] NOT NULL,
	[orderno] [int] NOT NULL,
	[fieldtype] [nvarchar](max) NULL,
	[crtdate] [datetime] NOT NULL,
	[updatetime] [datetime] NOT NULL,
	[deleteflag] [bit] NOT NULL,
	[pid] [int] NOT NULL,
	[isdisplay] [bit] NOT NULL,
	[displayorder] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TypeFields] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PubUnitTags]    Script Date: 12/17/2019 16:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PubUnitTags](
	[unitid] [int] NOT NULL,
	[tagid] [int] NOT NULL,
	[tagvalue] [nvarchar](max) NULL,
	[unittagid] [int] NOT NULL,
	[pid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PubUnitTags] PRIMARY KEY CLUSTERED 
(
	[unittagid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PubMediaInfoes]    Script Date: 12/17/2019 16:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PubMediaInfoes](
	[mediaid] [int] NOT NULL,
	[pid] [int] NOT NULL,
	[unitid] [int] NOT NULL,
	[typepicid] [int] NOT NULL,
	[orderno] [decimal](18, 2) NOT NULL,
	[medianame] [nvarchar](max) NULL,
	[desc] [nvarchar](max) NULL,
	[memo] [nvarchar](max) NULL,
	[mediaurl] [nvarchar](max) NULL,
	[isshow] [bit] NOT NULL,
	[crtdate] [datetime] NOT NULL,
	[updatetime] [datetime] NOT NULL,
	[deleteflag] [bit] NOT NULL,
	[videourl] [nvarchar](max) NULL,
	[mediatypeid] [int] NOT NULL,
	[topshow] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.PubMediaInfoes] PRIMARY KEY CLUSTERED 
(
	[mediaid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PubInfoUnits]    Script Date: 12/17/2019 16:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PubInfoUnits](
	[unitid] [int] NOT NULL,
	[pid] [int] NOT NULL,
	[typeid] [int] NOT NULL,
	[areacode] [nvarchar](max) NULL,
	[unitname] [nvarchar](max) NULL,
	[shortname] [nvarchar](max) NULL,
	[orderno] [decimal](18, 2) NOT NULL,
	[address] [nvarchar](max) NULL,
	[postcode] [nvarchar](max) NULL,
	[zonecode] [nvarchar](max) NULL,
	[telephone] [nvarchar](max) NULL,
	[infotel] [nvarchar](max) NULL,
	[booktel] [nvarchar](max) NULL,
	[complainttel] [nvarchar](max) NULL,
	[fax] [nvarchar](max) NULL,
	[url] [nvarchar](max) NULL,
	[url360] [nvarchar](max) NULL,
	[logopic] [nvarchar](max) NULL,
	[flagpic] [nvarchar](max) NULL,
	[publictrafic] [nvarchar](max) NULL,
	[desc] [nvarchar](max) NULL,
	[manager] [nvarchar](max) NULL,
	[managertel] [nvarchar](max) NULL,
	[businesslicense] [nvarchar](max) NULL,
	[businesstime] [nvarchar](max) NULL,
	[level] [int] NOT NULL,
	[sourcefrom] [int] NOT NULL,
	[state] [int] NOT NULL,
	[opentime] [nvarchar](max) NULL,
	[decorationtime] [nvarchar](max) NULL,
	[tips] [nvarchar](max) NULL,
	[favouredpolicy] [nvarchar](max) NULL,
	[innertrafic] [nvarchar](max) NULL,
	[maxcapacity] [int] NOT NULL,
	[ticketprice] [decimal](18, 2) NOT NULL,
	[pricedesc] [nvarchar](max) NULL,
	[id5a] [int] NOT NULL,
	[name5a] [nvarchar](max) NULL,
	[roomcount] [int] NOT NULL,
	[bedcount] [int] NOT NULL,
	[roomprice] [decimal](18, 2) NOT NULL,
	[boxcount] [int] NOT NULL,
	[seatcount] [int] NOT NULL,
	[personprice] [decimal](18, 2) NOT NULL,
	[licenseno] [nvarchar](max) NULL,
	[mainline] [nvarchar](max) NULL,
	[poitypename] [nvarchar](max) NULL,
	[poitypetag] [nvarchar](max) NULL,
	[detailurl] [nvarchar](max) NULL,
	[overallrating] [nvarchar](max) NULL,
	[servicerating] [nvarchar](max) NULL,
	[environmentrating] [nvarchar](max) NULL,
	[facilityrating] [nvarchar](max) NULL,
	[hygienerating] [nvarchar](max) NULL,
	[imgnum] [int] NOT NULL,
	[commentnum] [int] NOT NULL,
	[reservefield1] [nvarchar](max) NULL,
	[reservefield2] [nvarchar](max) NULL,
	[reservefield3] [nvarchar](max) NULL,
	[reservefield4] [nvarchar](max) NULL,
	[reservefield5] [nvarchar](max) NULL,
	[reservefield6] [nvarchar](max) NULL,
	[reservefield7] [nvarchar](max) NULL,
	[reservefield8] [nvarchar](max) NULL,
	[reservefield9] [nvarchar](max) NULL,
	[memo] [nvarchar](max) NULL,
	[crtdate] [datetime] NOT NULL,
	[updatetime] [datetime] NOT NULL,
	[deleteflag] [bit] NOT NULL,
	[gpsbd] [nvarchar](max) NULL,
	[gps] [nvarchar](max) NULL,
	[gpsgd] [nvarchar](max) NULL,
	[areaname] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PubInfoUnits] PRIMARY KEY CLUSTERED 
(
	[unitid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PubInfoUnitChilds]    Script Date: 12/17/2019 16:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PubInfoUnitChilds](
	[childid] [int] NOT NULL,
	[unitid] [int] NOT NULL,
	[childname] [nvarchar](max) NULL,
	[orderno] [int] NOT NULL,
	[flagurl] [nvarchar](max) NULL,
	[price] [nvarchar](max) NULL,
	[desc] [nvarchar](max) NULL,
	[memo] [nvarchar](max) NULL,
	[guidevoice] [nvarchar](max) NULL,
	[guidetext] [nvarchar](max) NULL,
	[gpsbd] [nvarchar](max) NULL,
	[gps] [nvarchar](max) NULL,
	[gpsgd] [nvarchar](max) NULL,
	[crtdate] [datetime] NOT NULL,
	[updatetime] [datetime] NOT NULL,
	[deleteflag] [bit] NOT NULL,
	[isshow] [bit] NOT NULL,
	[pid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PubInfoUnitChilds] PRIMARY KEY CLUSTERED 
(
	[childid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PubInfoUnitChildMedias]    Script Date: 12/17/2019 16:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PubInfoUnitChildMedias](
	[childmid] [int] NOT NULL,
	[unitid] [int] NOT NULL,
	[childid] [int] NOT NULL,
	[orderno] [int] NOT NULL,
	[picname] [nvarchar](max) NULL,
	[picurl] [nvarchar](max) NULL,
	[desc] [nvarchar](max) NULL,
	[crtdate] [datetime] NOT NULL,
	[updatetime] [datetime] NOT NULL,
	[deleteflag] [bit] NOT NULL,
	[pid] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PubInfoUnitChildMedias] PRIMARY KEY CLUSTERED 
(
	[childmid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectInfoes]    Script Date: 12/17/2019 16:09:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectInfoes](
	[pid] [int] IDENTITY(1,1) NOT NULL,
	[pname] [nvarchar](max) NULL,
	[homeurl] [nvarchar](max) NULL,
	[areacode] [nvarchar](max) NULL,
	[desc] [nvarchar](max) NULL,
	[crtdate] [datetime] NOT NULL,
	[updatetime] [datetime] NOT NULL,
	[deleteflag] [bit] NOT NULL,
	[topvideourl] [nvarchar](max) NULL,
	[toppicurl] [nvarchar](max) NULL,
	[detailhead] [nvarchar](max) NULL,
	[detailfoot] [nvarchar](max) NULL,
	[topjumpurl] [nvarchar](max) NULL,
	[topresourceurl] [nvarchar](max) NULL,
	[wapbgimg] [nvarchar](max) NULL,
	[appid] [nvarchar](max) NULL,
	[defaultlogo] [nvarchar](max) NULL,
	[subpid] [int] NOT NULL,
	[iscomment] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ProjectInfoes] PRIMARY KEY CLUSTERED 
(
	[pid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__ProjectIn__updat__1332DBDC]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[ProjectInfoes] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [updatetime]
GO
/****** Object:  Default [DF__ProjectIn__delet__1F98B2C1]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[ProjectInfoes] ADD  DEFAULT ((0)) FOR [deleteflag]
GO
/****** Object:  Default [DF__ProjectIn__subpi__67DE6983]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[ProjectInfoes] ADD  DEFAULT ((0)) FOR [subpid]
GO
/****** Object:  Default [DF__ProjectIn__iscom__68D28DBC]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[ProjectInfoes] ADD  DEFAULT ((0)) FOR [iscomment]
GO
/****** Object:  Default [DF__PubInfoUnit__pid__251C81ED]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnitChildMedias] ADD  DEFAULT ((0)) FOR [pid]
GO
/****** Object:  Default [DF__PubInfoUnit__pid__2610A626]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnitChilds] ADD  DEFAULT ((0)) FOR [pid]
GO
/****** Object:  Default [DF__PubInfoUn__maxca__74AE54BC]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [maxcapacity]
GO
/****** Object:  Default [DF__PubInfoUn__ticke__75A278F5]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [ticketprice]
GO
/****** Object:  Default [DF__PubInfoUni__id5a__76969D2E]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [id5a]
GO
/****** Object:  Default [DF__PubInfoUn__roomc__778AC167]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [roomcount]
GO
/****** Object:  Default [DF__PubInfoUn__bedco__787EE5A0]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [bedcount]
GO
/****** Object:  Default [DF__PubInfoUn__roomp__797309D9]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [roomprice]
GO
/****** Object:  Default [DF__PubInfoUn__boxco__7A672E12]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [boxcount]
GO
/****** Object:  Default [DF__PubInfoUn__seatc__7B5B524B]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [seatcount]
GO
/****** Object:  Default [DF__PubInfoUn__perso__7C4F7684]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [personprice]
GO
/****** Object:  Default [DF__PubInfoUn__imgnu__7D439ABD]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [imgnum]
GO
/****** Object:  Default [DF__PubInfoUn__comme__7E37BEF6]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [commentnum]
GO
/****** Object:  Default [DF__PubInfoUn__crtda__09A971A2]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [crtdate]
GO
/****** Object:  Default [DF__PubInfoUn__updat__0A9D95DB]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [updatetime]
GO
/****** Object:  Default [DF__PubInfoUn__delet__22751F6C]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubInfoUnits] ADD  DEFAULT ((0)) FOR [deleteflag]
GO
/****** Object:  Default [DF__PubMediaI__media__345EC57D]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubMediaInfoes] ADD  DEFAULT ((0)) FOR [mediatypeid]
GO
/****** Object:  Default [DF__PubMediaI__topsh__44952D46]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubMediaInfoes] ADD  DEFAULT ((0)) FOR [topshow]
GO
/****** Object:  Default [DF__PubUnitTa__unitt__7A3223E8]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubUnitTags] ADD  DEFAULT ((0)) FOR [unittagid]
GO
/****** Object:  Default [DF__PubUnitTags__pid__29E1370A]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[PubUnitTags] ADD  DEFAULT ((0)) FOR [pid]
GO
/****** Object:  Default [DF__TypeField__order__498EEC8D]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeFields] ADD  DEFAULT ((0)) FOR [orderno]
GO
/****** Object:  Default [DF__TypeField__crtda__13F1F5EB]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeFields] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [crtdate]
GO
/****** Object:  Default [DF__TypeField__updat__14E61A24]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeFields] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [updatetime]
GO
/****** Object:  Default [DF__TypeField__delet__15DA3E5D]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeFields] ADD  DEFAULT ((0)) FOR [deleteflag]
GO
/****** Object:  Default [DF__TypeFields__pid__1E6F845E]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeFields] ADD  DEFAULT ((0)) FOR [pid]
GO
/****** Object:  Default [DF__TypeField__isdis__4589517F]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeFields] ADD  DEFAULT ((0)) FOR [isdisplay]
GO
/****** Object:  Default [DF__TypeField__displ__467D75B8]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeFields] ADD  DEFAULT ((0)) FOR [displayorder]
GO
/****** Object:  Default [DF__TypeInfoe__ptype__7F2BE32F]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeInfoes] ADD  DEFAULT ((0)) FOR [ptypeid]
GO
/****** Object:  Default [DF__TypeInfoe__issho__03F0984C]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeInfoes] ADD  DEFAULT ((0)) FOR [isshow]
GO
/****** Object:  Default [DF__TypeInfoe__exist__04E4BC85]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeInfoes] ADD  DEFAULT ((0)) FOR [existschild]
GO
/****** Object:  Default [DF__TypeInfoe__exist__4D5F7D71]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeInfoes] ADD  DEFAULT ((0)) FOR [existsroom]
GO
/****** Object:  Default [DF__TypeInfoe__exist__12FDD1B2]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeInfoes] ADD  DEFAULT ((0)) FOR [existsscenic]
GO
/****** Object:  Default [DF__TypePics__ordern__0D7A0286]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypePics] ADD  DEFAULT ((0)) FOR [orderno]
GO
/****** Object:  Default [DF__TypePics__crtdat__160F4887]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypePics] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [crtdate]
GO
/****** Object:  Default [DF__TypePics__update__17036CC0]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypePics] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [updatetime]
GO
/****** Object:  Default [DF__TypePics__delete__236943A5]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypePics] ADD  DEFAULT ((0)) FOR [deleteflag]
GO
/****** Object:  Default [DF__TypePics__mediat__76619304]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypePics] ADD  DEFAULT ((0)) FOR [mediatypeid]
GO
/****** Object:  Default [DF__TypePics__pid__1F63A897]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypePics] ADD  DEFAULT ((0)) FOR [pid]
GO
/****** Object:  Default [DF__TypeTags__ordern__0E6E26BF]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeTags] ADD  DEFAULT ((0)) FOR [orderno]
GO
/****** Object:  Default [DF__TypeTags__crtdat__17F790F9]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeTags] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [crtdate]
GO
/****** Object:  Default [DF__TypeTags__update__18EBB532]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeTags] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [updatetime]
GO
/****** Object:  Default [DF__TypeTags__delete__245D67DE]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeTags] ADD  DEFAULT ((0)) FOR [deleteflag]
GO
/****** Object:  Default [DF__TypeTags__pid__2057CCD0]    Script Date: 12/17/2019 16:09:24 ******/
ALTER TABLE [dbo].[TypeTags] ADD  DEFAULT ((0)) FOR [pid]
GO
