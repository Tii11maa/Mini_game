using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpreter : MonoBehaviour
{
    List<string> response = new List<string>();

    public List<string> Interpret(string userinput)
    {
        response.Clear();
        string[] args = userinput.Split();
        

        if (args[0] == "/help")
        {
            response.Add("/List, will show aal of kansiot");
            response.Add("/Open (folder_name), will open folder");
            return response;
        }
        if (args[0] == "/List")
        {
            response.Add("Cam");
            response.Add("Door A_45");
            response.Add("Passwords");
            return response;
        }
        if (args[0] == "/Open")
        {
            if ( args.Length >1 && args[1] == "Cam")
            {
                if (args.Length > 2 && args[2] == "Pass")
                {
                    response.Add("Camera persmison cranted");
                    return response;
                }
                if (args.Length > 2)
                {
                    response.Add("Wrong password");
                    return response;
                }

                else
                {
                    response.Add("Password requierd");
                    return response;
                }
            }
            if (args.Length > 1 )
            {
                response.Add(args[1] +" folder dosent exist");
                return response;
            }

            else
            {
                response.Add("Please spesfify the folder");
                return response;
            }
              
        }
       


        else
        {
            response.Add("error");
            return response;
        }
    }
}
