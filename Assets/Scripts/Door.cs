using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static KeyCode OpenDoorCode = KeyCode.E;
    public bool isLocked;
    public Animator animator;
    bool isCol;
    private void OnTriggerEnter(Collider other)
    {
        isCol= true;
        if (!UIManager.instance.isOpen)
        {
            patHelp.instance.Show("E", "doorHelp");
            if (other.gameObject.name == "Player")
            {
                UIManager.instance.StartAnimPet();
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        isCol = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(OpenDoorCode) && isCol)
        {
            if(isLocked)
            {
                UIManager.instance.Error("door");
            }
        }
    }
}
