using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public void Stop(){
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void Continue(){
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void Quit(){
        Time.timeScale = 1;
        ChooseLevel.level = 1;
        SceneManager.LoadScene("MenuStart",LoadSceneMode.Single);
    }
}
