using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : StaticInstance<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;
    public CinemachineVirtualCamera cameraController;
    [Header("Enemies")]
    public GameObject[] enemyPrefabs;
    public Transform[] spawners;

    Player_Unit currentPlayer;

    private void Start()
    {
        JumpstartGame();   
    }

    void JumpstartGame()
    {
        GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, transform);
        currentPlayer = newPlayer.GetComponent<Player_Unit>();
        cameraController.Follow = newPlayer.transform;
        cameraController.LookAt = newPlayer.transform;
        CreateEnemy();
    }    

    void CreateEnemy()
    {
        int randSpawn = Random.Range(0, spawners.Length);
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[randEnemy], spawners[randSpawn].position, Quaternion.identity, transform);
    }
    void EndGame()
    {

    }

    public Player_Unit GetPlayerUnit()
    {
        return currentPlayer;
    }
}
