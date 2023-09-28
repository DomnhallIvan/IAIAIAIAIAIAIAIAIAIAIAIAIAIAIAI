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
        DesiredVelocity = (Position - Target).normalized * speed;
        float distance = (Target - Position).magnitude;

        Vector3 steering = DesiredVelocity - Velocity;
        Velocity = Vector3.ClampMagnitude(Velocity + steering, speed);

       
        //Si la distancia es menor al RunawayCircle entonces correrá con la velocidad normal
        if (distance < runAwayCircle)
        {
            Debug.Log("Esta ADENTRO, pero que no cunda el pánico");
            DesiredVelocity = (DesiredVelocity).normalized * speed * (runAwayCircle/distance );
            return steering;
        }
        if(distance<runAwayCircle&&distance>safeRadius)
        {
            Debug.Log($"Factor reducion: {distance / safeRadius}");
            Debug.Log("Estoy Safe");
            var distanceFRadius = distance / safeRadius;

            DesiredVelocity = (DesiredVelocity).normalized * speed * distanceFRadius;

            return steering;

        }

        Velocity = Vector3.zero;
        return Vector3.zero;

    }

}
