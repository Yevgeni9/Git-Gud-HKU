using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For scriptable objects
// More variables can be created to save more information per character
[CreateAssetMenu]
public class ActorScriptableObject : ScriptableObject
{
    public string actorName;
    public Color actorColour;
}
