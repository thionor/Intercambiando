using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        
        bool runPressed = Input.GetKey("left shift");

        // if player is walking to horizontal
        if((!isWalking && moveX != 0)) {
            animator.SetBool("isWalking", true);
        }

          // if player is walking to horizontal
        if((!isWalking && moveZ != 0)) {
            animator.SetBool("isWalking", true);
        }
     
        // if player stop walking
        if((isWalking && (moveX == 0 && moveZ == 0))) {
            animator.SetBool("isWalking", false);
        }

        // if player is running to right
        if(!isRunning && (moveX != 0 && runPressed) ) {
            animator.SetBool("isRunning", true);
        }

         // if player is running to right
        if(!isRunning && (moveZ != 0 && runPressed) ) {
            animator.SetBool("isRunning", true);
        }

        //if player stop running 
        if(isRunning  && (!runPressed || (moveX == 0 &&  moveZ == 0))) {
            animator.SetBool("isRunning", false);
        }
      
    }
}
