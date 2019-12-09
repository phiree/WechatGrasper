namespace Domain
{
    public abstract  class Entity
    {
        public string id { get; set; }
        public PlaceType PlaceType { get; set; }
        public  abstract  new  string GetHashCode();
         public abstract Entity ConvertToEntity();
        public string HashCode { get;protected set;}
    }

}

