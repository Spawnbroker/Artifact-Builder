using CardCrawler.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCrawlerTest
{
    [TestClass]
    public class CardSetTest
    {
        [TestMethod]
        public void NamePropertyTest()
        {
            // Arrange
            string testName = "Farvhan the Dreamer";
            Name name = new Name();
            // Act
            name.english = testName;
            // Assert
            Assert.AreEqual(testName, name.english);
        }

        [TestMethod]
        public void SetInfoPropertyTest()
        {
            // Arrange
            int testSetId = 00;
            int testPackItemDef = 0;
            Name testName = new Name();
            SetInfo setInfo = new SetInfo();
            // Act
            setInfo.set_id = testSetId;
            setInfo.pack_item_def = testPackItemDef;
            setInfo.name = testName;
            // Assert
            Assert.AreEqual(testSetId, setInfo.set_id);
            Assert.AreEqual(testPackItemDef, setInfo.pack_item_def);
            Assert.AreEqual(testName, setInfo.name);
        }

        [TestMethod]
        public void CardNamePropertyTest()
        {
            // Arrange
            string testName = "Farvhan the Dreamer";
            CardName cardName = new CardName();
            // Act
            cardName.english = testName;
            // Assert
            Assert.AreEqual(testName, cardName.english);
        }

        [TestMethod]
        public void CardTextPropertyTest()
        {
            // Arrange
            string testText = "Pack Leadership<BR>\nFarvhan the Dreamer's allied neighbors have +1 Armor.";
            CardText cardText = new CardText();
            // Act
            cardText.english = testText;
            // Assert
            Assert.AreEqual(testText, cardText.english);
        }

        [TestMethod]
        public void MiniImagePropertyTest()
        {
            // Arrange
            string testUrl = "<url to png>";
            MiniImage miniImage = new MiniImage();
            // Act
            miniImage.@default = testUrl;
            // Assert
            Assert.AreEqual(testUrl, miniImage.@default);
        }

        [TestMethod]
        public void LargeImagePropertyTest()
        {
            // Arrange
            string testUrl = "<url to png>";
            LargeImage largeImage = new LargeImage();
            // Act
            largeImage.@default = testUrl;
            // Assert
            Assert.AreEqual(testUrl, largeImage.@default);
        }

        [TestMethod]
        public void InGameImagePropertyTest()
        {
            // Arrange
            string testUrl = "<url to png>";
            IngameImage ingameImage = new IngameImage();
            // Act
            ingameImage.@default = testUrl;
            // Assert
            Assert.AreEqual(testUrl, ingameImage.@default);
        }

        [TestMethod]
        public void CardListPropertyTest()
        {
            // Arrange
            int cardId = 1000;
            int baseCardId = 1000;
            string cardType = "Stronghold";
            CardName cardName = new CardName();
            CardText cardText = new CardText();
            MiniImage miniImage = new MiniImage();
            LargeImage largeImage = new LargeImage();
            IngameImage ingameImage = new IngameImage();
            int hitPoints = 80;
            List<object> references = new List<object>();
            string illustrator = "Forrest Imel";
            int? manaCost = 3;
            int? attack = 2;
            bool? isBlack = true;
            string subType = "Accessory";
            int? goldCost = 3;
            bool? isGreen = false;
            bool? isRed = false;
            int? armor = 5;
            bool? isBlue = false;
            // Act
            CardList list = new CardList();
            list.card_id = cardId;
            list.base_card_id = baseCardId;
            list.card_type = cardType;
            list.card_name = cardName;
            list.card_text = cardText;
            list.mini_image = miniImage;
            list.large_image = largeImage;
            list.ingame_image = ingameImage;
            list.hit_points = hitPoints;
            list.references = references;
            list.illustrator = illustrator;
            list.mana_cost = manaCost;
            list.attack = attack;
            list.is_black = isBlack;
            list.sub_type = subType;
            list.gold_cost = goldCost;
            list.is_green = isGreen;
            list.is_red = isRed;
            list.armor = armor;
            list.is_blue = isBlue;
            // Assert
            Assert.AreEqual(cardId, list.card_id);
            Assert.AreEqual(baseCardId, list.base_card_id);
            Assert.AreEqual(cardType, list.card_type);
            Assert.AreEqual(cardName, list.card_name);
            Assert.AreEqual(cardText, list.card_text);
            Assert.AreEqual(miniImage, list.mini_image);
            Assert.AreEqual(largeImage, list.large_image);
            Assert.AreEqual(ingameImage, list.ingame_image);
            Assert.AreEqual(hitPoints, list.hit_points);
            Assert.AreEqual(references, list.references);
            Assert.AreEqual(illustrator, list.illustrator);
            Assert.AreEqual(manaCost, list.mana_cost);
            Assert.AreEqual(attack, list.attack);
            Assert.AreEqual(isBlack, list.is_black);
            Assert.AreEqual(subType, list.sub_type);
            Assert.AreEqual(goldCost, list.gold_cost);
            Assert.AreEqual(isGreen, list.is_green);
            Assert.AreEqual(isRed, list.is_red);
            Assert.AreEqual(armor, list.armor);
            Assert.AreEqual(isBlue, list.is_blue);
        }

        [TestMethod]
        public void CardSetPropertyTest()
        {
            // Arrange
            int version = 1;
            SetInfo setInfo = new SetInfo();
            List<CardList> cardList = new List<CardList>();
            CardSet set = new CardSet();
            // Act
            set.version = version;
            set.set_info = setInfo;
            set.card_list = cardList;
            // Assert
            Assert.AreEqual(version, set.version);
            Assert.AreEqual(setInfo, set.set_info);
            Assert.AreEqual(cardList, set.card_list);
        }

        [TestMethod]
        public void CardSetRootObjectPropertyTest()
        {
            // Arrange
            CardSet cardSet = new CardSet();
            CardSetRootObject root = new CardSetRootObject();
            // Act
            root.card_set = cardSet;
            // Assert
            Assert.AreEqual(cardSet, root.card_set);
        }
    }
}
