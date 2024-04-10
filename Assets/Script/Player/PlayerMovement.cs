using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 20f;
    private bool canMove = true;

    private HealthController healthController;
    private Rigidbody2D rb;

    private bool isDashing = false;
    public float dashBoost = 10;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    public string invunerabilityLayer;

    private void Awake()
    {
        InputManager.InputSystem.GamePlay.Dash.performed += dash;
    }

    private void Start()
    {
        healthController = GetComponent<HealthController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rotate(InputManager.rotateInput());
    }

    private void FixedUpdate()
    {
        if (canMove)
        { 
            move(InputManager.movementInput());
        }
    }

    private void move(Vector2 direction)
    {
        rb.velocity = direction * movementSpeed;
    }

    private void rotate(Vector2 direction)
    {
        direction = Input.mousePosition;

        Vector3 targetDirection = new Vector3(direction.x, direction.y, 0);
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(transform.position);

        targetDirection.x -= playerPosition.x;
        targetDirection.y -= playerPosition.y;

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private void dash(InputAction.CallbackContext context)
    {
        if (!isDashing) 
        {
            StartCoroutine(dashCorouting(InputManager.movementInput()));
        }
    }

    private IEnumerator dashCorouting(Vector2 direction) 
    {
        isDashing = true;
        healthController.isImmune = true;
        canMove = false;

        int previusLayer = gameObject.layer;
        gameObject.layer = LayerMask.NameToLayer(invunerabilityLayer);

        if (direction == Vector2.zero)
        {
            direction = Vector2.up;
        }

        rb.AddForce(new Vector2(direction.x , direction.y) * (dashBoost / dashDuration), ForceMode2D.Impulse);

        yield return new WaitForSeconds(dashDuration);
        canMove = true;

        gameObject.layer = previusLayer;

        yield return new WaitForSeconds(dashCooldown - dashDuration);
        healthController.isImmune = false;
        isDashing = false;
    }
}
