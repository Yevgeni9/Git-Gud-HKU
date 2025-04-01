using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogueCore : MonoBehaviour
{
    // these should not be available in the editor but are used in different scripts
    [HideInInspector]
    public int index = 0;
    [HideInInspector]
    public bool lineComplete;

    public float defaultTextSpeed;

    // variable for the conversation lines themself
    [TextArea]
    public string[] lines;

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

    public void OnNextLinePressed()
    {
        if (textComponent.text == DialogueSpeed.RemoveTags(lines[index]))
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = DialogueSpeed.RemoveTags(lines[index]);
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
}