using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region movement
    public Vector2 move;
    public float moveSpeed = 5f;
    #endregion

    public Vector2 mousePosition;
    public Camera cam;

    #region components
    private Rigidbody2D rb;
    private Animator anim;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DoMove();
        LookToMouse();
    }

    #region movement
    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    void OnMousePosition(InputValue value)
    {
        mousePosition = cam.ScreenToWorldPoint(value.Get<Vector2>());
    }
    void DoMove()
    {
        rb.velocity = new Vector2(move.x * moveSpeed, move.y * moveSpeed);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
    }

    #endregion

    void LookToMouse()
    {
        Vector2 lookDir = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
