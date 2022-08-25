using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SonicBloom.Koreo
{
public class HideShowGameObjects : MonoBehaviour //Hide or Show Koreographer game objects
{
    enum ObjectInteraction {Random, Straight, ShowAll};
    [SerializeField] ObjectInteraction objectInteraction;

    public int FramesPerTurn = 0;

    [EventID]
	public string eventIDTurnOn;
    [EventID]
	public string eventIDTurnOff;

    public bool ActiveOnAwake = false;
    public GameObject[] objects;

    private int startRange = 0;
    private int endRange;

    public int startIndex = -1;
    
    private void Awake(){
        if(eventIDTurnOff != null && eventIDTurnOn != null){
            if(objectInteraction == ObjectInteraction.Random){
                Koreographer.Instance.RegisterForEvents(eventIDTurnOn, TurnOnRandomObject);
                Koreographer.Instance.RegisterForEvents(eventIDTurnOff, HideAllGameobjects);

                // Koreographer.Instance.RegisterForEvents(eventIDTurnOff, TurnOnRandomObject);
            }else if(objectInteraction == ObjectInteraction.Straight){
                // Koreographer.Instance.RegisterForEvents(eventIDTurnOn, TurnOnRandomObject);
                // Koreographer.Instance.RegisterForEvents(eventIDTurnOff, TurnOnRandomObject);
            }else if(objectInteraction == ObjectInteraction.ShowAll){
                Koreographer.Instance.RegisterForEvents(eventIDTurnOn, ShowAllGameobjects);
                Koreographer.Instance.RegisterForEvents(eventIDTurnOff, HideAllGameobjects);
            }
        }


        endRange = objects.Length;

        if(startIndex != -1){
            startRange = startIndex;
        }

        if(ActiveOnAwake){
            ShowAllGameObjects();
        }
        else{
            HideAllGameObjects();
        }
    }

    public void ShowAllGameobjects(KoreographyEvent evt){
        StartCoroutine(ShowAllGameObjects());
    }
    public void HideAllGameobjects(KoreographyEvent evt){
        StartCoroutine(HideAllGameObjects());
    }

    public IEnumerator ShowAllGameObjects(){
        foreach(GameObject obj in objects)
        {
            if(!obj.active){
                obj.SetActive(true);
            }
            for(int i = 0; i < FramesPerTurn; i++)
                yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator HideAllGameObjects(){
        foreach (GameObject obj in objects)
        {
            if(obj.active){
                obj.SetActive(false);
            }
            for(int i = 0; i < FramesPerTurn; i++)
                yield return new WaitForEndOfFrame();
        }
    }

    public void TurnOnRandomObject(KoreographyEvent evt){
        int i = Random.Range(0, endRange);
        while(objects[i].active){
            i = Random.Range(0, endRange);
        }

        objects[i].SetActive(true);
    }

    public void TurnOffRandomObject(KoreographyEvent evt){
        int i = Random.Range(0, endRange);
        while(!objects[i].active){
            i = Random.Range(0, endRange);
        }

        objects[i].SetActive(false);
    }
}
}
