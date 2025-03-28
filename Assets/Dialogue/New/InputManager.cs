using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
