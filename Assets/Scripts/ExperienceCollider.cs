using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceCollider : MonoBehaviour
{
    public Collider2D Collider;

    private void Start()
    {
        Collider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
