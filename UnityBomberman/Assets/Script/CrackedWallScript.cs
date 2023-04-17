using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedWallScript : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            Destroy(gameObject);
        }
    }
}
    