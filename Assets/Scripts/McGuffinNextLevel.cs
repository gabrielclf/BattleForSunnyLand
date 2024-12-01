using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class McGuffinNextLevel : MonoBehaviour
{//O jogador Ao tocar esses itens (porta, gemas) fará um menu aparecer que lhe irá teleportar para a proxima cena/nivel

    private int cenaAtual;
    public GameObject proximafase;


    
    void Awake()
    {
        cenaAtual = SceneManager.GetActiveScene().buildIndex;
    }


    //SceneManager.LoadScene(cenaAtual+1);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MenuPausa.JogoPausado = true;
            Time.timeScale = 0f;
            proximafase.SetActive(true);
        }
    }

    public void AvancarFase(){
        SceneManager.LoadScene(cenaAtual+1);
    }
}
