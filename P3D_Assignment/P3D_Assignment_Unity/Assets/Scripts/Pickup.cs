using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    [SerializeField] private GameObject guide;
    [SerializeField] private GameObject ball;
    [SerializeField] private float throwForce = 30f;
    [SerializeField] private GameObject insPanel;
    [SerializeField] private GameObject pickIns;
    [SerializeField] private GameObject throwIns;
    [SerializeField] private Vector3 targetTextPos;
    [SerializeField] private Vector3 originalTextPos;

    private RectTransform textPos;
    private Rigidbody ballrb;
    private bool isHolding = false;


    private void Start()
    {
        ballrb = ball.GetComponent<Rigidbody>();
        textPos = throwIns.GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        if (isHolding)
        {
            textPos.anchoredPosition = targetTextPos;
            pickIns.SetActive(false);
            ballrb.useGravity = false;
            ballrb.velocity = Vector3.zero;
            ballrb.angularVelocity = Vector3.zero;

            ball.transform.position = guide.transform.position;

            if (Input.GetMouseButtonDown(0))
            {
                isHolding = false;
                ballrb.useGravity = true;
                ballrb.AddForce(guide.transform.forward * throwForce);
                textPos.anchoredPosition = originalTextPos;
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")  
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                isHolding = true;
            }   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            textPos.anchoredPosition = originalTextPos;
            pickIns.SetActive(true);
            insPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            insPanel.SetActive(false);
        }
    }
}

