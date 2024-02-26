using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Unit : Moving_Unit
{
    Player_Unit target;
    public Animator animatorComponent;
    // Start is called before the first frame update
    void Start()
    {
        if (animatorComponent == null)
            animatorComponent = GetComponentInChildren<Animator>();
        animatorComponent.speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            GetPlayerUnit();
        }
        else
        {
            if (animatorComponent.GetBool("moving") == false)
            {
                animatorComponent.SetBool("moving", true);
            }
            MoveUnit(target.transform.position);
        }
    }

    public override void MoveUnit(Vector3 moveVector)
    {
        transform.position = Vector3.MoveTowards(transform.position, moveVector, moveSpeed * Time.deltaTime);
        Vector3 lookRotation = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(lookRotation);
    }

    void GetPlayerUnit()
    {
        target = GameManager.Instance.GetPlayerUnit();
    }
}
