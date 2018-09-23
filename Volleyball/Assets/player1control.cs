﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1control : MonoBehaviour {

    public Rigidbody2D left;
    public Rigidbody2D right;
	public Collider2D wall;
	public Collider2D floor;
	public Collider2D net;

    public bool grounded;
    public bool wallcontact;
	public bool netcontact;
    
    
	// Use this for initialization
	void Start ()
	{
	    grounded = true;
		wallcontact = false;
		netcontact = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (left.IsTouching(wall) || right.IsTouching(wall))
		{
			wallcontact = true;
		}
		else
		{
			wallcontact = false;
		}

		if (left.IsTouching(net) || right.IsTouching(net))
		{
			netcontact = true;
		}
		else
		{
			netcontact = false;
		}
		
		
		if(left.IsTouching(floor) && right.IsTouching(floor))
		{
			grounded = true;
		}
		
		
		if(Input.GetKey("d"))
        {
	        if(!netcontact)
				this.transform.position += new Vector3(0.03f, 0);
        }
        else if (Input.GetKey("a"))
        {
	        if(!wallcontact)
				this.transform.position += new Vector3(-0.03f, 0);
        }
        if(Input.GetKeyDown("w"))
        {
	        if(grounded)
	        {
		        left.AddForce(new Vector2(0f, 425f));
                right.AddForce(new Vector2(0f, 425f));
                grounded = false;
	        }
	        
        }
    }


}