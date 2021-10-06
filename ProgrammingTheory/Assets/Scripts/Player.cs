using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    public float speed = 5;
    private RaycastHit2D hit;
    

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();    
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        // Reset moveDelta
        moveDelta = new Vector3(x, y, 0);
        // Swap Sprite direction
       
    }
    private void Update()
    {
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        MoveChar();
    }

    private void MoveChar()
    {
       

        //Make sure we can move in this direction by casting a box there, first. If the box returns a null, free to move.

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Move this crap
            transform.Translate(0, moveDelta.y * speed * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Move this crap
            transform.Translate(moveDelta.x * speed * Time.deltaTime, 0, 0);
        }
    }
}
