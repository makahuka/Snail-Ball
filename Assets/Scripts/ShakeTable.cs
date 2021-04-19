using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakeTable : MonoBehaviour
{
    public float shake_intensity;
    public Vector3 originPosition;

    public bool isShaking = true;

    private int count = 0;

    public GameObject inPlayBalls;

    public Text ballCount;
    public int countBalls = 0;

    public Text tilt;

    public float tiltSpawn = 5.0f;

    public Button playButton;

    void Start()
    {
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b")) // Need b key in GUI
        {
            print("b key was pressed");

            if (isShaking)
            {
                transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
            }

            print("Table Tilt!!!");
            print(count);
            count += 1;

            if (Random.value < 0.1f/*count == 5*/)
            {
                inPlayBalls.gameObject.SetActive(false);//
                countBalls += 1;
                ballCount.text = "Ball(s) Used: " + countBalls;
                tilt.gameObject.SetActive(true); // Text working in game view
            }
        }

        // If table is shaken to much, tilt and lose ball, add to ball used count
        if (Input.GetKeyUp("b") && Time.time > tiltSpawn)
        {
            tiltSpawn = Time.time;
            if (tiltSpawn >= 5.0f)
            {
                inPlayBalls.gameObject.SetActive(true);
                transform.position = inPlayBalls.transform.position + new Vector3(8.969501f, -0.105f, -5.6f); 
                tilt.gameObject.SetActive(false);
            }
            transform.position = originPosition;
        }

        if (countBalls >= 5)
        {
            //UnityEditor.EditorApplication.isPlaying = false; // In-game testing
            Application.Quit();
        }
    }
}