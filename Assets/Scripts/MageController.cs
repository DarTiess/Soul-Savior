using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;


[RequireComponent(typeof(MageAnimator))]
public class MageController : MonoBehaviour
{
    MageAnimator mageAnimator;
    [SerializeField] private List<Soul> soulsList = new List<Soul>();
    [SerializeField] private List<Transform> soulsPlaces = new List<Transform>();
    [SerializeField] private float levitateHeight;
  
    Sequence seqLevitate;
   

    GameManager gameManager;
    [Inject]
    private void Init(GameManager manager)
    {
        gameManager = manager;
        gameManager.OnLevelWin += Running;
    }

   

    // Start is called before the first frame update
    void Start()
    {
        mageAnimator = GetComponent<MageAnimator>();
      
       
        seqLevitate = DOTween.Sequence();
      
        Levitation();
    }
   
    void Levitation()
    {
      
        seqLevitate.Append(transform.DOMoveY(7f, 1.5f))
          .Append(transform.DOMoveY(4.5f, 1.5f));
            seqLevitate.SetLoops(-1, LoopType.Yoyo); ;
       
    }
 
    public void StoreSouls(Soul soul)
    {
            soul.gameObject.transform.parent = null;
            soulsList.Add(soul);
            soul.gameObject.transform.position = soulsPlaces[soulsList.IndexOf(soul)].position;
            soul.gameObject.transform.rotation = soulsPlaces[soulsList.IndexOf(soul)].rotation;
        soul.SetStorePosition(soulsPlaces[soulsList.IndexOf(soul)]);
        soul.LevitateSoul();
          //  soul.gameObject.SetActive(false);
           
        return;
    } 
    
    public void LostSouls(Soul soul)
    {
        soulsList.Remove(soul);
    }

    public void ClickedOnMage()
    {
        foreach(Soul soul in soulsList)
        {
            soul.gameObject.SetActive(true);
        }
    }

    private void Running()
    {
        var look = Quaternion.LookRotation(transform.forward*(-1));

        transform.DORotateQuaternion(look, 1f)
            .OnComplete(()=> {
                mageAnimator.RunAnimation();
                transform.DOMove(new Vector3(transform.position.x, transform.position.y, transform.position.z +20f), 1f);
            });

    }
}
