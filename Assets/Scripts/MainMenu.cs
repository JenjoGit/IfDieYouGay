using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    int currentMenu;

    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject optionsScreen;
    [SerializeField] GameObject creditsScreen;
    [SerializeField] GameObject achievementScreen;

    [SerializeField] GameObject animationScreen;

    [SerializeField] Sprite[] animationArray;

    [SerializeField] float animationSpeed = 0.05f;
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

            StartCoroutine(Right());

            Vector3 temp = titleScreen.transform.position;
            titleScreen.transform.position = achievementScreen.transform.position;
            achievementScreen.transform.position = creditsScreen.transform.position;
            creditsScreen.transform.position = optionsScreen.transform.position;
            optionsScreen.transform.position = temp;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Left());

            Vector3 temp = titleScreen.transform.position;
            titleScreen.transform.position = optionsScreen.transform.position;
            optionsScreen.transform.position = creditsScreen.transform.position;
            creditsScreen.transform.position = achievementScreen.transform.position;
            achievementScreen.transform.position = temp;
        }
    }

    private IEnumerator Left()
    {
        animationScreen.transform.position = new Vector3(0,0,0);
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[0];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[1];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[2];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[3];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[4];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[5];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[6];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[7];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[8];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[9];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[10];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[11];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[12];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[13];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[14];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[15];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[0];

        animationScreen.transform.position = new Vector3(0,2000,0);
    }
    private IEnumerator Right()
    {
        animationScreen.transform.position = new Vector3(0,0,0);
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[0];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[15];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[14];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[13];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[12];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[11];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[10];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[9];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[8];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[7];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[6];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[5];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[4];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[3];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[2];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[1];
        yield return new WaitForSeconds(animationSpeed);
        animationScreen.GetComponent<Image>().sprite = animationArray[0];

        animationScreen.transform.position = new Vector3(0,2000,0);
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
