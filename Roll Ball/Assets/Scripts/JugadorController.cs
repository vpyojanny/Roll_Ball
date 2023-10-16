using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class JugadorController : MonoBehaviour
{
    private Rigidbody rb;
    private int contador;
    public Text textoContador, textoGanar;
    public float velocidad;
    public AudioClip monedas;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        contador = 0;
        setTextoContador();
        textoGanar.text = "";


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

        rb.AddForce(movimiento*velocidad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador++;
            setTextoContador();
        }
    }

    void setTextoContador()
    {
        textoContador.text = "Contador: " + contador.ToString();
        AudioSource.PlayClipAtPoint(monedas, transform.position);

        if (contador >= 12)
        {
            textoGanar.text = "¡Ganaste!";
        }
    }
}
