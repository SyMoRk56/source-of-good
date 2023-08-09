using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Animator catAnim, doorAnim;
    void Awake()
    {
        instance = this;
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
