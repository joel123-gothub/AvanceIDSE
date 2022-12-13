using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public GameObject nave;
    public Vector3 posicion;
    // Start is called before the first frame update
    void Start()
    {
        posicion = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posicion = new Vector3(posicion.x, nave.transform.position.y, posicion.z);
        gameObject.transform.position = posicion;
    }
}
