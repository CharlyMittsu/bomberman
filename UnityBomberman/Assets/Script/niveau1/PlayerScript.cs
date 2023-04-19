using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MovableObject
{
    
    public int _bombRange;

    public int _pv;
    [SerializeField]
    private int maxPv;
    public float iFrame;
    [SerializeField]
    private float iFrameLength;
    [SerializeField]
    private LayerMask hitLayer;
    [SerializeField]
    private LayerMask hitLayerBomb;
    [SerializeField]
    private KeyCode _left ,_right, _up , _down, _leftMouse;
    [SerializeField]
    private BombScript bombPrefab1;
    [SerializeField]
    private Vector2 facing;

    private SpriteRenderer sr;
    [SerializeField]
    private GameObject textBegin;
    // Start is called before the first frame update
    void Start()
    {
        _pv = maxPv;
        sr = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine( Blinking());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_left))
        {
            Move("left");
            facing = Vector2.left;
        }
        if (Input.GetKey(_right))
        {
            Move("right");
            facing = Vector2.right;
        }
        if (Input.GetKey(_up))
        {
            Move("up");
            facing = Vector2.up;
        }
        if (Input.GetKey(_down))
        {
            Move("down");
            facing = Vector2.down;
        }
        if (Input.GetKeyDown(_leftMouse))
        {
            textBegin.SetActive(false);
            if (Check()) 
            { 
                Debug.Log("je suis face à un collider"); 
                
            }
            else
            {
                CreateBomb();
            }
            
        }
        
        if(iFrame > 0)
        {
            iFrame -= Time.deltaTime;
        }


    }
    private IEnumerator Blinking()
    {
        yield return new WaitForSeconds(0.1f);
        if (iFrame > 0)
        {
            Color defaultColor = sr.color;
            
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
            yield return new WaitForSeconds(0.1f);
            sr.color = defaultColor;
            
        }
        StartCoroutine(Blinking());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Explosion") && iFrame <= 0)
        {
            iFrame = iFrameLength;
            _pv -= 1;
            if(_pv <= 0)
            {
                //Debug.Log("Mort");
                SceneManager.LoadScene("DeathScreen");
            }
        }

    }
    private void CreateBomb()
    {
        
        BombScript bomb = Instantiate(bombPrefab1, getCoordinateFacing(), Quaternion.identity);
        bomb.range = _bombRange;

    }
    private bool Check()
    {
        RaycastHit2D hit = Physics2D.Raycast(GetCoordinate(), facing, 1,hitLayer);
        RaycastHit2D hitBomb = Physics2D.Raycast(GetCoordinate(), facing, 1, hitLayerBomb);
        Debug.DrawRay(GetCoordinate(), facing,Color.white,.2f);
        //Debug.Log(hit.transform.tag);
        
        //Debug.Log(hit.transform.tag );

        
        return hitBomb.collider || (hit.collider && (hit.collider.tag == "Mur"|| hit.collider.tag == "MurCassable"));
    }
    private Vector2 getCoordinateFacing()
    {
        Vector2 vector = GetCoordinate() + facing;
        
        return vector;
    }
}
