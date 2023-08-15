using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToToggle : MonoBehaviour
{
    public Animator buttonAnimator;
    public bool pressed;

    public void Start()
    {
        // Load the stored state from PlayerPrefs
        pressed = PlayerPrefs.GetInt("ButtonState", 0) == 1;
        Debug.Log("Loaded Button State: " + (pressed ? "Pressed" : "Normal"));

        
        // Set the initial state
        if (pressed)
            buttonAnimator.SetTrigger("Pressed");
        else
            buttonAnimator.SetTrigger("Normal");
    }

    public void OnButtonClick()
    {
        if (pressed)
        {
            buttonAnimator.SetTrigger("Normal");
            pressed = false;
        }
        else
        {
            buttonAnimator.SetTrigger("Pressed");
            pressed = true;
        }

        // Store the current state in PlayerPrefs
        PlayerPrefs.SetInt("ButtonState", pressed ? 1 : 0);
    }
    public void LoadButtonState()
    {
        // Load the stored state from PlayerPrefs
        pressed = PlayerPrefs.GetInt("ButtonState", 0) == 1;

        // Set the initial state
        if (pressed)
        {
            buttonAnimator.SetTrigger("Pressed");
        }
        else
        {
            buttonAnimator.SetTrigger("Normal");
        }
    }
}
