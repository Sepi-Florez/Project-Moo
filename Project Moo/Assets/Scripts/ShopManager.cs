using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

public class ShopManager : MonoBehaviour {
    Transform[] goods;
    int[] prices;


    public void Buy(int i) {

    }

}
public class Catalogue {
    public List<ShopItem> catalogue;
    Catalogue() {
        catalogue = new List<ShopItem>();
    }
}
public class ShopItem {
    [XmlElement("Name")]
    string name;
    [XmlElement("Description")]
    string description;
    [XmlElement("Price in money")]
    int price;
    [XmlElement("Identity")]
    int id;
    ShopItem() {

    }
}
