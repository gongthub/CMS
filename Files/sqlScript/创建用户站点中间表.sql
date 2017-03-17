CREATE TABLE Sys_UserWebSites
(
	Id varchar(50) PRIMARY KEY not null,
	UserId varchar(50),
	WebSiteId varchar(50),
	EnabledMark bit NULL,
	DeleteMark bit NULL, 
	CreatorUserId varchar(50) NULL,
	CreatorTime datetime NULL,
	DeleteUserId varchar(50) NULL,
	DeleteTime datetime NULL,
	LastModifyTime datetime NULL,
	LastModifyUserId varchar(50) NULL
)