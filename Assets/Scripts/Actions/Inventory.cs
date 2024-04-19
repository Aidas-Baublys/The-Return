using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (controller.player.inventory.Count == 0)
        {
            controller.currentText.text = "You have nothing. And noone.";
            return;
        }

        string result = "You have:\n";

        foreach (Item item in controller.player.inventory)
        {
            result += item.name + "\n";
        }
        controller.currentText.text = result;
    }
}
