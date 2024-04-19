using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;
    [TextArea(10, 20)] public string description;
    public Connection[] connections;
    public List<Item> items = new List<Item>();

    public string GetItemsText()
    {
        if (items.Count == 0) 
        { 
            return ""; 
        }

        string result = "You see: ";
       
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                string boldColorItemName = "<color=#aabbaaff><b>" + item.itemName + "</b></color>";
                string description = item.description.Replace(item.itemName, boldColorItemName);
                result += description + " ";
            }
        }
        return result;
    }

    public string GetConnectionText()
    {
        string result = "";

        foreach (Connection connection in connections)
        {
            if (connection.enabled)
            {
                result += "<color=#039474>" + connection.description + "</color> ";
            }
        }
        return result;
    }

    public Connection GetConnection(string connectionName)
    {
        foreach (Connection connection in connections)
        {
            if (connection.connectionEnabled && connection.connectionName.ToLower() == connectionName.ToLower())
            {
                return connection;
            }
        }
        return null;
    }

    public bool HasItem(Item item)
    {
        foreach (Item locationItem in items)
        {
            if (locationItem == item && item.itemEnabled)
            {
                return true;
            }
        }
        return false;
    }
}
