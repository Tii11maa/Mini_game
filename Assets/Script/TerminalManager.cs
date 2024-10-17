using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TerminalManager : MonoBehaviour
{
    public GameObject directoryLine;
    public GameObject responseLine;

    public TMP_InputField terminalInput;
    public GameObject userInputLine;
    public ScrollRect sr;
    public GameObject msgList;

    Interpreter interpreter;
    
    private void Start()
    {
        interpreter = GetComponent<Interpreter>();
    }


    private void OnGUI()
    {
        if (terminalInput.isFocused && terminalInput.text !="" && Input.GetKeyDown(KeyCode.Return)) 
        {
            //Stores users input text 
            string userInput = terminalInput.text;
            
            //Clears input flied
            ClearInputField();


            AddDirectoryLine(userInput);
            int lines = AddInterpreterLines(interpreter.Interpret(userInput));

            ScrolltoBottom(lines);

            //moving user input line to the end
            userInputLine.transform.SetAsLastSibling();

            terminalInput.ActivateInputField();
            terminalInput.Select();
        }
    }
    void ClearInputField()
    {
        terminalInput.text = "";
    }

    void AddDirectoryLine(string userInput)
    {
        //resizing command line container
        Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 35.0f);

        //Instantiate the directory line
        GameObject msg = Instantiate(directoryLine, msgList.transform);

        //Set its child index
        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);

        //Set text of to new gameobject
        TMP_Text[] texts = msg.GetComponentsInChildren<TMP_Text>();
        if (texts.Length > 1)
        {
            texts[1].text = userInput;
        }

    }

    int AddInterpreterLines(List<string> interpretation)
    {
        for (int i = 0; i < interpretation.Count; i++)
        {

            GameObject res = Instantiate(responseLine, msgList.transform);
            res.transform.SetAsLastSibling();
            Vector2 listSize = msgList.GetComponent<RectTransform>().sizeDelta;
            msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(listSize.x, listSize.y + 35.0f);

            res.GetComponentInChildren<TMP_Text>().text = interpretation[i];
        }

        return interpretation.Count;
    }

    void ScrolltoBottom(int lines)
    {
        if(lines > 4)
        {
            sr.velocity = new Vector2(0, 450);

        }

        else
        {
            sr.verticalNormalizedPosition = 0;
        }
    }
}
