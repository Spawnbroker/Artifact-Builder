using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Entities
{
    public class Name
    {
        public string english { get; set; }
    }

    public class SetInfo
    {
        public int set_id { get; set; }
        public int pack_item_def { get; set; }
        public Name name { get; set; }
    }

    public class CardName
    {
        public string english { get; set; }
    }

    public class CardText
    {
        public string english { get; set; }
    }

    public class MiniImage
    {
        public string @default { get; set; }
    }

    public class LargeImage
    {
        public string @default { get; set; }
    }

    public class IngameImage
    {
        public string @default { get; set; }
    }

    public class CardList
    {
        public int card_id { get; set; }
        public int base_card_id { get; set; }
        public string card_type { get; set; }
        public CardName card_name { get; set; }
        public CardText card_text { get; set; }
        public MiniImage mini_image { get; set; }
        public LargeImage large_image { get; set; }
        public IngameImage ingame_image { get; set; }
        public int hit_points { get; set; }
        public List<object> references { get; set; }
        public string illustrator { get; set; }
        public int? mana_cost { get; set; }
        public int? attack { get; set; }
        public bool? is_black { get; set; }
        public string sub_type { get; set; }
        public int? gold_cost { get; set; }
        public bool? is_green { get; set; }
        public bool? is_red { get; set; }
        public int? armor { get; set; }
        public bool? is_blue { get; set; }
    }

    public class CardSet
    {
        public int version { get; set; }
        public SetInfo set_info { get; set; }
        public List<CardList> card_list { get; set; }
    }

    public class CardSetRootObject
    {
        public CardSet card_set { get; set; }
    }
}
