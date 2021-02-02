using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    // constants
    const float HOLD_THRESHOLD = 0.15f; // threshold of time (in seconds) after which we consider mouse click/touch to be a "hold" instead of click

    // component and object references (linked through inspector)
    public Camera mainCam;
    
    // class variables
    float mouseHoldDuration = 0f; // how long its been since we were holding the mouse/touch (to determine hold vs click)
    bool startFollowing = false; // a flag to determin whether or not we pushed the mouse/touch down to start following and orbiting the camera
    Vector3 lastMousePos; // last stored mouse/touch position
    float rotationScale = 0.1f; // scale factor to convert screen size to rotation
    float rotationY = 0f; // to keep track of up-down rotation

    // Update is called once per frame
    void Update () {
        if (Input.touchSupported)
        {
            // use touch input
        }
        else
        {
            // use mouse input
            if (Input.GetMouseButtonDown(0))
            {
                startFollowing = true;
                lastMousePos = Input.mousePosition;
                mouseHoldDuration = 0;
            }
            if (Input.GetMouseButtonUp(0))
            {
                startFollowing = false;
                //// was this a click and not a hold/drag?
                //if (mouseHoldDuration < HOLD_THRESHOLD)
                //    ClickHandler(Input.mousePosition);
            }
        }

        // rotate screen
        if (startFollowing)
        {
            mouseHoldDuration += Time.deltaTime;
            if (mouseHoldDuration >= HOLD_THRESHOLD)
            {
                var delta = rotationScale * (Input.mousePosition - lastMousePos);
                float rotationX = transform.localEulerAngles.y + delta.x;
                rotationY += delta.y;
                rotationY = Mathf.Clamp(rotationY, -89.9f, 89.9f);
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            lastMousePos = Input.mousePosition;
        }
    }
    
}
