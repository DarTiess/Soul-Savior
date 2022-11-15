using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieVisage : MonoBehaviour
{
    [SerializeField] private GameObject normalFace;
    [SerializeField] private GameObject witoutSoulFace;
    [SerializeField] private GameObject happyFace;
    // Start is called before the first frame update
    void Start()
    {
        SetStartingFace();
    }

  

    void SetStartingFace()
    {
        normalFace.SetActive(true);
        happyFace.SetActive(false);
        witoutSoulFace.SetActive(false);
    }

    public void LooseSoul()
    {
        normalFace.SetActive(false);
        witoutSoulFace.SetActive(true);
    }

    public void GetYouSoul()
    {
        witoutSoulFace.SetActive(false);
        happyFace.SetActive(true);
    }
}
