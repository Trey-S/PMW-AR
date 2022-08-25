using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SonicBloom.Koreo;

public class KoreoEventTrigger : MonoBehaviour //Invoke Events on Koreographer trigger
{
    [EventID]
	public string eventIDChangeSpeed;

    private int index = 0;
    public UnityEvent[] eventTriggers;


    private void Awake(){
        Koreographer.Instance.RegisterForEvents(eventIDChangeSpeed, TriggerEvent);                                                           
    }

    private void TriggerEvent(KoreographyEvent evt){
        eventTriggers[index].Invoke();
        index++;
    }
}
