using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private float elapsedTime;

    private float variance;
    private Vector3 spawnPos;

    void Start()
    {
        elapsedTime = 0.0f;
    }


    public void obstacleSpawn()
    {
        variance = Random.Range(-3f, 3f);
        spawnPos = this.gameObject.transform.position;

        Vector3 obstaclePos = new Vector3(spawnPos.x, variance, spawnPos.z);
        Quaternion obstacleRot = this.transform.rotation;

        Instantiate(obstacle, obstaclePos, obstacleRot);
    }

    void Update()
    {

        elapsedTime += Time.deltaTime;

        if (elapsedTime > timeBetweenSpawn)
        {
            this.obstacleSpawn();
            elapsedTime = 0.0f;
        }


    }
}
