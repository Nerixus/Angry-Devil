using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class GameManager : StaticInstance<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;
    public CinemachineVirtualCamera cameraController;
    [Header("Enemies")]
    public EnemyFactory enemyFactory;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    Player_Unit currentPlayer;
    Health healthComponent;
    bool gameActive = false;
    int score;

    private void Start()
    {
        JumpstartGame();   
    }

    void JumpstartGame()
    {
        GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, transform);
        currentPlayer = newPlayer.GetComponent<Player_Unit>();
        healthComponent = currentPlayer.GetComponent<Health>();
        cameraController.Follow = newPlayer.transform;
        cameraController.LookAt = newPlayer.transform;
        enemyFactory.StartEnemyCreation();
        gameActive = true;
    }

    private void Update()
    {
        if (gameActive)
        {
            healthText.text = "Health: " + healthComponent.HealthValue.ToString();
            scoreText.text = "Score: " + score.ToString();
            if (healthComponent.HealthValue <= 0)
            {
                gameActive = false;
                StartCoroutine(EndGame());
            }
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);
    }

    void IncreaseScore()
    {
        score++;
    }

    public Player_Unit GetPlayerUnit()
    {
        return currentPlayer;
    }

    private void OnEnable()
    {
        Enemy_Unit.OnDisabled += IncreaseScore;
    }

    private void OnDisable()
    {
        Enemy_Unit.OnDisabled -= IncreaseScore;
    }
}
