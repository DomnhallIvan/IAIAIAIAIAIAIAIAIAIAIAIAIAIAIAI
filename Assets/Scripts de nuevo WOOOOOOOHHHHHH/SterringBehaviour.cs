using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SterringBehaviour : MonoBehaviour
{
    public float speed;
    public Vector3 DesiredVelocity;
    public Vector3 Velocity;
    public Vector3 Position;
    public Vector3 Target;
    public abstract Vector3 GetForce();

}
