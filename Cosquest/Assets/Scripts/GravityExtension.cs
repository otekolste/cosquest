using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityExtension : MonoBehaviour
{
    public static class CustomGravity
    {
        public static List<GravityExtension> sources = new List<GravityExtension>();
    }

    public bool useDefaultGravity = true;
    public Vector2 gravityDirection = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(gravityDirection * Time.deltaTime);
    }

    public Vector2 getGravity(Vector2 pos)
    {
        Vector2 g = Vector2.zero;
        return Vector2.zero;
    }
}
