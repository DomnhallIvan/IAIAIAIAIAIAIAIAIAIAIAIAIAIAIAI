using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SterringBehaviour : MonoBehaviour
{
    //Se mantiene el speed, el target y el velocity del Script original de Seek
    //Desired Velocity se declar� aqu� porque despu�s se le asigna su valor en otros Script
    //Position Se refiere al transform.position original de la clase que lo vaya a usar (Ej. el enemigo)
    //Por �ltimo Vector3 GetForce va a ser la funci�n en el que se calcule todo lo de Seek, desired velocity, steering despu�s Velocity y por �ltimo la actualizaci�n del transform.position
    public float speed;
    public Vector3 DesiredVelocity;
    public Vector3 Velocity;
    public Vector3 Position;
    public Vector3 Target;
    public Rigidbody rb;
    public abstract Vector3 GetForce();

}
