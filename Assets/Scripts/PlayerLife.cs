using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class PlayerLife : MonoBehaviour
{
    public Animator animator;
    public static int hp = 3; //quantidade de hits que pode tomar antes de perder uma via
    public GameObject hit1, hit2, hit3;
    public int vidas = 3;//se chegar a 0 = gameover
    [SerializeField] private TextMeshProUGUI contadorVidas;

    // Start is called before the first frame update
    void Start()
    {
        hit1.gameObject.SetActive(true);
        hit2.gameObject.SetActive(true);
        hit3.gameObject.SetActive(true);
    }

    public void PlayerHitPoints(int i)
    {
        //Controle de HP do jogador
        switch (i)
        {
            case 3:
                hit1.gameObject.SetActive(true);
                hit2.gameObject.SetActive(true);
                hit3.gameObject.SetActive(true);
                break;

            case 2:
                hit1.gameObject.SetActive(true);
                hit2.gameObject.SetActive(true);
                hit3.gameObject.SetActive(false);
                break;

            case 1:
                hit1.gameObject.SetActive(true);
                hit2.gameObject.SetActive(false);
                hit3.gameObject.SetActive(false);
                break;

            case 0:
                hit1.gameObject.SetActive(false);
                hit2.gameObject.SetActive(false);
                hit3.gameObject.SetActive(false);
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D detect)
    {
        if (vidas <= 0)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (detect.CompareTag("Obstaculo") && hp > 0)
        {
            animator.SetBool("isHit", true);
            hp -= 1;
            PlayerHitPoints(hp);
            StartCoroutine("Hurt");
        }
        else
        {
            vidas = Int32.Parse(contadorVidas.text) - 1;
            contadorVidas.text = vidas.ToString();
            hp = 3;
            animator.SetBool("isDead", true);
            PlayerHitPoints(hp);
            StartCoroutine("Death");
        }
    }
    
IEnumerator Hurt()
    {

        yield return new WaitForSeconds(1f); 
        animator.SetBool("isHit",false);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        
        animator.SetBool("isDead",false);
    }

}

