using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject player, spawner, gameOverPanelGO;
    private GameObject[] obstacles;

    private ObstaclesBehaviour obstaclesBehaviour;
    private PlayerControls playerControls;
    private SpawnBehaviour spawnBehaviour;
    private GameOverPanel gameOverPanel;

	private void Start()
	{
        player = GameObject.FindWithTag("Player");
        spawner = GameObject.FindWithTag("Spawner");
        gameOverPanelGO = GameObject.FindWithTag("GameOverPanel");

        spawnBehaviour = spawner.GetComponent<SpawnBehaviour>();
        playerControls = player.GetComponent<PlayerControls>();
        gameOverPanel = gameOverPanelGO.GetComponent<GameOverPanel>();
	}

	private void FixedUpdate()
	{
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
    }

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOverPanel.manageGameOverPanel(true);

            foreach (GameObject obstacle in obstacles)
            {
                obstaclesBehaviour = obstacle.GetComponent<ObstaclesBehaviour>();
                obstaclesBehaviour.speedPub = 0;
            }

            playerControls.enabled = false;
            spawnBehaviour.enabled = false;
        }
    }
}
