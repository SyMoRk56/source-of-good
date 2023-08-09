using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public Sprite lockscreenSpr, menuSpr, photoSpr, bestiarySpr;
    public Image screen;

    float timer;
    int stage;

    public GameObject[] phoneApp;
    public Image curApp;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Lock();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(stage == 0)
            {
                ChangeStage(1);
            }
            else if(stage == 1)
            {
                ChangeStage(2);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (stage == 1)
            {
                ChangeStage(0);
            }
            else if (stage == 2)
            {
                ChangeStage(1);
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UnLock();
        }
        
    }
    #region методы

    void ChangeStage(int cStage)
    {
        curApp.rectTransform.position = phoneApp[cStage].GetComponent<RectTransform>().position;
    }
    public void Lock()
    {
        screen.sprite = lockscreenSpr;
       // screen.color = Color.black;
    }
    public void UnLock() 
    {
        screen.sprite = menuSpr;
        timer = 0;
    }
    public void Photo()
    {
        screen.sprite = photoSpr;
        timer = 0;
    }
    public void bestiary()
    {
        screen.sprite = bestiarySpr;
        timer = 0;
    }
    #endregion
}
