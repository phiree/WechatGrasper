
using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.Base
{
   public  interface IRepository<Entity> 
    {
         
          void SaveOrUpdate(Entity entity,string newVersion);
         


    }
   
}
