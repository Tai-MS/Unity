using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller : MonoBehaviour
{

    [Header("Configuracion de la camara")]
    #region  Variables de la camara

    public Camera _camara;

    public float rotacionMinima;

    public float rotacionMaxima;

    public float sensibilidadMouse;

    [SerializeField]
    private float CamMovVertical;

    [SerializeField]
    private float CamMovHorizontal;

    #endregion

    [Header("Configuracion del movimiento")]
    #region Variables Movimiento

    public CharacterController _characterController;

    public float gravedad;

    public float velocidadCaminar;

    public float velocidadCorrer;

    public float fuerzaSalto;

    public KeyCode tecladoSalto;

    public Vector3 _velocidad;

    public GameObject pies;

    public LayerMask layerSuelo;

    public float radioPiesColision;

    #endregion

    [Header("Configuracion Disparo")]
    #region Variables Disparo

    public SistemaDeDisparo _sistemaDeDisparo;

    #endregion

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked; //.none o .locked o .confined
    }

    private void Update() {
        #region Rotacion de la camara

        CamMovVertical +=  Input.GetAxis("Mouse Y") * sensibilidadMouse;
        //CamMovVertical = CamMovVertical + Input.GetAxis("Mouse Y") * sensibilidadMouse; OTRA FORMA DE HACERLO

        CamMovHorizontal =  Input.GetAxis("Mouse X") * sensibilidadMouse;  

        CamMovVertical = Mathf.Clamp(CamMovVertical, rotacionMinima, rotacionMaxima);

        _camara.transform.localRotation =   
            Quaternion.Euler (
                -CamMovVertical, //CamMovVertical * (-1) O CamMovVertical = CamMovVertical * (-1) otra forma de hacer lo mismo
                0f,    
                0f
             );

        transform.Rotate(0f, CamMovHorizontal, 0f);   
        //transform.localRotation = Quaternion.Euler(0f, CamMovHorizontal, 0f);  
        #endregion
    

        #region Movimiento y Salto del Personaje

        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * movHorizontal + transform.forward * movVertical * 4;
        

        float velocidad = 0f;

        if(Input.GetKey(KeyCode.LeftShift) ){//si al principio de la condicion pongo "!" invierte el valor de la condicion
           velocidad = velocidadCorrer; 
        }
        else{
            velocidad= velocidadCaminar;
        }


        _characterController.Move(movimiento * velocidad * Time.deltaTime);


        bool sobreLaTierra = Physics.CheckSphere(pies.transform.position, radioPiesColision, layerSuelo);
        if(sobreLaTierra && _velocidad.y < 0 )
            _velocidad.y = -2f;
        
        //
        if(Input.GetKey(tecladoSalto) && sobreLaTierra)
            _velocidad.y = Mathf.Sqrt(fuerzaSalto * -2f * gravedad);
        
        _velocidad.y += gravedad * Time.deltaTime;

        _characterController.Move(_velocidad * Time.deltaTime);

        #endregion

        #region Disparo del personaje
        if(Input.GetMouseButtonDown( 0 ) )
            _sistemaDeDisparo.Disparar();
        #endregion
    }
}
