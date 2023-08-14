using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject healtBar;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
        if(pausePanel.activeSelf == true)
        {
            pausePanel.SetActive(false);
            healtBar.SetActive(true);
            Time.timeScale = 1;
        }
        else
        {
            healtBar.SetActive(false);
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
       } 
    }
    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        healtBar.SetActive(true);
        Time.timeScale = 1;   
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
