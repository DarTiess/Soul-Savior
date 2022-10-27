using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CanvasController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject inGame;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lost;

    GameManager gameManager;

    [Inject]
    private void Init(GameManager manager)
    {
        gameManager = manager;
        gameManager.OnLevelStart += OnLevelStart;
        gameManager.OnLevelWin += OnLevelWin;
        gameManager.OnLevelLost += OnLevelLost;
    }
  
    private void Start()
    {
        FalsePanels();
        mainMenu.SetActive(true);
    }

    private void OnLevelStart()
    {
        FalsePanels(); 
        inGame.SetActive(true);
    }

    private void OnLevelWin()
    {
        Debug.Log("Level Win");
        FalsePanels();
        win.SetActive(true);
    }

    private void OnLevelLost()
    {
        Debug.Log("Level Lost");
        FalsePanels(); 
        lost.SetActive(true);
    }
  

    // out to Level Manager
    public void LoadNextLevel()
    { 
        gameManager.LoadNextLevel(); 
    }
    public void LevelStart()
    {
        gameManager.LevelStart();
    }

    private void FalsePanels()
    {
       mainMenu.SetActive(false);
        inGame.SetActive(false);
        win.SetActive(false);
        lost.SetActive(false);
    }


}
