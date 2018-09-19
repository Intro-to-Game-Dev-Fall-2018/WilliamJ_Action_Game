using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1control : MonoBehaviour {

    public Rigidbody2D left;
    public Rigidbody2D right;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("d"))
        {
            this.transform.position += new Vector3(0.03f, 0);
        }
        else if (Input.GetKey("a"))
        {
            this.transform.position += new Vector3(-0.03f, 0);
        }
        if (Input.GetKeyDown("w"))
        {
            //left.AddForce(left.transform.up * 100.0f);
            //right.AddForce(right.transform.up * 100.0f);
            left.AddForce(new Vector2(0f, 425f));
            right.AddForce(new Vector2(0f, 425f));
        }
    }
}
