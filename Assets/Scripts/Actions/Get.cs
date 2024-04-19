using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        foreach (Item item in controller.player.currentLocation.items)
        {
            if (item.itemEnabled && item.name.ToLower() == noun.ToLower())
            {
                if (item.playerCanTake)
                {
                    controller.player.inventory.Add(item);
                    controller.player.currentLocation.items.Remove(item);
                    controller.currentText.text = "You take the " + noun + ".";
                    return;
                }
            }
        }
        controller.currentText.text = "You can't get that.";
    }
}
