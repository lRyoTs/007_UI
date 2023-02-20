using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifeTime = 2f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, lifeTime); //Destroy game object in a fitted time
    }

    //Function that destroy when the user press the object
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Bad")) {
            gameManager.isGameOver = true; //GAME OVER
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.Remove(transform.position); //Remove position from List
    }
}
