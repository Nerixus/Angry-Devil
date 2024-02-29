using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Unit : Moving_Unit
{
    Player_Unit target;
    public Animator animatorComponent;
    public float attackRange;
    public State state;
    public AnimationClip attackAnimation;

    bool attacking = false;
    
    void Start()
    {
        if (animatorComponent == null)
            animatorComponent = GetComponentInChildren<Animator>();
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
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
        if (!attacking)
        {
            attacking = true;
            animatorComponent.SetBool("moving", false);
            animatorComponent.SetBool("attacking", true);
            StartCoroutine(Attacking());
        }
        else
        {
            if (!IsTargetWithinAttackDistance())
            {
                state = State.MOVING;
                attacking = false;
                animatorComponent.SetBool("moving", true);
                animatorComponent.SetBool("attacking", false);
            }
        }
    }

    IEnumerator Attacking()
    {
        while (attacking)
        {
            yield return new WaitForSeconds(attackAnimation.length);
        }
        yield return null;
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

    }
}
