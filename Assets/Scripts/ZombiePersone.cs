using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;
using UnityEngine.AI;

[RequireComponent(typeof(ZombieAnimator))]
//[RequireComponent(typeof(ZombieVisage))]
[RequireComponent(typeof(NavMeshAgent))]
public class ZombiePersone : MonoBehaviour
{
    [SerializeField] private Souls soul;
   public bool hadSoul = true;
    ZombieAnimator animator;
   // ZombieVisage visage;
    int rndWalk;
    NavMeshAgent navMesh;
    [SerializeField] private float speed;
    private MageController mage;
    private GameObject player;
    GameManager gameManager;
    [Header("Magnet")]
    [SerializeField] private float _timeMagnet;
    [SerializeField] private int _countSteepMagnet;
    [SerializeField] private AnimationCurve _changeY;
    private float _steep;
    private float _timeInSteep;

   
    [Inject]
    private void Init(MageController mageController, GameManager manager , PlayerController playerController)
    {
        mage =mageController;
        gameManager = manager;
        player = playerController.gameObject;
        gameManager.StoreSouls += PushSoul;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<ZombieAnimator>();
       // visage = GetComponent<ZombieVisage>();
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.speed = Random.Range(0,speed);
        _steep = 1f / _countSteepMagnet;
        _timeInSteep = _timeMagnet / _countSteepMagnet;
        rndWalk = Random.Range(1,3);
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
            animator.MoveAnimation(rndWalk);
        }
    }

    void PushSoul()
    {
        animator.LooseSoul();
        soul.soulObj.GetComponent<Soul>().SetType(soul.soulsType);
        soul.soulObj.transform.DOJump(mage.transform.position, 4f, 1, 1f)
            .OnComplete(()=> 
            {
                hadSoul = false;
                mage.StoreSouls(soul.soulObj.GetComponent<Soul>());
               // visage.LooseSoul();
                //soul.soulObj.transform.parent = mage.transform;
            });
    }

    public void CompaireSouls(Soul soulGet)
    {
        if (soulGet.GetTypeOfSoul() == soul.soulsType)
        {
            soulGet.PushSoul(gameObject, _countSteepMagnet , _steep, _changeY, _timeInSteep);
           
               hadSoul = true;
               mage.LostSouls(soulGet);
            navMesh.isStopped = true;
            animator.GetRightSoul();
          //  visage.GetYouSoul();
        }
        else
        {
            mage.LostSouls(soulGet);
            navMesh.isStopped = true;
            animator.GetWrongSoul(soulGet.GetTypeOfSoul());
        }
    }

   

  

}
