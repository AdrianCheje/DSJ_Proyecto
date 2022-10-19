using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    
    [Header("Movimiento")]
    public float  moveSpeed;

    [Header("Salto")]
    private bool canDoubleJump;
    public float jumpForce;

    [Header("Componentes")]
    public Rigidbody2D theRB;

    [Header("Animator")]
    private Animator anim;
    private SpriteRenderer theSR;

    [Header("Grounded")]
   private bool isGrounded;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private  void Awake() {
        instance=this;
    }

    void Start()
    {
        anim= GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter<=0){

            theRB.velocity =new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        
        isGrounded =Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);
        
       
       if(isGrounded){
           canDoubleJump=true;
       }
       
       
        if(Input.GetButtonDown("Jump")){
            if(isGrounded){
            theRB.velocity =new Vector2(theRB.velocity.x,jumpForce);
            }else
            {
                if (canDoubleJump){
                    theRB.velocity=new Vector2(theRB.velocity.x,jumpForce);
                    canDoubleJump=false;
                }
            }



        }   
    if(theRB.velocity.x<0){
        theSR.flipX=true;
    } else if (theRB.velocity.x>0){
        theSR.flipX=false;
    }
        }
        
     else{
         knockBackCounter-=Time.deltaTime;
         if(!theSR.flipX){
             theRB.velocity=new Vector2(-knockBackForce,theRB.velocity.y);
         }else
         {
             theRB.velocity=new Vector2(knockBackForce,theRB.velocity.y);
         }
     }   
    
    anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
    anim.SetBool("isGrounded", isGrounded);
    }

    public void Knockback()
    {
        knockBackCounter=knockBackLength;
        theRB.velocity=new Vector2(0f,knockBackForce);
    }

}
