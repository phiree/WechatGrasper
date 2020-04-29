using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        IRepository<LineDetailScenic,string> repositoryLineDetailScenic;
        IRepository<LineDetail, string> repositoryLineDetail2;
        ISDTALineGrasperService sDTALineGrasperService;

        IRepository<SpecialLocalProductDetail.Data,string> specialProductRepository;

        public SDTAApplication(IUrlFetcher urlFetcher,
            IRepository<LineDetail, string> repositoryDetailItem, 
            IRepository<CityGuideDetail.Data, string> repositoryCityGuideDetail,
            IRepository<FoodDetail.Data, int> repositoryFoodDetail,

              IRepository<LineDetailScenic, string> repositoryLineDetailScenic,
        IRepository<LineDetail, string> repositoryLineDetail2,
        ISDTALineGrasperService sDTALineGrasperService,
        IRepository<SpecialLocalProductDetail.Data, string> specialProductRepository,
        ILogger<ListDetailFetcherWithPostList<Food, Food.Hit.Source, FoodDetail, FoodDetail.Data, int>> logger)
        {
            this.specialProductRepository=specialProductRepository;
            this.logger=logger;
         this.repositoryCityGuideDetail=repositoryCityGuideDetail;
            this.urlFetcher = urlFetcher;
            this.repositoryDetailItem = repositoryDetailItem;
            this.repositoryFoodDetail=repositoryFoodDetail;
            this. repositoryLineDetailScenic=repositoryLineDetailScenic;
            this.repositoryLineDetail2=repositoryLineDetail2;
            this.sDTALineGrasperService=sDTALineGrasperService;
        }

        public void Graspe(string version)

        {
            //新版路线
            
             sDTALineGrasperService.Graspe(version);
            //美食
            var foodListUrlBuilder = new FoodListUrlBuilder();
            var foodDetailBuilder = new FoodDetailUrlBuilder();
            var foodFetcher = new ListDetailFetcherWithPostList<Food, Food.Hit.Source, FoodDetail, FoodDetail.Data, int>
                (foodListUrlBuilder,
                foodDetailBuilder,
                urlFetcher,
                repositoryFoodDetail,
                new ListPostData
                {
                    PageIndex = 0,
                    PageSize = 20,
                    post_filter = new ListPostData.PostFilter
                    {
                        @bool = new ListPostData.PostFilter.Bool
                        {
                            must = new List<ListPostData.PostFilter.Bool.Must>{
                                  new ListPostData.PostFilter.Bool.Must{
                                      term=new ListPostData.PostFilter.Bool.Must.Term{
                                           citycode="370300"
                                          } }
                                 }
                        }
                    }
                } 
              );;
            foodFetcher.Fetch();
             
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
            //特产
            var specialProductListUrlBuilder = new SpecialProductListUrlBuilder();
            var specialProductDetailUrlBuilder = new CityGuideDetailUrlBuilder();

            var specialProductFetcher = new ListDetailFetcherWithPostList<SpecialLocalProduct, SpecialLocalProduct.Hits.Hit, SpecialLocalProductDetail, SpecialLocalProductDetail.Data, string>
                (specialProductListUrlBuilder,
                specialProductDetailUrlBuilder,
                urlFetcher,
                specialProductRepository,
                new ListPostData
                {
                    PageIndex = 0,
                    PageSize = 20,
                    post_filter = new ListPostData.PostFilter
                    {
                        @bool = new ListPostData.PostFilter.Bool
                        {
                            must = new List<ListPostData.PostFilter.Bool.Must>{
                                  new ListPostData.PostFilter.Bool.Must{
                                      term=new ListPostData.PostFilter.Bool.Must.Term{
                                           citycode="370300"
                                          } }
                                 }
                        }
                    }
                });
            specialProductFetcher.Fetch();


        }
    }

}
