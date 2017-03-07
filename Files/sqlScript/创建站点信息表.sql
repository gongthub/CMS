CREATE TABLE Sys_WebSite
(
	F_Id varchar(50) PRIMARY KEY not null,
	F_Name nvarchar(50),
	F_UrlAddress varchar(200),
	F_Point varchar(200),
	F_ShortName nvarchar(50),
	F_Icon varchar(200) NULL,
	F_UserName nvarchar(50),
	F_Phone nvarchar(50),
	F_Emaile nvarchar(50),
	F_Record nvarchar(200),
	F_VisitorNum nvarchar(50),
	F_Desc nvarchar(2000),
	F_EnabledMark bit NULL,
	F_DeleteMark bit NULL,
	F_MainMark bit NULL,
	F_CreatorUserId varchar(50) NULL,
	F_CreatorTime datetime NULL,
	F_DeleteUserId varchar(50) NULL,
	F_DeleteTime datetime NULL,
	F_LastModifyTime datetime NULL,
	F_LastModifyUserId varchar(50) NULL,
)