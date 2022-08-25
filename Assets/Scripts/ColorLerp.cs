using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class ColorLerp : MonoBehaviour //Go through color array and lerp between them
{
    [EventID]
	public string eventID;

    private SpriteRenderer spriteRender;
    [SerializeField] [Range(0f, 10f)] float lerpTime;
    [SerializeField] Color[] myColors;
    private Color startingColor;

    private bool startColorChange = false;
    private int colorIndex = 0;
    private float t = 0f;
    private int indexLength = 0;
    void Awake(){        
        if(eventID != null)
            Koreographer.Instance.RegisterForEvents(eventID,  ColorChange);
        spriteRender = GetComponent<SpriteRenderer>();
        indexLength = myColors.Length;
        startingColor = spriteRender.color;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(startColorChange){
            spriteRender.color = Color.Lerp(spriteRender.color, myColors[colorIndex], lerpTime*Time.deltaTime);
            t = Mathf.Lerp(t, 1f, lerpTime*Time.deltaTime);
            if(t > .9f){
                t = 0f;
                colorIndex++;
                colorIndex = (colorIndex >= indexLength) ? 0 : colorIndex;
            }
        }else if(startColorChange == false && startingColor != spriteRender.color){
            //Lerp Color to og Colors
            spriteRender.color = Color.Lerp(spriteRender.color, startingColor, lerpTime*Time.deltaTime);
            colorIndex = 0;
        }
    }

    private void ColorChange(KoreographyEvent evt){
        startColorChange = !startColorChange;
    }
}
