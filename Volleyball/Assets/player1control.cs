using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1control : MonoBehaviour {

    public Rigidbody2D left;
    public Rigidbody2D right;
	public Collider2D wall;
	public Collider2D LFloor;
	public Collider2D net;
    public SpriteRenderer PLeft;
    public SpriteRenderer PRight;
    public Sprite LIdle;
    public Sprite RIdle;
    public Sprite LJump;
    public Sprite RJump;
    public Sprite LWalk;
    public Sprite RWalk;
    public Sprite LCurrent;
    public Sprite RCurrent;

    public bool lastDirection;
    public bool grounded;
    public bool moving;
    float ButtonCooler;
    int ButtonLCount;
    int ButtonRCount;


    public int frames;
    
    
	// Use this for initialization
	void Start ()
	{
	    grounded = true;
        moving = false;
        LCurrent = LIdle;
        RCurrent = RIdle;
        frames =  0;
        ButtonCooler = 0.5f;
        ButtonLCount = 0;
        ButtonRCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey("d"))
        {
            this.transform.position += new Vector3(0.03f, 0);
            moving = true;
            //PLeft.flipX = false;
            PRight.flipX = false;
        }
        if(Input.GetKeyDown("d"))
        {
            //if(!grounded)
            {
                if (ButtonCooler > 0 && ButtonRCount == 1)
                {
                    //Has double tapped
                    //Debug.Log("dashed");
                    //left.AddForce(new Vector2(300f, 0f));
                    if (!lastDirection)
                    {
                        right.velocity = new Vector2(0f, 0f);
                    }
                    right.AddForce(new Vector2(300f, 0f));
                    lastDirection = true;
                }
                else
                {
                    ButtonCooler = 0.5f;
                    ButtonRCount += 1;
                }

            }
            
        }



        if (Input.GetKey("a"))
        {
		    this.transform.position += new Vector3(-0.03f, 0);
            moving = true;

            //PLeft.flipX = true;
            PRight.flipX = true;
        }
        if (Input.GetKeyDown("a"))
        {
            //if (!grounded)
            {
                if (ButtonCooler > 0 && ButtonLCount == 1)
                {
                    //Has double tapped
                    //Debug.Log("dash");
                    //left.AddForce(new Vector2(-30f, 0f));
                    if(lastDirection)
                    {
                        right.velocity = new Vector2(0f, 0f);
                    }
                    right.AddForce(new Vector2(-300f, 0f));
                    lastDirection = false;
                }
                else
                {
                    ButtonCooler = 0.5f;
                    ButtonLCount += 1;
                }

            }

        }



        //{
        //    moving = false;
        //}

        if (Input.GetKeyDown("w"))
        {

		    //left.AddForce(new Vector2(0f, 360f));
            right.AddForce(new Vector2(0f, 360f));

        }
        if (Input.GetKeyDown("s"))
        {

            //left.AddForce(new Vector2(0f, 360f));
            right.AddForce(new Vector2(0f, -360f));

        }

        //var ButtonCooler : float = 0.5; // Half a second before reset
        //var ButtonCount : int = 0;
        //function Update()
        //{
        //    if (Input.anyKeyDown())
        //    {

        //        if (ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/)
        //        {
        //            //Has double tapped
        //        }
        //        else
        //        {
        //            ButtonCooler = 0.5;
        //            ButtonCount += 1;
        //        }
        //    }

        if (ButtonCooler > 0)
        {

            ButtonCooler -= 1 * Time.deltaTime;

        }
        else
        {
            ButtonLCount = 0;
            ButtonRCount = 0;
        }
  
        if(!(Input.GetKeyDown("d") || Input.GetKeyDown("a")))
        {
            moving = false;
        }

        if (moving)
        {
            frames++;

            if(frames == 20)
            {
                if(LCurrent == LIdle)
                {
                    LCurrent = LWalk;
                    RCurrent = RWalk;
                }
                else
                {
                    LCurrent = LIdle;
                    RCurrent = RIdle;
                }

                frames = 0;
            }
        }
    }

	private void FixedUpdate()
	{
		if(right.IsTouching(LFloor))
		{
			grounded = true;
            PLeft.sprite = LCurrent;
            PRight.sprite = RCurrent;
		}
		else
		{
			grounded = false;
            PLeft.sprite = LJump;
            PRight.sprite = RJump;
        }

	}

}
