using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// The scene for this project only has one input, hence why this script is so small
public class InputManager : MonoBehaviour
{
    public UnityEvent OnSpaceBar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpaceBar.Invoke();
        }
    }
}
