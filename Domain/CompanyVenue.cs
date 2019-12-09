using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    //文化企业/场馆列表项

    public class CompanyVenue : Entity
    {

       // public double distance { get; set; }
        public string thumbnailKey { get; set; }
        public string locations { get; set; }
        public List<double> location { get; set; }
        public string name { get; set; }
        public string satisfactionScore { get; set; }
        public string typeId { get; set; }
        public string introduction { get; set; }
        //public IsComment isComment { get; set; }
        public  string  pictureKeyes { get; set; }
       
        public List<string> pictureKeys { get; set; }
        public string address { get; set; }
        public string isFavorite { get; set; }
        public string Version { get;set;}

        #region 场馆独有属性
        public string serviceTimeStart { get; set; }

        public string serviceNote { get; set; }
        public string serviceTimeEnd { get; set; }
        #endregion

        public string telNumber { get; set; }
        public override  Entity ConvertToEntity()
        { if(location!=null)
            { 
            this.locations=string.Join(",",location);
            }
        if(this.pictureKeys!=null)
            { 
            this.pictureKeyes=string.Join(",",pictureKeys);
            }
            this.HashCode=GetHashCode();
            return this;
            }
        public override string GetHashCode()
        {
           StringBuilder sb=new StringBuilder();
            sb.Append(id)
                .Append(this.address)
                 
                .Append(this.introduction)
               
                .Append(this.isFavorite)
                .Append(location!=null? string.Join(",",this.location):"")
                .Append(this.name)
                .Append(pictureKeyes==null?string.Empty: string.Join(",", this.pictureKeys))
                .Append(this.satisfactionScore)
                .Append(this.serviceNote)
                .Append(this.serviceTimeEnd)
                .Append(this.serviceTimeStart)
                .Append(this.telNumber)
                .Append(this.thumbnailKey)
                .Append(this.typeId);
             
            return MD5Helper.CalculateMD5Hash( sb.ToString());
        }
    }

}

