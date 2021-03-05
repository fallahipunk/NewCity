using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerBypass : MonoBehaviour
{
    private void Awake()
    {
        EventTrigger eventTrgr = GetComponent<EventTrigger>();
        if (eventTrgr != null)
        {
            foreach (var e in eventTrgr.triggers)
            {
                for (int i = 0; i < e.callback.GetPersistentEventCount(); i++)
                {
                    e.callback.SetPersistentListenerState(i,UnityEngine.Events.UnityEventCallState.Off);
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
