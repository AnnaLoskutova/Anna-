using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionConponent : MonoBehaviour
{
    [SerializeField] private UnityEvent OnCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged")
            return;

        OnCollision.Invoke();
    }
}
