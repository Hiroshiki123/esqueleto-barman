using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float Speed;
    private Rigidbody rig;

    public float JumpForce;
    public float dJumpForce;
    

    public bool isJumping;
    public bool doubleJump;
    


    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Cursor.lockState=CursorLockMode.Locked;
    }

    void Move()
    {
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    movement = transform.localRotation * movement;
    transform.localPosition += movement*Time.deltaTime * Speed;
    
    }
     private void FixedUpdate()
    {
       

        if (Input.GetKey(KeyCode.LeftShift)) {
            Speed = 10;
        }
        else
        {
            Speed = 5;
        }
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector3(0f,JumpForce,0f),ForceMode.Impulse);
                doubleJump = false;
            }
            else
            {
                if(!doubleJump)
                {
                rig.AddForce(new Vector3(0f,dJumpForce,0f), ForceMode.Impulse);  
                doubleJump = true;                 
                }
            }
            
        }

    }

    void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
        }
        
    }
    void OnCollisionExit (Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
    
    

}
