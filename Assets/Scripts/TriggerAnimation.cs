using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class TriggerAnimation : MonoBehaviour //Trigger Animation when Koregrapher event happens
{
    [EventID]
	public string eventID; //Event Id to find
    public string AnimationTrigger;

    
    private Animator animator;
    void Awake()
    {
        animator = this.GetComponent<Animator>();
        Koreographer.Instance.RegisterForEvents(eventID, NextAnimation);
    }

    public void NextAnimation(KoreographyEvent evt){
        animator.SetTrigger(AnimationTrigger);
    }
}
