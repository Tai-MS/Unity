using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeDaño : MonoBehaviour
{
    public float valor;

    private void OnCollisionEnter(Collision objeto) {

        if(objeto.transform.CompareTag("Disparable") ){
            //objeto.transform.GetComponent<Sistema_de_Vida>().vidaActual -= valor; 
            //objeto.transform.GetComponent<Sistema_de_Vida>().vidaActual = objeto.transform.GetComponent<Sistema_de_Vida>().vidaActual - valor;
            //objeto.transform.GetComponent<Sistema_de_Vida>().RestarVida(valor);
            objeto.transform.GetComponent<Sistema_de_Vida>().RestarVida(valor);
        }
    }

    private void OnCollisionStay(Collision other) {
    }

    private void OnCollisionExit(Collision other) {
    }



    private void OnTriggerEnter(Collider objeto) {
        if(objeto.CompareTag("Disparable") ){
            objeto.GetComponent<Sistema_de_Vida>().RestarVida(valor);
        }
    }

    private void OnTriggerStay(Collider other) {

    }

    private void OnTriggerExit(Collider other) {

    }
}
