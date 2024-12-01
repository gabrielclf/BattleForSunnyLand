using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int hp = 10;
    public GameObject defeat;
    
    public void LevarDano (int danoLevado){
        hp -= danoLevado;
        if (hp <= 0 ){
            Morre();
        }
    }

    void Morre()
    {
        Instantiate(defeat,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
