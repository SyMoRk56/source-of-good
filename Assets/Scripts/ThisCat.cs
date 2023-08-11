using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThisCat : MonoBehaviour
{
    
    public cat thisCat;
    public float thispleasure = 0;
    public float damagetimer, pleasuretimer;
    PlayerInteraction interaction;

    public GameObject infPanel;
    
    public TMP_Text nameText;
    UIManager uimanager;
    public bool isCol;
    private void Start()
    {
        interaction = FindObjectOfType<PlayerInteraction>();
        
        nameText.text = thisCat.name;
        uimanager = UIManager.instance;
    }
    private void Update()
    {
        damagetimer += Time.deltaTime;
        pleasuretimer += Time.deltaTime;

        if (pleasuretimer > 2 && thispleasure >= 0 && isCol)
        {
            thispleasure -= 0.004f;
            //Debug.Log("thispleasure " + thispleasure + "  max" + thisCat.maxpleasure);
            uimanager.ChangePetAmount(thispleasure, thisCat.maxpleasure);
            if (thispleasure < 0)
            {
                thispleasure = 0;
            }
            
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            infPanel.SetActive(true);
            isCol = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            infPanel.SetActive(false);
            isCol = false;
            thispleasure = 0;
            uimanager.StartCoroutine("HideBar");
        }
    }
    public void Pet()
    {
        

        float a = Random.Range(0, 10000);
        if (a <= thisCat.friendly && damagetimer > 1.3f)
        {
            damagetimer = 0;

            interaction.StartCoroutine("TakeDamage");
        }
        else
        {
            thispleasure += 0.002f;
            if (thispleasure > thisCat.maxpleasure)
            {
                thispleasure = thisCat.maxpleasure;
                
            }
            pleasuretimer = 0;
        }
        uimanager.ChangePetAmount(thispleasure, thisCat.maxpleasure);
    }
}
