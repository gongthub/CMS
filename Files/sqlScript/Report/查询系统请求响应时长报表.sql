select * from (
	SELECT A.id,A.UrlAddress,A.Date as StartDate,B.Date as EndDate,TIMESTAMPDIFF(SECOND,A.Date,B.Date) RequestTime from sys_requestlog as A
	left join sys_requestlog as B ON A.StartID=B.EndID
) as A
where A.RequestTime >0
order by A.RequestTime DESC,A.StartDate DESC