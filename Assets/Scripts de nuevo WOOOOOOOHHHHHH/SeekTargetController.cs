using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTargetController : MonoBehaviour
{
    //Desde Aquí se encuentra el Target y se asigna para el SeekBehaviour
    public Transform transformT;
    public SeekBehaviour seek;

    // Start is called before the first frame update
    void Start()
    {
        transformT = GameObject.FindWithTag("Target").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transformT)
        {
            seek.Target = transformT.position;
        }
    }
}
