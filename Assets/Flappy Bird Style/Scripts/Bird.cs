using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    // We check if the bird is dead with the isDead variable.
    private bool isDead = false;
    private float upForce = 200f;
    private Rigidbody2D rb2d;
    private Animator anim;


	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
        // if the bird is not dead we can play the game.
        if(isDead == false)
        {
            // if we are pressing on the left mouse button something must happen, 0 stand for left mouse button.
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
