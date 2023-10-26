using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitConfirm : MonoBehaviour
{
    public void ConfirmQuit()
    {
        Application.Quit();
    }
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
