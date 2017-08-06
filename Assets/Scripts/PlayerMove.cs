using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public  float       speed       = 10;
    public  float       basicMove   = 1.5f;
    public  float       basicJump   = 1.5f;
    private float       decrement   = 0.02f;
    private bool        checkJump   = true;
    private Rigidbody2D player;
    private SpriteRenderer playerColor;

    Vector2 move = new Vector2(0, 0);

    void OnCollisionEnter2D(Collision2D coll)
    {
        checkJump = false;
        move.y = 0;
        move.x = basicMove * 0.6f;
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        checkJump = true;
    }

    void Start ()
    {
        player = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate ()
    {
        //Buttons
        if (Input.GetKey("up") && !checkJump)
            move.y = basicJump;
        if (Input.GetKey("right") && !checkJump)
            move.x = basicMove;
        if (Input.GetKey("left") && !checkJump)
            move.x = -basicMove;
        //Physics
        if (checkJump)
            move.y -= decrement * 6;
        if (move.x < 0 && !checkJump)        
            move.x += decrement * 3;
        else if (move.x > 0 && !checkJump)
            move.x -= decrement * 3;
        if (!Input.GetKey("left") && !checkJump && !Input.GetKey("right") && !Input.GetKey("up"))
            move = Vector2.zero;

        player.velocity = move * speed;
    }
}
