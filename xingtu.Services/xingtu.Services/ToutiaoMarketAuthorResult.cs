namespace xingtu.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ToutiaoMarketAuthorResult 
    {
        [JsonPropertyName("msg")]
        public string Msg {get; set;}
        [JsonPropertyName("code")]
        public int Code {get; set;}
        [JsonPropertyName("data")]
        public ToutiaoMarketAuthorData Data {get; set;}
    }

    public class ToutiaoMarketAuthorData
    {
        [JsonPropertyName("extra_data")]
        public ExtraData ExtraData {get; set;}
        [JsonPropertyName("pagination")]
        public Pagination Pagination {get; set;}
        [JsonPropertyName("recommends")]
        public IList<Recommends> Recommends {get; set;}
        [JsonPropertyName("search_session_id")]
        public string SearchSessionId {get; set;}
        [JsonPropertyName("authors")]
        public IList<Authors> Authors {get; set;}
    }

    public class ExtraData 
    {
        [JsonPropertyName("original_keyword")]
        public string OriginalKeyword {get; set;}
        [JsonPropertyName("has_replaced")]
        public bool HasReplaced {get; set;}
        [JsonPropertyName("actual_keyword")]
        public string ActualKeyword {get; set;}
    }

    public class Pagination 
    {
        [JsonPropertyName("has_more")]
        public bool HasMore {get; set;}
        [JsonPropertyName("total_count")]
        public int TotalCount {get; set;}
        [JsonPropertyName("limit")]
        public int Limit {get; set;}
        [JsonPropertyName("page")]
        public int Page {get; set;}
    }

    public class Recommends 
    {

    }

    public class Authors 
    {
        [JsonPropertyName("tags_author_style")]
        public string TagsAuthorStyle {get; set;}

        [JsonPropertyName("has_coupon")]
        public bool HasCoupon {get; set;}

        [JsonPropertyName("grade")]
        public int Grade {get; set;}

        [JsonPropertyName("is_star")]
        public bool IsStar {get; set;}

        [JsonPropertyName("rank")]
        public int Rank {get; set;}

        /// <summary>
        /// 粉丝数
        /// </summary>
        [JsonPropertyName("follower")]
        public int Follower {get; set;}

        /// <summary>
        /// 平均播放
        /// </summary>
        [JsonPropertyName("avg_play")]
        public int AvgPlay { get; set; }

        /// <summary>
        /// 预期播放量
        /// </summary>
        [JsonPropertyName("expected_play_num")]
        public int ExpectedPlayNum { get; set; }

        /// <summary>
        /// 作品互动率
        /// </summary>
        [JsonPropertyName("personal_interate_rate")]
        public float PersonalInterateRate { get; set; }


        [JsonPropertyName("create_time")]
        public float CreateTime {get; set;}

        [JsonPropertyName("tags_ids")]
        public string TagsIds {get; set;}

        [JsonPropertyName("settlement_types")]
        public IList<Int32> SettlementTypes {get; set;}

        [JsonPropertyName("id")]
        public string Id {get; set;}

        [JsonPropertyName("appeal_id")]
        public Int64? AppealId {get; set;}

        [JsonPropertyName("city")]
        public string City {get; set;}

        [JsonPropertyName("short_id")]
        public Int64 ShortId {get; set;}

        [JsonPropertyName("abandon_sign_result")]
        public int AbandonSignResult {get; set;}

        [JsonPropertyName("aweme_tags")]
        public IList<String> AwemeTags {get; set;}

        [JsonPropertyName("tags")]
        public string Tags {get; set;}

        [JsonPropertyName("platform_source")]
        public int PlatformSource {get; set;}

        [JsonPropertyName("activity_icon_url")]
        public string ActivityIconUrl {get; set;}

        [JsonPropertyName("expected_cpm")]
        public float ExpectedCpm {get; set;}

        [JsonPropertyName("is_collected")]
        public bool IsCollected {get; set;}

        [JsonPropertyName("tags_level_two")]
        public string TagsLevelTwo {get; set;}

        [JsonPropertyName("recommend")]
        public bool Recommend {get; set;}

        [JsonPropertyName("lowest_price")]
        public int? LowestPrice {get; set;}

        [JsonPropertyName("author_type")]
        public int AuthorType {get; set;}

        [JsonPropertyName("province")]
        public string Province {get; set;}

        [JsonPropertyName("online_status")]
        public int? OnlineStatus {get; set;}
        [JsonPropertyName("e_commerce_enable")]

        public bool ECommerceEnable {get; set;}
        [JsonPropertyName("order_cnt")]
        public int OrderCnt {get; set;}

        [JsonPropertyName("creator_type")]
        public int CreatorType {get; set;}

        [JsonPropertyName("hot_list_ranks")]
        public IList<HotListRank> HotListRanks {get; set;}
        [JsonPropertyName("is_online")]
        public bool IsOnline {get; set;}
        [JsonPropertyName("has_phone")]
        public bool HasPhone {get; set;}
        [JsonPropertyName("core_user_id")]
        public Int64 CoreUserId {get; set;}

        [JsonPropertyName("category_id")]
        public int CategoryId {get; set;}

        [JsonPropertyName("is_plan_author")]
        public bool IsPlanAuthor {get; set;}
        [JsonPropertyName("protocol_id")]
        public int? ProtocolId {get; set;}
        [JsonPropertyName("nick_name")]
        public string NickName {get; set;}
        [JsonPropertyName("gender")]
        public int Gender {get; set;}
        [JsonPropertyName("tags_relation")]
        public TagsRelation TagsRelation {get; set;}
        [JsonPropertyName("opened_task_category")]
        public IList<int> OpenedTaskCategorys {get; set;}
        [JsonPropertyName("activity_info")]
        public IList<ActivityInfo> ActivityInfos {get; set;}
        [JsonPropertyName("tags_ids_level_two")]
        public string TagsIdsLevelTwo {get; set;}
        [JsonPropertyName("modify_time")]
        public float ModifyTime {get; set;}
        [JsonPropertyName("avatar_uri")]
        public string AvatarUri {get; set;}
        [JsonPropertyName("price_info")]
        public IList<PriceInfo> PriceInfos {get; set;}
        [JsonPropertyName("task_status")]
        public int? TaskStatus {get; set;}

        [JsonPropertyName("unique_id")]
        public object UniqueId { get; set; }

        [JsonPropertyName("star_tags")]
        public IList<StarTags> StarTags {get; set;}
    }

    public class TagsRelation 
    {
        [JsonPropertyName("运动健身")]
        public IList<string> 运动健身s {get; set;}
        [JsonPropertyName("旅行")]
        public IList<string> 旅行s {get; set;}
        [JsonPropertyName("情感")]
        public IList<string> 情感s {get; set;}
        [JsonPropertyName("美食")]
        public IList<string> 美食s {get; set;}
        [JsonPropertyName("颜值达人")]
        public IList<string> 颜值达人s {get; set;}
        [JsonPropertyName("美妆")]
        public IList<string> 美妆s {get; set;}
        [JsonPropertyName("舞蹈")]
        public IList<string> 舞蹈s {get; set;}
        [JsonPropertyName("生活")]
        public IList<string> 生活s {get; set;}
    }

    public class ActivityInfo 
    {

    }

    public class HotListRank
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("hot_list_name")]
        public string HotListName { get; set; }

        [JsonPropertyName("rank")]
        public Int32 Rank { get; set; }

        [JsonPropertyName("hot_list_id")]
        public string HotListId { get; set; }
    }

    public class PriceInfo 
    {
        [JsonPropertyName("template_list")]
        public IList<TemplateList> TemplateLists {get; set;}
        [JsonPropertyName("settlement_desc")]
        public string SettlementDesc {get; set;}
        [JsonPropertyName("enable")]
        public bool Enable {get; set;}
        [JsonPropertyName("platform_activity_id")]
        public decimal? PlatformActivityId {get; set;}
        [JsonPropertyName("price")]
        public int? Price {get; set;}
        [JsonPropertyName("settlement_type")]
        public int SettlementType {get; set;}
        [JsonPropertyName("platform_source")]
        public int PlatformSource {get; set;}
        [JsonPropertyName("video_type")]
        public int VideoType {get; set;}
        [JsonPropertyName("activity_info")]
        public IList<ActivityInfo> ActivityInfos {get; set;}
        [JsonPropertyName("field")]
        public string Field {get; set;}
        [JsonPropertyName("is_open")]
        public bool IsOpen {get; set;}
        [JsonPropertyName("has_discount")]
        public bool HasDiscount {get; set;}
        [JsonPropertyName("need_price")]
        public bool NeedPrice {get; set;}
        [JsonPropertyName("author_id")]
        public string AuthorId {get; set;}
        [JsonPropertyName("task_category")]
        public int TaskCategory {get; set;}
        [JsonPropertyName("origin_price")]
        public int? OriginPrice {get; set;}
        [JsonPropertyName("desc")]
        public string Desc {get; set;}
    }

    public class TemplateList 
    {

    }

    public class StarTags 
    {
        [JsonPropertyName("tag_desc")]
        public object TagDesc {get; set;}
        [JsonPropertyName("tag_value")]
        public int TagValue {get; set;}
        [JsonPropertyName("tag_type")]
        public int TagType {get; set;}
    }
}
