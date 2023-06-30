using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
