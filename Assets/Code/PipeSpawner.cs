using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipes;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] float yPosMin = -2f;
    [SerializeField] float yPosMax = 2f;

    void Start()
    {
        StartCoroutine(SpawnPipeCoroutine());
    }

    IEnumerator SpawnPipeCoroutine()
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(pipes, transform.position + Vector3.up * Random.Range(yPosMin, yPosMax), Quaternion.identity);
        StartCoroutine(SpawnPipeCoroutine());
    }
}
