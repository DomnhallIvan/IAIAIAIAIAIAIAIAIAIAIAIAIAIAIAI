using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : SterringBehaviour
{
    public float circleDistance;
    public float circleRadius;
    public Vector3[] targetChange;
    public Vector3 targetSpace;
    public float angleChange;
    public float[] angleRange;
    public bool showVectors;
    private bool _startRandom;
    private float _rotationAngle;
    private SeekBehaviour _seek;

    // Start is called before the first frame update
    private void Start()
    {
        _seek = GetComponent<SeekBehaviour>();
        StartCoroutine(RandomTarget());
        StartCoroutine(RandomAngle());
    }

    public override Vector3 GetForce()
    {
        Position = transform.position;
        DesiredVelocity = (targetSpace - Position).normalized * speed;
        Quaternion rotate = Quaternion.AngleAxis(angleChange, Vector3.forward);
        Vector3 Circle_Center = Velocity.normalized * circleDistance;
        Vector3 Displacement = Velocity.normalized * circleRadius;
        Displacement = rotate * Displacement;
        Vector3 wander = rotate * Displacement;

        // Combine the desired_velocity, wander, and steering vectors
        Vector3 steering = DesiredVelocity + wander - Velocity;

        DrawVectors(Circle_Center, Displacement);

        Velocity = Vector3.ClampMagnitude(Velocity + steering, speed);

        return steering;

    }

    private void DrawVectors(Vector3 center, Vector3 displacement)
    {
        Debug.DrawLine(Position, Position + center, Color.green);
        Debug.DrawLine(Position + center, Position + center + displacement, Color.red);
        Debug.DrawLine(Position, Position + center + displacement, Color.blue);
    }

    IEnumerator RandomTarget()
    {
        float TargetTime = 1f;

        while (true)
        {
            int index = Random.Range(0, targetChange.Length);
            yield return new WaitForSeconds(TargetTime);
            targetSpace = targetChange[index];
            _seek.Target = targetSpace;
        }

    }

    IEnumerator RandomAngle()
    {
        float AngleTime = 5f;
        while (true)
        {
            yield return new WaitForSeconds(AngleTime);
            angleChange = Random.Range(angleRange[0], angleRange[1]);
        }
    }
}
