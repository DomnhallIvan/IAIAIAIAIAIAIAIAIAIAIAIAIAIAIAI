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
        if(arrival==false)
        {
            DesiredVelocity = (Target - Position).normalized * speed;
        }
        if(arrival==true)
        {
            DesiredVelocity = (Target - Position).normalized * speed;
            float distance=(Target-Position).magnitude;
            if(distance<slowingRadius)
            {
                DesiredVelocity = DesiredVelocity.normalized * speed * (distance / slowingRadius);
            }
            else
            {
                DesiredVelocity = DesiredVelocity.normalized * speed;
            }
        }
        Vector3 steering = DesiredVelocity - Velocity;
        Velocity = Vector3.ClampMagnitude(Velocity + steering, speed);
        transform.position += Velocity * Time.deltaTime;
        return steering;
    }
}
