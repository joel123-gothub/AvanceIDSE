using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNave : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Transform transform;
    private AudioSource audiosource;
    
    public int vida;
    public float combustible;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        audiosource = GetComponent<AudioSource>();
        
        vida = 100;
        combustible = 100.0f;
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
            case "ColisionPeligrosa":
                vida -= 25;
                break;
            case "Combustible":
                combustible += 25f;
                combustible = combustible > 100 ? 100 : combustible;
                break;
            default:
                print("Perdiste...");
                break;
        }

    }

    private void ProcesarInput()
    {
        Propulsar();
        Rotar();

        if (vida <= 0)
        {
            print("Fin del juego");
        }
    }

    private void Propulsar()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (combustible > 0) {
                rigidbody.freezeRotation = true;
                combustible -= Time.deltaTime * 10.0f;
                rigidbody.AddRelativeForce(Vector3.up);
            }
            else {
                combustible = 0f;
            }
            
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
