using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateToCamera : MonoBehaviour
{
    public bool needCamera;
    GameObject obj;
    private void Start()
    {
        if(needCamera)
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
        }
        obj = FindObjectOfType<PlayerMovement>().gameObject;
    }
    private void Update()
    {
        Vector3 dir = transform.position - obj.transform.position;
        Vector3 rot = Vector3.RotateTowards(transform.forward, dir, Time.deltaTime * 20, 0f);

        transform.rotation = Quaternion.LookRotation(rot);
    }
}
