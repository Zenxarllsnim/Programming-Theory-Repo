using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector3 playerChange;
    public Vector2 cameraChange;
    private CameraHandler cam;
    public bool needText = true;
    public string placeName;
    public GameObject text;
    public Text placeText;


    // Start is called before the first frame update
    void Start()
    {
       
        cam = Camera.main.GetComponent<CameraHandler>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("What?!");
        if (collision.CompareTag("Player")) {
         
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            collision.transform.position += playerChange;


                    if (needText == true)
                     {
            Debug.Log("why the fuck isn't this working?");
            StartCoroutine(placeNameCo());
                     }

        }
    }
    private IEnumerator placeNameCo()
    {

        text.SetActive(true);
        placeText.text = placeName;
        placeText.CrossFadeAlpha(0, 3.5f, false);
        // Adds fade to text
        yield return new WaitForSeconds(4f);
        text.SetActive(false);

    }
}
