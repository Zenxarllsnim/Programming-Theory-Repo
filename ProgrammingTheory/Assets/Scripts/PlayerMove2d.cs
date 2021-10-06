using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2d : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public float speed = 5.0f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {


        if (change != Vector3.zero)
        {
            MoveChar();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else {
            animator.SetBool("moving", false);

        }
        
    }

    void MoveChar()
    {
        myRigidbody.MovePosition(transform.position + change.normalized * speed * Time.fixedDeltaTime);
    }
}
