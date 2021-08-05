using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeDisparo : MonoBehaviour
{
    public bool raycastMode;

    public float valorDeDAño;

    public GameObject prefabDeBala;

    public Transform arma;

    public float fuerzaDeDisparo;

    public void Disparar(){
        if(raycastMode){
            
            RaycastHit hit;
            if( Physics.Raycast(transform.position, transform.forward, out hit) ){

                Debug.DrawRay(transform.position, transform.forward * 100f, Color.green);

                if(hit.transform.CompareTag("Disparable"))
                    hit.transform.GetComponent<Sistema_de_Vida>().RestarVida(valorDeDAño);
            }
        }
        else{
            GameObject bala = GameObject.Instantiate(prefabDeBala, arma.transform.position, Quaternion.identity);
            bala.GetComponent<Rigidbody>().AddForce(arma.transform.forward * fuerzaDeDisparo, ForceMode.Impulse);
        }   
    }                     
}
