using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    SolarSystemHover lastHover = null;

    public bool raycastUI;
    public GraphicRaycaster graphicRaycaster;
    ButtonHover lastButtonHover;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //lastMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update () {
        if (Input.touchSupported)
        {
            // use touch input
        }
        else
        {
            startFollowing = true;
            // use mouse input
            //if (Input.GetMouseButtonDown(0))
            //{
            //    startFollowing = true;
            //    lastMousePos = Input.mousePosition;
            //    mouseHoldDuration = 0;
            //}
            if (Input.GetMouseButtonUp(0))
            {
                //startFollowing = false;
                //// was this a click and not a hold/drag?
                //if (mouseHoldDuration < HOLD_THRESHOLD)
                //{
                if (raycastUI)
                {
                    Vector3 virtualPos = new Vector3(0.5f, 0.5f, 0);
                    var data = new PointerEventData(EventSystem.current);
                    Ray ray = mainCam.ViewportPointToRay(virtualPos);
                    var screenPoint = mainCam.ViewportToScreenPoint(virtualPos);
                    data.position = new Vector2(screenPoint.x, screenPoint.y);// ray.origin;
                    List<RaycastResult> results = new List<RaycastResult>();
                    graphicRaycaster.Raycast(data, results);
                    LoadListScene loader = null;
                    foreach (var r in results)
                    {
                        loader = r.gameObject.GetComponent<LoadListScene>();
                        if (loader != null) { loader.BeginIsClicked(); }
                    }
                }
                else
                {
                    // raycast from center of screen
                    Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        EventTrigger eventTrgr = hit.collider.gameObject.GetComponent<EventTrigger>();
                        if (eventTrgr != null)
                        {
                            foreach (var e in eventTrgr.triggers)
                            {
                                if (e.eventID == EventTriggerType.PointerClick)
                                {
                                    for (int i = 0; i < e.callback.GetPersistentEventCount(); i++)
                                    {
                                        e.callback.SetPersistentListenerState(i, UnityEngine.Events.UnityEventCallState.RuntimeOnly);
                                        e.callback.Invoke(new BaseEventData(EventSystem.current));
                                        e.callback.SetPersistentListenerState(i, UnityEngine.Events.UnityEventCallState.Off);
                                    }
                                }
                            }
                        }
                    }
                }
                //}
            }
        }

        // rotate screen
        if (startFollowing)
        {
            //mouseHoldDuration += Time.deltaTime;
            //if (mouseHoldDuration >= HOLD_THRESHOLD)
            //{
                //var delta = rotationScale * (Input.mousePosition - lastMousePos);
                //float rotationX = transform.localEulerAngles.y + delta.x;
                //rotationY += delta.y;
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X");
                rotationY += Input.GetAxis("Mouse Y");
                rotationY = Mathf.Clamp(rotationY, -89.9f, 89.9f);
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            if (raycastUI)
            {
                Vector3 virtualPos = new Vector3(0.5f, 0.5f, 0);
                var data = new PointerEventData(EventSystem.current);
                Ray ray = mainCam.ViewportPointToRay(virtualPos);
                var screenPoint = mainCam.ViewportToScreenPoint(virtualPos);
                data.position = new Vector2(screenPoint.x, screenPoint.y);// ray.origin;
                List<RaycastResult> results = new List<RaycastResult>();
                graphicRaycaster.Raycast(data, results);
                //Debug.Log(results.Count);
                bool buttonAvailable = false;
                ButtonHover btn = null;
                foreach (var r in results)
                {
                    btn = r.gameObject.GetComponent<ButtonHover>();
                    if (btn != null)
                    {
                        buttonAvailable = true;
                        break;
                    }
                }

                if (buttonAvailable)
                {
                    if (btn != lastButtonHover)
                    {
                        Debug.Log("Selecting button: " + btn.gameObject.name);
                        btn.buttonImageIn();
                        btn.swichTextColorIn();
                        lastButtonHover = btn;
                    }
                }
                else
                {
                    if (lastButtonHover != null)
                    {
                        Debug.Log("Deselecting button: " + lastButtonHover.gameObject.name);
                        lastButtonHover.buttonImageOut();
                        lastButtonHover.swichTextColorOut();
                        lastButtonHover = null;
                    }
                }
            }
            else
            {
                // raycast from center of screen
                Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject != null)
                    {
                        SolarSystemHover newHover = hit.collider.gameObject.transform.parent.GetComponent<SolarSystemHover>();
                        if (lastHover != null && newHover != lastHover) { lastHover.swichMaterialOut(); }
                        if (newHover != null) { newHover.swichMaterialIn(); }
                        lastHover = newHover;
                    }
                    else
                    {
                        if (lastHover != null) { lastHover.swichMaterialOut(); }
                        lastHover = null;
                    }
                }
                else
                {
                    if (lastHover != null) { lastHover.swichMaterialOut(); }
                    lastHover = null;
                }
            }

            //}
            //lastMousePos = Input.mousePosition;
        }
    }
    
}
