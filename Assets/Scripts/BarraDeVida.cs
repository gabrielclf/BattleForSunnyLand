using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider sliderr;

    public void setMaxHealth(int vida){
        sliderr.maxValue = vida;
        sliderr.value = vida;
    }
    
    public void SetHealth(int vida){
        sliderr.value = vida;
    }
}
