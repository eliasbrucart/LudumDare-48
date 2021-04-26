using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float speed;

    public Animator PlayerAnimator;
    bool isIdle;
    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        isIdle = true;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isIdle = false;
            PlayerAnimator.SetBool("GoingRight", true);
            PlayerAnimator.SetBool("GoingIdle", false);
            PlayerAnimator.SetBool("GoingDown", false);
            PlayerAnimator.SetBool("GoingLeft", false);
            PlayerAnimator.SetBool("GoingUp", false);
            transform.position += Vector3.right * speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isIdle = false;
            PlayerAnimator.SetBool("GoingLeft", true);
            PlayerAnimator.SetBool("GoingRight", false);
            PlayerAnimator.SetBool("GoingIdle", false);
            PlayerAnimator.SetBool("GoingDown", false);
            PlayerAnimator.SetBool("GoingUp", false);
            transform.position += Vector3.left * speed * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            isIdle = false;
            PlayerAnimator.SetBool("GoingUp", true);
            PlayerAnimator.SetBool("GoingIdle", false);
            PlayerAnimator.SetBool("GoingRight", false);
            PlayerAnimator.SetBool("GoingDown", false);
            PlayerAnimator.SetBool("GoingLeft", false);
            transform.position += Vector3.up * speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isIdle = false;
            PlayerAnimator.SetBool("GoingDown", true);
            PlayerAnimator.SetBool("GoingIdle", false);
            PlayerAnimator.SetBool("GoingRight", false);
            PlayerAnimator.SetBool("GoingLeft", false);
            PlayerAnimator.SetBool("GoingUp", false);
            transform.position += Vector3.down * speed * Time.fixedDeltaTime;
        }
        if(isIdle == true)
        {
            PlayerAnimator.SetBool("GoingIdle", true);
            PlayerAnimator.SetBool("GoingRight", false);
            PlayerAnimator.SetBool("GoingDown", false);
            PlayerAnimator.SetBool("GoingLeft", false);
            PlayerAnimator.SetBool("GoingUp", false);
        }
    }
}
