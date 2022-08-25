using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class SwapGameObjectSprites : MonoBehaviour //Event script that changes sprites for gameobjects based on Koreographer event ID
{

    [EventID]
	public string eventID;
    public SpriteRenderer[] spriteRenderers;
    public Sprite[] Sprites;
    private int index = 0;

    public int FramesPerTurn = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if(eventID != null)
            Koreographer.Instance.RegisterForEvents(eventID, NextSprite);
    }

    public void NextSprite(KoreographyEvent evt){
        StartCoroutine(StartNextSprite());
    }

    public IEnumerator StartNextSprite(){
        if(index >= spriteRenderers.Length)
            index = 0;
        else
            index++;

        foreach(SpriteRenderer sprite in spriteRenderers)
        {
            sprite.sprite = Sprites[index]; 

            for(int i = 0; i < FramesPerTurn; i++)
                yield return new WaitForEndOfFrame();
        }
    }
}
