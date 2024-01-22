using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(kill());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator kill()
    {
        yield return new WaitForSeconds(0.5f); 
        Destroy(gameObject);
    }
}
