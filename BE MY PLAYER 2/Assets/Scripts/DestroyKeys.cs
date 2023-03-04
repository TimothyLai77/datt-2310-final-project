using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyKeys : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        print("aaaa");
        Destroy(other.gameObject);
    }
}
