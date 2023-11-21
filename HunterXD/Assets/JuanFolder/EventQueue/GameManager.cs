using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    private Queue<ICommand> _events = new Queue<ICommand>();
    private bool _isCharacterFrozen;

    public GameObject DialogBox;
    public TextMeshProUGUI DialogText;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }
    private void Update()
    {
        while (_events.Count > 0)
        {
            var command = _events.Dequeue();
            //if (_isCharacterFrozen && command is CmdMove) continue;
            command.Do();

        }

        if (Input.GetKeyDown(KeyCode.Space)) _isCharacterFrozen = !_isCharacterFrozen;
    }
    public void AddEvents(ICommand command) => _events.Enqueue(command);

    public void ShowText(string text)
    {
        DialogBox.SetActive(true);
        DialogText.text = text;
    }
    public void HideText()
    {
        DialogBox.SetActive(false);
        DialogText.text = "";
    }
}
