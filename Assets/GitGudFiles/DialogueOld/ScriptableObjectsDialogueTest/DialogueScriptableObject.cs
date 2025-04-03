using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueScriptableObject : ScriptableObject
{
    public DialogueActors[] actors;

    [Header("Dialogue")]
    [TextArea]
    public string[] dialogue;
}
