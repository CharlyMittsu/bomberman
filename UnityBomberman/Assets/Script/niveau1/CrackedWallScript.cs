using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedWallScript : MonoBehaviour
{
    
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Explosion"))
        {
            Destroy(gameObject);
        }
        
    }
}
    