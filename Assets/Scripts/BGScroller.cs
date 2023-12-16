using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float speed = 0;
    private Material mat;
    private GameObject player;

    private float pos = 0;

	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //var vel = pl.GetComponent<Rigidbody2D>().velocity.x;
		float move = Input.GetAxis("Horizontal");

       // if (vel != 0f) {
		    pos += speed*move;
            mat.mainTextureOffset = new Vector2(pos, 0);

       // }
	}
}
