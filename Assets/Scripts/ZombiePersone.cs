using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class ZombiePersone : MonoBehaviour
{
    [SerializeField] private Souls soul;
   public bool hadSoul = true;
    Animator animator;
    NavMeshAgent navMesh;

    private GameObject mage;
    private GameObject player;
    GameManager gameManager;

    [Inject]
    private void Init(MageController mageController, GameManager manager , PlayerController playerController)
    {
        mage =mageController.gameObject;
        gameManager = manager;
        player = playerController.gameObject;
        gameManager.StoreSouls += PushSoul;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hadSoul)
        {
            if (navMesh == null)
            {
                navMesh = GetComponent<NavMeshAgent>();
            }
                navMesh.SetDestination(player.transform.position);
        }
    }

    void PushSoul()
    {
        soul.soulObj.GetComponent<Soul>().SetType(soul.soulsType);
        soul.soulObj.transform.DOJump(mage.transform.position, 4f, 1, 1f)
            .OnComplete(()=> 
            {
                hadSoul = false;
            });
       
    }
}
