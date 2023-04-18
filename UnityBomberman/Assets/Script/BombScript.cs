using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MovableObject
{
    [SerializeField]
    private LayerMask hitLayer;

    public int range;
    [SerializeField]
    private float lifespan;
    private float life;
    private bool dead;
    private Color ColorSR;
    [SerializeField]
    private GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        life = lifespan;
        ColorSR = gameObject.GetComponent<SpriteRenderer>().color;
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
        ColorSR.a = 0;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity, transform);
        CreateExplosionLine(Vector2.left);
        CreateExplosionLine(Vector2.right);
        CreateExplosionLine(Vector2.up);
        CreateExplosionLine(Vector2.down);
        yield return new WaitForSeconds(0.5f);
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
             x = (int)Mathf.Floor(Vector2.Distance(position, hit.point)) ;
            if (hit.collider.tag== "MurCassable") { 
                x++; 
            }
            
            //Debug.DrawRay(position, direction*x, Color.white, 0.5f);
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
   
}
