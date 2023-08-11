using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region variables
    public static UIManager instance;

    public RectTransform catHelpPanel,errorPanel;
    public float needTimeToAnim;
    public TMP_Text errorText;
    [HideInInspector]
    public bool isOpen = false;
    public bool isErr = false;
    public float catHelpY1, catHelpY2,errX1,errX2;
    public Image bar, barO;
    
    bool isAlphaShow = false;
    #endregion
    void Awake()
    {
        Color a = bar.color,b = barO.color;
        a.a = 0;
        b.a = 0;
        bar.color = a;
        barO.color = b;

        instance = this;
    }
    
    public void ChangePetAmount(float amount,float max)
    {
        
        bar.fillAmount = amount / max;
        
        if(!isAlphaShow)
        {
            StartCoroutine("ShowBar");
            isAlphaShow = true;
        }
        
        
    }
    IEnumerator ShowBar()
    {
        Color c1 = bar.color;
        Color c2 = barO.color;
        for(int i = 0; i < 256; i++)
        {
            Debug.Log(i);
            c1.a = (float)i / 255;
            c2.a = (float)i / 255;
            bar.color = c1;
            barO.color = c2;
            
            yield return new WaitForSeconds(0.002f);
        }
        
    }
    public IEnumerator HideBar()
    {
        Debug.Log("Hide");
        Color c1 = bar.color;
        Color c2 = barO.color;
        for (int i = 255; i > 0; i--)
        {
            c1.a = (float)i / 255;
            c2.a = (float)i / 255;
            bar.color = c1;
            barO.color = c2;
            
            yield return new WaitForSeconds(0.002f);
        }
        isAlphaShow = false;
    }

    #region animPet
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
    #endregion
    #region error
    public void Error(string thisname)
    {

        if (thisname == "door")
        {
            errorText.text = "Door is closed";
        }
        StartAnimErr();

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
    #endregion

}
