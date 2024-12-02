using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Vida : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public int maxHP = 20;
    public int hpAtual;
    public BarraDeVida healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        hpAtual = maxHP;
        healthBar.setMaxHealth(maxHP);
    }
    public GameObject defeat,proxFase;
    
    public void LevarDano (int danoLevado){
        anim.SetBool("isHit",true);
        hpAtual -= danoLevado;
        healthBar.SetHealth(hpAtual);
        StartCoroutine("Hurt");
        if (hpAtual <= 0 ){
            Morre();
        }
        
    }

    IEnumerator Hurt()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("isHit",false); 
        
    }

    void Morre()
    {
        anim.SetBool("isDead",true);
        //Instantiate(defeat,transform.position, Quaternion.identity);
        StartCoroutine("Dead");
        proxFase.SetActive(true);
    }
    IEnumerator Dead(){

        yield return new WaitForSeconds(1f);
        defeat.SetActive(false);
        

    }
}
