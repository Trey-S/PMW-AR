using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour //Moved VectorZ towards main Camera.
{
    public float speed = 1.0f;
    [SerializeField] Transform[] targets;
    
    void FixedUpdate()
    {
        foreach (Transform target in targets)
        {
            // Determine which direction to rotate towards
            Vector3 targetDirection = this.transform.position - target.transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = speed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(target.transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            // Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            target.transform.rotation = Quaternion.LookRotation(newDirection);
        }
       
    }
}
