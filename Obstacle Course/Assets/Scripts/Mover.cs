using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    private Vector2 currentMovement = Vector2.zero;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movementAmount = currentMovement * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(movementAmount.x, 0f, movementAmount.y));
    }

    private void OnMove(InputValue value)
    {
        currentMovement = value.Get<Vector2>();
    }
}
