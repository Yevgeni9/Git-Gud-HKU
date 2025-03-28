using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueCore))]
public class DialogueAudio : MonoBehaviour
{
    private DialogueCore dialogueCore;
    [SerializeField] private AudioSource DialogueSFX;

    [System.Serializable]
    public struct PitchRange
    {
        public float minPitch;
        public float maxPitch;
    }

    [SerializeField] private PitchRange[] pitchRanges;

    private void Start()
    {
        dialogueCore = GameObject.Find("Dialogue").GetComponent<DialogueCore>();
    }

    public void NextCharacter()
    {
        int currentIndex = dialogueCore.index;
        PitchRange currentPitchRange = pitchRanges[currentIndex];

        if (DialogueSFX != null)
        {
            DialogueSFX.pitch = Random.Range(currentPitchRange.minPitch, currentPitchRange.maxPitch);
            DialogueSFX.Play();
        }
    }
}
