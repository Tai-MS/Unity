using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistema_de_Vida : MonoBehaviour
{
    [SerializeField]
    private float vidaMaxima;
    [SerializeField]
    public float vidaActual;

    //NO SE PORQ HACE Q EL CUBO SE DESTRUYA DE UNA
    //private void Start() {
    //    vidaActual = vidaMaxima;
    //}

    public void RestarVida(float value){
        vidaActual -= value;

        if(vidaActual <= 0){
            Destroy(this.gameObject);
        }
    }
}
