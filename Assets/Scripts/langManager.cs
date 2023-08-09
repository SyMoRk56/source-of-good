using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class langManager : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetString("Lang", "EN");
    }
}
