using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text textScore;
    public float timer = 0;
    public GameControl gm;
    public bool isAlive = true;

    private void FixedUpdate()
    {
        if(isAlive)
        {
            timer += Time.fixedDeltaTime;
            if (timer > 0f)
            {
                textScore.text = "Survived: " + timer.ToString("F2") + "s";
            }
        }        
    }
}

