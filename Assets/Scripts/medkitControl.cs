using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkitControl : MonoBehaviour
{
    [SerializeField] AudioClip healSound;
    [SerializeField] float destroyDelay = 3f;
    private float timer = 0f;

    private void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Missile"), LayerMask.NameToLayer("Medkit"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Obstacles"), LayerMask.NameToLayer("Medkit"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Spawner"), LayerMask.NameToLayer("Medkit"));
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= destroyDelay)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameControl.m_instance.Heal(1);
            Destroy(gameObject);
            if (healSound != null)
            {
                AudioSource.PlayClipAtPoint(healSound, transform.position);
            }
        }
    }
}
