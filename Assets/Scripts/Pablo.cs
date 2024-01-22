using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pablo : MonoBehaviour
{
    private Animator anim;
    public GameObject Pab;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    public Transform target;
    public int speed;
    public GameObject player;
    bool move = true;
    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            Vector3 localPosition = player.transform.position - transform.position;
            localPosition = localPosition.normalized; // The normalized direction in LOCAL space
            transform.Translate(localPosition.x * Time.deltaTime * -speed, localPosition.y * Time.deltaTime * -speed, localPosition.z * Time.deltaTime * -speed);
            transform.LookAt(target);
        }
        
    }
 
    IEnumerator Death()
    {
        anim.SetBool("Death", true);
        StartCoroutine(Dupe());
        yield return new WaitForSeconds(1);
        StartCoroutine(Dupe());
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    IEnumerator Dupe()
    {
        int randomNumber = Random.Range(30, 70);
        int randomNumber1 = Random.Range(30, 70);
        GameObject clone;
        clone = Instantiate(Pab);
        clone.transform.position = new Vector3(transform.position.x + randomNumber, transform.position.y +
        10f, transform.position.z + randomNumber1);
        yield return new WaitForSeconds(2);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Sword"))
        {
            StartCoroutine(Death());
            move = false;
        }
    }
}
