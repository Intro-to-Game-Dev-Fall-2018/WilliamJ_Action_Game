using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehaviour : MonoBehaviour {

    public int LCount;
    public int RCount;
    public GameObject p1;
    public GameObject p2;
    public Rigidbody2D t;
    bool state;
    int LScore;
    int RScore;
    public TextMesh LS;
    public TextMesh RS;

    private float LTimer;
    private float RTimer;

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
	    this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * 4f;
	    LTimer -= Time.deltaTime;
	    RTimer -= Time.deltaTime;
	    LS.text = LScore.ToString();
	    RS.text = RScore.ToString();
	    
	    
	    if (RTimer <= 0)
	    {
	        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stick2").GetComponent<Collider2D>(), false);
	        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stick2r").GetComponent<Collider2D>(), false);
	    }
	    if (LTimer <= 0)
	    {
	        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stick").GetComponent<Collider2D>(), false);
	        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stickr").GetComponent<Collider2D>(), false);
	    }
	    
	    
	}


    private void FixedUpdate()
    {
        if (Input.GetKeyDown("r"))
        {
            Reset(3);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "stick" || collision.collider.name == "stickr")
        {
            if (state == false)
            {
                state = true;
                t.gravityScale = 0.01f;
            }

            if (lastHit == "stick2" || lastHit == "stick2r")
            {
                RCount = 0;
            }
            
            if(LCount < 3)
            {
                LCount++;
                lastHit = collision.collider.name;
                LTimer = 2;
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stick").GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stickr").GetComponent<Collider2D>());
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
                t.gravityScale = 0.01f;
            }

            if (lastHit == "stick" || lastHit == "stickr")
            {
                LCount = 0;
            }
            
            if (RCount < 3)
            {
                RCount++;
                lastHit = collision.collider.name;
                RTimer = 2f;
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stick2").GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stick2r").GetComponent<Collider2D>());
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

        /** if(collision.collider.name == "net")
        {
            if(lastHit == "stick2" || lastHit == "stick2r")
            {
                Reset(1);
            }
            else
            {
                Reset(2);
            }
        } **/

    }

    public void Reset(int side)
    {
        if(side == 1 || side == 3)
        {
            this.transform.position = new Vector3(-8f, -2.7f, 0f);
        }
        else
        {
            this.transform.position = new Vector3(8f, -2.7f, 0f);
        }
        p1.transform.position = new Vector3(0.024291f, 0.01f, -0.01164815f);
        p2.transform.position = new Vector3(12.98f, 0.01f, -0.01164815f);
        
        LCount = 0;
        RCount = 0;
        state = false;
        t.gravityScale = 0;
        t.velocity = new Vector2(0, 0);
        lastHit = "";

        if(side == 3)
        {
            LScore = 0;
            RScore = 0;
        }
    }


}
