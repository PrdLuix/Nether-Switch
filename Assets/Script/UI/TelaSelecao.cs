﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaSelecao : MonoBehaviour
{
    private GameObject[] players;
    float tempo;
    public static Dictionary<int, string> teclasEscolhidas = new Dictionary<int, string>();

    public void Game(string cena)
    {
        players = GameObject.FindGameObjectsWithTag("Caixa");
        foreach (var i in players)
        {
            var temp = i.GetComponent<CaixaPlayer>();
            if (temp.ativado)
                teclasEscolhidas.Add(temp.id, temp.txt_teclaEscolhida.text);
        }
        StartCoroutine("Esperar", cena);

    }
        IEnumerator Esperar(string cena)
        {
            UI ui = this.GetComponent<UI>();
            tempo = 2;
            ui.Fades(false, tempo, Random.Range(0, 2));
            yield return new WaitForSeconds(tempo);
            SceneManager.LoadScene(cena);
        }
}
