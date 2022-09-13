using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class RotateObject : MonoBehaviour //Rotate Object at runtime
{
    public float xRotationSpeed = 0f;
    public float yRotationSpeed = 0f;
    public float zRotationSpeed = 0f;

    [EventID]
	public string change_ySpeedEvent; //Event ID for changing speed of rotation.

    private void Awake() {
        Koreographer.Instance.RegisterForEvents(change_ySpeedEvent, ChangeYSpeed);
    }
    void FixedUpdate()
    {
        transform.Rotate(xRotationSpeed, yRotationSpeed, zRotationSpeed, Space.Self); 
    }

    private void ChangeYSpeed(KoreographyEvent evt){
        if(evt.GetFloatValue() != null)
            yRotationSpeed = evt.GetFloatValue();
    }

    public void ChangeYSpeed(float speed){
        yRotationSpeed = speed;
    }
}

