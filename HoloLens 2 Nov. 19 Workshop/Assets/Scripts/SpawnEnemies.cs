using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine(TimedRaycast());
    }
    

    private IEnumerator TimedRaycast()
    {
        while (true)
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, RandomDirection(), out hit))
            {
                SpawnTheThing(hit.point);
                yield return new WaitForSeconds(5f);
            }
            else
            {
                yield return null;
            }
        }
    }
    public void SpawnTheThing(Vector3 position)
    {
        GameObject spawnedEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);
    }

    private Vector3 RandomDirection()
    {
        return new Vector3(Random.RandomRange(0, 1), Random.Range(0.5f, mainCamera.transform.position.y + 0.4f), Random.Range(0, 1));
    }
}
