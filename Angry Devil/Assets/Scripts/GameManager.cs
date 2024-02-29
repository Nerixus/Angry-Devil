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
    public EnemyFactory enemyFactory;

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
        enemyFactory.CreateEnemy();
    }
    void EndGame()
    {

    }

    public Player_Unit GetPlayerUnit()
    {
        return currentPlayer;
    }
}
