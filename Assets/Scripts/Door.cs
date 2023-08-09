using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
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
}
