using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    [SerializeField] private LayerMask mousePlaneLayerMask;

    //Esto es para el Pursuit
    public Vector3 previousPosition;
    //public Vector3 futurePos;
    public Vector3 velocity;

    //Esto es para el Seek
    private Vector3 _target;
    private BehaviourController _behaviourController;
    public List<SterringBehaviour> enemies=new List<SterringBehaviour>();

    private void Awake()
    {
        _behaviourController = gameObject.GetComponent<BehaviourController>();
        instance = this;
        
    }

    private void FixedUpdate()
    {

        previousPosition = transform.position;

        transform.position=GetPosition();

        velocity = (transform.position - previousPosition) / Time.deltaTime;

        _target = GetPosition();

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

    //Static significa que solo pertenecerá a la clase en sí y no a ninguna instancia de la clase
    //El Raycast checa donde esta golpeando y regresará el Vector3 o sea la posición.
    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray , out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return new Vector3(raycastHit.point.x,2,raycastHit.point.z);
    }



}
