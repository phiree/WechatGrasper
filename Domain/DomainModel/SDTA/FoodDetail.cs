using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.SDTA
{
   

   

    

   

    public class FoodDetail:IDetailWrapper<FoodDetail.Data>
    {
        public bool error { get; set; }
        public string message { get; set; }
        public Data data { get; set; }

        public Data Detail => data;

        public class Data:Entity<int>
        {
           
            public string res_type_rela { get; set; }
            public string restaurant_id { get; set; }
            public string user_id { get; set; }
            public string snack_name { get; set; }
            public string snack_pho { get; set; }
            public string snack_int { get; set; }
            public string updated_at { get; set; }
            public string destination_id { get; set; }
            public string keywords { get; set; }
            public string snack_intr_m { get; set; }
            public string tags { get; set; }
            public int source { get; set; }
            public string unitcode { get; set; }
            public int state { get; set; }
            public string food_fullnane { get; set; }
            public string food_shortname { get; set; }
            public string food_enname { get; set; }
            public string food_recmmond { get; set; }
            public string food_price { get; set; }
            public string created_at { get; set; }
            public string food_type_id { get; set; }
            public ImageUrl defaultphoto { get; set; }
            public int rank { get; set; }
            public int is_404 { get; set; }
            public string cityname { get; set; }
            public string areaname { get; set; }
            public string commentscore { get; set; }
            public int commentcount { get; set; }
            public int likescount { get; set; }
            public int collectscount { get; set; }
            public List<FilterPicture> filter_pictures { get; set; }
            public string perlink { get; set; }
            public string compresspic { get; set; }
            public Destination destination { get; set; }
            public SnackFoodType snack_food_type { get; set; }
            public List<Picture> pictures { get; set; }
            public class Picture
            {
                public int id { get; set; }
                public string pho_id { get; set; }
                public string picable_id { get; set; }
                public string picable_type { get; set; }
                public string pho_name { get; set; }
                public string pho_type { get; set; }
                public string pho_format { get; set; }
                public ImageUrl pho_path { get; set; }
                public string created_at { get; set; }
                public string updated_at { get; set; }
                public int rank { get; set; }
                public int is_404 { get; set; }
                public string deleted_at { get; set; }
            }
            public class FilterPicture
            {
                public int id { get; set; }
                public string pho_id { get; set; }
                public string picable_id { get; set; }
                public string picable_type { get; set; }
                public string pho_name { get; set; }
                public string pho_type { get; set; }
                public string pho_format { get; set; }
                public ImageUrl pho_path { get; set; }
                public string created_at { get; set; }
                public string updated_at { get; set; }
                public int rank { get; set; }
                public int is_404 { get; set; }
                public string deleted_at { get; set; }
            }

            public class Destination
            {
                public int id { get; set; }
                public string destination_id { get; set; }
                public string destname { get; set; }
                public string full_name { get; set; }
                public string short_name { get; set; }
                public string adm_name { get; set; }
                public string adm_address { get; set; }
                public string adm_phone { get; set; }
                public string dest_des { get; set; }
                public string culture { get; set; }
                public string dest_adver { get; set; }
                public string clim_des { get; set; }
                public string notes_des { get; set; }
                public string tou_taboo { get; set; }
                public string fea_inf { get; set; }
                public string longitude { get; set; }
                public string latitude { get; set; }
                public string airlines { get; set; }
                public string railway { get; set; }
                public string highway { get; set; }
                public string water_carriage { get; set; }
                public string bus { get; set; }
                public string taxi { get; set; }
                public string fea_traffic { get; set; }
                public string created_at { get; set; }
                public string updated_at { get; set; }
                public int audit_state { get; set; }
                public string website { get; set; }
                public int dest_type_id { get; set; }
                public ImageUrl defaultphoto { get; set; }
                public string keywords { get; set; }
                public string tags { get; set; }
                public string charmcitypic { get; set; }
                public string daren_picture { get; set; }
                public string area_id { get; set; }
                public int rank { get; set; }
                public int is_404 { get; set; }
                public string cityname { get; set; }
            }
            public class SnackFoodType
            {
                public string food_type_id { get; set; }
                public string user_id { get; set; }
                public string food_type_id_p { get; set; }
                public string food_type_name { get; set; }
                public string grade { get; set; }
                public string updated_at { get; set; }
                public string deleted_at { get; set; }
                public string created_at { get; set; }
                public int id { get; set; }
            }
        }
    }
}
