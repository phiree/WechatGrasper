
select * from dbo.sys.objects
create database EWQY 
go

use EWQY
go

/*
drop table activity
drop table companyvenue
*/


 
create table Activity
(     id varchar(256) primary key,
      hashCode integer,
        PlaceType integer,
        entityid varchar(256),
        startTime varchar(256),
         createTime varchar(256),
         thumbnailKey  varchar(256),
          address  varchar(256),
        name  varchar(256),
        endTime  varchar(256),

         detail text,
         pictureKeyes varchar(1000),

         credits  integer,
         isShared bit,
          version varchar(100),
        )
        go
    create table  CompanyVenue  
   (
     id varchar(256) primary key,
     hashCode integer,
        PlaceType integer,
        
          thumbnailKey varchar(256),
       
         locations varchar(256),
        name  varchar(256),
         satisfactionScore  varchar(256),
       typeId  varchar(256),
        introduction text,
         isComment varchar(256),
         pictureKeyes  varchar(1000),
        address  varchar(256),
        isFavorite  varchar(256),
        version varchar(100),
   
         serviceTimeStart  varchar(256),

         serviceNote  varchar(256),
         serviceTimeEnd  varchar(256),
        

         telNumber  varchar(256) 

      )
      go