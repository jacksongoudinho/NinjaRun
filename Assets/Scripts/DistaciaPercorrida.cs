using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistaciaPercorrida : MonoBehaviour
{

    public TextMeshProUGUI _txtMetrosGameOver;

    void Start()
    {
       int metrosPercorridos = PlayerPrefs.GetInt("DistanciaPercorrida", 0);
       _txtMetrosGameOver.text = metrosPercorridos.ToString() + " m";
    }
}
