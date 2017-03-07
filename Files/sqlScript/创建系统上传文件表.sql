Create TABLE Sys_UpFiles
(
F_Id varchar(50) PRIMARY KEY not null,
F_PId varchar(50),
F_ModuleName nvarchar(200),
F_FileName nvarchar(200),
F_FileOldName nvarchar(200),
F_ExtName nvarchar(50),
F_FilePath nvarchar(200),
F_FileMd5 nvarchar(500),
F_Desc nvarchar(500),
F_IsMain bit,
F_EnabledMark bit,
F_DeleteMark bit,
F_CreatorUserId varchar(50),
F_CreatorTime datetime,
F_DeleteUserId varchar(50),
F_DeleteTime datetime,
F_LastModifyUserId varchar(50),
F_LastModifyTime datetime,

)