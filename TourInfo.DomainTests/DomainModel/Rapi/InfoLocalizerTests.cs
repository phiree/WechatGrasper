using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourInfo.Domain.DomainModel.Rapi;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using TourInfo.Domain.Base;

namespace TourInfo.Domain.DomainModel.Rapi.Tests
{
    [TestClass()]
    public class InfoLocalizerTests
    {
        [TestMethod()]
        public void LocalizerTest()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mediaInfo = fixture.Freeze<DemoInfo>();
            mediaInfo.NewsDetail =new ImageUrlsInText( "<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20200106/20200106093431_951.jpg\" alt=\"\" />  　1月4日，在桓台县新时代文明实践中心推出非遗、文旅商品年货大集展销活动。“齐风冬韵”淄博文化旅游惠民展销暨桓台县首届民俗文化艺术节、乐游桓台贺年会将持续开展系列活动，营造新时代新年味，丰富和活跃群众精神文化生活。<br />");
            var imageLocalizer = fixture.Freeze<Mock<IImageLocalizer>>();
            string localSavedPath = "../download/img/";
            string imageClientPath = "download/img";
            imageLocalizer.Setup(x => x.Localize( It.IsAny<string>(),localSavedPath,imageClientPath))
                .Returns("downloadimage/folder1/1.jpg");

            var repository = fixture.Freeze < Mock<IRepository<DemoInfo, string>>>();
            repository.Setup(x => x.Get(It.IsAny<string>())).Returns<DemoInfo>(null);

            var InfoLocalizer = fixture.Create<InfoLocalizer<DemoInfo,string>>();
            bool isExisted;
            InfoLocalizer.Localize ( mediaInfo, string.Empty, localSavedPath,imageClientPath,"version1",out isExisted);
            Assert.AreEqual("downloadimage/folder1/1.jpg",mediaInfo.TitlePic.LocalizedUrl);
            Assert.AreEqual("downloadimage/folder1/1.jpg",mediaInfo.DetailPics[0].LocalizedUrl);
            Assert.AreEqual("<p style=\"text-align:center;\">\r\n\t<img src=\"downloadimage/folder1/1.jpg\" alt=\"\" />  　1月4日，在桓台县新时代文明实践中心推出非遗、文旅商品年货大集展销活动。“齐风冬韵”淄博文化旅游惠民展销暨桓台县首届民俗文化艺术节、乐游桓台贺年会将持续开展系列活动，营造新时代新年味，丰富和活跃群众精神文化生活。<br />"
                , mediaInfo.NewsDetail.ImageLocalizedText);
            Assert.AreEqual("<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20200106/20200106093431_951.jpg\" alt=\"\" />  　1月4日，在桓台县新时代文明实践中心推出非遗、文旅商品年货大集展销活动。“齐风冬韵”淄博文化旅游惠民展销暨桓台县首届民俗文化艺术节、乐游桓台贺年会将持续开展系列活动，营造新时代新年味，丰富和活跃群众精神文化生活。<br />", mediaInfo.NewsDetail.OriginaText);
        }

        public class DemoInfo:VersionedEntity<string>
        {
            public string Name { get; set; }
            public ImageUrl TitlePic { get; set; }
            public  IList<ImageUrl> DetailPics { get; set; }
            public ImageUrlsInText NewsDetail { get; set; }
        }
    }
}