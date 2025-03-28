using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogueCore : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    // these should not be available in the editor but are used in different scripts
    [HideInInspector]
    public int index = 0;

    [HideInInspector]
    public bool lineComplete;

    public float textSpeed;

    // variable for the conversation lines themself
    [TextArea]
    public string[] lines;

    public UnityEvent OnNextCharacter;
    public UnityEvent OnNextLine;
    public UnityEvent OnTypeLine;

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void StartDialogue()
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

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            OnNextCharacter.Invoke();
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Debug.Log("Dialogue is complete");
        }

        OnNextLine.Invoke();
    }

    public void OnNextLinePressed()
    {
        if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }
    private void IsLineComplete()
    {
        if (textComponent.text == lines[index])
        {
            lineComplete = true;
        }
        else
        {
            lineComplete = false;
        }
    }
}