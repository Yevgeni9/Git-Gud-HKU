using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for if you want to change the color of the dialogue text
[RequireComponent(typeof(DialogueCore))]
public class DialogueColor : MonoBehaviour
{
    private DialogueCore dialogueCore;
    public List<ColorMapping> colorMappings = new List<ColorMapping>();

    private void Awake()
    {
        dialogueCore = GameObject.Find("Dialogue").GetComponent<DialogueCore>();
    }

    public Color GetColorForIndex(int index)
    {
        foreach (var mapping in colorMappings)
        {
            if (mapping.indices.Contains(index))
            {
                return mapping.color;
            }
        }

        return Color.white;
    }

    public void UpdateTextColor()
    {
        int currentIndex = dialogueCore.index;
        dialogueCore.textComponent.color = GetColorForIndex((int)currentIndex);
    }
}
