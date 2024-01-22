using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject hitbox;
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Stabby());
        }
        
    }
    IEnumerator Stabby()
    {
        GameObject clone;
        clone = Instantiate(hitbox);
        clone.transform.position = target.position;
        yield return new WaitForSeconds(2.1f);
    }
}
