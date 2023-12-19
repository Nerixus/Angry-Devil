using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    public Health health;

    public void Start()
    {
        if (health == null)
            health = GetComponent<Health>();
    }
}
