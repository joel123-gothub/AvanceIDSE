using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNave : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //print("Hola");
        //Debug.Log(Time.deltaTime + "seg." + (1.0f/Time.deltaTime) + "FPS");

        ProcesarInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ColisionSegura":
                print("Colision segura...");
                break;
            case "Combustible":
                print("Combustible...");
                break;
            default:
                print("Perdiste...");
                break;
        }
        /*if (collision.gameObject.CompareTag("ColisionSegura"))
        {
            print("Colision segura...");
        }
        if (collision.gameObject.CompareTag("ColisionPeligrosa"))
        {
            print("Colision peligrosa...");
        }*/
    }

    private void ProcesarInput()
    {
        Propulsar();
        Rotar();
    }

    private void Propulsar()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.freezeRotation = true;
            //print("Propulsor...");
            rigidbody.AddRelativeForce(Vector3.up);
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
        }
        else
        {
            audiosource.Stop();
        }
        rigidbody.freezeRotation = false;
    }
    
    private void Rotar()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //print("Rotar a la izquierda...");
            //transform.Rotate(Vector3.forward);
            var rotarIzquierda = transform.rotation;
            rotarIzquierda.z += Time.deltaTime * 1;
            transform.rotation = rotarIzquierda;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(-Vector3.forward);
            var rotarDerecha = transform.rotation;
            rotarDerecha.z -= Time.deltaTime * 1;
            transform.rotation = rotarDerecha;
        }
    }
}
