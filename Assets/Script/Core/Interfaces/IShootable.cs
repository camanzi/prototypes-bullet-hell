using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    public void move(Vector3 direction, float speed);

    public void OnCollisionEnter2D(Collision2D collision);
}
