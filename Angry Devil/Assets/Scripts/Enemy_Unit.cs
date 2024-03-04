using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_Unit : Moving_Unit
{
    Player_Unit target;
    public Animator animatorComponent;
    public float attackRange;
    public State state;
    public AnimationClip attackAnimation;
    public float attackFrequency;
    public float damage;
    float lastAttackTime;

    bool attacking = false;
    public static event Action OnDisabled;


    public override void OnEnable()
    {
        base.OnEnable();
        if (animatorComponent == null)
            animatorComponent = GetComponentInChildren<Animator>();
        StartCoroutine(Spawn());
        lastAttackTime = Time.time;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        OnDisabled?.Invoke();
    }

    // Update is called once per frame
    public override void Start()
    {
        base.Start();
    }

    IEnumerator Spawn()
    {
        state = State.SPAWNING;
        yield return new WaitForSeconds(1f);
        if (target == null)
            GetPlayerUnit();
        state = State.MOVING;
        animatorComponent.SetBool("moving", true);
        animatorComponent.SetBool("attacking", false);
        StartCoroutine(StateCheck());
    }

    IEnumerator StateCheck()
    {
        while (target != null)
        {
            if (!target.isActiveAndEnabled)
                break;
            StateMachine();
            yield return null;
        }
        Debug.Log("Character died");
        StopAllCoroutines();
        state = State.IDLE;
        animatorComponent.SetBool("moving", false);
        animatorComponent.SetBool("attacking", false);
        animatorComponent.SetBool("idle", true);
    }
    void StateMachine()
    {
        if (state != State.SPAWNING)
        {
            switch (state)
            {
                case State.MOVING:
                    MoveUnit(target.transform.position);
                    break;
                case State.ATTACKING:
                    Attack();
                    break;
                case State.DYING:
                    break;
            }
        }
    }

    public override void MoveUnit(Vector3 moveVector)
    {
        
        transform.position = Vector3.MoveTowards(transform.position, moveVector, moveSpeed * Time.deltaTime);
        Vector3 lookRotation = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(lookRotation);
        if(IsTargetWithinAttackDistance())
            state = State.ATTACKING;
    }

    public void Attack()
    {
        if (lastAttackTime <= Time.time && !attacking)
        {
            lastAttackTime = Time.time + attackFrequency;
            DealDamage(target);
        }
    }

    public override void DealDamage(Unit target)
    {
        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        attacking = true;
        animatorComponent.SetBool("moving", false);
        animatorComponent.SetBool("attacking", true);
        yield return new WaitForSeconds(attackFrequency * .5f);
        target.health.Damage(new DamageInfo(damage));
        yield return new WaitForSeconds(attackFrequency * .5f);
        animatorComponent.SetBool("moving", true);
        animatorComponent.SetBool("attacking", false);
        if (!IsTargetWithinAttackDistance())
        {
            state = State.MOVING;
            attacking = false;
            animatorComponent.SetBool("moving", true);
            animatorComponent.SetBool("attacking", false);
        }
        attacking = false;
    }
    void GetPlayerUnit()
    {
        target = GameManager.Instance.GetPlayerUnit();
    }

    private bool IsTargetWithinAttackDistance()
    {
        return Vector3.Distance(transform.position, target.transform.position) <= attackRange;
    }

    public override void ResetUnit()
    {
        base.ResetUnit();
        state = State.SPAWNING;
        StopAllCoroutines();
    }
}
