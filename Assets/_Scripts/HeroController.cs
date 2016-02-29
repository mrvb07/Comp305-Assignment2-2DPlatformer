using UnityEngine;
using System.Collections;


//VELOCITY RANGE UTILITY CLASS
[System.Serializable]
public class VelocityRange
{
    //PUBLIC INSTANCE VARIABLES
    public float minimum;
    public float maximum;

    public VelocityRange(float minimum, float maximum)
    {
        this.minimum = minimum;
        this.maximum = maximum;
    }
}

public class HeroController : MonoBehaviour {
    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Animator _anim;
    private Rigidbody2D _rigidBody2D;
    private float _move;
    private float _jump;
    private bool _facingRight;
    private bool _isGrounded;
    

    //PUBLIC INSTANCE VARIABLES
    public VelocityRange velocityRange;
    public float moveForce;
    public float jumpForce;
    public Transform groundCheck;
    public Transform camera;
    public GameController gameController;

	// Use this for initialization
	void Start () {
        //INTIALIZE PUBLIC INSTANCE VARIABLES
        this.velocityRange = new VelocityRange(300f,1000f);

        //INTIALIZE PRIVATE INSTANCE VARIABLES
        this._transform = gameObject.GetComponent<Transform>();
        this._anim = gameObject.GetComponent<Animator>();
        this._rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        this._move = 0f;
        this._jump = 0f;
        this.moveForce = 1000f;
        this.jumpForce = 30000f;
        this._spawn();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 currentCamPos = new Vector3(this._transform.position.x + 140, -56.41403f, -10);
        this.camera.position = currentCamPos;

        //check whether the player is grounded or not
        this._isGrounded = Physics2D.Linecast(this._transform.position, this.groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(this._transform.position, this.groundCheck.position);

        float forceX = 0f;
        float forceY = 0f;
        float absVelX = Mathf.Abs(this._rigidBody2D.velocity.x);
        float absVelY = Mathf.Abs(this._rigidBody2D.velocity.y);

        //gets a number between -1 and 1 for both horizontal and vertical axis
        this._move = Input.GetAxis("Horizontal");
        this._jump = Input.GetAxis("Vertical");


        //Ensure the player is grounded bwfoew any movement
        if (this._isGrounded)
        {
            if (this._move != 0)
            {
                if (this._move > 0)
                {
                    //Movement Force
                    if (absVelX < this.velocityRange.maximum)
                    {
                        forceX = this.moveForce;
                    }

                    this._facingRight = true;
                    this._flip();
                }
                if (this._move < 0)
                {
                    //Movement Force
                    if (absVelX < this.velocityRange.maximum)
                    {
                        forceX = -this.moveForce;
                    }
                    this._facingRight = false;
                    this._flip();
                }
                //playing the running animation clip
                this._anim.SetInteger("AnimState", 1);
            }
            else
            {

                //setting the default animation
                this._anim.SetInteger("AnimState", 0);
            }
            if (this._jump > 0)
            {
                //Jump Force
                if (absVelY < this.velocityRange.maximum)
                {
                    forceY = this.jumpForce;
                }
            }
        }
        else
        {
            //playing the jump animation clip
            this._anim.SetInteger("AnimState", 2);
        }

       // Debug.Log(forceX);
        this._rigidBody2D.AddForce(new Vector2(forceX, forceY));

        if(this._transform.position.x < -402)
        {
            this.camera.position = new Vector3(-254.9157f, -56.41403f, -10);
        }
        if (this._transform.position.x < -908.4078f)
        {
            this._transform.position = new Vector2(-908.4078f, -256.414f);
        }
	}

    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            
            this._spawn();
            this.gameController.LivesValues--;
        }
    }

    //PRIVATE METHODS

    //Flips the player object on X-Axis
    private void _flip()
    {
        if (this._facingRight)
        {
            this._transform.localScale = new Vector2(1, 1);
        }
        else
        {
            this._transform.localScale = new Vector2(-1, 1);
        }
    }

    private void _spawn()
    {

        this._transform.position = new Vector3(-402, -256, 0);
        this._facingRight = true;
    }
}
