using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomBound : MonoBehaviour
{
    // Start is called before the first frame update
    // Here's my script for the empty objects with the colliders:

    private BoxCollider2D bounds;
    private CameraController cam;    //     <----    Obviously you'll have to reference your own camera script if it's named different from mine.
    private bool flip = false;
    private IEnumerator coroutine;
    public bool needText = true;
    public string placeName;
    public GameObject text;
    public Text placeText;

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


            
                if (needText)
                {
                    if (coroutine != null)
                    {
                        StopCoroutine(coroutine);
                    }
                    coroutine = placeNameCo();
                    StartCoroutine(coroutine);

                }
                    
            
        }
    }
    private IEnumerator placeNameCo()
    {

        text.SetActive(true);
        placeText.text = placeName;
        placeText.CrossFadeAlpha(0, 3.5f, false);
        // Adds fade to text
        flip = true;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
        
    }
}
