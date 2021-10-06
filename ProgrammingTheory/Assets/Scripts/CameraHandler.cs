using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public Transform lookAt;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != lookAt.position)
        {
            Vector3 targetPosition = new Vector3(lookAt.position.x, lookAt.position.y, -10);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
