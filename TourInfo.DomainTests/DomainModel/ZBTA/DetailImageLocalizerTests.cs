using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourInfo.Domain.DomainModel.ZBTA;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace TourInfo.Domain.DomainModel.ZBTA.Tests
{
    [TestClass()]
    public class DetailImageLocalizerTests
    {
        [TestMethod()]
        public void LocalizeTest()
        {
            var fixture = new Fixture();
                fixture.Customize(new AutoMoqCustomization());

            var i = fixture.Create<IImageLocalizer>();
            string detail = "< p style =\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191220/20191220154814_629.jpg\" alt=\"\" />\r\n</p>\r\n<p>\r\n\t　　12月19日，山东省博物馆学会陶瓷专业委员会成立大会暨《山东省馆藏明清官窑瓷器展》开幕式在中国陶瓷琉璃馆举行。共97件从明代至清代的官窑瓷器集中亮相，为观众打造一场视觉盛宴。此次展览将持续至2020年3月20日，市民可免费参观，近距离感受明清官窑瓷器的华丽风采。\r\n</p>\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191220/20191220154826_664.jpg\" alt=\"\" />\r\n</div>\r\n　　市政府副秘书长刘波，市委宣传部副部长、调研员荣先锋，山东博物馆副馆长、山东省博物馆学会秘书长卢朝辉，市文化和旅游局党组成员、副局长，市陶瓷琉璃博物馆馆长曹丕祯，市文化和旅游局党组成员、副局长吴晓晖，青岛、烟台、潍坊、德州、济宁等地市博物馆负责人以及文化和旅游行业共百余人出席活动，吴晓晖主持仪式。<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191220/20191220154838_373.jpg\" alt=\"\" />\r\n</div>\r\n　　曹丕祯致开幕辞，他表示，本次活动既是山东省博物馆学会的一件大事、喜事，也是淄博市文化和旅游系统的一件大事、喜事，此举对加快淄博市文旅融合发展、促进文化名城建设具有重大而深远的意义。淄博市陶瓷博物馆作为山东省博物馆学会团体会员单位和陶瓷专业委员会挂靠单位，要自觉履行会员单位义务和挂靠单位责任，认真学习和借鉴各兄弟馆的好经验好做法，积极融入文博事业和博物馆学会这个大家庭，努力搭建全省陶瓷专业人才培养、学术交流、展览展示服务平台，发挥好桥梁和纽带作用，促进馆际交流和学术交流，为推动全省博物馆事业发展做出积极贡献。<br />\r\n<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191220/20191220154848_469.jpg\" alt=\"\" />\r\n</p>\r\n<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191220/20191220154858_21.jpg\" alt=\"\" />\r\n</p>\r\n<p>\r\n\t　　一件件精美的瓷器在展厅内交相辉映，获得现场观众的一致好评与交口称赞。“这些瓷器造型和纹饰精美、色彩丰富、工艺水准极高，在这里既感受到古代皇家韵味与时代风貌，同时也展现了帝王的审美情趣与精神情感，这样的文化饕餮盛宴很有意义，希望以后可以经常举办此类活动 ”张店区市民朱先生说。\r\n</p>\r\n<p>\r\n\t<br />\r\n</p>\r\n　　据悉，此次展览由中国陶瓷琉璃馆联合山东博物馆、青岛市博物馆、烟台市博物馆、潍坊市博物馆、淄博市博物馆等共同举办。明清官窑瓷器以构图严谨，形制考究，制器精巧等特点闻名，一直以来都是博物馆收藏的一个重要门类。本次展览展出了明清时期的青花、粉彩、五彩、斗彩、素三彩、单色釉等各类官窑瓷器精品97件，展器社会价值、历史价值、经济价值较高，展览数量最多、规模最大，在山东省内尚属首次。<br />\r\n<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191220/20191220154929_249.jpg\" alt=\"\" />\r\n</div>\r\n<p>\r\n\t　　为弘扬中华优秀陶瓷文化，搭建全省博物馆陶瓷专业领域文物研究和学术交流平台，促进文博系统陶瓷专业发展。当日下午，山东省博物馆学会陶瓷专业委员会成立大会暨第一次委员代表大会在淄博举办。\r\n</p>\r\n<p style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191220/20191220154949_121.jpg\" alt=\"\" />\r\n</p>\r\n　　会议表决通过了《山东省博物馆学会陶瓷专业委员会管理办法（草案）》《山东省博物馆学会陶瓷专业委员会换届选举办法（草案）》，选举出了山东省博物馆学会陶瓷专业委员会第一届委员会主任委员、副主任委员、秘书长等。<br />\r\n<div style=\"text-align:center;\">\r\n\t<img src=\"/ziboback/upload/image/20191220/20191220155003_950.jpg\" alt=\"\" />\r\n</div>\r\n　　新当选的陶瓷专委会主任委员、市陶瓷琉璃博物馆副馆长战化军致辞，他表示，近年来，随着“博物馆热”的出现，使得平时在普通观众眼中“高冷”的博物馆逐渐走进寻常百姓家。博物馆开始由收藏中心向传播知识文化的教育中心转变，许多博物馆成为爱国主义教育基地、思想品德教育基地。博物馆成为研学游基地已成为趋势。专委会下一步工作要加强博物馆科普教育、文化娱乐项目和工艺互动体验项目的开发，寓教于乐，逐步将博物馆打造成研学游基地和文旅融合前沿阵地。<br />";
                DetailImageLocalizer detailImageLocalizer = new DetailImageLocalizer(i,"","");
            detailImageLocalizer.Localize(detail,"version");
        }
    }
}