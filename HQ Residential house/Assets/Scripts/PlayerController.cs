using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;


    [SerializeField] private float jumpHeight;


    //REFERENCES
    private CharacterController controller;
    private Animator Animator;

  

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Animator = GetComponentInChildren<Animator>(); //Animator ta Player er vitorer child Toon_RTS e nibo


    }

    // Update is called once per frame
    private void Update()
    {
        Move();
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

     
        if (isGrounded && velocity.y < 0) //stops applying gravity when we are grounded
        {
            velocity.y = -2f;
        }

        if(!isGrounded)
        {
            Animator.SetBool("Jump",true);
        }
        else
        {
            Animator.SetBool("Jump", false);
        }
    
    

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection); // jedike move korbe setai amr player er direction hoye jabe
                                                                     //Local will be used       
            if (isGrounded)
            {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {

                Walk();
                Debug.Log("Walk");
            }
             else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {

                Run();
                Debug.Log("Run");
            }

            else if (moveDirection == Vector3.zero)
            {

                Idle();
                Debug.Log("Idle");
            }

            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
          
        }


      

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



    }

    private void Idle()
    {
        Animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
    private void Walk()
    {
        moveSpeed = walkSpeed;
        Animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }
    private void Run()
    {
        moveSpeed = runSpeed;
        Animator.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void Attack()
    {
        Animator.SetTrigger("Attack");
    }

}
