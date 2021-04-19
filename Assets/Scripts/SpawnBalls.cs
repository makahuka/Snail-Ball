using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBalls : MonoBehaviour
{
    private Rigidbody ball;

    public GameObject balls;

    public Text ballCount;

    public int countBalls = 0;

    public GameObject[] spawnPoints = null;

    public Text pointsTotal;

    public float mag = 0;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(ball);

        ball = GetComponent<Rigidbody>();

        // Find a reference to the ScoreCounter GameObject        
        GameObject scoreGO = GameObject.Find("PointsCounter");               // b        
        // Get the Text Component of that GameObject        
        pointsTotal = scoreGO.GetComponent<Text>();                             // c        
        // Set the starting number of points to 0        
        pointsTotal.text = "0";

        direction = new Vector3(5.0f, 5.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            Respawn();
        }

        // ball count
        if (other.gameObject.tag == "Hazard")
        {
            countBalls += 1;
            ballCount.text = "Ball(s) Used: " + countBalls;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        ball.AddForce(Vector3.Reflect(direction, coll.contacts[0].normal) * mag, ForceMode.Impulse);

        // Find out what hit this bumper       
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Points")
        {
            //Destroy(collidedWith);
            // Parse the text of the scoreGT into an int            
            int score = int.Parse(pointsTotal.text);
            // Add points for catching the apple            
            score += 100;
            // Convert the score back to a string and display it            
            pointsTotal.text = score.ToString();

            // Track the high score            
            /*if (score > HighScore.score)
            {
                HighScore.score = score;
            }*/

            /*if (score == scoreForNextLevel)
            {
                Debug.Log("4000");
                SceneManager.LoadScene("SweetsTVScene");
            }*/
        }
    }
}
