using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MageAnimator))]
public class MageController : MonoBehaviour
{
    MageAnimator mageAnimator;
    [SerializeField] private List<Soul> soulsList = new List<Soul>();

    [SerializeField] private List<Transform> soulsPlaces = new List<Transform>();
    int indexPlaces = 0;
    // Start is called before the first frame update
    void Start()
    {
        mageAnimator = GetComponent<MageAnimator>();
    }
 
    public void StoreSouls(Soul soul)
    {
      
            soulsList.Add(soul);
            soul.gameObject.transform.position = soulsPlaces[indexPlaces].position;
            soul.gameObject.transform.parent = null;
            soul.gameObject.SetActive(false);
            indexPlaces++;
        
     
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
}
