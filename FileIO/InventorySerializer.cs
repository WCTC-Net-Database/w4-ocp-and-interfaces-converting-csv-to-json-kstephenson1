namespace w4_assignment_ksteph.FileIO;

using System;
using System.Collections.Generic;
using w4_assignment_ksteph.Inventories;
using w4_assignment_ksteph.DataHelper;

public class InventorySerializer
{
    // InventorySerializer contains fuctions to turn a string into List<Item> to Inventories and vice versa.
    public static Inventory Deserialize(string inventoryString)//Takes an inventory string and returns an inventory object.
    {
        // Converts String into Inventories
        return ToInventory(ToItemList(inventoryString));
    }

    public static string? Serialize(Inventory inventory) //Takes an inventory object and returns it in string form.
    {
        // Converts Inventories into String
        return ToString(ToItemList(inventory)!);
    }

    private static List<Item> ToItemList(string itemString) // Turns an item string into an item list
    {
        //Converts String into List<Item>
        List<Item> itemList = [];

        string[] items = itemString.Split('|');

        foreach (string item in items)
            itemList.Add(new Item(item));

        return itemList;
    }

    private static string ToString(List<Item> items) // turns an item list into an item string
    {
        // Converts List<Item> to String
        if (items == null)
            return "";
        else
        {
            string inventory = "";

            foreach (Item item in items)
            {
                if (inventory == "")
                    inventory += StringHelper.ToItemIdFormat(item.ID);
                else
                    inventory += "|" + StringHelper.ToItemIdFormat(item.ID);
            }

            return inventory;
        }
    }

    private static Inventory ToInventory(List<Item> itemList) // turns an item list into an inventory
    {
        // Converts List<Item> to Inventories
        return new(itemList);
    }

    private static List<Item>? ToItemList(Inventory inventory) // turns an inventory into an item list
    {
        // Converts Inventories to List<Item>
        return inventory.Items;
    }
}
