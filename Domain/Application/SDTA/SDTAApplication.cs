using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel;
using TourInfo.Domain.DomainModel.SDTA;

namespace TourInfo.Domain.Application.SDTA
{
    public class SDTAApplication : ISDTAApplication
    {
        IUrlFetcher urlFetcher;
        IRepository<LineDetail, string> repositoryDetailItem;
        IRepository<CityGuideDetail.Data, string> repositoryCityGuideDetail;
        IRepository<FoodDetail.Data, int> repositoryFoodDetail;
        ILogger<ListDetailFetcherWithPostList<Food, Food.Hit.Source, FoodDetail, FoodDetail.Data, int>> logger;

        IRepository<LineDetailScenic2,string> repositoryLineDetailScenic;
        IRepository<LineDetail2, string> repositoryLineDetail2;

        public SDTAApplication(IUrlFetcher urlFetcher,
            IRepository<LineDetail, string> repositoryDetailItem, 
            IRepository<CityGuideDetail.Data, string> repositoryCityGuideDetail,
            IRepository<FoodDetail.Data, int> repositoryFoodDetail,
            ILogger<ListDetailFetcherWithPostList<Food, Food.Hit.Source, FoodDetail, FoodDetail.Data, int>> logger)
        {
            this.logger=logger;
         this.repositoryCityGuideDetail=repositoryCityGuideDetail;
            this.urlFetcher = urlFetcher;
            this.repositoryDetailItem = repositoryDetailItem;
            this.repositoryFoodDetail=repositoryFoodDetail;
        }

        public void Graspe(IUrlFetcher lineDetailScenicPostFetcher)

        { //美食
            var foodListUrlBuilder = new FoodListUrlBuilder();
            var foodDetailBuilder = new FoodDetailUrlBuilder();

            var foodFetcher = new ListDetailFetcherWithPostList<Food, Food.Hit.Source, FoodDetail, FoodDetail.Data, int>
                (foodListUrlBuilder,
                foodDetailBuilder,
                urlFetcher,
                repositoryFoodDetail,
                new FoodListPostData
                {
                    PageIndex = 0,
                    PageSize = 20,
                    post_filter = new FoodListPostData.PostFilter
                    {
                        @bool = new FoodListPostData.PostFilter.Bool
                        {
                            must = new List<FoodListPostData.PostFilter.Bool.Must>{
                                  new FoodListPostData.PostFilter.Bool.Must{
                                      term=new FoodListPostData.PostFilter.Bool.Must.Term{
                                           citycode="370300"
                                          } }
                                 }
                        }
                    }
                },logger
              );;
            foodFetcher.Fetch();
            //路线
            var listUrlBuilder = new LineListUrlBuilder( );
            var detailUrlBuilder = new LineDetailUrlBuilder();

            var linesFetcher = new ListDetailFetcher<ResponseLines,Lines, LineDetail,LineDetail, string>(listUrlBuilder,
                detailUrlBuilder,
                urlFetcher,
                repositoryDetailItem,
                new PagingSetting { NeedPaging = false, StartIndex = -1 });
            linesFetcher.Fetch();


            //todo: 精品路线中的景区
            //城市锦囊
            var cityGuideUrlBuilder = new CityGuideListUrlBuilder();
            var cityUrlBuilder = new CityGuideDetailUrlBuilder();

            var cityGuidesFetcher = new ListDetailFetcher<CityGuide, CityGuide.Category.List, CityGuideDetail,CityGuideDetail.Data, string>
                (cityGuideUrlBuilder,
                cityUrlBuilder,
                urlFetcher,
                repositoryCityGuideDetail,
                new PagingSetting { NeedPaging = false, StartIndex = -1 });
            cityGuidesFetcher.Fetch();

           //新版路线

            var linesFetcher2=new NestedFetcher<
                ResponseLines2, string,
                LineDetail2,string,
                LineDetailScenic2,string
                >
                (
                 "",urlFetcher,false,null,
                new  LineDetailUrlBuilder(),urlFetcher,true, repositoryLineDetail2,
                new LineDetailScenicUrlBuilder(), postfe,true, repositoryLineDetailScenic
                );
            linesFetcher2.Fetch();

        }
    }

}
