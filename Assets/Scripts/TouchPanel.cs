using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class TouchPanel : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerClickHandler
{

    bool isClicked;
    MageController mage;
    Soul clickedSoul;
    ZombiePersone zombieClicked;

    [Inject]
    private void Init(MageController mageController)
    {
        mage = mageController;
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
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000f))
            {
                if (hit.transform.gameObject.CompareTag("Zombie"))
                {                   
                    zombieClicked = hit.transform.gameObject.GetComponent<ZombiePersone>();
                    zombieClicked.CompaireSouls(clickedSoul);
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isClicked = false;
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
