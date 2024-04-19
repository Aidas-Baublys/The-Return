using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currentLocation;
    public List<Item> inventory = new List<Item>();

    public bool ChangeLocation(GameController controller, string connectionName)
    {
        Connection connection = currentLocation.GetConnection(connectionName);
        if (connection != null)
        {
            currentLocation = connection.location;
            return true;
        }
        return false;
    }

    public void Teleport(GameController controller, Location destination)
    {
        currentLocation = destination;
        controller.currentText.text = destination.description;
    }

    public bool CanUseItem(GameController controller, Item item)
    {
        if (item.targetItem == null)
        {
            return true;
        }

        if (HasItem(item.targetItem))
        {
            return true;
        }

        if (currentLocation.HasItem(item.targetItem))
        {
            return true;
        }

        return false;
    }

    private bool HasItem(Item item)
    {
        foreach (Item palyerItem in inventory)
        {
            if (palyerItem == item)
            {
                return true;
            }
        }
        return false;
    }

    public bool CanTalkToItem(GameController controller, Item item)
    {
        return item.playerCanTalkTo;
    }

    public bool CanGiveToItem(GameController controller, Item item)
    {
        return item.playerCanGiveTo;
    }
}
