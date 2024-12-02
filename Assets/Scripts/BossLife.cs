using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public int maxHP = 100;
    public int hpAtual;
    public BarraDeVida healthBar;
    // Start is called before the first frame update
    void Start()
    {
        hpAtual = maxHP;
    }

    void LevarDano(int dano){

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
