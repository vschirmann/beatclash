using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public MergeBehaviour MergeBehaviour;
    void Start()
    {
    }

    public void OnFirstLaneHit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("[FirstLane] Tap started");
        }
        else if (context.canceled)
        {
            Debug.Log("[FirstLane] Tap canceled");
        }
    }

    public void OnSecondLaneHit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("[SecondLane] Tap started");
        }
        else if (context.canceled)
        {
            Debug.Log("[SecondLane] Tap canceled");
        }
    }
}
