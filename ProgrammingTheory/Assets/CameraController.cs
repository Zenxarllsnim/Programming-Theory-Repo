using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     [Header("Settings")]
    [SerializeField] private Transform target;    // Drag your player to this slot in the inspector.
    [SerializeField] private float smoothing;     //  Set smoothing in inspector aswell.

    private Camera cam;
    private BoxCollider2D boundBox;
    private Vector2 maximumBounds;
    private Vector2 minimumBounds;
    private float halfHeight;
    private float halfWidth;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        targetPosition.x = Mathf.Clamp(targetPosition.x, minimumBounds.x + halfWidth, maximumBounds.x - halfWidth);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minimumBounds.y + halfHeight, maximumBounds.y - halfHeight);
        if (transform.position != targetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }

    
    // Made this a Coroutine to get that freeze-time effect from A Link to the past.
    // Also, have almost a full cell gap between the triggers to prevent the player from being able to run back and forth between the triggers and glitch the camera. 
    // Haven't been able to reproduce that bug after I did this.
    public IEnumerator SetBounds(BoxCollider2D bounds)
    {
        boundBox = bounds;
        minimumBounds = boundBox.bounds.min;
        maximumBounds = boundBox.bounds.max;
        Vector2 direction = (target.position - transform.position).normalized;
        target.Translate(direction, Space.World);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1;
    }
}
