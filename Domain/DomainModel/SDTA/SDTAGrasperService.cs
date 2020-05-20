using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.SDTA
{
    public class SDTALineGrasperService : ISDTALineGrasperService
    {
        IUrlFetcher urlFetcher;

        InfoLocalizer<LineDetail, string> lineLocalizer;
        InfoLocalizer<LineDetailScenic.Doc.Source, string> lineDetailScenicLocalizer;

        public SDTALineGrasperService(IUrlFetcher urlFetcher, IRepository<LineDetail, string> lineRepository, IRepository<LineDetailScenic.Doc.Source, string> lineDetailScenicRepository)
        {
            this.urlFetcher = urlFetcher;

            this.lineLocalizer = new InfoLocalizer<LineDetail, string>(lineRepository, urlFetcher, "..\\DownloadImages\\sdta\\", string.Empty);
            this.lineDetailScenicLocalizer = new InfoLocalizer<LineDetailScenic.Doc.Source, string>(lineDetailScenicRepository, urlFetcher, "..\\DownloadImages\\sdta\\", string.Empty);
        }

        public void Graspe(string version)
        {
            string rootUrl = "https://www.sdta.cn/json/lines/list_370300.json?channel=zibo";

            
            ResponseLines responseLines = JsonConvert.DeserializeObject<ResponseLines>
                (urlFetcher.FetchAsync(rootUrl).Result
                
                );//new ResponseLines();//fetch by api

            foreach (var line in responseLines.lines)
            {
                string detailUrl = $"https://www.sdta.cn/json/lines/{line.id}.json?channel=zibo";
                LineDetail lineDetail = JsonConvert.DeserializeObject<LineDetail>(urlFetcher.FetchAsync(detailUrl).Result, new ImageUrlJsonConverter());//new ResponseLines();//fetch by api
                lineDetail.id=line.id;
                string detailScenicUrl = "https://www.sdta.cn/searches/element/ele/_mget";
                bool isLineDetailExisted;
                lineLocalizer.Localize(lineDetail, string.Empty, version, out isLineDetailExisted);
                foreach (var day in lineDetail.days)
                {

                    var postData = JsonConvert.SerializeObject(new { ids = day.place.Select(x => x.type + "_" + x.id).ToArray() });
                    LineDetailScenic lineDetailScenic = JsonConvert.DeserializeObject<LineDetailScenic>
                        (urlFetcher.PostWithJsonAsync(detailScenicUrl, postData), new ImageUrlJsonConverter());//new ResponseLines();//fetch by api
                    foreach (var doc in lineDetailScenic.docs.Select(x => x._source))
                    {
                        bool docExisted;
                        lineDetailScenicLocalizer.Localize(doc, "https://www.sdta.cn", version, out docExisted);
                    }
                }
            }



        }
    }
}
