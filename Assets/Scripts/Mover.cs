using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        //5.0f f because velocity does not accept double. 5f relates to the x so travels at +5 and 0 on the y.
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.0f);
    }
}
