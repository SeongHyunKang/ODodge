using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public Text textScore;
    public Text EndMsg;
    string str;

    private void Start()
    {
        str = textScore.text;
        textScore.text = str;
        EndMsg.text = "Press R to Restart";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeMessage();
            Invoke("Restart", 1f);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void ChangeMessage()
    {
        EndMsg.text = "Restarting...";
    }
}

