using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombFall2 : MonoBehaviour
{
    public Transform tf;
    public Rigidbody rb;
    public Transform playerTf;

    float zPos;
    Vector3 newPosToDeploy;
    void Update()
    {
        zPos = Random.Range(-7.14f, -4.43f);
        newPosToDeploy = new Vector3(0, 5.2f, zPos);

        if (playerTf.transform.position.z < -5.14f)
        {
            newPosToDeploy = new Vector3(0, 3.48f, playerTf.transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Ground" || collision.collider.name =="wall")
        {
            tf.position = newPosToDeploy;
        }
    }
}
