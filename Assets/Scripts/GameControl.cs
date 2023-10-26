using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject crate;
    [SerializeField] Transform crate_spawn;
    [SerializeField] Text t_count;
    [SerializeField] float speed;
    [SerializeField] GameObject medkit;
    [SerializeField] Transform medkit_spawn;
    [SerializeField] GameObject barrel;
    [SerializeField] Transform barrel_spawn;
    [SerializeField] GameObject missile;
    [SerializeField] Transform missile_spawn;
    public bool isAlive = true;
    public bool isInvincible = false;
    public float timer = 0;
    public int playerHP;
    [SerializeField] Text max_result;
    private float maxRes = 0f;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip barrelAlert;
    [SerializeField] AudioClip missileAlert;
    public float move;

    private static GameControl instance;
    public static GameControl m_instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameControl>();
            }
            return instance;
        }
    }

    void Start()
    {
        GetComponent<Animator>().SetBool("isMoving", true);
        StartCoroutine(CrateSpawn());
        StartCoroutine(MedkitSpawn());
        StartCoroutine(BarrelSpawn());
        StartCoroutine(MissileSpawn());
        playerHP = 3;
        if (PlayerPrefs.HasKey("Max"))
        {
            maxRes = PlayerPrefs.GetFloat("Max");
        }
        max_result.text = "Maximum: " + maxRes.ToString("F2") + "s";
    }

    void Update()
    {
        //float move = Input.GetAxisRaw("Horizontal");

        if (move != 0)
        {
            GetComponent<Animator>().SetBool("isMoving", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false);
        }

        player.transform.Translate(new Vector3(move * speed * Time.deltaTime, 0, 0));

        if (isAlive)
        {
            timer += Time.deltaTime;
            if (timer > 0f)
            {
                t_count.text = "Survived: " + timer.ToString("F2") + "s";
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if (isInvincible)
            return;

        playerHP -= damage;

        if (playerHP <= 0)
        {
            GameOver();
        }
        else
        {
            StartCoroutine(InvincibilityDuration(1.5f));
        }

        PlayerHealth.m_instance.Initialize();
    }
    IEnumerator InvincibilityDuration(float duration)
    {
        isInvincible = true; 

        yield return new WaitForSeconds(duration);

        isInvincible = false;
    }

    public void Heal(int amount)
    {
        playerHP += amount;
        playerHP = Mathf.Clamp(playerHP, 0, 3);

        PlayerHealth.UpdateHealth(playerHP);
    }
    IEnumerator PlaySoundForDuration(AudioClip clip, float duration)
    {
        soundSource.PlayOneShot(clip);
        yield return new WaitForSeconds(duration);
        soundSource.Stop();
    }
    IEnumerator CrateSpawn()
    {
        float spawnDelay = 0.7f;
        float accelerationRate = 0.01f;

        for (int i = 0;; i++)
        {
            crate_spawn.position = new Vector3(Random.Range(25f, 41f), 11, 9);

            Instantiate(crate, crate_spawn.position, crate_spawn.rotation);

            spawnDelay -= accelerationRate;
            spawnDelay = Mathf.Max(spawnDelay, 0.3f);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    IEnumerator MedkitSpawn()
    {
        for (int i = 0;; i++)
        {
            medkit_spawn.position = new Vector3(Random.Range(25f, 41f), 11, 9);

            Instantiate(medkit, medkit_spawn.position, medkit_spawn.rotation);

            yield return new WaitForSeconds(20f);
        }
    }
    IEnumerator BarrelSpawn()
    {
        float spawnDelay = 1f;
        float accelerationRate = 0.01f;

        yield return new WaitForSeconds(15f);

        yield return StartCoroutine(PlaySoundForDuration(barrelAlert, 4f));

        for (int i = 0;; i++)
        {
            barrel_spawn.position = new Vector3(Random.Range(25f, 41f), 11, 9);

            Instantiate(barrel, barrel_spawn.position, barrel_spawn.rotation);

            spawnDelay -= accelerationRate;
            spawnDelay = Mathf.Max(spawnDelay, 0.5f);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
    IEnumerator MissileSpawn()
    {
        float spawnDelay = 30f;
        float accelerationRate = 5f;

        yield return new WaitForSeconds(spawnDelay);
        yield return StartCoroutine(PlaySoundForDuration(missileAlert, 4f));

        for (int i = 0; ; i++)
        {
            missile_spawn.position = new Vector3(Random.Range(25f, 41f), 11, 9);

            Instantiate(missile, missile_spawn.position, missile_spawn.rotation);

            spawnDelay -= accelerationRate;
            spawnDelay = Mathf.Max(spawnDelay, 5f);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
    public void GameOver()
    {
        isAlive = false;
        Destroy(player);

        if (timer > maxRes)
        {
            maxRes = timer;
            PlayerPrefs.SetFloat("Max", maxRes);
            max_result.text = "Maximum: " + maxRes.ToString("F2") + "s";
        }
        SceneManager.LoadScene(3);
    }
}
