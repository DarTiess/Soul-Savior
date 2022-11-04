using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CanvasController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject inGame;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lost;
    [SerializeField] private Text Level;

    [Header("Sliders")]
    [SerializeField] private ProgressOnScene progressOnScene;
    [SerializeField] private LevelsProgress levelsProgress;
    int numLevel;
    GameManager gameManager;

    [Inject]
    private void Init(GameManager manager)
    {
        gameManager = manager;
        gameManager.OnLevelStart += OnLevelStart;
        gameManager.OnLateWin += OnLevelWin;
        gameManager.OnLateLost += OnLevelLost;
      //  gameManager.OnLevelWin += ChangeLevelValue;
        gameManager.AddSoul += AddSouls;
        gameManager.FreeSoul+= FreeSoul;
      
    }

   

    private void Start()
    {
        FalsePanels();
        numLevel = gameManager.loadScene.numScene;
        mainMenu.SetActive(true);
        Level.text = "Level "+numLevel.ToString();
        
        levelsProgress.SetMaxValue(gameManager.loadScene.GetScenesCount());
        levelsProgress.SetLevel(numLevel);
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

    private void AddSouls()
    {
        progressOnScene.ChangeMaxValus();
    }
    private void FreeSoul()
    {
        progressOnScene.SetValues(0.7f);
    }
    private void ChangeLevelValue()
    {
        numLevel = gameManager.loadScene.numScene;
        levelsProgress.SetLevel(numLevel);
    }

    public void RestartGame()
    {
        gameManager.RestartScene();
    }

}
