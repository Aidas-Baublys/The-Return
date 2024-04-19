using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        controller.currentText.text = "Type a verb (e.g. inventory) or a verb with a noun (e.g. go north).";
        controller.currentText.text += "\nVerbs: Inventory, Help.";
        controller.currentText.text += "\nVerbs+noun: Go, Examine, Get, Use, Give, TalkTo, Say, Read.";
        controller.currentText.text += "\nDon't worry about the cassing (examine = Examine = eXamiNe). Mind the spelling though.";
    }
}
