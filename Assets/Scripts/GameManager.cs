using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action StoreSouls;
    public event Action OnLevelStart;
    public event Action OnLevelWin;
    public event Action OnLevelLost;
 

   
    [Space] 
    [Header("LevelLoader")] 
    public LoadScene loadScene;

    private void Awake()
    {  
      //  
    }
    private void Start()
    {
       Time.timeScale = 0;
    }
    public void StartStoringSouls()
    {
        StoreSouls?.Invoke();
    }
    public void LevelStart()
    {
        Time.timeScale = 1;
       
        OnLevelStart?.Invoke();
    }

    public void LevelLost()
    {
        OnLevelLost?.Invoke();
        Time.timeScale = 0;
    }


    public void LevelWin()
    {
      
        OnLevelWin?.Invoke();
        Time.timeScale = 0;
    }
             
    public void LoadNextLevel()
    {
        loadScene.LoadNextLevel();
    }

    public void RestartScene()
    {
        loadScene.RestartScene();
    }

    public void ClearProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}
