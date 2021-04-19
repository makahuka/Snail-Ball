using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    int scoreForNextLevel = 4000; //1000 for testing

    // Use this for initialization
    void Start()
    {
        // Find a reference to the ScoreCounter GameObject        
        GameObject scoreGO = GameObject.Find("ScoreCounter");               // b        
        // Get the Text Component of that GameObject        
        scoreGT = scoreGO.GetComponent<Text> ();                             // c        
        // Set the starting number of points to 0        
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Inpu        
        Vector3 mousePos2D = Input.mousePosition;                             // a        
        // The Camera's z position sets how far to push the mouse        
        mousePos2D.z = Camera.main.transform.position.z;                     // b        
        // Convert the point from 2D screen space into 3D game wo        
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        // Move the x position of this Basket to the x position o        
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {// Find out what hit this basket        
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            // Parse the text of the scoreGT into an int            
            int score = int.Parse( scoreGT.text );
            // Add points for catching the apple            
            score += 100;
            // Convert the score back to a string and display it            
            scoreGT.text = score.ToString();
            // Track the high score            
            /*if (score > HighScore.score) 
            {
                HighScore.score = score;
            }*/

            if (score == scoreForNextLevel)
            {
                Debug.Log("4000");
                SceneManager.LoadScene("SweetsTVScene");
            }
        }
    }
}
