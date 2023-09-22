using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Vector3 _target;
    private BehaviourController _behaviourController;
    public List<SterringBehaviour> enemies=new List<SterringBehaviour>();

    private void Start()
    {
        _behaviourController = gameObject.GetComponent<BehaviourController>();
        
    }

    private void FixedUpdate()
    {
        _target = transform.position;

        //Esto es para que el GameObject Player persiga al mouse
        /*
        foreach(SterringBehaviour behaviour in _behaviourController.behaviours)
        {
            behaviour.Target = _target;
        }*/

        //Esto es para que los enemigos persigan al jugador
        if (enemies != null) AssignPositionToEnemies();
    }

    private void AssignPositionToEnemies()
    {
       foreach(SterringBehaviour enemies in enemies)
        {
            enemies.Target = _target;
        }
    }


}
