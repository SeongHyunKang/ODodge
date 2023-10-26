using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileControl : MonoBehaviour
{
    [SerializeField] AudioClip hitSound;
    [SerializeField] GameObject explosionEffect;
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Obstacles"), LayerMask.NameToLayer("Missile"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Medkit"), LayerMask.NameToLayer("Missile"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Wall"), LayerMask.NameToLayer("Missile"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Spawner"), LayerMask.NameToLayer("Missile"));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameControl.m_instance.TakeDamage(3);
            Explode();
            Destroy(gameObject);
            if (hitSound != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            Explode();
            Destroy(gameObject);
            if (hitSound != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
            }
        }
    }
    void Explode()
    {
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
        }
    }
}
