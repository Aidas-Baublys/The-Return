using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Player player;
    public TMP_InputField playerInput;
    public TMP_Text historyText;
    public TMP_Text currentText;
    public Action[] actions;
    [TextArea] public string introText;

    void Start()
    {
        historyText.text = introText;
        DisplayLocation();
        playerInput.ActivateInputField();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void DisplayLocation(bool addToExistingText = false)
    {
        string description = player.currentLocation.description + "\n";
        description += player.currentLocation.GetConnectionText();
        description += player.currentLocation.GetItemsText();
        currentText.text = addToExistingText ? currentText.text + "\n<color=#9F8181>" + description + "</color>" : description;
    }

    public void TextEntered()
    {
        LogCurrentText();
        ProcessIntput(playerInput.text);
        playerInput.text = "";
        playerInput.ActivateInputField();
    }

    void LogCurrentText()
    {
        historyText.text += "\n\n";
        historyText.text += currentText.text;
        historyText.text += "\n\n";
        historyText.text += "<color=#aaccaaff>" + playerInput.text + "</color>";
    }

    void ProcessIntput(string input)
    {
        input = input.ToLower();
        char[] delimiter = { ' ' };
        string[] separatedWords = input.Split(delimiter);

        foreach (Action action in actions)
        {
            if (action.keyword.ToLower() == separatedWords[0])
            {
                if (separatedWords.Length > 1)
                {
                    action.RespondToInput(this, separatedWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }
        currentText.text = "Nothing happens. (Having trouble? Type Help)";
    }
}
