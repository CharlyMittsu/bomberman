using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField]
    private float lifespan;
    private float life;
    private bool dead;
    // Start is called before the first frame update
    void Start()
    {
        life = lifespan;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (life > 0) {
            life -= Time.deltaTime;
            
        }
        else if (dead !=true)
        {
            dead = true;
            StartCoroutine(BlowUp());
        }
    }
    private IEnumerator BlowUp()
    {
        Debug.Log("EXPLOSION");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Destroy");
        if (collision.gameObject.tag == "Mur")
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }
}
