using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SSC_movement : MonoBehaviour
{

    //movment varibles
    public float MaxMoveSpeed = 1.0f;
    float moveMultiplyer = 0;
    public float maxVelocity = 100;

    public bool active = true;
    // character body
    Rigidbody2D rb;

    //animation controller
    Animator AController;

    PlayerInput input;

    public void OnMove(InputAction.CallbackContext context)
    {
        // read the value for the "move" action each event call
        moveMultiplyer = context.ReadValue<Vector2>().x;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AController = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        //AController.SetBool("skipIntro", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void FixedUpdate()
    {
        if (active)
        {
            //sets the animation
            if (moveMultiplyer > 0.25)
            {
            AController.SetFloat("movmentDirection", 1);
            AController.SetBool("Moving", true);

            }else if(moveMultiplyer < -0.25)
            {
            AController.SetFloat("movmentDirection",-1);
            AController.SetBool("Moving", true);

            }
            else
            {
            AController.SetBool("Moving", false);
            }

        
            Vector2 movement = new Vector2(moveMultiplyer * MaxMoveSpeed, 0);
            //Debug.Log(movement);
            rb.AddForce(movement, ForceMode2D.Impulse);
        }

    }

    public void activeInput()
    {
        input.ActivateInput();
        Debug.Log("activating input");
    }

    public void deactiveInput()
    {
        input.DeactivateInput();
        Debug.Log("Deactivating input");

    }

}
