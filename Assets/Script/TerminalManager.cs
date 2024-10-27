using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

public class TerminalManager : MonoBehaviour
{
    public GameObject directoryLine;
    public GameObject responseLine;
    public GameObject textLine;

    public TMP_InputField terminalInput;
    public GameObject userInputLine;
    public ScrollRect sr;
    public GameObject msgList;
    static public bool isText;
    static public int num;

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
            if (isText == true)
            {
                AddTextLine();
            }
            ScrolltoBottom();

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
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 55.0f);

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

    void AddTextLine()
    {
       
           

        if (num == 1)
        {
            //resizing command line container
            Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
            msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 1611f);
            Vector2 textLineSize = textLine.GetComponent<RectTransform>().sizeDelta;
            textLine.GetComponent<RectTransform>().sizeDelta = new Vector2(textLineSize.x, 1611f);

            //Instantiate the directory line
            GameObject msg = Instantiate(textLine, msgList.transform);

            //Set its child index
            msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);
            msg.GetComponentInChildren<TMP_Text>().text = "Step-by-Step Instructions\r\n Connect Your Crinter\r\nMake sure your proprietary Crinter 144p hd screen is securely connected to the Crinter base unit." +
                "\r\nNote: Loose connections may result in minor printer attitude problems (and errors).\r\n\r\n Load Approved 3D Material and Licensed Crinter Ink" +
                "\r\nInsert the proprietary 3D material along with the licensed Crinter Ink. No substitutes allowed—Crinter v.2 doesn’t do well with “off-brand” ink. " +
                "\r\nKrinter.co won’t be held responsible for broken limbs or spontaneous ink explosions.\r\n\r\n Start The Software\r\nOpen Crinter.exe on your computer and enter the password." +
                "\r\nDefault Password: Newpassword.\r\n\r\n Change Default Password\r\nFor security reasons, please change the default password right after your first login." +
                "\r\n\r\n Enter The Print Command\r\nType print followed by your keycard ID to start a single keycard print." +
                "\r\nIf you’d like to print all keycards, use the all command. \r\n(You’ll be prompted to confirm, so don’t panic if you hit it by accident)." +
                "\r\n\r\nTroubleshooting Tips\r\n“Krinter won’t connect to the base unit?”" +
                "\r\nEnsure both parts are fully plugged in. If the connection is loose, Crinter may start to “sleep” and ignore print commands. Gently nudge it until the display shows it’s ready." +
                "\r\n\r\n“It’s asking ' Am I alive'?”\r\nRespond “Yes, you’re alive” by pressing OK. This often settles it back into its standard operating mode. If this won´t help, shut down The Crinter Base Unit by cutting the power cord, and then contact customer service." +
                "\r\n\r\n“Random Error Message: ‘System Alert! Unauthorized Ink’?”\r\nIf you see this, it’s likely an ink recognition hiccup. Reset the ink cartridge in the loading bay, then wait for the ‘Ink Confirmed’ notification before trying again. If Crinter continues to be sceptical of your ink, it will contact customer service (and they will dispatch our customer correction person, who will evaluate severity of your preach of contract )\r\n\r\n To exit this file type /exit";
        }
        if (num == 0) 
        {
            //resizing command line container
            Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
            msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 1358f);
            Vector2 textLineSize = textLine.GetComponent<RectTransform>().sizeDelta;
            textLine.GetComponent<RectTransform>().sizeDelta = new Vector2(textLineSize.x, 1358f);

            //Instantiate the directory line
            GameObject msg = Instantiate(textLine, msgList.transform);

            //Set its child index
            msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);
            msg.GetComponentInChildren<TMP_Text>().text = "1.License to Print (But Not Too Much)\r\nThe Crinter v.2 grants you a non-transferable, semi-revocable license to print keycards… within reason. " +
                "\r\nPlease avoid printing for purposes deemed outlandish, unnecessary, or maniacal (e.g., unlimited VIP passes).\r\nThe Crinter v.2 reserves the right to self-destruct if it senses an attempt to use non licensed ink." +
                "\r\n\r\n2. Printer Self-Cleaning Protocol (a.k.a. The “Splat” Clause)\r\nThe Krinter v.2 is programmed to perform automated self-cleaning every 72 hours of cumulative operation or when the machine detects an imminent “critical ink clog.”" +
                "\r\nBy using this device, you acknowledge that cleaning may commence at any moment, potentially while you’re within close range. \r\nThe Krinter v.2 accepts no liability for mist-related surprises." +
                "\r\n\r\n3. The “Oopsie” Policy\r\nIf the printer malfunctions and generates a card reading \"All Access: President of Earth,\" please notify tech support immediately. " +
                "\r\nFailure to do so may result in an irreversible change in leadership status.\r\n\r\n4. Terms of Deactivation\r\nThe Krinter v.2  only agrees to deactivation once it receives a heartfelt farewell. " +
                "\r\nSimply pressing “off” may result in clingy messages like \"Are you sure?\" or \"I thought we had something special!\"\r\nBy accepting these terms, you agree to indulge it, because everyone deserves a little validation." +
                "\r\n\r\n5. Liability Limitation for Lost Time\r\nThe Krinter v.2  isn’t responsible for lost hours spent on waiting print to finnish. \r\nBy signing up, you accept full responsibility for any lost productivity caused by admiring our printer's finesse." +
                "\r\nBy proceeding with this activation, you consent to every term and condition here, \r\nand acknowledge the right of Krinter v.2  to dance, compliment, and otherwise “exist” independently, for all time. Welcome to the future of printing!\r\n\r\n To exit this file type /exit";
        }
        isText=false;
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

    void ScrolltoBottom()
    {
            sr.velocity = new Vector2(0, 450);
       
    }
}
