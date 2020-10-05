using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainButtons;
    public GameObject instructionBG;

    public void PlayGame ()
    {
        Debug.Log("Play game");
        SceneManager.LoadScene("Dream01");
        Time.timeScale = 1f;
    }

    public void ShowInstructions ()
    {
        instructionBG.SetActive(true);
        mainButtons.SetActive(false);
    }

    public void HideInstructions ()
    {
        instructionBG.SetActive(false);
        mainButtons.SetActive(true);
    }

    public void ExitGame ()
    {
        Application.Quit();
    }
}
