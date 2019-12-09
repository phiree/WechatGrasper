namespace Domain
{
    public abstract  class Entity
    {
        public string id { get; set; }
        public PlaceType PlaceType { get; set; }
        public  abstract override  int GetHashCode();
         
        public int HashCode { get;protected set;}
    }

}

