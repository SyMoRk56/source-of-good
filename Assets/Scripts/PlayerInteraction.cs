using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject patHelpObj;
    patHelp patHelp;
    ThisCat catObj;
    public KeyCode patKeyCode;
    bool isCollede;
    
    public Image damageImage;
    public Image[] wounds;
    private void Start()
    {
        patHelp = patHelpObj.GetComponent<patHelp>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cat"))
        {
            isCollede = true;
            
                catObj = other.gameObject.GetComponent<ThisCat>();

                patHelp.Show(patKeyCode.ToString(), "petHelp");
            if (!UIManager.instance.isOpen)
            {
                UIManager.instance.StartAnimPet();
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("cat"))
        {
            isCollede = false;
            catObj = null;

            
            
        }
    }
    private void Update()
    {
        if (Input.GetKey(patKeyCode) && isCollede)
        {
            catObj.Pet();
        }
    }
    public IEnumerator TakeDamage()
    {
        int a = Random.Range(0, wounds.Length);
        Color backgroundcolor = Color.red;
        Color woundsColor = Color.white;
        for(int i = 0; i < 30; i++)
        {
            woundsColor.a = (float)i / 30;
            backgroundcolor.a = (float)i / 180;
            wounds[a].color = woundsColor;
            damageImage.color = backgroundcolor;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1.5f);
        for (int i = 30; i > 0; i--)
        {
            woundsColor.a = (float)i / 30;
            backgroundcolor.a = (float)i / 180;
            wounds[a].color = woundsColor;
            damageImage.color = backgroundcolor;
            yield return new WaitForSeconds(0.006f);
        }
        woundsColor.a = 0;
        wounds[a].color = woundsColor;

    }
}
