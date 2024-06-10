using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;


public class GameController : MonoBehaviour
{

    // Propriedades do chão
    [Header("Configuração do chão")]
    public float _chaoDestruido;
    public float _chaoTamanho;
    public float _chaoVelocidade;
    public GameObject _chaoPrefab;



    [Header("Configuração do Obstaculo")]

    public float _ObstaculoTempo;
    public GameObject _ObstaculoPrefab;
    public float _ObstaculoVelocidade;


    [Header("Configuração do coin - Moeda")]

    public float _coinTempo;
    public GameObject _coinPrefab;


    [Header("Configuração UI")]

    public int _pontosPlayer;
    public Text _txtPontos;
    public int _vidasPlayer;
    public Text _txtVidas;
    public Text _txtMetros;

    [Header("Controle de distancia")]

    public int _metrosPercorridos = 0;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("SpawnObstaculo");
        StartCoroutine("SpawnCoin");
        InvokeRepeating("DistanciaPercorrida", 0f, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnObstaculo()
    {
        yield return new WaitForSeconds(_ObstaculoTempo);

        GameObject ObjetoObstculoTemp = Instantiate(_ObstaculoPrefab);

        StartCoroutine("SpawnObstaculo");

        yield return new WaitForSeconds(1.5f);

        //instancia Moedas Coin
        StartCoroutine("SpawnCoin");

    }

    IEnumerator SpawnCoin()

    {

        int moedasaleatorias = Random.Range(1, 5);

        Debug.Log("moedas sorteadas: " + moedasaleatorias);

        for (int contagem = 1; contagem <= moedasaleatorias; contagem++)

        {
            yield return new WaitForSeconds(_coinTempo);

            GameObject _objetoSpawn = Instantiate(_coinPrefab);

            _objetoSpawn.transform.position = new Vector3(_objetoSpawn.transform.position.x, _objetoSpawn.transform.position.y, 0);

        }
    }


    public void Pontos(int _qtgPontos)

    {

        _pontosPlayer += _qtgPontos;
        _txtPontos.text = _pontosPlayer.ToString();
        PlayerPrefs.SetInt("Pontos", _pontosPlayer);

    }

    void DistanciaPercorrida()
    {

        _metrosPercorridos++;
        _txtMetros.text = _metrosPercorridos.ToString() + " m";
        PlayerPrefs.SetInt("DistanciaPercorrida", _metrosPercorridos);

        if ((_metrosPercorridos % 100) == 0)
        {
            _chaoVelocidade += 0.5f;
            _ObstaculoTempo -= 0.15f;
            _ObstaculoVelocidade += 0.15f;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void InstructionsScene()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Creditos()
    {
       SceneManager.LoadScene("Creditos");
    }

    public void CreditsScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
