using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public float healthMax = 100f;
	private float health = 0f;

	public GameObject hitEffect;

	public class DamageInfo
	{
		public float damage = 0f;

		public DamageInfo(float _damage)
		{
			damage = _damage;
		}
	}

	// Use this for initialization
	void Start()
	{
		health = healthMax;
	}

	public void Damage(DamageInfo damageInfo)
	{
		if (health != -1f)
			health = Mathf.Clamp(health - damageInfo.damage, 0f, healthMax);

		if (health == 0f)
			Destroy(gameObject);
	}

	public float CurrentHealth
	{
		get { return health; }
	}
}
