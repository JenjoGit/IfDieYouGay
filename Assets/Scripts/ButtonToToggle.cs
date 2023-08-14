using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToToggle : MonoBehaviour
{
    public Animator buttonAnimator;
    public bool pressed = false;
    [SerializeField] Button button;

    public void OnButtonClick()
    {
        // Trigger the "Pressed" animation state
        if(pressed == false)
        {
            buttonAnimator.SetTrigger("Pressed");
            pressed = true;
        }
        else
        {
            buttonAnimator.SetTrigger("Normal");
            pressed = false;
        }
        
        
        // Perform any other actions you want when the button is clicked
        Debug.Log("Button Clicked!");
    }
}
