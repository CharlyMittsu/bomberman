using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallManager : MonoBehaviour
{
    public List<CrackedWallScript> _list = new List<CrackedWallScript>();

    public List<GemsScript> _gemMax;
    public int _collectedGem = 0;
    // Start is called before the first frame update

    
    void Start()
    {
        for (int i = 0; i < _gemMax.Count; i++)
        {
            var x = Random.Range(0, _list.Count);
            _gemMax[i].transform.position = _list[x].GetCoordinate();
            _gemMax[i].transform.position = new Vector3(_gemMax[i].transform.position.x, _gemMax[i].transform.position.y, 1);
            _list[x].gameObject.SetActive(true);
            _list.RemoveAt(x);
        }
        for (int i = 0; i < _list.Count; i++)
        {
            _list[i].gameObject.SetActive(true);//activer tout les mur cassable
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GemScrore()
    {
        _collectedGem++;
        if (_collectedGem >= _gemMax.Count)
        {
            StartCoroutine(Win());
            
        }
    }
    private IEnumerator Win()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("WinScreen");
    }
}
