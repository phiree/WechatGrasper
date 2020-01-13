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
            var imageLocalizer = fixture.Freeze<Mock<IImageLocalizer>>();
            string localSavedPath = "../download/img/";
            string imageClientPath = "download/img";
           
            imageLocalizer.Setup(x => x.Localize( It.IsAny<string>(),localSavedPath,imageClientPath))
                .Returns("downloadimage/folder1/1.jpg");

            var InfoLocalizer = fixture.Create<InfoLocalizer<DemoInfo,string>>();
            bool isExisted;
            InfoLocalizer.Localize ( mediaInfo, string.Empty, localSavedPath,imageClientPath,"version1",out isExisted);
            Assert.AreEqual("downloadimage/folder1/1.jpg",mediaInfo.TitlePic.LocalizedUrl);
            Assert.AreEqual("downloadimage/folder1/1.jpg",mediaInfo.DetailPics[0].LocalizedUrl);

        }

        public class DemoInfo:VersionedEntity<string>
        {
            public string Name { get; set; }
            public ImageUrl TitlePic { get; set; }
            public  ImageUrl[] DetailPics { get; set; }
        }
    }
}