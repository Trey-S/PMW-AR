using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class SwapEmojiSprites : MonoBehaviour //Swap Emoji Sprites Based on Koreographer Sprites
{
    [EventID]
	public string eventID;
    public Sprite[] Sprites;
    private int index = 0;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        if(eventID != null)
            Koreographer.Instance.RegisterForEvents(eventID, SwapSprites);
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void SwapSprites(int i){
        spriteRenderer.sprite = Sprites[i];
    }

    private void SwapSprites(KoreographyEvent evt){
        if(index < Sprites.Length - 1){
            index++;
            spriteRenderer.sprite = Sprites[index];
        }else{
            index = 0;
            spriteRenderer.sprite = Sprites[0];
        }
    }
}
