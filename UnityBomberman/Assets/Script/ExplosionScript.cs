using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField]
    private float lifespan;
    private float life;
    
    // Start is called before the first frame update
    void Start()
    {
        life = lifespan;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life > 0)
        {
            life -= Time.deltaTime;

        }
        else 
        {
            Expiration();
        }
    }

    private void Expiration()
    {
        //Destroy(gameObject);
    }

    
}
