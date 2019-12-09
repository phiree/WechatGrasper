using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
   public  interface IRepository
    {
          string[] GetAllIds();
          void Save(Entity entity,string dateVersion);
          IList<Entity> DownloadData(DateTime dateTime);


    }
}
