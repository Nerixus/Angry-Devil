using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Unit : Unit
{
    public float moveSpeed;
    public void Start()
    {
        base.Start();
    }

    public virtual void MoveUnit(Vector3 moveVector)
    {
        transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
    }
}