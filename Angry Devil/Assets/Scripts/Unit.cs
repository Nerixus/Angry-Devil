using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    public Health health;
    public UnitPool pool;

    public static event Action OnUnitActivated;
    public static event Action OnUnitDeactivated;

    public virtual void OnEnable()
    {
        if (health == null)
            health = GetComponent<Health>();
        OnUnitActivated?.Invoke();
    }

    public virtual void OnDisable()
    {
        ResetUnit();
        OnUnitDeactivated?.Invoke();
    }

    public virtual void DealDamage(Unit target)
    {
        target.health.Damage(new DamageInfo(10));
    }

    public virtual void ResetUnit()
    {
        if(pool != null)
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
