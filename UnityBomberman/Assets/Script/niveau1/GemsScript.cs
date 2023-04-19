using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GemsScript : MonoBehaviour
{
    
    public UnityEvent ToLaunchOnTrigger;
    public Collider2D _hitBox;
    [SerializeField]
    private GameObject UIPoint;
    private Vector3 startPosition;
    private Vector3 destination;
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private float animSpeed;
    private float delta;

    [SerializeField]
    private WallManager manager;
    

    private bool pickedUp = false;

    private void Start()
    {
        
    }
    void Update()
    {
        
        if (pickedUp)
        {
            
            
            
            delta += Time.deltaTime*animSpeed;
            if (delta > 1) { delta = 1; }
            var x = Mathf.Lerp(startPosition.x, destination.x, curve.Evaluate(delta));
            var y = Mathf.Lerp(startPosition.y, destination.y, curve.Evaluate(delta));
            var z = Mathf.Lerp(startPosition.z, destination.z, curve.Evaluate(delta));
            transform.position = new Vector3(x, y, z);
                

            
            
        }
        if(delta >= 1) { pickedUp = false; }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ToLaunchOnTrigger.Invoke();
            _hitBox.enabled = false;
            startPosition = transform.position;
            switch (manager._collectedGem)
            {
                case 1:
                    destination = UIPoint.transform.position;
                    break;
                case 2:
                    destination = new Vector3(UIPoint.transform.position.x, UIPoint.transform.position.y - 2, UIPoint.transform.position.z);
                    break;
                case 3:
                    destination = new Vector3(UIPoint.transform.position.x, UIPoint.transform.position.y - 4, UIPoint.transform.position.z);
                    break;
            }
            delta = 0;
            pickedUp = true;
            //Destroy(gameObject);
        }

    }
    private void GoInUi()
    {
        
        
    }
}
