using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoid : SterringBehaviour
{

    public ObstacleController obController;
    public float maxSeeAhead;
    public float obstacleRadius;
    public float maxAvoidForce;
    public bool showVectors;
    private List<Vector3> _obstacleList;
    private Vector3 _ahead, _ahead2;

    private void Start()
    {
        
    }

    public override Vector3 GetForce()
    {

        throw new System.NotImplementedException();
    }

    /*
    private Vector3 FindBiggestThreat()
    {
        Vector3 BiggECheese = null;

        return BiggECheese;
    }

    private bool CollisionDetected(Vector3 añaX,Vector3 añaY,Vector3 anaZ)
    {
        return añaX;
    }

    private void DrawVectors(V3)
    {

    }*/
}
