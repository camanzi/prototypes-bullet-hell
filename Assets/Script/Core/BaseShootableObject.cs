using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShootableObject : MonoBehaviour, IShootable
{

    public float speed = 20f;

    private void Update()
    {
        move(transform.up, speed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Object.Destroy(gameObject);
    }

    public void move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
