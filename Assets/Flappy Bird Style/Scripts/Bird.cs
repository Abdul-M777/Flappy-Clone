using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    // We check if the bird is dead with the isDead variable.
    private bool isDead = false;
    // Here we decide how high the bird can fly.
    private float upForce = 200f;
    // Holds the Rigidbody2D component of the bird.
    private Rigidbody2D rb2d;
    // Reference to the Animator component.
    private Animator anim;


	// Use this for initialization
	void Start () {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D> ();
        //Get reference to the Animator component attached to this GameObject.
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
                // The bird position is on (0,0).
                rb2d.velocity = Vector2.zero;
                // When we click the position will change to (0,200).
                rb2d.AddForce(new Vector2(0, upForce));
                // Here we tell the Animator that it should trigger the "Flap".
                anim.SetTrigger("Flap");
            }
        }
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // We stop the bird on (0,0).
        rb2d.velocity = Vector2.zero;
        // If the bird colides with something, we set the bird to dead.
        isDead = true;
        // We tell the Animator to trigger the "Die" animation.
        anim.SetTrigger("Die");
        // We tell the GameControl about it.
        GameControl.instance.BirdDied();
    }
}
