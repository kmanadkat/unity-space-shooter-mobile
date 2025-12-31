using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour {

    private Camera mainCamera;
    private Vector3 touchPlayerOffset;

    private float maxLeft;
    private float maxRight;
    private float maxUp;
    private float maxDown;

    void Start() {
        mainCamera = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    void Update() {
        if (Touch.activeTouches.Count != 0) {
            // Get Touch Position
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPosition = myTouch.screenPosition;

            // Screen to World Position
            touchPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            // Calculate Distance between touch and player when touch just began
            if (Touch.activeTouches[0].phase.Equals(TouchPhase.Began)) {
                touchPlayerOffset = touchPosition - transform.position;
            }

            // Update Player Position
            if (Touch.activeTouches[0].phase.Equals(TouchPhase.Moved)) {
                float newPositionX = touchPosition.x - touchPlayerOffset.x;
                float newPositionY = touchPosition.y - touchPlayerOffset.y;
                transform.position = new Vector3(newPositionX, newPositionY, 0);
            }

            // Restrict Movement inside World
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, maxLeft, maxRight),
                Mathf.Clamp(transform.position.y, maxDown, maxUp),
                0
            );
        }
    }

    private void OnEnable() {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable() {
        EnhancedTouchSupport.Disable();
    }

    private IEnumerator SetBoundaries() {
        // do something or nothing
        yield return new WaitForSeconds(0.4f);

        maxLeft = mainCamera.ViewportToWorldPoint(new Vector2(0f, 0f)).x;
        maxRight = mainCamera.ViewportToWorldPoint(new Vector2(1f, 0f)).x;
        maxUp = mainCamera.ViewportToWorldPoint(new Vector2(0f, 0.85f)).y;
        maxDown = mainCamera.ViewportToWorldPoint(new Vector2(0f, 0.05f)).y;
    }
}
