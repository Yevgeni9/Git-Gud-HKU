using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

// icon appears when line ends, useful for showing the keybind for the next line
[RequireComponent(typeof(DialogueCore))]
public class DialogueIcon : MonoBehaviour
{
    private DialogueCore dialogueCore;
    [SerializeField] private Image icon;

    private void Start()
    {
        dialogueCore = GameObject.Find("Dialogue").GetComponent<DialogueCore>();
    }

    private void Update()
    {
        CheckIfLineComplete();
    }

    private void CheckIfLineComplete()
    {
        if (dialogueCore.lineComplete)
        {
            icon.enabled = true;
        }
        else
        {
            icon.enabled = false;
        }
    }
}
