using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public List<Item> items;
    public static Inventory instance;
    public Canvas canvas;

    public RectTransform itemRoot;

    //40.5, 114.6

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        AddItem("Candle");
       // AddItem("Turtle");
    }


    public bool ContainsItem(string itemName)
    {
        foreach(Item item in items)
        {
            if (item.GetName() == itemName)
            {
                return true;
            }
        }

        return false;
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddItem("Turtle");
        }
    }

    public void AddItem(string itemName)
    {
        Debug.Log("/GameData/Items/" + itemName + "/Item_" + itemName + ".prefab");
        //GameObject ItemObj = Instantiate(Resources.Load("Item_" + itemName)) as GameObject;
         GameObject ItemObj = Instantiate(Resources.Load("GameData/Items/" + itemName + "/Item_" + itemName)) as GameObject;
        ItemObj.name = itemName;
        AddItem(ItemObj.GetComponent<Item>());
        // AddItem(   );
    }

    public void RemoveItem(string itemName)
    {
        foreach(Item i in items)
        {
            if (i.GetName() == itemName)
            {
                items.Remove(i);
                Destroy(i.gameObject);
                return;
            }
        }
    }

    public void AddItem(Item item)
    {
        // item.transform.parent = itemRoot.transform;

        item.transform.SetParent(itemRoot.transform, false);
        // item.GetComponent<RectTransform>().anchorMin = itemRoot.GetComponent<RectTransform>().anchorMin;
        // item.GetComponent<RectTransform>().anchorMax = itemRoot.GetComponent<RectTransform>().anchorMax;

        
        //rect.anchorMin = rect.left;


        int x = items.Count;
        int y = 0;
        if (x >= 9)
        {
            x = items.Count - 9;
            y = 1;
        }

        item.transform.localPosition = new Vector3(60 * x - 400, y*-80, 0);
        items.Add(item);
        //AnchorsToCorners(rect);
    }


    public void ShowItems()
    {

    }

    public void HideItems()
    {

    }
}
