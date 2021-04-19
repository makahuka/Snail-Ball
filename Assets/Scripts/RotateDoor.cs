using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    //Rotate door
    [SerializeField] private Vector3 dPos;
    private bool _rotateDoor;
    public float _rotate = 90;
    //public float _rotateClose = -90;
    //public float 

    public void Operate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            transform.Rotate(0, _rotate, 0);
        }

        /*if (_rotateDoor)
        {
            transform.Rotate(0, _rotate, 0);
            //transform.Translate(-5, 0, 0);
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
        }*/
        else
        {
            transform.Rotate(0, _rotate, 0);
            //transform.position = pos;
        }
        _rotateDoor = !_rotateDoor;
    }

    //Activate and Deactivate
    public void Activate()
    {
        if (!_rotateDoor)
        {
            transform.Rotate(0, _rotate, 0);
            //transform.position = pos;
            _rotateDoor = true;
        }
    }
    /*public void Deactivate()
    {
        if (_rotateDoor)
        {
            transform.Rotate(0, _rotate, 0);
            //transform.position = pos;
            _rotateDoor = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, speed, 0);
    }*/
}
