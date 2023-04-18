using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public List<CrackedWallScript> _list = new List<CrackedWallScript>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _list.Count; i++)
        {
            _list[i].gameObject.SetActive(true);//activer tout les mur cassable
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
