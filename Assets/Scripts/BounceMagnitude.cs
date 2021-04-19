using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMagnitude : MonoBehaviour
{
    private Rigidbody ball;

    public float mag = 0;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();

        direction = new Vector3(5.0f, 5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision coll)
    {
        ball.AddForce(Vector3.Reflect(direction, coll.contacts[0].normal) * mag, ForceMode.Impulse);
    }
}
