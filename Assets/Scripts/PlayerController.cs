using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
  
    GameManager gameManager;
    [Inject]
    private void Init(GameManager manager)
    {
        gameManager = manager;
     
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
      /*  if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000f))
            {
                if (hit.transform.gameObject.CompareTag("Mage"))
                {
                    Debug.Log("Mage clicked");
                    mage.ClickedOnMage();
                } 
                if (hit.transform.gameObject.CompareTag("Soul"))
                {
                    clickedSoul = hit.transform.gameObject.GetComponent<Soul>();
                    Debug.Log(clickedSoul.GetTypeOfSoul()+ " clicked");
                   // clickedSoul.ClickedOnSoul();


                }

            }
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            gameManager.LevelLost();
        }
    }


}
