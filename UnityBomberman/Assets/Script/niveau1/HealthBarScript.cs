using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    private PlayerScript player;
    [SerializeField]
    private List<Sprite> sp;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        sr.enabled = player.iFrame > 0;
        
        //Debug.Log(player._pv);
        if(player._pv > 0)
        {
            sr.sprite = sp[player._pv-1];
        }
        
    }
}
