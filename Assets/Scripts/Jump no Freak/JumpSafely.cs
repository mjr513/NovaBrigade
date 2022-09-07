using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpSafely : MonoBehaviour
{
    public EventSystem events;

    // Update is called once per frame
    void Update()
    {
        events.SetSelectedGameObject(null);
    }
}