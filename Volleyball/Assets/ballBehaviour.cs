using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehaviour : MonoBehaviour {

    int LCount;
    int RCount;
    public GameObject p1;
    public GameObject p2;
    public Rigidbody2D t;
    bool state;
    int LScore;
    int RScore;

    string lastHit;

	// Use this for initialization
	void Start () {
        LCount = 0;
        RCount = 0;
        LScore = 0;
        RScore = 0;
        state = false;
        t.gravityScale = 0;

	}
	
	// Update is called once per frame
	void Update () {
        t.rotation--;

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "stick" || collision.collider.name == "stickr")
        {
            if (state == false)
            {
                state = true;
                t.gravityScale = 1;
            }
            if(LCount < 3)
            {
                LCount++;
                lastHit = collision.collider.name;
            }
            else {
                Reset(2);
            }
        }
        if (collision.collider.name == "stick2" || collision.collider.name == "stick2r")
        {
            if (state == false)
            {
                state = true;
                t.gravityScale = 1;
            }
            if (RCount < 3)
            {
                RCount++;
                lastHit = collision.collider.name;
            }
            else
            {
                Reset(1);
            }
        }

        if (collision.collider.name == "RFloor" && (lastHit == "stick" || lastHit == "stickr"))
        {
            LScore++;
            Reset(1);
        }
        else if(collision.collider.name == "RFloor")
        {
            Reset(1);
        }

        if (collision.collider.name == "LFloor" && (lastHit == "stick2" || lastHit == "stick2r"))
        {
            RScore++;
            Reset(2);
        }
        else if (collision.collider.name == "LFloor")
        {
            Reset(2);
        }

        if(collision.collider.name == "net")
        {
            if(lastHit == "stick2" || lastHit == "stick2r")
            {
                Reset(1);
            }
            else
            {
                Reset(2);
            }
        }

    }

    public void Reset(int side)
    {
        if(side == 1)
        {
            this.transform.position = new Vector3(-5f, -0.73f, 0f);
        }
        else
        {
            this.transform.position = new Vector3(5f, -0.73f, 0f);
        }
        p1.transform.position = new Vector3(0.024291f, 0.09672341f, -0.01164815f);
        p2.transform.position = new Vector3(12.98f, 0.09672341f, -0.01164815f);
        
        LCount = 0;
        RCount = 0;
        state = false;
        t.gravityScale = 0;
        t.velocity = new Vector2(0, 0);
        lastHit = "";
    }


}
