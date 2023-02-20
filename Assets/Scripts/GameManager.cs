using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;

    public bool isGameOver;
    public float spawnRate = 2f;
    public List<Vector3> targetPositionsInScene;
    public Vector3 randomPos;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        StartCoroutine("SpawnRandomTarget");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 RandomSpawnPosition() {
        float spawnPosX = minX + Random.Range(0, 4) * distanceBetweenSquares;
        float spawnPosY = minY + Random.Range(0, 4) * distanceBetweenSquares;
        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    private IEnumerator SpawnRandomTarget() {
        while (!isGameOver) {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomPos = RandomSpawnPosition();

            //Check if the position is already busy
            while (targetPositionsInScene.Contains(randomPos)) {
                randomPos = RandomSpawnPosition(); //Search new position
            }

            Instantiate(targetPrefabs[randomIndex], randomPos, targetPrefabs[randomIndex].transform.rotation);
            targetPositionsInScene.Add(randomPos); //Add new Position
        }
    }
}
