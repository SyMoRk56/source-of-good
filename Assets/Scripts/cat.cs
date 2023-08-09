using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "cat")]
public class cat : ScriptableObject
{
    public string catName;
    public float maxpleasure;
    public float friendly;
    public Sprite icon;
}
