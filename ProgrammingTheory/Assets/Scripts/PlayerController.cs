using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float vertInput;
    public float horInput;
    public float horSpeed = 1f;
    public float vertSpeed = 1f;
    public float xRange = 23;
    public float zRange = 15;
    public float yRange = 10;
    public GameObject projectilePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Will launch projectiles from player.
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        // Don't run off the map, or fall through it in case I fuck something up.
        /*     if (transform.position.x < -xRange )
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }
          if (transform.position.z < -7)
           {
               transform.position = new Vector2(transform.position.x, transform.position.y, -7 );
           }
           if (transform.position.z > zRange)
           {
               transform.position = new Vector2(transform.position.x, transform.position.y, zRange);
           }
        
        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(0, 1);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(0, 1);
        }
        */


        horInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * horInput * Time.deltaTime * horSpeed);
        transform.Translate(Vector2.up * vertInput * Time.deltaTime * vertSpeed);
    }
}
