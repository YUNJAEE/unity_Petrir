using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fSpeed;
    public float fStrafeSpeed;
    public float fJumpForce;
    public bool isGrounded;
    public bool isRunning;

    public Rigidbody rigidbody_Hips;
    public Animator animator;

    void Start()
    {
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", true);
                isRunning = true;
                rigidbody_Hips.AddForce(rigidbody_Hips.transform.forward * fSpeed * 1.5f);
            }
            else
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isWalk", true);
                rigidbody_Hips.AddForce(rigidbody_Hips.transform.forward * fSpeed);
            }
        }
        else
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
            isRunning = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isLeft", true);
            rigidbody_Hips.AddForce(-rigidbody_Hips.transform.right * fStrafeSpeed);
        }
        else
        {
            animator.SetBool("isLeft", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalk", true);
            rigidbody_Hips.AddForce(-rigidbody_Hips.transform.forward * fSpeed);
        }
        else if(!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalk", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRight", true);
            rigidbody_Hips.AddForce(rigidbody_Hips.transform.right * fStrafeSpeed);
        }
        else
        {
            animator.SetBool("isRight", false);
        }

        if (Input.GetAxis("Jump") > 0)
        {
            Debug.Log("테스트1");
            if (isGrounded)
            {
                Debug.Log("테스트2");
                rigidbody_Hips.AddForce(new Vector3(0, fJumpForce, 0));
                isGrounded = false;
            }
        }
    }
}
