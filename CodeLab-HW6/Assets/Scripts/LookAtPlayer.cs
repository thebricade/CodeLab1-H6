using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class LookAtPlayer : MonoBehaviour
{
    public Transform LookPlayer;
    public float rotateSpeed; 
    
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 2; 
    }

    // Update is called once per frame
    void Update()
    {
        if (LookPlayer == null)
        {
            return;
        } // if there's nothing to look at don't go futher

        Vector3 forward = transform.position - LookPlayer.position;
        Quaternion targetRotation = Quaternion.LookRotation(forward);
        
        //slerp the information smooth
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
       // transform.rotation = new Vector3(forward);
    }
}
