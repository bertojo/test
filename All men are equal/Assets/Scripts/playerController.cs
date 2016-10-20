using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float speed = 10;
	public float jump = 200;
	public float throwSpeed = 50;
    public CircleCollider2D player1Coll;

    private Rigidbody2D rb2d;
    private bool isRight = false;

	float moveVelocity;
	private Rigidbody2D player2rb2d;
	bool onGround = true;
   
	bool throwReady;

	// Use this for initialization
	void Start () {
		player2rb2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        rb2d = this.GetComponent<Rigidbody2D>();
	}



    // Update is called once per frame
    void Update() {
        Vector2 velo = rb2d.velocity;
        moveVelocity = 0;
        //left-right movements
        if (Input.GetKey(KeyCode.W))
        { if (onGround) {
                velo.y = jump * Time.deltaTime;
                rb2d.velocity = velo;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            velo.x = speed*Time.deltaTime;
            rb2d.velocity = velo;

        }


        //jump
        if (Input.GetKey(KeyCode.A))
        {
            velo.x = -speed * Time.deltaTime;
            rb2d.velocity = velo;
        }


        if (Input.GetKey(KeyCode.LeftShift)){

        	if(throwReady){
                velo.y = throwSpeed * Time.deltaTime;
                player2rb2d.velocity = velo;
                print(throwReady);

 
            }
        }
	
	}

	void OnTriggerEnter2D(Collider2D other){
		//print(onGround);
		if (other.gameObject.CompareTag("floor")){
			//print(onGround);
			onGround = true;
		}
		if (other.gameObject.CompareTag("Player")){
			throwReady = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag("floor")){
			//print(onGround);
			onGround = false;
		}
		if (other.gameObject.CompareTag("Player")){
			throwReady = false;
		}

	}
}
