using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class TouchPanel : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerClickHandler
{

    bool isClicked;
    
    Soul clickedSoul;
    ZombiePersone zombieClicked;

    MageController mage;
    PlayerController player;
    [Inject]
    private void Init(MageController mageController, PlayerController playerController)
    {
        mage = mageController;
        player = playerController;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ClickObject();
    }
    public void ClickObject()
    {

        if (!isClicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000f))
            {
                if (hit.transform.gameObject.CompareTag("Soul"))
                {
                    clickedSoul = hit.transform.gameObject.GetComponent<Soul>();
                    // clickedSoul.ClickedOnSoul();
                    isClicked = true;
                    Debug.DrawLine(ray.origin, hit.point, Color.red);
                }
               

            }
        }


    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(eventData.position);

            clickedSoul.DragSoul(ray);
            player.DragSoul(clickedSoul.transform);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000f))
            {
                if (hit.transform.gameObject.CompareTag("Zombie"))
                {                   
                    zombieClicked = hit.transform.gameObject.GetComponent<ZombiePersone>();
                   
                }
            }
        }
        else
        {
            ClickObject();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isClicked = false;
        if (zombieClicked!=null)
        {
            zombieClicked.CompaireSouls(clickedSoul);
            zombieClicked = null;
            clickedSoul = null;
        }
        else
        {
            if (clickedSoul!=null)
            {
                clickedSoul.ReturnSoulToMage();
                clickedSoul = null;
            }
           
        }
      
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000f))
            {

                if (hit.transform.gameObject.CompareTag("Mage"))
                {                   
                    mage.ClickedOnMage();
                    Debug.DrawLine(ray.origin, hit.point, Color.red);
                }
            }
        }
    }
}
