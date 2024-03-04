using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public float healthMax = 100f;
	private float health = 0f;

	public GameObject hitEffect;

    private void OnEnable()
    {
		health = healthMax;
	}

	public void Damage(DamageInfo damageInfo)
	{
		if (health != -1f)
			health = Mathf.Clamp(health - damageInfo.damage, 0f, healthMax);

		if (health == 0f)
			gameObject.SetActive(false);
	}

	public float HealthValue
	{
		set { health = value; }
		get { return health; }
	}
}

public class DamageInfo
{
	public float damage = 0f;

	public DamageInfo(float _damage)
	{
		damage = _damage;
	}
}