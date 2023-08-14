using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject healtBar;
    [SerializeField] GameObject settingPanel;


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
            PauseGame();
    }
    public void PauseGame()
    {
        if(pausePanel.activeSelf == true)
        {
            ContinueGame(); 
        }
        else
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            healtBar.SetActive(false);
        }
    }
    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        healtBar.SetActive(true);
        Time.timeScale = 1;   
    }
    public void OpenSettings()
    {
        pausePanel.SetActive(false);
        settingPanel.SetActive(true);
    }
    public void QuitSettings()
    {
        pausePanel.SetActive(false);
        settingPanel.SetActive(false);
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
