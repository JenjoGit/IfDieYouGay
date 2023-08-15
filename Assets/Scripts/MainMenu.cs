using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class MainMenu : MonoBehaviour
{
    int currentMenu;

    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject optionsScreen;
    [SerializeField] GameObject creditsScreen;
    [SerializeField] GameObject achievementScreen;

    // Start is called before the first frame update
    void Start()
    {
        //left = titleScreen.;

        currentMenu = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Vector3 temp = titleScreen.transform.position;
            titleScreen.transform.position = achievementScreen.transform.position;
            achievementScreen.transform.position = creditsScreen.transform.position;
            creditsScreen.transform.position = optionsScreen.transform.position;
            optionsScreen.transform.position = temp;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Vector3 temp = titleScreen.transform.position;
            titleScreen.transform.position = optionsScreen.transform.position;
            optionsScreen.transform.position = creditsScreen.transform.position;
            creditsScreen.transform.position = achievementScreen.transform.position;
            achievementScreen.transform.position = temp;
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Debug.Log("Quit game\n Doesn't work in the Editor but will quit the game when compiled.");
        Application.Quit();
    }
    
}
