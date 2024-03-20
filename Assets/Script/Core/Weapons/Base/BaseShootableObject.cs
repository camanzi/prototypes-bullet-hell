using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShootableObject : MonoBehaviour, IShootable
{

    public float speed = 20f;

    public float damage = 0.5f;

    private void Update()
    {
        move(transform.up, speed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        HealthController healthController = collision.gameObject.GetComponent<HealthController>();
        healthController?.takeDamage(damage);
        Object.Destroy(gameObject);
    }

    public void move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
