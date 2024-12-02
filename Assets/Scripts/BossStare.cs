using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStare : MonoBehaviour
{
    public Transform player;

    public bool isFlip = false;

    public void LookAtPlayer(){
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlip){
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            isFlip = false;
        } else if (transform.position.x < player.position.x && !isFlip){
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            isFlip = true;
        }
    }
}
