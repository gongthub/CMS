Create TABLE Sys_UpFiles
(
Id varchar(50) PRIMARY KEY not null,
PId varchar(50),
ModuleName nvarchar(200),
FileName nvarchar(200),
FileOldName nvarchar(200),
ExtName nvarchar(50),
FilePath nvarchar(200),
FileMd5 nvarchar(500),
Description nvarchar(500),
IsMain bit,
EnabledMark bit,
DeleteMark bit,
CreatorUserId varchar(50),
CreatorTime datetime,
DeleteUserId varchar(50),
DeleteTime datetime,
LastModifyUserId varchar(50),
LastModifyTime datetime,

)