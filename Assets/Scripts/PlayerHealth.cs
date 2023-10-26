using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    [SerializeField] private GameObject[] hearts;

    private static PlayerHealth instance;
    public static PlayerHealth m_instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerHealth>();
            }
            return instance;
        }
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        playerHealth = GameControl.m_instance.playerHP;
        UpdateHealth(playerHealth);
    }

    public static void UpdateHealth(int currentHealth)
    {
        GameObject[] hearts = FindObjectOfType<PlayerHealth>().hearts;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}

