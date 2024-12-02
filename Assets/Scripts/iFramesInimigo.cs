using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class iFramesInimigo : MonoBehaviour
{
    Renderer rend;
    Color c;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Projetil")){
            StartCoroutine("InvincibleForAWhile");
        }
    }
    

    IEnumerator InvincibleForAWhile(){
        Physics2D.IgnoreLayerCollision(6,7,true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(6,7,false);
        c.a = 1f;
        rend.material.color = c;
    }
}
