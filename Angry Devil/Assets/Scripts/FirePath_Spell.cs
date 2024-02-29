using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePath_Spell : Spell
{
    public float damageFrequency;
    public int damageRepetitions;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Enemies")
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                StartCoroutine(DamageRoutine(health));
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
