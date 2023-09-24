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
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = true;
            DesiredVelocity=Vector3.zero;
            
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

       
        
        //Esto es para que no se descontrole el enemigo con la velocidad
        Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude > speed)
        {
           rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);
        }

        Vector3 steering = DesiredVelocity - Velocity;
        Velocity = Vector3.ClampMagnitude(Velocity + steering, speed);
        transform.position += Velocity * Time.deltaTime;
        return steering;
    }

}
