using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {
    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Animator _anim;
    private float _move;
    private float _jump;
    private bool _facingRight;

	// Use this for initialization
	void Start () {
        this._transform = gameObject.GetComponent<Transform>();
        this._anim = gameObject.GetComponent<Animator>();
        this._move = 0f;
        this._jump = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        
        this._move = Input.GetAxis("Horizontal");
        this._jump = Input.GetAxis("Vertical");
        if(this._move != 0)
        {
            if(this._move > 0)
            {
                this._facingRight = true;
                this._flip();
            }
            if (this._move < 0)
            {
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

        if(this._jump > 0)
        {
            //playing the jump animation clip
            this._anim.SetInteger("AnimState", 2);
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
}
