CREATE TABLE Sys_WebSites
(
	Id varchar(50) PRIMARY KEY not null,
	FullName nvarchar(50),
	UrlAddress varchar(200),
	SortCode int, 
	Point varchar(200),
	ShortName nvarchar(50),
	Icon varchar(50) NULL,
	UserName nvarchar(50),
	Phone nvarchar(50),
	Emaile nvarchar(50),
	Record nvarchar(200),
	VisitorNum bigint,
	LastVistorTime datetime NULL,
	Description nvarchar(2000),
	EnabledMark bit NULL,
	DeleteMark bit NULL,
	MainMark bit NULL,
	CreatorUserId varchar(50) NULL,
	CreatorTime datetime NULL,
	DeleteUserId varchar(50) NULL,
	DeleteTime datetime NULL,
	LastModifyTime datetime NULL,
	LastModifyUserId varchar(50) NULL
)