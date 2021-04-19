using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltTable : MonoBehaviour
{
    public int countBalls = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        // ball count
        if (other.gameObject.tag == "Ball")
        {
            countBalls += 1;
            //ballCount.text = "Ball(s) Used: " + countBalls;
        }

        if (other.gameObject.tag == "Ball" && countBalls >= 5) // Not working
        {

            Debug.Log("Player Tilted");

            //Destroy(gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
