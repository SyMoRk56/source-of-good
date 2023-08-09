using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Animator catAnim, doorAnim, errorAnim;
    public TMP_Text errorText;
    void Awake()
    {
        instance = this;
    }
    public void Error(string thisname)
    {
        
        if (thisname == "door")
        {
            errorText.text = "Door is closed";
        }
        errorAnim.SetTrigger("On");
        Debug.Log("error");
    }
     
public void CatAnimOn()
    {
        catAnim.SetTrigger("On");
    }
    public void CatAnimOff()
    {
        catAnim.SetTrigger("Off");
    }
    public void DoorAnimOn()
    {
        doorAnim.SetTrigger("On");

    }
    public void DoorAnimOff()
    {
        doorAnim.SetTrigger("Off");
    }

}
