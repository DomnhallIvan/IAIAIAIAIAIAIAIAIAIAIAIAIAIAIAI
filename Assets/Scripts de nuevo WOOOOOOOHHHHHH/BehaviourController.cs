using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourController : MonoBehaviour
{
    public List<SterringBehaviour> behaviours = new List<SterringBehaviour>();
    public float maxSpeed = 5f;
    public float maxForce = 5f;
    public Vector3 velocity;
    public Vector3 totalForce = Vector3.zero;

    public void FixedUpdate()
    {
        totalForce = Vector3.zero;
        foreach(SterringBehaviour behaviour in behaviours)
        {
            totalForce += behaviour.GetForce();
        }

        velocity += totalForce;
        transform.position += velocity * Time.deltaTime;
    }
}
