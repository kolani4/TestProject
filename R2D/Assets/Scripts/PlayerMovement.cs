using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controler;
    public Animator animator;

    public float runSpead = 40f;

    float horizontalMove = 1f;

    bool jump = false;
    bool crouch = false;


	// Update is called once per frame
    void Start()
    {

    }
	void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpead;

       

        if (Input.GetButton("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
            
    }

    void FixedUpdate()
    {
        controler.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
