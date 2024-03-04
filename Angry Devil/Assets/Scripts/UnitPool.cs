using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPool : MonoBehaviour
{
    public GameObject unitPrefab;
    public Queue<Unit> pool = new Queue<Unit>();

    public Unit GetPoolUnit()
    {
        if (pool.Count > 0)
        {
            Unit poolUnit = pool.Dequeue();
            poolUnit.transform.SetParent(transform);
            poolUnit.gameObject.SetActive(true);
            poolUnit.pool = this;
            return poolUnit;
        }
        else
        {
            GameObject newUnit = Instantiate(unitPrefab);
            newUnit.transform.SetParent(transform);
            Unit newUnitComponent = newUnit.GetComponent<Unit>();
            newUnitComponent.pool = this;
            return newUnitComponent;
        }
    }

    public void ReturnToPool(Unit v_returningUnit)
    {
        pool.Enqueue(v_returningUnit);
    }
}
