using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;

    public bool isGameOver; //Game status
    public float spawnRate = 2f; //Time between spawns
    public List<Vector3> targetPositionsInScene; //store position already busy
    public Vector3 randomPos; //Store a random position

    public TextMeshProUGUI scoreText;
    private int score = 0;
    public GameObject gameOverPanel;
    public GameObject startGamePanel;

    // Start is called before the first frame update
    void Start()
    {

    }


    private Vector3 RandomSpawnPosition() {
        float spawnPosX = minX + Random.Range(0, 4) * distanceBetweenSquares;
        float spawnPosY = minY + Random.Range(0, 4) * distanceBetweenSquares;
        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    //Coroutine
    private IEnumerator SpawnRandomTarget() {
        //Check if is NOT Game Over
        while (!isGameOver) {
            yield return new WaitForSeconds(spawnRate); //Wait before spawn
            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomPos = RandomSpawnPosition();

            //Check if the position is not already busy
            while (targetPositionsInScene.Contains(randomPos)) {
                randomPos = RandomSpawnPosition(); //Search new position
            }

            Instantiate(targetPrefabs[randomIndex], randomPos, targetPrefabs[randomIndex].transform.rotation);
            targetPositionsInScene.Add(randomPos); //Add new Position
        }
    }

    //Public function that increase socre value
    public void UpdateScore(int newPoints) {
        score += newPoints;
        scoreText.text = $"Score:\n{score}";
    }

    //Public function that manage Game Over
    public void GameOver() {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    //Function that select dificulty
    public void StartGame(int difficulty)
    {
        isGameOver = false;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnRandomTarget());
        scoreText.text = $"Score:\n{score}";
        startGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    //Function that Restart game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Load same scene
    }
}
