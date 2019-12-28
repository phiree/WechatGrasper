using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TourInfo.Infrastracture.Repository.ADONET
{
  public static  class ListToDataTbale 
    {
        public static DataTable ConvertGenericListToDataTable<T>(this IList<T> inputList)
        {
            var dt = new DataTable();
             dt = ListToDataTbale2.ConvertToDataTable<T>(inputList);
            //using (var reader = ObjectReader.Create(inputList))
            //{
            //    dt.Load(reader);
            //}
            return dt;
        }
    }
}
