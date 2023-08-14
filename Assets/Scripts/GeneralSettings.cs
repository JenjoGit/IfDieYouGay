using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneralSettings : MonoBehaviour
{
    [SerializeField] GameObject fpsDisplay;
    [SerializeField] TMP_Text fpsText;
    private float deltaTime;
    [SerializeField] ButtonToToggle btt;
    // Start is called before the first frame update
    public int target = 30;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;

    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Application.targetFrameRate != target)
            Application.targetFrameRate = target;
        displayFPS();
    }
    void displayFPS()
    {
        if(btt.pressed == true)
        {
            fpsDisplay.SetActive(true);
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		    float fps = 1.0f / deltaTime;
		    fpsText.text = Mathf.Ceil (fps).ToString ();
        }
        else if(btt.pressed == false)
        {
            fpsDisplay.SetActive(false);

        }
    }
}
