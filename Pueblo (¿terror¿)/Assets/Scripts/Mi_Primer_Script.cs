using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mi_Primer_Script : MonoBehaviour
{
    //public float variable_float;
    //public int variable_entera;
    //public bool variable_logica;
    //[SerializeField]
    //private string variable_texto;
    public Transform _transform;
    public float x;
    public float y;
    public float z;
    private void Start() {

    }//MUESTRAS LO Q PASA EN LA VARIABLE INDICADA SOLO AL DAR PLAY

    private void Update() {
        _transform.position = new Vector3(  x,  y,  z);
    }//MUESTRA FRAME A FRAME LO Q PASA EN LA VARIABLE INDICADA
}
