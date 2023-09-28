using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitBehaviour : SterringBehaviour
{
    //Aquí se va a hacer la acción de Seek 
    public bool arrival;
    public float slowingRadius;
    [SerializeField] private int _T;
    public GameObject pursuitTarget;
    private PlayerController _pController;


    private void Start()
    {
        _pController = pursuitTarget.GetComponent<PlayerController>();
    }


    public override Vector3 GetForce()
    {

        return Seek();
    }

    private Vector3 Seek()
    {
        Position = transform.position;
        Target = pursuitTarget.transform.position;

        Vector3 FuturePos = Target + _pController.velocity * _T;
        DesiredVelocity = (FuturePos - Position).normalized * speed;
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
