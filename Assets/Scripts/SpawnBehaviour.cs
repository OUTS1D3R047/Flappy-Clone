using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private float timeBetweenSpawn, elapsedTime, scale, varianceScale;

    private float variance;
    private Vector3 spawnPos;

    void Start()
    {
        elapsedTime = 0.0f;
    }


    public void obstacleSpawn()
    {
        variance = Random.Range(-varianceScale, varianceScale);
        spawnPos = this.gameObject.transform.localPosition;

        Vector3 obstaclePos = new Vector3(spawnPos.x, variance, spawnPos.z);
        Quaternion obstacleRot = this.transform.rotation;

        GameObject obstacleClone = Instantiate(obstacle, obstaclePos, obstacleRot);
        obstacleClone.transform.SetParent(gamePanel.transform, false);
        obstacleClone.transform.localScale = new Vector3(scale, scale, scale);
    }

    void FixedUpdate()
    {

        elapsedTime += Time.deltaTime;

        if (elapsedTime > timeBetweenSpawn)
        {
            this.obstacleSpawn();
            elapsedTime = 0.0f;
        }


    }
}
