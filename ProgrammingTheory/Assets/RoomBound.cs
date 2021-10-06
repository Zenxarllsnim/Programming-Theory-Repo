using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBound : MonoBehaviour
{
    // Start is called before the first frame update
    // Here's my script for the empty objects with the colliders:

    private BoxCollider2D bounds;
    private CameraController cam;    //     <----    Obviously you'll have to reference your own camera script if it's named different from mine.

    private void Start()
    {
        bounds = GetComponent<BoxCollider2D>();
        cam = FindObjectOfType<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(cam.SetBounds(bounds));
        }
    }

}
