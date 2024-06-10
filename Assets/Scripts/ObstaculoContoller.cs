using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoContoller : MonoBehaviour
{
    private Rigidbody2D obstaculoRB;


    private GameController _GameController;
    private CameraShaker  _CameraShaker;


    // Start is called before the first frame update
    void Start()
    {
        
    obstaculoRB = GetComponent<Rigidbody2D>();

   // obstaculoRB .velocity = new Vector2(-5f, 0);

   _GameController = FindObjectOfType(typeof(GameController)) as GameController;

   _CameraShaker = FindObjectOfType(typeof(CameraShaker)) as CameraShaker;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

    MoveObjeto();

        
    }

    void MoveObjeto()

    {

    transform.Translate(Vector2.left * _GameController._ObstaculoVelocidade* Time.smoothDeltaTime);

    }

   void OnTriggerEnter2D(Collider2D collision)

   {
       if(collision.tag =="Player")

       {


       _GameController._vidasPlayer--;
        if( _GameController._vidasPlayer <=0)     
        {
           _GameController._txtVidas.text = "0";
           _GameController.GameOver();
           Debug.Log("Fim do jogo");
        }

        else {
        
        _GameController._txtVidas.text = _GameController._vidasPlayer.ToString();
         Debug.Log("Tocou no obstaculo");
           
         _CameraShaker.ShakeIt();


        }
  

       }


   }
    
    private void OnBecameInvisible()
   {
    Destroy(this.gameObject);

    Debug.Log("Pedra destruída!");

    }


}
