using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltSpawn : MonoBehaviour
{
    private Rigidbody ball;

    public GameObject balls;

    //public Text ballCount;

    public int countBalls = 0;

    public GameObject[] spawnPoints = null;

    //public Text pointsTotal;

    public float mag = 0;

    //Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(ball);

        ball = GetComponent<Rigidbody>();

        //direction = new Vector3(5.0f, 5.0f, 0.0f);
    }

    private void Respawn()
    {
        int index = 0;
        while (Physics.CheckBox(spawnPoints[index].transform.position, new Vector3(8.969501f, -0.105f, -5.6f)))
        {
            index++;
        }
        ball.MovePosition(spawnPoints[index].transform.position);
        ball.velocity = Vector3.zero;

        if (ball == false)
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        

        // ball count
        if (other.gameObject.tag == "Ball")
        {
            countBalls += 1;
            //ballCount.text = "Ball(s) Used: " + countBalls;
        }
    }
}
