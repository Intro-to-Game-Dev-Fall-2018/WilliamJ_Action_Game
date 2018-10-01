using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2control : MonoBehaviour {

    public Rigidbody2D left;
    public Rigidbody2D right;
    public Collider2D wall;
    public Collider2D RFloor;
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


    public bool grounded;
    public bool wallcontact;
    public bool netcontact;
    public bool moving;


    public int frames;


    // Use this for initialization
    void Start ()
    {
        grounded = true;
        wallcontact = false;
        netcontact = false;
        moving = false;
        LCurrent = LIdle;
        RCurrent = RIdle;
        frames = 0;
    }
	
    // Update is called once per frame
    void Update () {
		
		
        if(Input.GetKey("right"))
        {
            if (!wallcontact)
            {
                this.transform.position += new Vector3(0.03f, 0);
                moving = true;
            }
            PLeft.flipX = true;
            PRight.flipX = true;

        }
        else if (Input.GetKey("left"))
        {
            if (!netcontact)
            {
                this.transform.position += new Vector3(-0.03f, 0);
                moving = true;
            }
            PLeft.flipX = false;
            PRight.flipX = false;

        }
        else
        {
            moving = false;
        }

        if(Input.GetKeyDown("right shift"))
        {
            if(grounded)
            {
                left.AddForce(new Vector2(0f, 360f));
                right.AddForce(new Vector2(0f, 360f));
            }
	        
        }


        if (moving)
        {
            frames++;

            if (frames == 20)
            {
                if (LCurrent == LIdle)
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
        if(left.IsTouching(RFloor) && right.IsTouching(RFloor))
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
    }
}