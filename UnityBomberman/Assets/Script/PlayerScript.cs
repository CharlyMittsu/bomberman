using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MovableObject
{
    [SerializeField]
    private LayerMask hitLayer;
    [SerializeField]
    private KeyCode _left ,_right, _up , _down, _leftMouse;
    [SerializeField]
    private GameObject bombPrefab1;
    [SerializeField]
    private Vector2 facing;
    // Start is called before the first frame update
    void Start()
    {
        
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
            if (Check()) 
            { 
                Debug.Log("je suis face à un collider"); 
                
            }
            else
            {
                CreateBomb();
            }
            
        }



    }
    private void CreateBomb()
    {
        Instantiate(bombPrefab1, getCoordinateFacing(), Quaternion.identity);

    }
    private bool Check()
    {
        RaycastHit2D hit = Physics2D.Raycast(GetCoordinate(), facing, 1,hitLayer);
        Debug.DrawRay(GetCoordinate(), facing,Color.white,.2f);
        //Debug.Log(hit.transform.tag);
        
        //Debug.Log(hit.transform.tag );

        
        return hit.collider && (hit.collider.tag == "Mur"|| hit.collider.tag == "MurCassable");
    }
    private Vector2 getCoordinateFacing()
    {
        Vector2 vector = GetCoordinate() + facing;
        Debug.Log(vector);
        return vector;
    }
}
