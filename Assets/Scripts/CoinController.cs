using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    private GameController _gameController;


    private Rigidbody2D _moedasRB2D;

    // Start is called before the first frame update
    void Start()
    {

        _gameController = FindObjectOfType(typeof(GameController)) as GameController;

        _moedasRB2D = GetComponent<Rigidbody2D>();
        
        _moedasRB2D.velocity = new Vector2(-6f, 0); // Corrigido para velocity
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private void OnTriggerEnter2D(Collider2D collision) // Corrigido para Collider2D
    {
        if (collision.tag == "Player") // Adicionado bloco de chaves
        {

            _gameController.Pontos(1);

            Debug.Log("Pegou a moeda!");

            Destroy(this.gameObject);
        }
    }

     private void OnBecameInvisible()
   {
    Destroy(this.gameObject);

    Debug.Log("Pedraa moeda destruída!");

    }

}
