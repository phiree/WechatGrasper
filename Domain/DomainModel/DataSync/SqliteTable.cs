using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.TourNews;

namespace TourInfo.Domain.DomainModel.DataSync
{
    public  abstract class SqliteTable<T> where T:Entity<string>
    {
        public string Id { get;set;}
        public abstract SqliteTable<T> UpdateFromEntity( T t);
        
    }
    
    [Table("Activity")]
   public class SqliteActivity:SqliteTable<Activity>
    {
      
        public string Version { get; set; }
        
        public PlaceType PlaceType { get; set; }
        public string startTime { get; set; }
        public string createTime { get; set; }
        public string thumbnailKey { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public string endTime { get; set; }

        public string detail { get; set; }


        public string pictureKeys { get; set; }

        public int credits { get; set; }
        public bool isShared { get; set; }
        public  override SqliteTable<Activity> UpdateFromEntity( Activity activity)
        {
           //var activity = Entity;
           Id=activity.id;
            address = activity.address;
            this.createTime = activity.createTime;
            this.credits = activity.credits;
            this.detail = activity.detail;
            this.endTime = activity.endTime;
            this.isShared = activity.isShared;
            this.name = activity.name;
            this.pictureKeys = pictureKeys ?? string.Join(";", pictureKeys);
            this.PlaceType = activity.PlaceType;
            this.startTime = activity.startTime;
            this.thumbnailKey = activity.thumbnailKey;
            this.Version = activity.Version;
            return this;
            
        }

       
    }
    [Table("CompanyVenue")]
    public class SqliteCompanyVenue : SqliteTable<CompanyVenue>
    {
      
        public string Version { get; set; }
        
        public PlaceType PlaceType { get; set; }
        public string thumbnailKey { get; set; }
        public string location { get;set;}
       // public double[] location { get; set; }
        public string name { get; set; }
        public string satisfactionScore { get; set; }
        public string typeId { get; set; }
        public string introduction { get; set; }
        //public IsComment isComment { get; set; }

        public string  pictureKeys { get; set; }
        //  public string[] pictureKeys { get; set; }
        public string address { get; set; }
        public string isFavorite { get; set; }

        #region 场馆独有属性
        public string serviceTimeStart { get; set; }

        public string serviceNote { get; set; }
        public string serviceTimeEnd { get; set; }
        #endregion

        public string telNumber { get; set; }
        public override SqliteTable<CompanyVenue> UpdateFromEntity(CompanyVenue Entity)
        {Id=Entity.id;
            
           this. address = Entity.address;
            this.introduction = Entity.introduction;
            this.isFavorite = Entity.isFavorite;
            this.location = Entity.location==null?string.Empty:string.Join(";",Entity.location);
            this.name = Entity.name;
         
            this.PlaceType = Entity.PlaceType;
            this.pictureKeys = Entity.pictureKeys==null?string.Empty: string.Join(";", pictureKeys);
         
            this.satisfactionScore = Entity.satisfactionScore;
           
        
            this.serviceNote=Entity.serviceNote;
            this.serviceTimeEnd=serviceTimeEnd;
                this.serviceTimeStart=Entity.serviceTimeStart;
                this.telNumber=Entity.telNumber;
                this.thumbnailKey=Entity.thumbnailKey;
                this.typeId=Entity.typeId;
                this.Version=Entity.Version;
            return this;

        }


    }
    [Table("ZbtaNews")]
    public class SqliteZbtaNews : SqliteTable<ZbtaNews>
    {
        
        public string Version { get; set; }
        public string releaseTime { get; set; }
        public string checkState { get; set; }

        public string titles { get; set; }
        public string image { get; set; }
        public string created { get; set; }
        public string back1 { get; set; }
        public string details { get; set; }
        public string createUser { get; set; }
        public override SqliteTable<ZbtaNews> UpdateFromEntity(ZbtaNews Entity)
        {


            Id=Entity.id;
            this.Version=Entity.Version;
        this.releaseTime =Entity.releaseTime;
        this.checkState =Entity.checkState;

        this.titles =Entity.titles;
        this.image =Entity.image;
        this.created =Entity.created;
        this.back1 =Entity.back1;
        this.details =Entity.details;
        this.createUser =Entity.createUser;
            return this;
    }

         
    }

}
