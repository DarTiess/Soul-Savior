using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MageAnimator))]
public class MageController : MonoBehaviour
{
    MageAnimator mageAnimator;
    [SerializeField] private List<SoulsType> soulsList = new List<SoulsType>();
    // Start is called before the first frame update
    void Start()
    {
        mageAnimator = GetComponent<MageAnimator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Soul"))
        {
            StoreSouls(other.gameObject.GetComponent<Soul>().GetTypeOfSoul());
        }
    }
    public void StoreSouls(SoulsType soulsType)
    {
        soulsList.Add(soulsType);
    }
}
