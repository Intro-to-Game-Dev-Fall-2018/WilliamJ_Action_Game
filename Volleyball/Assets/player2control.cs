using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2control : MonoBehaviour {

    public Rigidbody2D left;
    public Rigidbody2D right;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            this.transform.position += new Vector3(0.03f, 0);
        }
        else if (Input.GetKey("left"))
        {
            this.transform.position += new Vector3(-0.03f, 0);
        }
        if (Input.GetKeyDown("up"))
        {
            left.AddForce(left.transform.up * 10.0f);
            right.AddForce(right.transform.up * 10.0f);
        }
    }
}