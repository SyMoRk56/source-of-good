using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class patHelp : MonoBehaviour
{
    
    public TMP_Text helpText;
    string text;
    public static patHelp instance;
    private void Awake()
    {
        instance = this;
    }
    public void Show(string name,string a)
    {
        
        switch (PlayerPrefs.GetString("Lang"))
        {
            case "EN":
                if(a == "petHelp")
                text = "Hold " + name + " to pet the cat";
                else if(a == "doorHelp")
                text = "Click " + name + " to open the door";
                break;
            case "RU":
                if (a == "petHelp") text = "Зажми" + name + "чтобы погладит кота(кошку)";
                else if (a == "petHelp") text = "Нажми на" + name + "чтобы открыть дверь";
                break;
            default:
                if (a == "petHelp")
                    text = "Hold " + name + " to pet the cat";
                else if (a == "doorHelp")
                    text = "Click " + name + " to open the door";
                break;
                
        }
        helpText.text = text;
        
    }
}
