using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelControl : MonoBehaviour
{
    [SerializeField] AudioClip hitSound;

    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Missile"), LayerMask.NameToLayer("Obstacles"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Medkit"), LayerMask.NameToLayer("Obstacles"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Spawner"), LayerMask.NameToLayer("Obstacles"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameControl.m_instance.TakeDamage(1);
            Destroy(gameObject, 1f);

            if (hitSound != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
            }
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}