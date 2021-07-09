using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorPosition : MonoBehaviour
{

    public Vector2 mousePosition;
    public Camera cam;

    private void FixedUpdate()
    {
        transform.position = mousePosition;
    }

    void OnMousePosition(InputValue value)
    {
        mousePosition = cam.ScreenToWorldPoint(value.Get<Vector2>());
    }

}
