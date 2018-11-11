using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawler.Entities
{
    public class Name
    {
        public string english { get; set; }

        public override string ToString()
        {
            return "Name Properties:\n"
                 + "\tenglish: " + english + "\n";
        }
    }

    public class SetInfo
    {
        public int set_id { get; set; }
        public int pack_item_def { get; set; }
        public Name name { get; set; }

        public override string ToString()
        {
            string returnString = "SetInfo Properties:\n"
                + "\tset_id: " + set_id + "\n"
                + "\tpack_item_def: " + pack_item_def + "\n";
            returnString += (name != null) ? ("\tname: " + name.ToString() + "\n") : ("\tname: NULL\n");
            return returnString;
        }
    }

    public class CardName
    {
        public string english { get; set; }

        public override string ToString()
        {
            return "CardName Properties:\n"
                 + "\tenglish: " + english + "\n";
        }
    }

    public class CardText
    {
        public string english { get; set; }

        public override string ToString()
        {
            return "CardText Properties:\n"
                 + "\tenglish: " + english + "\n";
        }
    }

    public class MiniImage
    {
        public string @default { get; set; }

        public override string ToString()
        {
            return "MiniImage Properties:\n"
                 + "\t@default: " + @default + "\n";
        }
    }

    public class LargeImage
    {
        public string @default { get; set; }

        public override string ToString()
        {
            return "LargeImage Properties:\n"
                 + "\t@default: " + @default + "\n";
        }
    }

    public class IngameImage
    {
        public string @default { get; set; }

        public override string ToString()
        {
            return "IngameImage Properties:\n"
                 + "\t@default: " + @default + "\n";
        }
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

        public override string ToString()
        {
            string returnString = "CardList Properties:\n"
                + "\tcard_id: " + card_id + "\n"
                + "\tbase_card_id: " + base_card_id + "\n"
                + "\tcard_type: " + card_type + "\n";
            returnString += (card_name != null) ? ("\tcard_name: " + card_name.ToString() + "\n") : ("\tcard_name: NULL\n");
            returnString += (card_text != null) ? ("\tcard_text: " + card_text.ToString() + "\n") : ("\tcard_text: NULL\n");
            returnString += (mini_image != null) ? ("\tmini_image: " + mini_image.ToString() + "\n") : ("\tmini_image: NULL\n");
            returnString += (large_image != null) ? ("\tlarge_image: " + large_image.ToString() + "\n") : ("\tlarge_image: NULL\n");
            returnString += (ingame_image != null) ? ("\tingame_image: " + ingame_image.ToString() + "\n") : ("\tingame_image: NULL\n");
            returnString += "\thit_points: " + hit_points + "\n";
            if (references != null && references.Count > 0)
            {
                int i = 1;
                foreach (object o in references)
                {
                    returnString += "\treferences #" + i + ": " + o.ToString() + "\n";
                    i++;
                }
            }
            else
            {
                returnString += "\treferences: NULL\n";
            }
            returnString += "\tillustrator: " + illustrator + "\n"
                + "\tmana_cost: " + mana_cost + "\n"
                + "\tattack: " + attack + "\n"
                + "\tis_black: " + is_black + "\n"
                + "\tsub_type: " + sub_type + "\n"
                + "\tgold_cost: " + gold_cost + "\n"
                + "\tis_green: " + is_green + "\n"
                + "\tis_red: " + is_red + "\n"
                + "\tarmor: " + armor + "\n"
                + "\tis_blue: " + is_blue + "\n";
            return returnString;
        }
    }

    public class CardSet
    {
        public int version { get; set; }
        public SetInfo set_info { get; set; }
        public List<CardList> card_list { get; set; }

        public override string ToString()
        {
            string returnString = "CardSet Properties:\n"
                                + "\tversion: " + version + "\n";
            returnString += (set_info != null) ? ("\tset_info: " + set_info.ToString() + "\n") : ("\tset_info: NULL\n");
            if(card_list != null && card_list.Count > 0)
            {
                int i = 1;
               foreach(CardList list in card_list)
               {
                    returnString += "\tcard_list #" + i + ": " + list.ToString() + "\n";
                    i++;
               }
            }
            else
            {
                returnString += "\tcard_list: NULL\n";
            }
            return returnString;
        }
    }

    public class CardSetRootObject
    {
        public CardSet card_set { get; set; }

        public override string ToString()
        {
            string returnString = "CardSetRootObject Properties:\n";
            returnString += (card_set != null) ? ("\tcard_set: " + card_set.ToString() + "\n") : ("\tcard_set: NULL\n");
            return returnString;
        }
    }
}
