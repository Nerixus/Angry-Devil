using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public List<UnitPool> enemyPools;
    public Unit enemyBoss;
    public Transform[] spawners;

    public void CreateEnemy()
    {
        int randSpawn = Random.Range(0, spawners.Length);
        int randEnemy = Random.Range(0, enemyPools.Count);
        Unit newEnemy = enemyPools[randEnemy].GetPoolUnit();
        newEnemy.transform.position = spawners[randSpawn].position;
        newEnemy.transform.rotation = Quaternion.identity;
        newEnemy.transform.parent = transform;
    }


}
