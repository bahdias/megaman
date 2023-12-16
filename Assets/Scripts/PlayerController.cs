using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Rigidbody2D playerRigidbody;
	public SpriteRenderer playerRenderer;
    public Animator anime;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	public bool jump;
	public bool slide;
	public bool run;

	public bool grounded;
	public float timeTemp;
	public float slideTemp;
	public int forceJump = 0;

    public float maxSpeed = 5f;             // The fastest the player can travel in the x axis.
	public float moveForce = 365f;          // Amount of force added to move the player left and right.

	private int doubleJump;
	public Transform colisor;
	private bool isDownArrowPressed = false;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        // se detectar colisão com o hero detrói a moeda
        if (other.gameObject.CompareTag("Enemy"))
        {
			//Destroy(gameObject);
			Application.LoadLevel(Application.loadedLevel);

        }


    }

	// Update is called once per frame
	void Update () {
        // correr
		float move = Input.GetAxis("Horizontal");
		if (move * playerRigidbody.velocity.x < maxSpeed)
			playerRigidbody.AddForce(Vector2.right * move * moveForce);
		if (Mathf.Abs(playerRigidbody.velocity.x) > maxSpeed)
			playerRigidbody.velocity = new Vector2(Mathf.Sign(playerRigidbody.velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);     
		if (move > 0) {
			playerRenderer.flipX = false;
			run = true;
         } 
        // Otherwise if the input is moving the player left and the player is facing right...
		else if (move < 0) {
			playerRenderer.flipX = true;
			run = true;
		} else {
			run = false;
		}
        
        // pulo
		grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);
                
		if(Input.GetButtonDown("Jump") && doubleJump < 1) {
				doubleJump++;
				playerRigidbody.AddForce(new Vector2(0, forceJump));
			if (slide)
			{
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				slide = false;
			}

		} else if (grounded){
			doubleJump = 0;
		}

        // slide
		if (Input.GetButtonDown("Slide")) {
			if(!slide) {
				colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
            }
			slide = true;
			timeTemp = 0;
		}

		// Seta para baixo
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
        isDownArrowPressed = true;

        // Aumente temporariamente a gravidade para fazer o jogador cair mais rápido.
        playerRigidbody.gravityScale = 2.0f; // Ajuste este valor conforme necessário.
    }

    if (Input.GetKeyUp(KeyCode.DownArrow))
    {
        isDownArrowPressed = false;

        // Restaure a gravidade normal quando a seta para baixo for liberada.
        playerRigidbody.gravityScale = 1.0f; // Ajuste este valor para a gravidade normal do seu jogo.
    }

		if(slide) {
			timeTemp += Time.deltaTime;
			if(timeTemp >= slideTemp) {
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				slide = false;
			}
		}
        
        // animacoes
		anime.SetBool("jump", !grounded);
		anime.SetBool("slide", slide);
		anime.SetBool("run", run);


        
	}
}
