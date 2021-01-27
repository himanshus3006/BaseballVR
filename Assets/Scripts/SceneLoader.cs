using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void BattingLoad()
    {
        SceneManager.LoadScene(1);
    }

    public void PitchingLoad()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }


    public void quitGame()
    {
        Application.Quit();
    }
}
