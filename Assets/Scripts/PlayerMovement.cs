using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Transform tf;
    public float speed;

    float xInput;
    float xRot = 0f;

    public MeshRenderer Mesh1, Mesh2, Mesh3, Mesh4;
    public bombFall bomb1, bomb4;
    public bombFall2 bomb2, bomb3;
    public ScoreDisplay sDisplay;
    public PlayerMovement pmScript;
    AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");

        if (xInput < 0)
        {
            xRot -= 1500;
            tf.rotation = Quaternion.Euler(xRot * Time.fixedDeltaTime, 0, 0);
            rb.velocity = new Vector3(0, 0, -speed * Time.fixedDeltaTime);
        }
        if (xInput > 0)
        {
            xRot += 1500;
            tf.rotation = Quaternion.Euler(xRot * Time.fixedDeltaTime, 0, 0);
            rb.velocity = new Vector3(0, 0, speed * Time.fixedDeltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Mesh1.enabled = false;
            Mesh2.enabled = false;
            Mesh3.enabled = false;
            Mesh4.enabled = false;
            bomb1.enabled = false;
            bomb2.enabled = false;
            bomb3.enabled = false;
            bomb4.enabled = false;
            sDisplay.enabled = false;
            this.enabled = false;
        }
    }
}
