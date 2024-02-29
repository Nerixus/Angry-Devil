using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    public Health health;
    private UnitPool pool;

    public void Start()
    {
        if (health == null)
            health = GetComponent<Health>();
    }

    public UnitPool Pool
    {
        get { return pool; }
        set { pool = value; }
    }

    public virtual void DealDamage(Unit target)
    {
        target.health.Damage(new DamageInfo(10));
    }

    public virtual void ResetUnit()
    {
        pool.ReturnToPool(this);
    }
}

public enum State
{
    SPAWNING,
    MOVING,
    ATTACKING,
    DYING,
    IDLE
}
