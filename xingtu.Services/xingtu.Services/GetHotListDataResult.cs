using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace xingtu.Services
{
   
    public class GetHotListDataResult 
    {
        [JsonPropertyName("msg")]
        public string Msg {get; set;}
        [JsonPropertyName("code")]
        public int Code {get; set;}
        [JsonPropertyName("data")]
        public GetHotListDataResultData Data {get; set;}
    }

    public class GetHotListDataResultData
    {
        [JsonPropertyName("file_name")]
        public string FileName {get; set;}
        [JsonPropertyName("total_cnt")]
        public int TotalCnt {get; set;}
        [JsonPropertyName("stars")]
        public IList<Stars> Stars {get; set;}
        [JsonPropertyName("conf")]
        public Conf Conf {get; set;}
    }

    public class Stars 
    {
        [JsonPropertyName("province")]
        public string Province {get; set;}
        [JsonPropertyName("city")]
        public string City {get; set;}
        [JsonPropertyName("old_rank")]
        public int OldRank {get; set;}
        [JsonPropertyName("nick_name")]
        public string NickName {get; set;}
        [JsonPropertyName("fields")]
        public IList<Fields> Fields {get; set;}
        [JsonPropertyName("is_collected")]
        public bool IsCollected {get; set;}
        [JsonPropertyName("avatar_uri")]
        public string AvatarUri {get; set;}
        [JsonPropertyName("avg_play")]
        public int AvgPlay {get; set;}
        [JsonPropertyName("new_rank")]
        public int NewRank {get; set;}
        [JsonPropertyName("id")]
        public string Id {get; set;}
        [JsonPropertyName("core_user_id")]
        public string CoreUserId {get; set;}
    }

    public class Fields 
    {
        [JsonPropertyName("value")]
        public string Value {get; set;}
        [JsonPropertyName("label")]
        public string Label {get; set;}
    }

    public class Conf 
    {
        [JsonPropertyName("status")]
        public int Status {get; set;}
        [JsonPropertyName("platform_channel")]
        public int PlatformChannel {get; set;}
        [JsonPropertyName("description")]
        public string Description {get; set;}
        [JsonPropertyName("weight")]
        public int Weight {get; set;}
        [JsonPropertyName("tags")]
        public IList<Tags> Tags {get; set;}
        [JsonPropertyName("enable_tag")]
        public int EnableTag {get; set;}
        [JsonPropertyName("platform_source")]
        public int PlatformSource {get; set;}
        [JsonPropertyName("name")]
        public string Name {get; set;}
        [JsonPropertyName("item_type")]
        public int ItemType {get; set;}
        [JsonPropertyName("create_time")]
        public int CreateTime {get; set;}
        [JsonPropertyName("modify_time")]
        public int ModifyTime {get; set;}
        [JsonPropertyName("fields_conf")]
        public IList<FieldsConf> FieldsConfs {get; set;}
        [JsonPropertyName("type")]
        public int Type {get; set;}
        [JsonPropertyName("id")]
        public string Id {get; set;}
        [JsonPropertyName("system_type")]
        public int SystemType {get; set;}
    }

    public class Tags 
    {
        [JsonPropertyName("value")]
        public string Value {get; set;}
        [JsonPropertyName("label")]
        public string Label {get; set;}
    }

    public class FieldsConf 
    {
        [JsonPropertyName("display_order")]
        public int DisplayOrder {get; set;}
        [JsonPropertyName("label")]
        public string Label {get; set;}
        [JsonPropertyName("desc")]
        public string Desc {get; set;}
    }
}
