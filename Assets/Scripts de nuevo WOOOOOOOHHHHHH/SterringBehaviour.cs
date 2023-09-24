using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SterringBehaviour : MonoBehaviour
{
    //Se mantiene el speed, el target y el velocity del Script original de Seek
    //Desired Velocity se declará aquí porque después se le asigna su valor en otros Script
    //Position Se refiere al transform.position original de la clase que lo vaya a usar (Ej. el enemigo)
    //Por último Vector3 GetForce va a ser la función en el que se calcule todo lo de Seek, desired velocity, steering después Velocity y por último la actualización del transform.position
    public float speed;
    public Vector3 DesiredVelocity;
    public Vector3 Velocity;
    public Vector3 Position;
    public Vector3 Target;
    public Rigidbody rb;
    public abstract Vector3 GetForce();

}
