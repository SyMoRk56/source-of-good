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
    private void Start()
    {
        interaction = FindObjectOfType<PlayerInteraction>();
        
        nameText.text = thisCat.name;
    }
    private void Update()
    {
        damagetimer += Time.deltaTime;
        pleasuretimer += Time.deltaTime;

        if (pleasuretimer > 2 && thispleasure >= 0)
        {
            thispleasure -= 0.001f;
            
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

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            infPanel.SetActive(false);

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
        
    }
}
