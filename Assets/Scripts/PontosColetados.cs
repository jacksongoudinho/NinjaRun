using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PontosColetados : MonoBehaviour
{
    public TextMeshProUGUI _txtPontosGameOver;

    void Start()
    {
        int pontos = PlayerPrefs.GetInt("Pontos", 0);
        _txtPontosGameOver.text = pontos.ToString();
    }
}
