using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPool : MonoBehaviour
{
    public GameObject unitPrefab;
    Queue<Unit> pool = new Queue<Unit>();

    public Unit GetPoolUnit()
    {
        if (pool.Count > 0)
        {
            return pool.Dequeue();
        }
        else
        {
            GameObject newUnit = Instantiate(unitPrefab);
            Unit newUnitComponent = newUnit.GetComponent<Unit>();
            newUnitComponent.Pool = this;
            return newUnitComponent;
        }
    }

    public void ReturnToPool(Unit v_returningUnit)
    {
        pool.Enqueue(v_returningUnit);
    }
}
