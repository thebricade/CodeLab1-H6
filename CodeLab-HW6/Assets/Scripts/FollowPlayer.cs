using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    public float speed = 1;  // how fast they come after you 

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();

        Quaternion newQuatDir = Quaternion.LookRotation(direction);

        float dotProduct = Vector3.Dot(direction, transform.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, newQuatDir, Time.deltaTime);
        rb.velocity = transform.forward * speed; 
    }
}
