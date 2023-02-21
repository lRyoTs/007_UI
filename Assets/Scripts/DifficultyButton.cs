using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty; //Set difficulty 1 (Easy) / 2 (Normal) / 3 (Hard)
    private Button _button; //Store button
    private GameManager gameManager;

    //Initialize own components
    private void Awake()
    {
        _button = GetComponent<Button>(); //Get button component
        _button.onClick.AddListener(SetDifficulty); //AddListener
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); //Get GameManager Script
    }

    private void SetDifficulty(){
        gameManager.StartGame(difficulty); //Start Game
    }
}
