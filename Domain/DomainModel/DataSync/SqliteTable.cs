using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.DataSync
{
    public  abstract class SqliteTable<T> where T:Entity<string>
    {
         
        
        public abstract void UpdateFromEntity(T t);
    }
   public class SqliteActivity:SqliteTable<Activity>
    {
        
        public string Version { get; set; }
        public string Fingerprint { get; set; }
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
        public override  void UpdateFromEntity(Activity activity )
        {
          //  var activity = Entity;
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
            
        }
    }
}
