using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ZombieAnimator : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void MoveAnimation(int numWalk)
    {
        animator.SetFloat("IsMove", numWalk);
    }

    public void LooseSoul()
    {
        animator.SetBool("LooseSoul", true);
    }

    public void GetRightSoul()
    {
        animator.SetBool("IsWin", true);
    }

    public void GetWrongSoul(SoulsType soulsType)
    {
        switch (soulsType)
        {  
            case SoulsType.Character_7:
                animator.SetFloat("IsLose", 1);
                break;
            case SoulsType.Assasin:
            case SoulsType.Bandit: 
            case SoulsType.Character_10:
            case SoulsType.Character_8:
                animator.SetFloat("IsLose", 2);
                break;   
            case SoulsType.Character_2:
                animator.SetFloat("IsLose", 3);
                break;
            case SoulsType.Samurai:
            case SoulsType.Character_1:
            case SoulsType.Character_15:
                animator.SetFloat("IsLose", 4);
                break;
         
            case SoulsType.Character_5:
            case SoulsType.Character_6: 
            case SoulsType.Character_11:
                animator.SetFloat("IsLose", 5);
                break;
            case SoulsType.Supergirl:
                animator.SetFloat("IsLose", 6);
                break;
            case SoulsType.Character_12:
            case SoulsType.Character_13:
            case SoulsType.Character_14:
            case SoulsType.Character_16:
            case SoulsType.Character_3:
            case SoulsType.Character_4:
            case SoulsType.Viking:
            case SoulsType.Character_9:
                animator.SetFloat("IsLose", 7);
                break;
        }
    }
}
