using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public List<AudioSource> audioSources;
    public AudioSource murchanie;
    private void Start()
    {
        audioSources = GetComponents<AudioSource>().ToList();
        interaction = FindObjectOfType<PlayerInteraction>();
        
        nameText.text = thisCat.name;
        uimanager = UIManager.instance;
        StartCoroutine("ticks");
        for(int i = 0; i < audioSources.Count; i++) {
            if (audioSources[i] == murchanie)
            {
                audioSources.Remove(audioSources[i]);
                break;
            }
        }
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
    IEnumerator ticks()
    {
        int r = Random.Range(0, 1200);
        if(r == 1)
        {
            int a = Random.Range(0, audioSources.Count);
            audioSources[a].Play();
        }

        if (thispleasure > thisCat.maxpleasure * 0.8f)
        {
            Debug.Log("Mur");
            if(!murchanie.isPlaying)
            {
                murchanie.Play();
            }
            
        }
        //else murchanie.Stop();
        
        yield return new WaitForSeconds(0.01f);
        StartCoroutine("ticks");
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
