using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public List<UnitPool> enemyPools;
    public Unit enemyBoss;
    public Transform[] spawners;
    int maxEnemies = 100;
    int currentEnemies = 0;
    float createInterval = 5;
    float minimalInterval = 0.5f;
    Unit playerUnit;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void StartEnemyCreation()
    {
        StartCoroutine(EnemyCreationRoutine());
    }

    IEnumerator EnemyCreationRoutine()
    {
        while (playerUnit == null)
        {
            playerUnit = GameManager.Instance.GetPlayerUnit();
            yield return null;
        }
        while (playerUnit != null && playerUnit.enabled)
        {
            if (currentEnemies < maxEnemies)
            {
                CreateEnemy();
                yield return new WaitForSeconds(createInterval);
                if (createInterval > minimalInterval)
                    createInterval = createInterval * .95f;
            }
        }
    }

    void CreateEnemy()
    {
        int randSpawn = Random.Range(0, spawners.Length);
        int randEnemy = Random.Range(0, enemyPools.Count);
        Unit newEnemy = enemyPools[randEnemy].GetPoolUnit();
        newEnemy.transform.position = spawners[randSpawn].position;
        newEnemy.transform.rotation = Quaternion.identity;
        newEnemy.transform.parent = transform;
    }


}
