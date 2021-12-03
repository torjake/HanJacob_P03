using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    public event Action PressedConfirm = delegate { };
    public event Action PressedCancel = delegate { };
    public event Action PressedLeft = delegate { };
    public event Action PressedRight = delegate { };
    //
    public event Action PressedMouseOne = delegate { };

    void Update()
    {
        DetectConfirm();
        DetectCancel();
        DetectLeft();
        DetectRight();
        DetectMouseOne();
    }
    private void DetectMouseOne() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            PressedMouseOne?.Invoke();
        }
    }
    private void DetectRight() 
    {
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            PressedRight?.Invoke();
        }
    }
    private void DetectLeft() 
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            PressedLeft?.Invoke();
        }
    }
    private void DetectCancel() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            PressedCancel?.Invoke();
        }
    }
    private void DetectConfirm() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            PressedConfirm?.Invoke();
        }
    }
}
