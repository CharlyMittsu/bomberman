using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombScript : MovableObject
{
    [SerializeField]
    private LayerMask hitLayer;

    public int range;
    [SerializeField]
    private float lifeSpan;
    [SerializeField]
    private float explosionLifeSpan;
    private float life;
    private bool dead;
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private GameObject explosionPrefab;

    

    // Start is called before the first frame update
    void Start()
    {
        life = lifeSpan;
        sr = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(TicTac());
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
    private IEnumerator TicTac()
    {
        
        var x = 0.5f;
        if (life < 1) { x = 0.1f; }
        yield return new WaitForSeconds(x);
        sr.color = Color.red;
        yield return new WaitForSeconds(x);
        sr.color = Color.black;
        StartCoroutine(TicTac());
    }
    private IEnumerator BlowUp()
    {
        
        
        
        sr.enabled = false;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity, transform);
        CreateExplosionLine(Vector2.left);
        CreateExplosionLine(Vector2.right);
        CreateExplosionLine(Vector2.up);
        CreateExplosionLine(Vector2.down);
        yield return new WaitForSeconds(explosionLifeSpan);
        Destroy(gameObject);
    }
    private int GetRangeExplosionLine(Vector2 direction)
    {
        var position = GetCoordinate();
        int x;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, range, hitLayer);
        Debug.DrawRay(position, direction * range, Color.green, 0.5f);

        if (hit)
        {
            x = (int)Mathf.Floor(Vector2.Distance(position, hit.point));
                //Debug.Log(hit.collider.tag);
            
            if (hit.collider.tag== "MurCassable") { 
                x++; 
            }
            
            
            return x;
        }
        return range;
    }
    private void CreateExplosionLine(Vector2 direction)
    {
        var length = GetRangeExplosionLine(direction);
        
        if (length == 0) { return; }
        for (int i = 1; i < length+1; i++)
        {
            Vector3 vector = (direction * i);
            Instantiate(explosionPrefab, transform.position + vector, Quaternion.identity, transform);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Explosion"))
        {
            life = 0;
        }

    }

}
