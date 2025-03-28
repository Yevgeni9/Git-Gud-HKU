using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for if you want to change the colours of the text
[RequireComponent(typeof(DialogueCore))]
public class DialogueColour : MonoBehaviour
{
    private DialogueCore dialogueCore;
    public List<ColourMapping> colorMappings = new List<ColourMapping>();

    // putting this in Start causes issues
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

    public void UpdateTextColour()
    {
        int currentIndex = dialogueCore.index;
        dialogueCore.textComponent.color = GetColorForIndex((int)currentIndex);
    }
}
