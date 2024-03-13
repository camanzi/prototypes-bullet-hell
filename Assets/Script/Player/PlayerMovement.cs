using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 20;
    public LayerMask wallLayer;

    private void Update()
    {
        move(InputManager.movementInput());
        rotate(InputManager.rotateInput());
    }

    public void move(Vector2 direction)
    {
        if (!Physics2D.Raycast(transform.position, direction, 0.7f, wallLayer))
        {
            transform.position += new Vector3(direction.x, direction.y, 0) * movementSpeed * Time.deltaTime;
        }
    }

    public void rotate(Vector2 direction)
    {
        direction = Input.mousePosition;

        Vector3 targetDirection = new Vector3(direction.x, direction.y, 0);
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(transform.position);

        targetDirection.x -= playerPosition.x;
        targetDirection.y -= playerPosition.y;

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
