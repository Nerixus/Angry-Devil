using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePath_Spell : Spell
{
    public float damageFrequency;
    public int damageRepetitions;
    public int maxUses;
    int uses;

    private void OnTriggerEnter(Collider other)
    {
        if (uses == maxUses)
            return;
        Debug.Log(other.name);
        if (other.tag == "Enemies")
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                StartCoroutine(DamageRoutine(health));
                uses++;
            }
        }
    }

    IEnumerator DamageRoutine(Health v_health)
    {
        for (int i = 0; i < damageRepetitions; i++)
        {
            v_health.Damage(new DamageInfo(damage));
            yield return new WaitForSeconds(damageFrequency);
        }
    }
}
