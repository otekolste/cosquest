using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CustomGravityRigidbody : MonoBehaviour
{
    Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
}