using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMover : MonoBehaviour {

    Rigidbody2D rb;
    public float speed = 100;
    public int fret;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(1, -speed));
    }
	
	// Update is called once per frame
	void Update () {

    }
}
