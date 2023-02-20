using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Load same scene
    }
}
