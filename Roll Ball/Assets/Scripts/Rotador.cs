using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class Rotador : MonoBehaviour
{
    public Text textoTiempo, textoPerder;
    public int tiempo, aux;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15,30,45)*Time.deltaTime);
        aux++;
        tiempo=aux/100;
        textoTiempo.text = "Tiempo (segundos): " + (tiempo).ToString();

        if (tiempo >= 60)
        {
            textoPerder.text = "¡Game Over!";
            Thread.Sleep(5000);
            SceneManager.LoadScene("Menu");
        }
    }
}
