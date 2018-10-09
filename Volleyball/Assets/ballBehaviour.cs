using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehaviour : MonoBehaviour {


    public GameObject p1;
    public GameObject p2;
    public Rigidbody2D t;
    bool state;
    int LScore;
    int RScore;
    public TextMesh LS;
    public TextMesh RS;
    public AudioSource wallBounce;
    public AudioSource playerBounce;
    public AudioSource crackling;

    private float LTimer;
    private float RTimer;

    string lastHit;

	// Use this for initialization
	void Start () {
        LScore = 0;
        RScore = 0;
        state = false;
        t.gravityScale = 0;
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("InvisWall").GetComponent<Collider2D>());
    }
	
	// Update is called once per frame
	void Update () {
        t.rotation++;
	    this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * 5f;
	    LTimer -= Time.deltaTime;
	    RTimer -= Time.deltaTime;
	    LS.text = LScore.ToString();
	    RS.text = RScore.ToString();
	    
	    
	    if (RTimer <= 0)
	    {
	        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stick2").GetComponent<Collider2D>(), false);
	        //Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stick2r").GetComponent<Collider2D>(), false);
	    }
	    if (LTimer <= 0)
	    {
	        //Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stick").GetComponent<Collider2D>(), false);
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
                crackling.Play();
            }

            lastHit = collision.collider.name;
            LTimer = 2;
            //Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stick").GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stickr").GetComponent<Collider2D>());
            if(playerBounce.isPlaying)
            {
                playerBounce.Stop();
                playerBounce.Play();
            }
            else
            {
                playerBounce.Play();
            }
        }
        if (collision.collider.name == "stick2" || collision.collider.name == "stick2r")
        {
            if (state == false)
            {
                state = true;
                t.gravityScale = 0.01f;
            }

            lastHit = collision.collider.name;
            RTimer = 2f;
            //Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("stick2r").GetComponent<Collider2D>());
            if (playerBounce.isPlaying)
            {
                playerBounce.Stop();
                playerBounce.Play();
            }
            else
            {
                playerBounce.Play();
            }
        
        }

        if (collision.collider.name == "RFloor" && (lastHit == "stickr"))
        {
            LScore++;
            Reset(1);
        }
        else if(collision.collider.name == "RFloor")
        {
            Reset(1);
        }

        if (collision.collider.name == "LFloor" && (lastHit == "stick2"))
        {
            RScore++;
            Reset(2);
        }
        else if (collision.collider.name == "LFloor")
        {
            Reset(2);
        }

        if(collision.collider.name == "right wall" || collision.collider.name == "left wall" || collision.collider.name == "ceiling" || collision.collider.name == "net")
        {
            if (wallBounce.isPlaying)
            {
                wallBounce.Stop();
                wallBounce.Play();
            }
            else
            {
                wallBounce.Play();
            }
        }

    }

    public void Reset(int side)
    {
        if(side == 1 || side == 3)
        {
            this.transform.position = new Vector3(-5f, -2.7f, 0f);
        }
        else
        {
            this.transform.position = new Vector3(5f, -2.7f, 0f);
        }
        p1.transform.position = new Vector3(-5f, -4.05f, 0.01164815f);
        p2.transform.position = new Vector3(5, -4.49f, -0.01164815f);
        GameObject.Find("stick2").GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        GameObject.Find("stickr").GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);


        state = false;
        t.gravityScale = 0;
        t.velocity = new Vector2(0, 0);
        lastHit = "";

        if(side == 3)
        {
            LScore = 0;
            RScore = 0;
            crackling.Stop();
        }
    }


}
