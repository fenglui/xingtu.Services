using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Web;

namespace xingtu.Services
{
    public enum HotListType
    {
        达人指数榜,
        涨粉指数榜
    }

    public enum HotListTag
    {
        颜值达人,
        剧情搞笑,
        美妆,
        时尚,
        萌宠,
        音乐,
        舞蹈,
        美食,
        游戏,
        旅行,
        汽车,
        生活,
        测评,
        二次元,
        母婴亲子,
        科技数码,
        教育培训,
        运动健身,
        家居家装,
        才艺技能,
        影视娱乐,
        艺术文化,
        财经投资,
        情感,
        三农,
        园艺
    }

    public static class ToutiaoMarketService
    {
        static readonly string apiV = "https://star.toutiao.com/v/api";
        static readonly string apiH = "https://star.toutiao.com/h/api";

        static String getHotListTypeId(HotListType type)
        {
            switch (type)
            {
                case HotListType.达人指数榜:
                    return "6766936376500813837";

                case HotListType.涨粉指数榜:
                    return "6720184315054915588";
            }
            // 全部
            return "6766936376500813837";
        }

        static String getSign(HotListTag tag)
        {
            switch (tag)
            {
                case HotListTag.颜值达人:
                    return "dd13e4123f98b324a180bab753bc628c";

                case HotListTag.剧情搞笑:
                    return "ad12718bce3776998bb250bc4cd3a6a9";

                case HotListTag.美妆:
                    return "ff2e737d9008f495347908924878aaaf";

                case HotListTag.时尚:
                    return "6f4ba341c3744daabf0456d482d11dc9";

                case HotListTag.萌宠:
                    return "e42e33dbff38f86e086a92d4a7c701ad";

                case HotListTag.音乐:
                    return "458e07ea4f387008dc21a4a4321ece76";

                case HotListTag.舞蹈:
                    return "58df0a68bbc790f1f7a72cb366ef774f";

                case HotListTag.美食:
                    return "109060a3de7154dfeeb7bbb3d71c815a";

                case HotListTag.游戏:
                    return "3c0bbcb5a77af35e89d5a3f4c1f27d6e";

                case HotListTag.旅行:
                    return "8ad4e0f8d311331679df0ee4ee0e2222";

                case HotListTag.汽车:
                    return "576874d80792429288226e1eeb3d8fe3";

                case HotListTag.生活:
                    return "f4afdc41eff79a011c15240aafe699ad";

                case HotListTag.测评:
                    return "13d3b98b4ed53cd4bd94b484f05f6fb8";

                case HotListTag.二次元:
                    return "94f85ba5e09faa8f44e73281add376dd";

                case HotListTag.母婴亲子:
                    return "bbfe3df3e4723905aa1ce85f8d517d92";

                case HotListTag.科技数码:
                    return "2c5f2fd675f1a2c6b4489753fc19f417";

                case HotListTag.教育培训:
                    return "209545266b0ab86277602f6bf366bffa";

                case HotListTag.运动健身:
                    return "83aed6604a6bd57b8b24b0315e02669a";

                case HotListTag.家居家装:
                    return "253a39d7354fdfeda434b71f521db36c";

                case HotListTag.才艺技能:
                    return "2b2635b3697700078a79c716cb019d61";

                case HotListTag.影视娱乐:
                    return "d2b2e189aec4c6349ad2980d0279da6e";

                case HotListTag.艺术文化:
                    return "4b1191492b150415e331da02c69c0b10";

                case HotListTag.财经投资:
                    return "313239b33b29720e752698033d72e0ce";

                case HotListTag.情感:
                    return "be47713df317e09574b0a7e880e3cec2";

                case HotListTag.三农:
                    return "23c34c6b6a480c5a292e76eced7b5252";

                case HotListTag.园艺:
                    return "929bfc99bbfd53c671e7538a5d0e3951";
            }
            // 全部
            return "dd13e4123f98b324a180bab753bc628c";
        }

        /// <summary>
        /// 达人指数榜
        /// </summary>
        /// <returns></returns>
        public static GetHotListDataResult GetHotListData(XingTuConfig cfg, HotListType listType, HotListTag listTag, IWebProxy proxy = null)
        {
            string tag = listTag.ToString();
            if (String.IsNullOrEmpty(tag) == false)
            {
                tag = HttpUtility.UrlEncode(tag);
            }

            String hotListId = getHotListTypeId(listType);

            String sign = getSign(listTag);

            String url = $"{ apiH }/gateway/handler_get/?hot_list_id={hotListId}&tag={tag}&service_name=author.AdStarAuthorService&service_method=GetHotListData&sign={sign}";

            String responseBody = ToutiaoTool.StarRequest(cfg, url, @"https://star.toutiao.com/ad/hot", @"author.AdStarAuthorService", @"GetHotListData", proxy);

            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<GetHotListDataResult>(responseBody);
            }
            catch (Exception)
            {
                Console.WriteLine(responseBody);

                throw;
            }
        }

        public static ToutiaoMarketAuthorResult AuthorListDefault(XingTuConfig cfg)
        {
            return AuthorList(cfg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        /// <param name="tag"></param>
        /// <param name="industry_tag_level_one"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static ToutiaoMarketAuthorResult AuthorList(XingTuConfig cfg, string k = "", int tag = 0, string industry_tag_level_one = "", int page = 1, int limit = 100, int platform = 1, string saveToFile = null, IWebProxy proxy = null)
        {
            Console.WriteLine($"AuthorList k is {k}");

            string url = $"{ apiV }/demand/author_list/?limit={ limit }&need_detail=true&page={ page }&platform_source={ platform }&task_category=1&order_by=score&disable_replace_keyword=false&is_filter=true";

            if (tag > 0)
            {
                url += $"&tag={ tag }";
            }

            if (string.IsNullOrEmpty(industry_tag_level_one) == false)
            {
                url += $"&industry_tag_level_one={ HttpUtility.UrlEncode(industry_tag_level_one) }";
            }

            if (string.IsNullOrEmpty(k) == false)
            {
                url += $"&key={ HttpUtility.UrlEncode(k) }";
            }

            string responseData = ToutiaoTool.StarRequest(cfg, url, @"https://star.toutiao.com/ad/market", proxy: proxy);
            //Console.WriteLine(responseData);
            if (string.IsNullOrEmpty(responseData))
            {
                return null;
            }
            if (string.IsNullOrEmpty(saveToFile) == false)
            {
                File.WriteAllText(saveToFile, responseData);
            }
            try
            {
                return JsonSerializer.Deserialize<ToutiaoMarketAuthorResult>(responseData);
            }
            catch (Exception ex)
            {
                string file = $"{k}_{industry_tag_level_one}_{ tag }_{page}_{limit}.err.json";
                File.WriteAllText(file, responseData);

                Console.WriteLine($"{ex.Message}");
                if (null != ex.InnerException)
                {
                    Console.WriteLine($"{ex.InnerException.Message}");
                }
                throw;
            }
        }


        public static IList<Authors> ReadJson(String industry_tag_level_one = "", int tag = 0, int limit = 100, int totalPage = 1)
        {
            List<Authors> authors = new List<Authors>(1);
            for (int page = 1; page <= totalPage; page++)
            {
                var file = $"{industry_tag_level_one}_{ tag }_{page}_{limit}.json";
                var json = System.IO.File.ReadAllText(file);

                ToutiaoMarketAuthorResult res = null;

                try
                {
                    res = JsonSerializer.Deserialize<ToutiaoMarketAuthorResult>(json);
                }
                catch (Exception)
                {
                    Console.WriteLine(file);
                    throw;
                }

                authors.AddRange(res.Data.Authors);
            }
            return authors;
        }

        public class Foo
        {
            //public int Id { get; set; }
            public string NickName { get; set; }


            public int Follower { get; set; }

            public float ExpectedCpm { get; set; }
            public int? LowestPrice { get; set; }

            //public String Price1Desc { get; set; }

            // 1-20s视频
            public int? Price1_20s { get; set; }

            public String Price1_20s_Desc { get; set; }

            public int? Price20_60s { get; set; }

            public String Price20_60s_Desc { get; set; }

            public int? Price60s { get; set; }

            public String Price60s_Desc { get; set; }

            public int? Price1_60s { get; set; }

            public String Price1_60s_Desc { get; set; }
        }
    }
}
