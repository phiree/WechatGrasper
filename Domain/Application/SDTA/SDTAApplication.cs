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
        IRepository<FoodDetail.Data, string> repositoryFoodDetail;
        ILogger<ListDetailFetcherWithPostList<Food, Food.Hit.Source, FoodDetail, FoodDetail.Data, string>> logger;

        IRepository<LineDetailScenic,string> repositoryLineDetailScenic;
        IRepository<LineDetail, string> repositoryLineDetail2;
        ISDTALineGrasperService sDTALineGrasperService;

        IRepository<SpecialLocalProductDetail.Data,string> specialProductRepository;
        string specialFoodImageLocalSavePath;
        string specialFoodImageClientPath;
        string cityGuideImageLocalSavePath;
        string cityGuideFoodImageClientPath;
        string remoteImageRootUrl;
        public SDTAApplication(IUrlFetcher urlFetcher,
            IRepository<LineDetail, string> repositoryDetailItem, 
            IRepository<CityGuideDetail.Data, string> repositoryCityGuideDetail,
            IRepository<FoodDetail.Data, string> repositoryFoodDetail,

              IRepository<LineDetailScenic, string> repositoryLineDetailScenic,
        IRepository<LineDetail, string> repositoryLineDetail2,
        ISDTALineGrasperService sDTALineGrasperService,
        IRepository<SpecialLocalProductDetail.Data, string> specialProductRepository,
        ILogger<ListDetailFetcherWithPostList<Food, Food.Hit.Source, FoodDetail, FoodDetail.Data, string>> logger)
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
            #region //特产
            /*
            var specialProductListUrlBuilder = new SpecialProductListUrlBuilder();
            var specialProductDetailUrlBuilder = new SpecialProductDetailUrlBuilder();

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
                }
                , specialFoodImageLocalSavePath, specialFoodImageClientPath, remoteImageRootUrl, version);

            specialProductFetcher.Fetch();
            */
            #endregion

            //新版路线

            sDTALineGrasperService.Graspe(version);

            #region //美食 --无需抓取,使用百度的数据
            //var foodListUrlBuilder = new FoodListUrlBuilder();
            //var foodDetailBuilder = new FoodDetailUrlBuilder();
            //var foodFetcher = new ListDetailFetcherWithPostList<Food, Food.Hit.Source, FoodDetail, FoodDetail.Data, string>
            //    (foodListUrlBuilder,
            //    foodDetailBuilder,
            //    urlFetcher,
            //    repositoryFoodDetail,
            //    new ListPostData
            //    {
            //        PageIndex = 0,
            //        PageSize = 20,
            //        post_filter = new ListPostData.PostFilter
            //        {
            //            @bool = new ListPostData.PostFilter.Bool
            //            {
            //                must = new List<ListPostData.PostFilter.Bool.Must>{
            //                      new ListPostData.PostFilter.Bool.Must{
            //                          term=new ListPostData.PostFilter.Bool.Must.Term{
            //                               citycode="370300"
            //                              } }
            //                     }
            //            }
            //        }
            //    } 
            //  );
            ////美食 --无需抓取,使用百度的数据
            ////foodFetcher.Fetch();
            #endregion
            #region //城市锦囊
            var cityGuideUrlBuilder = new CityGuideListUrlBuilder();
            var cityUrlBuilder = new CityGuideDetailUrlBuilder();

            var cityGuidesFetcher = new ListDetailFetcher<CityGuide, CityGuide.Category.List, CityGuideDetail,CityGuideDetail.Data, string>
                (cityGuideUrlBuilder,
                cityUrlBuilder,
                urlFetcher,
                repositoryCityGuideDetail,
                new PagingSetting { NeedPaging = false, StartIndex = -1 });
            cityGuidesFetcher.Fetch();
            #endregion

           

        }
    }

}
