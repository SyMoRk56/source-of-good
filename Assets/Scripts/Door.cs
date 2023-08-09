using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static KeyCode OpenDoorCode = KeyCode.E;
    public bool isLocked;
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        patHelp.instance.Show("E", "doorHelp");
        if(other.gameObject.name == "Player")
        {
            animator.SetTrigger("On");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            animator.SetTrigger("Off");
        }
    }
    private void Update()
    {
        if (Input.GetKeyUp(OpenDoorCode))
        {
            if(isLocked)
            {
                UIManager.instance.Error("door");
            }
        }
    }
}
