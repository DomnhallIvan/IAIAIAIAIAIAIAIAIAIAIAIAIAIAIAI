using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourController : MonoBehaviour
{
    //Necesito el BehaviourController por que tiene fixedUpdate
    public List<SterringBehaviour> behaviours;
    public float maxSpeed = 5f; //?
    public float maxForce = 5f;//?
    private Vector3 _velocity;
    private Vector3 _totalForce;


    private void FixedUpdate()
    {
        //Debug.Log(rb.velocity.magnitude);
        if (_velocity.magnitude > maxSpeed)
        {
            _velocity = Vector3.ClampMagnitude(_velocity, maxSpeed);
        }

        _totalForce = Vector3.zero;
        //Aquí busco por el tipo de Sterring Behaviour que tenga para obtener el tipo de GetForce Respectivo
        foreach(SterringBehaviour behaviour in behaviours)
        {
            
            _totalForce += behaviour.GetForce();
        }
        //Aquí se hace la suma para actualizar el movimiento de la clase respectiva
        //Estas son las últimas dos líneas de todos los Steering originales, _velocity=es lo que hayamos obtenido del GetForce, y el transform.position se actualiza acorde.
        _velocity += _totalForce;
        transform.position += _velocity * Time.deltaTime;
    }

    /*
    public abstract Vector3 GetForce()
    {
        return _velocity;
    }*/

    /*
    private Vector3 LimitVector(Vector3 force,float limit)
    {
        return 
    }*/
}
