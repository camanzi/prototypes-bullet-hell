using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 20;
    private void Update()
    {
        Move(InputManager.MovementInput().normalized);
    }

    public void Move(Vector2 direction)
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * movementSpeed * Time.deltaTime;
    }
}
