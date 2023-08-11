using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public RectTransform catHelpPanel,errorPanel;
    public float needTimeToAnim;
    public TMP_Text errorText;
    [HideInInspector]
    public bool isOpen = false;
    public bool isErr = false;
    public float catHelpY1, catHelpY2,errX1,errX2;
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
        StartAnimErr();
       
    }
    public void StartAnimPet() {
        if (!isOpen)
        {
            LeanTween.moveY(catHelpPanel, catHelpY1, needTimeToAnim);
            Invoke("CloseAnimPet", 3f);
        }
        isOpen = true;
    }
    public void CloseAnimPet()
    {
        
        LeanTween.moveY(catHelpPanel, catHelpY2, needTimeToAnim);
        
        StartCoroutine("resetIsOpen");
    }
    IEnumerator resetIsOpen()
    {
        yield return new WaitForSeconds(needTimeToAnim); isOpen = false;
    }
    public void StartAnimErr()
    {
        Debug.Log("StartAnimErr");
        if(!isErr)
        {
            
            LeanTween.moveX(errorPanel, errX1, needTimeToAnim);
            Invoke("CloseAnimErr", 2f);
        }
        isErr = true;
        
    }
    void CloseAnimErr()
    {
        
        LeanTween.moveX(errorPanel, errX2, needTimeToAnim);
        StartCoroutine("resetIsErr");
    }
    IEnumerator resetIsErr()
    {
        yield return new WaitForSeconds(needTimeToAnim); isErr = false;
    }


}
