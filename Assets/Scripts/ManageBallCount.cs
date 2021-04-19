using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageBallCount : MonoBehaviour
{
    private Rigidbody ball;

    public GameObject balls;

    //public Text ballCount;

    public int countBalls = 0;

    public GameObject[] spawnPoints = null;

    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {

        // ball count
        if (other.gameObject.tag == "Ball")
        {
            countBalls += 1;
            //ballCount.text = "Ball(s) Used: " + countBalls;
        }

        if (other.gameObject.tag == "Ball" && countBalls >= 5) 
        {
            //Destroy(gameObject);
            other.gameObject.SetActive(false);
            Application.Quit();
        }
    }
}
