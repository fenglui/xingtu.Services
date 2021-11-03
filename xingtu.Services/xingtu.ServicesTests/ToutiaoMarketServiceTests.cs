using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xingtu.Services;
using xingtu.ServicesTests;

namespace xingtu.Services.Tests
{
    [TestClass()]
    public class ToutiaoMarketServiceTests
    {
        [TestMethod()]
        public void GetHotListDataTest()
        {
            var tags = new HotListTag[] { HotListTag.颜值达人, HotListTag.剧情搞笑, HotListTag.美妆, HotListTag.旅行 };

            XingTuConfig cfg = (XingTuConfig)server.Services.GetService(typeof(XingTuConfig));


            foreach (var tag in tags)
            {
                var res = ToutiaoMarketService.GetHotListData(cfg, HotListType.达人指数榜, HotListTag.旅行);

                Assert.IsNotNull(res);

                Console.WriteLine($"{ res.Code } { res.Msg } ");

                Assert.IsNotNull(res.Data);

                Assert.IsNotNull(res.Data.Stars);

                Assert.IsTrue(res.Data.Stars.Count > 0);

                Console.WriteLine($" 昵称 城市 平均播放 评分（旧）评分（新）");

                foreach (var star in res.Data.Stars)
                {
                    Console.WriteLine($"{ star.NickName } { star.City } { star.AvgPlay } { star.OldRank } - { star.NewRank } ");
                }
            }
        }

        [TestMethod()]
        public void AuthorListTest()
        {
            XingTuConfig cfg = (XingTuConfig)server.Services.GetService(typeof(XingTuConfig));

            var res = ToutiaoMarketService.AuthorList(cfg, "沉默寡言老咖啡", page: 1, limit: 1);

            Assert.IsNotNull(res);

            Assert.IsNotNull(res.Data);

            if (null != res.Data)
            {
                foreach (var author in res.Data.Authors)
                {
                    Console.WriteLine($"{ author.TagsIds } { author.Id } { author.NickName } { author.City } 平均播放：{ author.AvgPlay } 预期播放量 { author.ExpectedPlayNum } 预期CPM {author.ExpectedCpm} 作品互动率 { author.PersonalInterateRate } 星图：{ author.IsStar } - { author.IsCollected } ");
                }
            }
        }

        TestServer server;

        [TestInitialize]
        public void Initialize()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var builder = TestProgram.CreateWebHostBuilder(new string[] { })
            .UseStartup<Startup>();

            server = new TestServer(builder);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (null != server)
            {
                server.Dispose();
            }
        }
    }
}