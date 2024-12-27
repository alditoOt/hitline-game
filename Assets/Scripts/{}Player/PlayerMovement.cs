using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region movement
    public Vector2 move;
    public float moveSpeed = 5f;
    public float angleDiscrepancy = 90f;
    #endregion

    public static Vector2 mousePosition;
    public static Vector3 mousePosition3;
    public Camera cam;

    #region components
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerDead deadScript;
    private Transform transform;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        deadScript = GetComponent<PlayerDead>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!deadScript.dead)
        {
            DoMove();
            LookToMouse();
        }
    }

    #region movement
    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    void OnMousePosition(InputValue value)
    {
        mousePosition3 = Camera.main.ScreenToWorldPoint(new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y, Camera.main.nearClipPlane));   
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
        // Vector2 lookDir = mousePosition - new Vector2(transform.position.x, transform.position.y);
        // float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - angleDiscrepancy;
        // rb.rotation = angle;
       Vector3 direction = mousePosition3 - transform.position;
       float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - angleDiscrepancy;
       transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
       Debug.DrawLine(transform.position, mousePosition3, Color.red);
    }
}
