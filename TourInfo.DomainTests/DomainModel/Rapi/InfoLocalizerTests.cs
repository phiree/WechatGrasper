using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourInfo.Domain.DomainModel.Rapi;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;

namespace TourInfo.Domain.DomainModel.Rapi.Tests
{
    [TestClass()]
    public class InfoLocalizerTests
    {
        [TestMethod()]
        public void LocalizerTest()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mediaInfo = fixture.Freeze<TourInfo.Domain.DomainModel.Rapi.Pubmediainfo>();
            var imageLocalizer = fixture.Freeze<Mock<IImageLocalizer>>();
            string localSavedPath = "download/img/";
            imageLocalizer.Setup(x => x.Localize(It.IsAny<string>(),localSavedPath))
                .Returns("downloadimage/folder1/1.jpg");

            var InfoLocalizer = fixture.Create<InfoLocalizer<Pubmediainfo>>();
            InfoLocalizer.Localizer(mediaInfo, localSavedPath);
            Assert.AreEqual("downloadimage/folder1/1.jpg",mediaInfo.mediaurl.LocalizedUrl);

        }
    }
}