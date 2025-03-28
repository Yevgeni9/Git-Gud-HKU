using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueColour))]
[System.Serializable]
public class ColourMapping : MonoBehaviour
{
    public Color color;
    public List<int> indices = new List<int>();
}
