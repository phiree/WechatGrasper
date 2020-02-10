﻿using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Text.RegularExpressions;
using TourInfo.Domain.Base;
using TourInfo.Domain.DomainModel.Rapi;
 
namespace TourInfo.Domain.TourNews
{
    public class ZBTAApplication : IZBTAApplication
    {
        IUrlFetcher urlFetcher;
        IImageLocalizer imageLocalizer;
   //     IDetailImageLocalizer detailImageLocalizer;
        IInfoLocalizer<ZbtaNews,string> infoLocalizerZbtaNews;
        string titleImageBaseUrl,detailImageBaseUrl,localSavedPath,imageClientPath;
        IVersionedRepository<ZbtaNews, string> newsRepository;
        ILogger logger;
        public ZBTAApplication(IUrlFetcher urlFetcher,
            ILoggerFactory loggerFactory,
              //      IDetailImageLocalizer detailImageLocalizer,
        IVersionedRepository<ZbtaNews, string> newsRepository
            ,string titleImageBaseUrl,string detailImageBaseUrl, string localSavedPath,string imageClientPath, IImageLocalizer imageLocalizer, IInfoLocalizer<ZbtaNews,string> infoLocalizerZbtaNews)
        {
            logger = loggerFactory.CreateLogger<ZBTAApplication>();
            this.infoLocalizerZbtaNews=infoLocalizerZbtaNews;
          //  this.detailImageLocalizer = detailImageLocalizer;
            this.imageLocalizer = imageLocalizer;
            this.titleImageBaseUrl = titleImageBaseUrl;
            this.detailImageBaseUrl = detailImageBaseUrl;
           this.localSavedPath = localSavedPath;
            this.newsRepository = newsRepository;
            this.urlFetcher = urlFetcher;
            this.imageClientPath = imageClientPath;
        }
        const string baseUrl = "http://www.zbta.net/informationW/getInformation.html?page=";
        public void Graspe(string _dateVersion)
        {
            logger.LogInformation("开始抓取ZbtaNews");
            bool needContinue = true;
            int pageIndex = 1;
            while (needContinue)
            {
                
                string result = urlFetcher.FetchAsync(baseUrl + pageIndex).Result;
                logger.LogInformation($"第{pageIndex}页抓取结果:" + result);
                //转换错误,可能是因为json的Id是int类型
               
                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ZbtaNewsResponse>
                    (result,new ImageUrlJsonConverter(),new TextContainsImageUrlsJsonConverter());
                if (jsonResult.TourNews.Count == 0)
                {
                    logger.LogInformation("返回数据为空");
                    needContinue = false;
                    continue;
                }
                foreach (var news in jsonResult.TourNews)
                {
                    if (news.releaseTime.CompareTo("2019-12-01 00:00:00") < 0)
                    {
                        needContinue = false;
                        break;
                    }
                   bool isExisted=false;
                    //特殊处理:
                    news.details = new ImageUrlsInText(news.details.OriginaText, string.Empty, detailImageBaseUrl);
                    infoLocalizerZbtaNews.Localize(news,titleImageBaseUrl, localSavedPath, imageClientPath,_dateVersion, out isExisted);
                    if(isExisted)
                    {
                        needContinue=false;
                        break;
                        }
                }
                //遍历 如果已经发现已经存在，则 needContinue=false,并跳过。
                pageIndex++;

                //
            }
        }
        /*
         http://www.zbta.net/informationW/getInformation.html?page=[pagenumber]

        {
  "success": true,
  "object": [
    {
      "releaseTime": "2019-11-29 19:44:15",
      "checkState": "1",
      "id": 1378,
      "titles": "全省公共数字文化服务暨馆长履职与创新能力培训班在淄博举办",
      "image": "upload/2019-12-02/ba6a008de48a47de8c9d6e7344defc2c.jpg",
      "created": "2019-12-02 15:47:17",
      "back1": "11月26日至29日，由山东省图书馆、山东省图书馆学会主办的全省公共数字文化服务暨馆长履职与创新能力培训班在淄博成功举办，全省各地各级公共图书馆的馆长和公共数字文化建设负责同志180余人参加培训。",
      "details": "　　11月26日至29日，由山东省图书馆、山东省图书馆学会主办的全省公共数字文化服务暨馆长履职与创新能力培训班在淄博成功举办，全省各地各级公共图书馆的馆长和公共数字文化建设负责同志180余人参加培训。<br />\r\n<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191202/20191202154656_155.jpg\" alt=\"\" /> \r\n</p>\r\n<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191202/20191202154703_950.jpg\" alt=\"\" /> \r\n</p>\r\n<br />\r\n<p>\r\n\t　　本次培训围绕着“公共数字文化建设、基层图书馆馆长履职能力和业务创新”主题，邀请了山东省图书馆党委书记、馆长刘显世，山东大学教授江三宝，国家图书馆信息技术部副主任张炜，高级工程师赵娜等专家授课。\r\n</p>\r\n<p>\r\n\t<br />\r\n</p>\r\n　　培训班上，山东省图书馆刘显世馆长以《锐意进取 做新时代合格的图书馆馆长》为题，结合自身工作感受，深入浅出从“把握方向，党建为首，做政治上的明白人”、“积极创新，锐意进取，做事业上的掌舵人”、“科学管理，以人为本，做群众的贴心人”、“廉洁自律，修身正己，做工作生活中的规矩人”四个方面分析了新时代背景下，如何做一名合格的图书馆馆长，实现管理价值，促进事业发展。<br />\r\n<br />\r\n　　山东大学江三宝教授从《基层公共图书馆服务的创新与发展》的角度，深入细致讲解了基层图书馆作为中国图书馆事业的中心，下一步服务创新工作的出发点和突破点。国家图书馆张炜副主任、高级工程师赵娜分别作了《凝聚共识 创新思路——共创公共数字文化工程融合创新发展新局面》《公共数字文化工程融合创新发展下的两微一端建设和服务》和《新视角下的公共数字文化工程资源发布》的报告，通报了新时代环境下公共数字文化融合创新发展的顶层设计和最新成果。同时，培训班还针对“山东省公共文化云建设”和“全省市、县（市、区）级公共图书馆绩效评价”两项工作进行了重点部署。<br />\r\n<br />\r\n　　本次培训班立足新时代，贯彻新思想，搭建了全省公共图书馆界学习和沟通的平台，拓展了全省基层图书馆馆长工作思路，为下一步更好地开展公共数字文化建设和服务效能提升工作创造了条件，奠定了基础。<br />"
    },
    {
      "releaseTime": "2019-11-27 15:32:40",
      "checkState": "1",
      "id": 1376,
      "titles": "沈阳盛京大剧院上演“换魂奇情”五音戏《紫凤》四地巡演落帷幕",
      "image": "upload/2019-11-28/13a8bdb3b81d4a93bb2edd6512569df2.jpg",
      "created": "2019-11-28 15:34:22",
      "createUser": "297ebc2d58dcd0510158dcd0adda0002",
      "back1": "11月26日晚，由淄博市五音戏艺术传承保护中心创排的五音戏《紫凤》在沈阳盛京大剧院上演，为当地观众送上了一出富有聊斋特色的剧目。中共沈阳市委宣传部副部长刘壮野，淄博市人民政府副秘书长刘波，中共淄博市委宣传部调研员、副部长荣先锋，沈阳市文化旅游和广播电视局副局长王大庆，淄博市文化和旅游局党组成员、副局长严旭等领导嘉宾与近千名观众观看了演出。",
      "details": "<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191128/20191128153334_672.jpg\" alt=\"\" />\r\n</p>\r\n<p>\r\n\t　　11月26日晚，由淄博市五音戏艺术传承保护中心创排的五音戏《紫凤》在沈阳盛京大剧院上演，为当地观众送上了一出富有聊斋特色的剧目。中共沈阳市委宣传部副部长刘壮野，淄博市人民政府副秘书长刘波，中共淄博市委宣传部调研员、副部长荣先锋，沈阳市文化旅游和广播电视局副局长王大庆，淄博市文化和旅游局党组成员、副局长严旭等领导嘉宾与近千名观众观看了演出。\r\n</p>\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191128/20191128153349_512.jpg\" alt=\"\" />\r\n</div>\r\n　　《紫凤》是五音戏里程碑式的作品，曾荣获山东省第十届泰山文艺奖音乐作品奖，是淄博首部获得国家艺术基金支持的戏曲，由国家一级演员、梅花奖获得者吕凤琴领衔主演。剧中一系列人物形象生动鲜活、各具特色，曲调优美、内容奇幻、对白风趣，通过“还魂”“换魂”等离奇的情节，塑造了一个对爱情、生活、社会采取独立自主积极进取态度和不畏强权、敢于斗争、纯真善良的紫凤。该剧题材新颖，歌颂了真善美的人间大义，以大欢喜的结局收场。<br />\r\n<br />\r\n　　在悠扬的曲调中，剧情缓缓展开，牟复生、紫凤、冬梅、土地、判官依次登场，为观众倾力“讲述”了一个聊斋故事。“命抵命，命换命”的姑嫂情深，令判官鬼卒唏嘘不已，判官通情理判姑嫂二人同生还阳。土地恼羞成怒，施计将紫凤和牟复生男女灵魂颠倒，引发众怒。优美的音乐、跌宕的剧情把现场观众完全带入到了戏中，随着剧情的进展，他们时而会心一笑，时而揪心大怒，深深体会到了淄博五音戏的魅力，现场不时爆发出热烈的掌声。此外，该剧演员的化妆、服装、道具等都遵循中国传统的美学原则，力求突出古代传奇戏形神兼备的特点，剧中还借助现代技术力量，借鉴了时尚前卫的电影元素和表现手段，令人耳目一新。<br />\r\n<br />\r\n　　“看完以后非常震惊，这出戏有地方文化历史特色，表演体系完备，唱腔音乐优美，剧情紧扣心弦，非常出彩，地方戏种演出了国内大戏种的感觉，可以与京剧评剧相媲美。”沈阳音乐学院教授陈秉义连声赞叹。<br />\r\n<br />\r\n<p>\r\n\t　　‘’没想到一个地方戏如此精彩，音乐设计采用了山东地方民歌，特点鲜明；乐队在配器手法上中西合璧，保持了音乐的张力和感染力；演员们都做得很到位，盘活了整台戏。”沈阳音乐学院音乐教育学院院长于学友告诉记者，他希望能看到更多的五音戏新剧。\r\n</p>\r\n<p>\r\n\t<br />\r\n</p>\r\n　　淄博市人民政府副秘书长刘波表示，沈阳是中国戏曲的重要阵地，沈阳音乐学院在全国知名度极高，沈阳观众的欣赏水平也很高。从观演现场来看，观众对《紫凤》还是比较认可的，让人感到意外的是，现场有很多年轻人来观看。下一步，淄博还会大量组织类似的文化交流及演出活动，促进淄博的地方文化发展。<br />\r\n<br />\r\n　　至此，五音戏《紫凤》四地巡演落下了帷幕。12月2日、3日，淄博市民可前往淄博大剧院一睹《紫凤》凤采。<br />"
    },
    {
      "releaseTime": "2019-11-25 18:04:01",
      "checkState": "1",
      "id": 1369,
      "titles": "“齐风冬韵”淄博文化旅游惠民季启动",
      "image": "upload/2019-11-26/7b67e270eb3e4151b04508e59e49b728.jpg",
      "created": "2019-11-26 11:05:41",
      "createUser": "297ebc2d58dcd0510158dcd0adda0002",
      "back1": "11月25日，淄博两建筑获2019世界结构大奖发布、“齐风冬韵”淄博文化旅游惠民季启动暨淄博市文化和旅游局与马蜂窝旅游网战略签约仪式在淄博潭溪山旅游度假区举办。淄博市委常委、宣传部部长毕荣青，淄博市委副秘书长刘艳，淄博市委宣传部副部长朱玉友，淄博市文化和旅游局党组副书记张振香，淄川区委副书记罗建，淄博潭溪山玻璃桥设计方、同济大学土木工程学院张其林教授，王村小米醋博物馆设计方、天津大学建筑设计规划研究总院设计师张华教授等领导出席仪式。各区县文化旅游局、全市3A级以上景区，部分旅行社、酒店，相关媒体记者等近150人参加了活动。",
      "details": "<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126110239_130.jpg\" alt=\"\" />\r\n</p>\r\n<p>\r\n\t　　11月25日，淄博两建筑获2019世界结构大奖发布、“齐风冬韵”淄博文化旅游惠民季启动暨淄博市文化和旅游局与马蜂窝旅游网战略签约仪式在淄博潭溪山旅游度假区举办。淄博市委常委、宣传部部长毕荣青，淄博市委副秘书长刘艳，淄博市委宣传部副部长朱玉友，淄博市文化和旅游局党组副书记张振香，淄川区委副书记罗建，淄博潭溪山玻璃桥设计方、同济大学土木工程学院张其林教授，王村小米醋博物馆设计方、天津大学建筑设计规划研究总院设计师张华教授等领导出席仪式。各区县文化旅游局、全市3A级以上景区，部分旅行社、酒店，相关媒体记者等近150人参加了活动。\r\n</p>\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126110257_239.jpg\" alt=\"\" />\r\n</div>\r\n　　仪式上，淄博市委常委、宣传部部长毕荣青讲话。她说，这两个获奖建筑向世界展示了淄博建筑的创新品质、时尚之美，同时也向世界展示了“齐国故都”旅游目的地品牌的知名度和影响力，强力推动了淄博市文旅市场的繁荣兴旺。淄博是齐文化的发祥地、世界足球起源地，也是蒲松龄的故乡、陶琉名城。淄博的历史和发展、淄博的精神和风采，需要我们不断传承、不断提升，也需要各界广泛宣传、大力弘扬。<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126110312_776.jpg\" alt=\"\" />\r\n</div>\r\n　　淄博市文化和旅游局党组副书记张振香发布了淄博两建筑获奖情况。近日，2019世界结构大奖揭晓，在世界结构大奖12个主要奖项中，中国结构设计斩获4奖，其中淄博独占2席。分别是“潭溪山高空玻璃桥”获行人桥梁奖，“小米醋博物馆”获小型项目奖。张振香表示，借助这次淄博两建筑获2019世界结构大奖发布仪式，同时启动“齐风冬韵”淄博文化旅游惠民季活动，市文化和旅游局将重点利用冬季旅游惠民政策，提高冬季旅游产品的吸引力，吸引越来越多的朋友走进淄博、认识淄博、乐游淄博。<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126110426_708.jpg\" alt=\"\" />\r\n</div>\r\n　　淄博潭溪山玻璃桥设计方、同济大学土木工程学院张其林教授，淄博潭溪山旅游发展有限公司董事长侯纪山，王村小米醋博物馆设计方、天津大学建筑设计规划研究总院设计师张华教授，山东华王酿造有限公司董事长侯长胜分别介绍了获奖项目建设和设计情况。<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126110435_637.jpg\" alt=\"\" />\r\n</div>\r\n　　由同济大学土木工程学院设计的“潭溪山高空玻璃桥”，为世界首例无背索斜拉弧形玻璃桥，彩虹般的独特造型充满动感与美感，与山崖风格浑然一体，成为淄博文旅融合最具活力和时尚的景观，且是中国唯一获奖的桥梁建筑。<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126110444_172.jpg\" alt=\"\" />\r\n</div>\r\n　　由天津大学建筑设计规划研究总院设计的“小米醋博物馆”，是在山东华王酿造有限公司(原称淄博市王村酿造厂)厂区基础上进行改扩建而成，是中国首家小米醋博物馆。建筑形体总体上为简单的立方体，正是印证了老子的“大象无形、大音希声”。&nbsp;<br />\r\n<br />\r\n　　为向广大群众提供更多、更优质的文化旅游产品和服务，提升游客来淄博冬季旅游体验的感受，配合全省“冬游齐鲁--好客山东惠民季”活动，市文化和旅游局精心策划了“齐风冬韵”淄博文化旅游惠民季活动，重点利用冬季旅游产品的吸引力，真正把“齐风冬韵”淄博文化旅游惠民季活动办成游客满意、企业得利、促进消费的双赢活动。围绕“齐风冬韵”淄博文化旅游惠民季，市文化和旅游局还推出了一系列冬季旅游产品和线路。<br />\r\n<p>\r\n\t<br />\r\n</p>\r\n　　为挖掘淄博旅游新线路、新概念、新打卡地标，探索线上淄博文化旅游新营销方式，淄博市文化和旅游局与马蜂窝旅游网展开战略合作，通过合作，开辟淄博文化旅游营销新平台、新方式，使得淄博成为网上旅游目的地搜索新地标。<br />\r\n<br />\r\n　　马蜂窝基于平台大数据和海量UGC内容（即用户原创内容），每年向公众推出「马蜂窝旅行者之选」榜单，即“蜂选榜”，淄博是目前山东省继青岛后第二个上榜的城市。其中，齐文化博物院、周村古商城、潭溪山旅游度假区等入选玩乐之选，淄博知味斋大饭店等入选酒店之选，丁家煮锅等入选美食之选。<br />\r\n<br />\r\n　　仪式上，淄博市委常委、宣传部部长毕荣青，淄博市委副秘书长刘艳，淄博市委宣传部副部长朱玉友，淄博市文化和旅游局党组副书记张振香，淄川区委副书记罗建共同启动“齐风冬韵”淄博文化旅游惠民季活动。<br />\r\n<br />\r\n　　淄博两建筑斩获两个大奖，不仅是颜值担当，更是实力派的雄厚展示，向世界展示了淄博的风采。初冬的淄博正洋溢着如火的热情，再一次向全国各地的朋友发出诚挚的邀请，欢迎四面八方的朋友关注淄博，走进淄博，乐游淄博！<br />"
    },
    {
      "releaseTime": "2019-11-24 18:30:48",
      "checkState": "1",
      "id": 1371,
      "titles": "乡村振兴题材剧《绿水青山带笑颜》淄博杀青",
      "image": "upload/2019-11-26/b9b5ba3e6d8145a0a64bb55f0d640d45.jpg",
      "created": "2019-11-26 15:32:30",
      "createUser": "297ebc2d58dcd0510158dcd0adda0002",
      "back1": "11月24日，电视剧《绿水青山带笑颜》杀青仪式暨媒体见面会在山东省淄博市博山区举行。仪式上，与会人员集体观看了电视剧片花，剧组介绍了电视剧拍摄情况，主要演员畅谈了拍摄感受并与媒体进行了互动。",
      "details": "<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126153123_669.jpg\" alt=\"\" />\r\n</p>\r\n<p>\r\n\t　　11月24日，电视剧《绿水青山带笑颜》杀青仪式暨媒体见面会在山东省淄博市博山区举行。仪式上，与会人员集体观看了电视剧片花，剧组介绍了电视剧拍摄情况，主要演员畅谈了拍摄感受并与媒体进行了互动。\r\n</p>\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126153132_366.jpg\" alt=\"\" />\r\n</div>\r\n　　电视剧《绿水青山带笑颜》由刘流担任总导演，杨烁、潘之琳、于洋、马苏担任主演。取材于博山区当地农村老百姓的日常生活，真实反映十八大以来乡村振兴、脱贫攻坚带来的深刻变化，以“绿水青山就是金山银山”理念为主旨，讲述了都市优秀青年响应国家号召，积极返乡创业，建设美丽乡村的励志故事。<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126153146_562.jpg\" alt=\"\" />\r\n</div>\r\n<p>\r\n\t　　《绿水青山带笑颜》主要取景地放在了淄博市博山区的古村落和上房村。该村位于齐长城遗址的山脚下，地处原始古老峡谷之中，群山环抱，山清水秀，具有独特原生态乡村气息，村里有入选山东省第二批历史优秀建筑的石楼。该剧以本地农村百姓的日常生活为故事背景，融入了乡村美景、自然山水、人文历史、民间风土、地方特产等各类博山特色元素，对博山进行实名宣传，对于全面提升博山区及淄博市知名度、拉长产业链、加快文旅融合、推动乡村振兴、促进经济社会繁荣发展具有重要意义。\r\n</p>\r\n<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126153211_160.jpg\" alt=\"\" />\r\n</p>\r\n　　博山区三面环山、一河穿城，历史悠久、风光秀美，这里不仅是国家级风景名胜区、中华陶琉文化城、国家文化出口基地，也是县委书记的榜样——焦裕禄的故乡，陶琉文化、孝文化、红色文化、饮食文化在这片沃土上源远流长。<br />\r\n<p>\r\n\t<br />\r\n</p>\r\n<p>\r\n\t　　剧情简介：\r\n</p>\r\n<br />\r\n　　32岁的许晗在上海工作了八年，他疲惫不堪，想回老家，到乡下找老同学沈欢歌，偶遇杜笑语，并一见钟情。沈欢歌已经暗恋杜笑语十年，杜笑语决定辞职回家开办农场，许晗觉得办民宿不错就租下了杜笑语家的老房子，开办起了民宿。因为杜笑语老爸贪便宜，把杜笑语的果树都给用除草剂烧死了，许晗给出了主意搞无土水培。这时沈欢歌患了重病，他要许晗保证要对杜笑语好一辈子。<br />\r\n<br />\r\n　　许晗的民宿办的有了起色，很多人想来学习，从而办起了民宿学校。根据市场需求杜笑语的果园办起了养鸡场，村民开始赚到了钱脱离了贫困。沈欢歌身体却越来越虚弱，沈欢歌要许晗和杜笑语二人尽快结婚，二人答应了沈欢歌，其实沈欢歌是编造出来得了病，让他们两人在一起。民宿和养鸡场办的越来越好，他们的感情也越来越深，他们在绿水青山之间，过上了幸福的生活。<br />"
    },
    {
      "releaseTime": "2019-11-24 18:15:11",
      "checkState": "1",
      "id": 1370,
      "titles": "搭乘“高铁环游齐鲁”专列 淄博文化旅游实力“圈粉”山东",
      "image": "upload/2019-11-26/907d6df4f7264093aa7c8bfbcd656b28.jpg",
      "created": "2019-11-26 15:17:03",
      "createUser": "297ebc2d58dcd0510158dcd0adda0002",
      "back1": "为配合“冬游齐鲁·好客山东惠民季”活动的深入开展，11月24日，由中国铁路济南局集团公司与各地市文化和旅游部门精心组织策划的“高铁环游齐鲁”旅游营销推介会在G5567/6次“复兴号”高铁体验专列上举行。来自中央驻鲁及京沪、省、市级重点媒体的记者以及山东省文化和旅游厅、沿线8地市文化和旅游局、企业代表、非遗传承人以及游客共同组成的体验团，成为“高铁环游齐鲁”旅游专列的首批乘客。",
      "details": "<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126151513_112.jpg\" alt=\"\" />\r\n</p>\r\n<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126151522_848.jpg\" alt=\"\" />\r\n</p>\r\n<p>\r\n\t　　为配合“冬游齐鲁·好客山东惠民季”活动的深入开展，11月24日，由中国铁路济南局集团公司与各地市文化和旅游部门精心组织策划的“高铁环游齐鲁”旅游营销推介会在G5567/6次“复兴号”高铁体验专列上举行。来自中央驻鲁及京沪、省、市级重点媒体的记者以及山东省文化和旅游厅、沿线8地市文化和旅游局、企业代表、非遗传承人以及游客共同组成的体验团，成为“高铁环游齐鲁”旅游专列的首批乘客。\r\n</p>\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126151543_627.jpg\" alt=\"\" />\r\n</div>\r\n　　淄博文化和旅游局组织的淄博文化旅游促销团登上“复兴号”专列，发布一系列针对“冬游齐鲁·好客山东惠民季”和“高铁环游齐鲁”的特色文化旅游产品及景区、酒店等优惠政策，宣传展示淄博文化旅游品牌形象、展示文创商品、手工纪念品等，使流动的车厢变成一张“乐游淄博”城市名片，为体验者奉献了一场跨越时空、极具特色的高铁文化旅游大餐。<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126151559_236.jpg\" alt=\"\" />\r\n</div>\r\n　　5号车厢内，金牌导游向体验团现场推介淄博文化旅游资源。聊斋俚曲研究理事会会长鞠素萍老师唱出婉转动听的聊斋俚曲，车厢内叫好声不绝于耳。据悉，蒲松龄老先生创作的聊斋俚曲，是首批国家级非物质文化遗产。它被誉为明清俗曲的“活化石”，至今已传唱三百多年，是山东地区一种独树一帜的群众性艺术形式。<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126151617_427.jpg\" alt=\"\" />\r\n</div>\r\n　　除了代表性景区展示推介，“乐游淄博”车厢还进行了多项淄博非遗文化及手工艺展示。齐州窑与兆霞陶瓷分别拿出了针对人们旅游出行所创新研发的熊猫悠乐泡、皿道系列等获奖产品；专列上的“高姐”亲自为布艺堆画、周村丝绸扎染技艺代言；周村烧饼、王村醋、知味斋（香肠、肉干、肴鸡等）是吃货们的最爱；张店“小炉匠”琉璃工作室带来的一件件颇具现代艺术气息的琉璃制品极富视觉冲击力，让人爱不释手的同时也感慨于中国传统文化的神奇。列车还未到站，车厢内的商品早早就被抢售一空。<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126151637_148.jpg\" alt=\"\" />\r\n</div>\r\n　　此外，体验者通过现场扫描二维码即可实现“一部手机畅游淄博”，不用下车就能了解齐国故都、聊斋故里、陶琉名城、世界足球起源地的历史文化和转型升级中的淄博，令这片文化遗存与自然山水相互交融、相互辉映的旅游福地和文化热土“圈粉”无数。<br />\r\n<br />\r\n　　据悉，鲁南（日兰）高速铁路日照至临沂至曲阜段将于11月26日正式开通运营，与已建成的京沪高铁、青盐铁路、济青高铁及胶济客专实现连通，山东省内形成高铁环形客运通道，串起济南、泰安、曲阜、临沂、日照、青岛、潍坊、淄博等地市，每天开行8趟高铁环形列车，从此旅客乘高铁环游齐鲁成为现实。周村古商城景区的一位负责人透露，“高铁环游齐鲁”专列的开通将进一步拓展景区临沂、日照等地的客源市场，游客数量将至少增加30% 。<br />"
    },
    {
      "releaseTime": "2019-11-23 15:33:03",
      "checkState": "1",
      "id": 1372,
      "titles": "淄博市第四家高标准城市书房落户天鸿万象",
      "image": "upload/2019-11-26/474fd606f8eb459da6d6287d776d9eed.jpg",
      "created": "2019-11-26 15:34:45",
      "createUser": "297ebc2d58dcd0510158dcd0adda0002",
      "back1": "11月23日，由淄博市图书馆、张店区体育场街道办事处和山东天鸿大成置业有限公司联合打造天鸿万象 “城市书房”（淄博市图书馆体育场街道分馆）建设合作签约仪式正式举行。市图书馆副馆长丁雷，张店区文化和旅游局副局长陈跃山，张店区图书馆馆长孙凤芹，体育场街道党工委副书记、办事处主任石璐，体育场街道党工委委员、办事处副主任刘雯雯，山东天鸿大成置业有限公司总经理王铭宇等领导以及部分周边市民参加了签约仪式。",
      "details": "<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126153358_855.jpg\" alt=\"\" />\r\n</p>\r\n<p>\r\n\t　　11月23日，由淄博市图书馆、张店区体育场街道办事处和山东天鸿大成置业有限公司联合打造天鸿万象 “城市书房”（淄博市图书馆体育场街道分馆）建设合作签约仪式正式举行。市图书馆副馆长丁雷，张店区文化和旅游局副局长陈跃山，张店区图书馆馆长孙凤芹，体育场街道党工委副书记、办事处主任石璐，体育场街道党工委委员、办事处副主任刘雯雯，山东天鸿大成置业有限公司总经理王铭宇等领导以及部分周边市民参加了签约仪式。\r\n</p>\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126153418_285.jpg\" alt=\"\" />\r\n</div>\r\n　　“城市书房”建设是适应新时代全市人民的基本文化需求，提升城市文化品位，助力文化名城建设的重要组成部分。淄博市图书馆计划利用3年时间建成至少10家高品质、现代时尚的“城市书房”，先期完成覆盖张店中心城区的图书馆总分馆服务网络。<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126153431_324.jpg\" alt=\"\" />\r\n</div>\r\n　　天鸿万象城市书房面积约400平方米。建成后，将是淄博市图书馆联合企业打造的第四家高品质、高标准、现代化的城市书房，为广大市民提供“便捷、高效、舒适”的阅读服务，发挥文化的引领作用。目前，淄博市图书馆合建的紫园城市书房和万科城市书房，开馆以来深受市民欢迎，两个城市书房共接待读者15.45万余人次，流通图书4.74万余册，开展阅读推广活动30余次，社会效应十分显著。银泰城城市书房也将于近期正式开馆运行。<br />"
    },
    {
      "releaseTime": "2019-11-21 18:40:24",
      "checkState": "1",
      "id": 1373,
      "titles": "市文化和旅游局召开专题会议",
      "image": "upload/2019-11-26/da2281af6f0b4190a48521f98229fd2c.jpg",
      "created": "2019-11-26 15:42:17",
      "createUser": "297ebc2d58dcd0510158dcd0adda0002",
      "back1": "11月21日下午，淄博市文化和旅游局召开专题会议，认真学习贯彻全市政务督查工作会议精神，进一步提高政治站位，不断增强责任感和紧迫感，以钉钉子精神抓好市委、市政府各项工作部署的贯彻落实。",
      "details": "<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126154133_936.jpg\" alt=\"\" />\r\n</p>\r\n<p>\r\n\t　　11月21日下午，淄博市文化和旅游局召开专题会议，认真学习贯彻全市政务督查工作会议精神，进一步提高政治站位，不断增强责任感和紧迫感，以钉钉子精神抓好市委、市政府各项工作部署的贯彻落实。\r\n</p>\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191126/20191126154145_156.jpg\" alt=\"\" />\r\n</div>\r\n　　一是全面梳理工作任务,做好年度工作目标冲刺。围绕《政府工作报告》确定的年度经济社会发展目标和政府常务会议确定事项以及重点工作、创新工作，组织机关科室召开年度工作任务完成情况调度会，对工作完成情况进行全面梳理，认真查漏补缺，分析原因，及时做出改进，确保各项任务目标圆满完成。<br />\r\n<br />\r\n　　二是建设督查信息化平台，促进督查工作智能化管理。创新督查工作方式，开发建设督查信息化平台，将市委、市政府及各部门交办事项统一录入平台，在局机关大厅LED屏幕实时滚动显示，实现督查工作“快速交办、定期提醒、台账管理、集中展示”，平台将于11月25日正式上线运行。<br />\r\n<br />\r\n　　三是开展系统工作培训，提高督查工作能力。拟于下周举办全市文化和旅游系统办公室暨政务信息工作培训班，重点围绕提升督查工作水平和督查信息报送质量，增强新形势、新任务、新要求下办公室人员统筹谋划、综合协调、文字表达、接待服务能力，为督查工作顺利开展提供坚强保障。<br />"
    }
  ]
}
         */

        public string GetNewsDetail(string id)
        {
            var news= newsRepository.Get(id);
            return news.details.ImageLocalizedText;
        }
    }
}
