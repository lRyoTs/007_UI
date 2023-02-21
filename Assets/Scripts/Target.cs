using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifeTime = 2f;
    public int points = 5;  //Store object's points
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
            if (gameObject.CompareTag("Bad")) { //Pressed Wrong
                gameManager.GameOver();
            }
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); //Activate SystemParticle (destroys itself at end)
            gameManager.UpdateScore(points); //Update score
            Destroy(gameObject);
        }

    }

    //When game Object is Destroy()
    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.Remove(transform.position); //Remove position from List
    }
}
