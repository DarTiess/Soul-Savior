using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject wandPoint;
    GameManager gameManager;
    [Inject]
    private void Init(GameManager manager)
    {
        gameManager = manager;
     
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            gameManager.LevelLost();
        }
    }
    public void DragSoul(Transform soul)
    {
        wandPoint.transform.LookAt(soul);
    }

}
