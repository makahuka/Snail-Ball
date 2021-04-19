using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // Mole Prefab
    public GameObject Capsule;
    public float aliveTime = 3;

    // Spawn Interval
    public int intervalMin = 3;
    public int intervalMax = 12;

    public float maxY = -2.0f;
    public float minY = 2.0f;
    public float speed = 3.0f;
    private int _direction = 1;

    // Use this for initialization
    void Start()
    {
        Invoke("Spawn", Random.Range(intervalMin, intervalMax));
    }

    void Spawn()
    {
        // Spawn the mole
        GameObject g = (GameObject)Instantiate(Capsule, transform.position, Quaternion.identity);
        transform.Translate(0, _direction * speed * Time.deltaTime, 0);

        bool bounced = false;
        if (transform.position.y > maxY || transform.position.y < minY)
        {
            _direction = -_direction;
            bounced = true;
        }
        if (bounced)
        {
            transform.Translate(0, _direction * speed * Time.deltaTime, 0);
        }
        // Make sure to destroy it after a few seconds
        Destroy(g, aliveTime);

        // Next Spawn
        Invoke("Spawn", Random.Range(intervalMin, intervalMax));
    }

}
