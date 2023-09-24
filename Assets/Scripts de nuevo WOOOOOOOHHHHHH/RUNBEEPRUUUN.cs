using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using TMPro;

public class RUNBEEPRUUUN : SterringBehaviour
{
    public float runAwayCircle;
    public float safeRadius;

    public override Vector3 GetForce()
    {
        Position = transform.position;

        DesiredVelocity = (Position - Target).normalized * speed;
        float distance = (Target - Position).magnitude;

        //Si la distancia es menor al RunawayCircle entonces correrá con la velocidad normal
        if (distance < runAwayCircle)
        {
            DesiredVelocity = DesiredVelocity.normalized * speed * (runAwayCircle / distance); 

        }
        else 
        {
            DesiredVelocity = DesiredVelocity.normalized * speed / (runAwayCircle / distance) * 0;
        }
        
        /*//Si la distancia es menor que el safeRadius su velocidad se reducirá dependiendo de que tan cerco este el jugador
        else if(distance < safeRadius)
        {
            DesiredVelocity = DesiredVelocity.normalized * speed * (distance / safeRadius);
        }
        else
        {
            DesiredVelocity = Vector3.zero;
        } */                     

        Vector3 steering = DesiredVelocity - Velocity;
        Velocity = Vector3.ClampMagnitude(Velocity + steering, speed);
        transform.position += Velocity * Time.deltaTime;
        return steering;
    }

}
