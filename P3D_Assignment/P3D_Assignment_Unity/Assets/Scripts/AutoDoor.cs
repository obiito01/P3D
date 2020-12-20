using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    
    [SerializeField] private float upForce = 0.05f;
    [SerializeField] private float upDistance = 3f;
    private bool isOpen = false;
    private Vector3 targetPos;
    private Vector3 currentPos;

    private void Start()
    {
        currentPos = transform.position;
    }
    private void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, upForce);
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, currentPos, upForce);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            targetPos = currentPos + Vector3.up * upDistance;
            isOpen = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isOpen = false;

        }
    }
}
