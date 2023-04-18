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
        
        Instantiate(explosionPrefab,transform.position,Quaternion.identity,transform); 
        Debug.Log("EXPLOSION");

        ColorSR.a = 0;
        GetRangeExplosionLine(Vector2.left);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    private int GetRangeExplosionLine(Vector2 direction)
    {
        var position = GetCoordinate();
        int x;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, range, hitLayer);
        if (hit)
        {
             x = (int)Mathf.Floor(Vector2.Distance(position, hit.point)) ;
            if (hit.collider.tag== "MurCassable") { x++; }

            return x;
        }
        return range;
    }
   
}
