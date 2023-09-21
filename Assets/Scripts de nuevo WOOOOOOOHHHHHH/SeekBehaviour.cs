using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : SterringBehaviour
{
    //Aquí se va a hacer la acción de Seek 
    public bool arrival;
    public float slowingRadius;

    public override Vector3 GetForce()
    {
        Position = transform.position;

        DesiredVelocity = (Target - Position).normalized * speed;
        float distance = (Target - Position).magnitude;

        
        if (distance < slowingRadius)
        {
            arrival = true;
            
        }
        else
        {
            arrival = false;
            
        }

        //Empieza disminuir si es que esta cerca del Slowing  Radius, solo si el arrival es true
        if (arrival == true)
        {
            DesiredVelocity = DesiredVelocity.normalized * speed * (distance / slowingRadius);
        }
        else
        {
            DesiredVelocity = DesiredVelocity.normalized * speed;
        }


        Vector3 steering = DesiredVelocity - Velocity;
        Velocity = Vector3.ClampMagnitude(Velocity + steering, speed);
        transform.position += Velocity * Time.deltaTime;
        return steering;
    }
}
