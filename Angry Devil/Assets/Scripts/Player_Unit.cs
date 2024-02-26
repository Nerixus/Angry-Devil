using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Unit : Moving_Unit
{
    public float damage;

    private void Start()
    {
        base.Start();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        MoveUnit(new Vector3(horizontal, 0, vertical));
    }

    public override void MoveUnit(Vector3 moveVector)
    {
        if (Input.GetKey(KeyCode.LeftShift))
            moveVector = moveVector * 1.5f;
        base.MoveUnit(moveVector);
    }
    public override void DealDamage(Unit target)
    {
        target.health.Damage(new Health.DamageInfo(damage));
    }
}
