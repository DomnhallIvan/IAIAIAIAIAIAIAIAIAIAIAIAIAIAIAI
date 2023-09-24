using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    [SerializeField] private LayerMask mousePlaneLayerMask;

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
        transform.position=GetPosition();

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

    //Static significa que solo pertenecer� a la clase en s� y no a ninguna instancia de la clase
    //El Raycast checa donde esta golpeando y regresar� el Vector3 o sea la posici�n.
    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }


}
