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

        public SDTAApplication(  IUrlFetcher urlFetcher, IRepository<LineDetail, string> repositoryDetailItem)
        {
         
            this.urlFetcher = urlFetcher;
            this.repositoryDetailItem = repositoryDetailItem;
        }

        public void Graspe()
        {
            var listUrlBuilder = new LineListUrlBuilder( );
            var detailUrlBuilder = new LineDetailUrlBuilder();

            var linesFetcher = new ListDetailFetcher<ResponseLines,Lines, LineDetail, string>(listUrlBuilder,
                detailUrlBuilder,
                urlFetcher,
                repositoryDetailItem,
                new PagingSetting { NeedPaging = false, StartIndex = -1 });
            linesFetcher.Fetch();


            //todo: 精品路线中的景区
            //城市锦囊
            var cityGuideUrlBuilder = new CityGuideListUrlBuilder();
            var cityUrlBuilder = new CityGuideDetailUrlBuilder();

            //var cityGuidesFetcher = new ListDetailFetcher<CityGuide, Lines, LineDetail, string>(cityGuideUrlBuilder,
            //    cityUrlBuilder,
            //    urlFetcher,
            //    repositoryDetailItem,
            //    new PagingSetting { NeedPaging = false, StartIndex = -1 });
            //linesFetcher.Fetch();
            
            //美食

        }
    }

}
