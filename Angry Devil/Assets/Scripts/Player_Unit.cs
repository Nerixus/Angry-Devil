using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Unit : Moving_Unit
{
    public float damage;
    public Transform playerObject;
    public float turnSpeed = 10f;
    public bool isPlayerAlive = true;

    private void Start()
    {
        base.Start();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(horizontal != 0 || vertical != 0)
            MoveUnit(new Vector3(horizontal, 0, vertical));
    }

    public override void MoveUnit(Vector3 moveVector)
    {
        if (Input.GetKey(KeyCode.LeftShift))
            moveVector = moveVector * 1.5f;
        base.MoveUnit(moveVector);
        if(moveVector.magnitude >= 0.1f)
            RotatePlayer(moveVector);
    }

    private void RotatePlayer(Vector3 v_moveVector)
    {
        playerObject.rotation = Quaternion.Slerp(
                playerObject.rotation,
                Quaternion.LookRotation(v_moveVector),
                Time.deltaTime * turnSpeed
        );
    }
    public override void DealDamage(Unit target)
    {
        target.health.Damage(new DamageInfo(damage));
    }
}
