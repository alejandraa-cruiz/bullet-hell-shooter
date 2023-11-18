using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    //Variables de movimiento
    public float speed = 2.0f;
    public float horizontalInput;
    public float forwardInput;


    /// <summary>
    /// This method is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// This method is called once per frame. Allows player to move the vehicle using the keyboard.
    /// The vehicle will move forward, backward and rotate.
    /// <example>
    /// By using Traslate and Transform methods:
    /// <code>
    /// transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
    /// transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    /// </code>
    /// results in <c>player</c> movement.
    /// </example>
    /// </summary>
    void Update()
    {
        //Llamar el input con el nombre en el Input Manager
        //Obtiene el valor del teclado
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Mover vehiculo hacia adelante
        //transform.Translate(0,0,1);
        // Time.deltatime realentiza la velocidad del objeto de acuerdo
        // a los fotogramas del juego
        //El forwardInput hace que el vehiculo se mueva hacia adelante presionando la tecla de arriba o abajo
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        
        //Translate hace que solo se traslade der o izq y queremos que gire
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        
    }
}
