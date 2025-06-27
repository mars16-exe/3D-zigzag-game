using System;
using System.Collections;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    private Rigidbody parentRB;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentRB = GetComponentInParent<Rigidbody>();
        parentRB.useGravity = false;
        parentRB.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(CheckForBall(other));
    }

    private IEnumerator CheckForBall(Collider col)
    {
        yield return new WaitForSeconds(0.3f);
        
        if (col.CompareTag("Ball"))
        { 
            
            parentRB.useGravity = true;
            parentRB.isKinematic = false;
            
            Destroy(transform.parent.gameObject, 2f);
        }
    }
}
