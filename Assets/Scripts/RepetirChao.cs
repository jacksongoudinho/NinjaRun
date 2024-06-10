using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirChao : MonoBehaviour
{
    private GameController _gameController;
    public bool _chaoinstanciado = false;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_chaoinstanciado)
        {
            if (transform.position.x <= 0)
            {
                _chaoinstanciado = true;

                GameObject objetoTemporarioChao = Instantiate(_gameController._chaoPrefab);
                objetoTemporarioChao.transform.position = new Vector3(transform.position.x + _gameController._chaoTamanho, transform.position.y, 0);

                Debug.Log("O chão está sendo instanciado");
            }
        }

         if (transform.position.x < _gameController._chaoDestruido) { //-38
        Destroy(this.gameObject);
    }
}


    private void FixedUpdate()
    {
        MoveChao();
    }
   


    void MoveChao()
    {
        transform.Translate(Vector2.left * _gameController._chaoVelocidade * Time.deltaTime);
    }
}

