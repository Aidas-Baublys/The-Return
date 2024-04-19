using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    [TextArea]
    public string description;
    public bool playerCanTake;
    public bool playerCanTalkTo = false;
    public bool playerCanGiveTo = false;
    public bool playerCanRead = false;
    public bool itemEnabled = true;
    public Item targetItem = null;
    public Interaction[] interactions;

    public bool InteractWith(GameController controller, string actionKeyword, string noun = "")
    {
        foreach (Interaction interaction in interactions)
        {
            if (interaction.action.keyword.ToLower() == actionKeyword.ToLower())
            {
                if (noun.ToLower() != "" && noun.ToLower() != interaction.textToMatch.ToLower())
                {
                    continue;
                }
                foreach(Item item in interaction.itemsToDisable)
                {
                    item.itemEnabled = false;
                }
                foreach(Item item in interaction.itemsToEnable)
                {
                    item.itemEnabled = true;
                }
                foreach (Connection connection in interaction.connectionsToDisable)
                {
                    connection.connectionEnabled = false;
                }
                foreach (Connection connection in interaction.connectionsToEnable)
                {
                    connection.connectionEnabled = true;
                }

                controller.currentText.text = interaction.response;
                controller.DisplayLocation(true);

                if (interaction.teleportLocation != null)
                {
                    controller.player.Teleport(controller, interaction.teleportLocation);
                }
                return true;
            }
        }
        return false;
    }
}
