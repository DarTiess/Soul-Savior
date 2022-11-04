using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class MageAnimator : MonoBehaviour
{
    Animator animator;
    AnimationClip startingClip;
    AnimationEvent storeSouls;
    bool isStored;
    GameManager gameManager;
   
    [Inject]
    private void Init(GameManager manager)
    {
        gameManager = manager;
       
    }

   

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        storeSouls = new AnimationEvent();
        storeSouls.time = 2.13f;
        storeSouls.functionName = "TakingSouls";
        startingClip = FindAnimation(animator, "StoreSouls");
        startingClip.AddEvent(storeSouls);
    }

    public AnimationClip FindAnimation(Animator animator, string name)
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }

        return null;
    }

   public void TakingSouls()
    {
        if (!isStored)
        {
            gameManager.StartStoringSouls();
            isStored = true;
        }
       
    }

    public void RunAnimation()
    {
        animator.SetBool("Run", true);
    }

}
