using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public void Move(string direction)
    {
        Debug.Log(direction);
        switch (direction)
        {
            case "left":
                transform.position += Vector3.left * Time.deltaTime * speed;
                break;
            case "right":
                transform.position += Vector3.right * Time.deltaTime * speed;
                break;
            case "up":
                transform.position += Vector3.up * Time.deltaTime * speed;
                break;
            case "down":
                transform.position += Vector3.down * Time.deltaTime * speed;
                break;
        }
    }
    public void ChangeSpeed(float newSpeed)
    {
        if (newSpeed >= 0){speed = newSpeed;}
 
    }
    public void AddSpeed (float moreSpeed)
    {
        speed += moreSpeed;
        if (speed < 0) { speed = 0; }
    }
    public Vector2 GetCoordinate()
    {
        float x= Mathf.Round(transform.position.x);
        float y= Mathf.Round(transform.position.y);

        Vector2 vector = new Vector2(x,y);
        //Debug.Log(vector);
        return vector;
    }
}
