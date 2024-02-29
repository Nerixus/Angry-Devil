using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public float duration;
    public float damage;

    public virtual void Start()
    {
        Destroy(gameObject, duration);
    }
}
