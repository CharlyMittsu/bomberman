using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MovableObject
{
    [SerializeField]
    private KeyCode _left ,_right, _up , _down, _leftMouse;
    [SerializeField]
    private GameObject bombPrefab1;
    private string facing;
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
            facing = "left";
        }
        if (Input.GetKey(_right))
        {
            Move("right");
            facing = "right";
        }
        if (Input.GetKey(_up))
        {
            Move("up");
            facing = "up";
        }
        if (Input.GetKey(_down))
        {
            Move("down");
            facing = "down";
        }
        if (Input.GetKeyDown(_leftMouse))
        {
            CreateBomb();
        }



    }
    private void CreateBomb()
    {
        Instantiate(bombPrefab1, getCoordinateFacing(), Quaternion.identity);

    }
    private Vector2 getCoordinateFacing()
    {
        Vector2 vector = new Vector2 (0,0);
        switch (facing)
        {
            case "left":
                vector = GetCoordinate() + Vector2.left;
                break;
            case "right":
                vector = GetCoordinate() + Vector2.right;
                break;
            case "up":
                vector = GetCoordinate() + Vector2.up;
                break;
            case "down":
                vector = GetCoordinate() + Vector2.down;
                break;
        }
        
        return vector;
    }
}
