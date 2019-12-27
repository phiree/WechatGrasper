using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourInfo.Infrastracture;
using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using TourInfo.Domain;

namespace TourInfo.Infrastracture.Tests
{
    [TestClass()]
    public class ImageLocalizerTests
    {
        [TestMethod()]
        public void LocalizeTest()
        {
            
        }
        public class DemoInfo
        { 
            public string Name { get;set;}
            public ImageUrl TitlePic { get;set;}
            public IList<ImageUrl> DetailPics { get; set; }
        }
    }
}