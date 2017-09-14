using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

public class ShopManager : MonoBehaviour {
    public Transform[] goods;
    public int[] prices;

    public string dataPath;
    Catalog shopCatalog;

    public Text title;
    public Text description;
    public Text price;
    public Image image;

    private void Awake() {
        Load();

    }
    public void Select(int i) {
        title.text = shopCatalog.catalog[i].name;
        description.text = shopCatalog.catalog[i].description;
    }
    public void Buy(int i) {

    }
    private void Load() {
        TextAsset n = (TextAsset)Resources.Load(dataPath);
        if (n != null) {
            shopCatalog = Deserialize(n);
            print("Deserialized!");
        }
        else {
            print("Shop Catalog XML file not found");
            shopCatalog = new Catalog();
        }
    }
    Catalog Deserialize(TextAsset xmlFile) {
        XmlSerializer serializer = new XmlSerializer(typeof(Catalog));
        using (System.IO.StringReader reader = new System.IO.StringReader(xmlFile.text)) {
            return serializer.Deserialize(reader) as Catalog;
        }
    }
}
public class Catalog {
    public List<ShopItem> catalog = new List<ShopItem>();
    public Catalog() {
    }
}

public class ShopItem {
    [XmlElement("Name")]
    public string name;
    [XmlElement("Description")]
    public string description;
    [XmlElement("Image")]
    public string spritePath;
    [XmlElement("Price")]
    public int price;
    [XmlElement("Identity")]
    public int id;

    public ShopItem() {

    }
    public ShopItem(string _name, string _description, string _spritePath, int _price, int _id) {
        name = _name;
        description = _description;
        spritePath = _spritePath;
        price = _price;
        id = _id;
    }
}
