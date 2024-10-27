using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interpreter : MonoBehaviour
{
    List<string> response = new List<string>();
    List<string> commands = new List<string>();
    List<string> files = new List<string>();
    List<string> filenames = new List<string>();
    static public bool isInDocuments = false;
    public GameObject helpWin;
    bool canExit, printT;

    public void Start()
    {
        commands.Add("/help");
        commands.Add("/list");
        commands.Add("/open");

        files.Add("TC.doc");
        files.Add("CSG.doc");
        files.Add("run.exe");

        filenames.Add("Terms_And_Conditions.doc (TC.doc)");
        filenames.Add("Crinter_setup_guide.doc (CSG.doc)");
        filenames.Add("Crinter.exe (run.exe)");
    }
    public List<string> Interpret(string userinput)
    {
       
        response.Clear();
        string[] args = userinput.Split();


        if (commands.Contains(args[0])&& canExit==false)
        {
            if (isInDocuments == false)
            {
                switch (args[0])
                {
                    case "/help":
                        helpWin.SetActive(true);
                        return response;

                    case "/list":
                        response.Add(string.Join(", ", filenames));
                        return response;

                    case "/open":
                        if (args.Length > 1 && args[1] == files[0])
                        {
                            canExit = true;
                            TerminalManager.isText = true;
                            TerminalManager.num = 0;
                            return response;
                        }
                        if (args.Length > 1 && args[1] == files[1])
                        {
                            canExit = true;
                            TerminalManager.isText = true;
                            TerminalManager.num = 1;
                          
                            return response;

                        }
                        if (args.Length > 1 && args[1] == files[2])
                        {
                            if (args.Length > 2)
                            {
                                if (args[2] == "Newpassword")
                                {
                                    response.Add("Type /print and then followed by card ID or use all command");
                                    printT = true;
                                    canExit = true;
                                    return response;
                                }
                                else
                                {
                                    response.Add("Wrong password");
                                    return response;
                                }
                            }
                            else
                            {
                                response.Add("Password required");
                                return response;
                            }

                        }
                        if (args.Length > 1)
                        {
                            response.Add(args[1] + " file dosent exist");
                            return response;
                        }
                        else
                        {
                            response.Add("Please spesfify the folder");
                            return response;
                        }


                }

                response.Add("Unknown command");
                return response;

            }

        }
        if (args[0] == "/exit" && canExit == true)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            return response;
        }
        if (args[0] == "/print" && printT == true)
        {
            if (args.Length > 1) 
            {
                if (args[1] == "all")
                {
                    //but code here for keycard print
                    response.Add("key");
                    printT = false;
                    return response;
                }
                else
                {
                    response.Add("Wrong key ID");
                    return response;
                }
            }
            else
            {
                response.Add("Please provide ID key or use all command");
                return response;
            }
           
        }


        else
        {
            response.Add("Unknown command");
            return response;
        }
    }
}
