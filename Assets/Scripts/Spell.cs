using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private int dano = 50;
    [SerializeField] GameObject vfxImpacto;


    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hit) {
        Inimigo_Vida inimigo = hit.GetComponent<Inimigo_Vida>();
        if (inimigo != null){
            inimigo.LevarDano(dano);
        }
        Instantiate(vfxImpacto,transform.position,transform.rotation);
        //Debug.Log(hit.name);
        Destroy(gameObject);
    }
}

  
