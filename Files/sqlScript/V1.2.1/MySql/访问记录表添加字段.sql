ALTER TABLE sys_accesslog ADD Country varchar(200);
ALTER TABLE sys_accesslog ADD CountryNo varchar(200);
ALTER TABLE sys_accesslog ADD BigArea varchar(200);
ALTER TABLE sys_accesslog ADD Isp varchar(200);
ALTER TABLE sys_accesslog ADD IsProcessIp TINYINT(4);

ALTER TABLE sys_requestlog ADD Country varchar(200);
ALTER TABLE sys_requestlog ADD CountryNo varchar(200);
ALTER TABLE sys_requestlog ADD BigArea varchar(200);
ALTER TABLE sys_requestlog ADD Isp varchar(200);
ALTER TABLE sys_requestlog ADD IsProcessIp TINYINT(4);