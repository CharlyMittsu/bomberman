using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
         startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            StopAllCoroutines();
            start = false;
            StartCoroutine(Shaking());
        }
    }
    private IEnumerator Shaking()
    {
        
        float elapsedtime = 0f;

        while (elapsedtime < duration)
        {
            elapsedtime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedtime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;
    }
    private void Shake()
    {
        start = true;
    }
    
}
