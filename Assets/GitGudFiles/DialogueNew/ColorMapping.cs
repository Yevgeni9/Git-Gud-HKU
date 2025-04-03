using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueColor))]
[System.Serializable]
public class ColorMapping : MonoBehaviour
{
    public Color color;
    public List<int> indices = new List<int>();
}
