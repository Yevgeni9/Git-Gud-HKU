using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

// The core for the dialogue, on its own it will only convert strings and display them character for character
public class DialogueCore : MonoBehaviour
{
    [HideInInspector] public int index = 0;
    [HideInInspector] public bool lineComplete;
    [TextArea] public string[] lines; // variable for the conversation itself
    public float defaultTextSpeed;

    public TextMeshProUGUI textComponent;

    public UnityEvent OnNextCharacter;
    public UnityEvent OnTypeLine;

    private void Start()
    {
        StartCoroutine(TypeLine());
    }

    private void Update()
    {
        IsLineComplete();
    }

    private IEnumerator TypeLine()
    {
        OnTypeLine.Invoke();

        string rawLine = lines[index];

        List<(char, float)> parsedText = DialogueSpeed.Parse(rawLine, defaultTextSpeed);
        textComponent.text = string.Empty;

        foreach (var (character, charSpeed) in parsedText)
        {
            textComponent.text += character;
            yield return new WaitForSeconds(charSpeed);
            OnNextCharacter.Invoke();
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            Debug.Log("Dialogue is complete");
        }
    }

    private void IsLineComplete()
    {
        if (textComponent.text == DialogueSpeed.RemoveTags(lines[index]))
        {
            lineComplete = true;
        }
        else
        {
            lineComplete = false;
        }
    }

    public void OnNextLinePressed()
    {
        if (lineComplete)
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = DialogueSpeed.RemoveTags(lines[index]);
        }
    }
}