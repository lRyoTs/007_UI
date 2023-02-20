using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifeTime = 2f;
    public int points = 5;
    private GameManager gameManager;
    public GameObject explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, lifeTime); //Destroy game object in a fitted time
    }

    //Function that destroy when the user press the object
    private void OnMouseDown()
    {
        if (!gameManager.isGameOver) {
            if (gameObject.CompareTag("Bad")) {
                gameManager.GameOver();
            }
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(points);
            Destroy(gameObject);
        }

    }

    //When game Object is Destroy()
    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.Remove(transform.position); //Remove position from List
    }
}
