using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private Vector2 movement;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Rigidbody2D rb;

    [Header("Border")]
    [SerializeField] private GameObject topWall;
    [SerializeField] private GameObject bottomWall;
    [SerializeField] private Vector3 topWallLimit;
    [SerializeField] private Vector3 bottomWallLimit;
    void Start()
    {
        topWallLimit = topWall.transform.position;
        bottomWallLimit = bottomWall.transform.position;
    }

    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);

        if((transform.position.y >= topWallLimit.y && movement.y == 1 ) || (transform.position.y <= bottomWallLimit.y && movement.y == -1))
        {
            currentSpeed = 0;
        }
        else
        {
            currentSpeed = speed;
        }
    }
}
