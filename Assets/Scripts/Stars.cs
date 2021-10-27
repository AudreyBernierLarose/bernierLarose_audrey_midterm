using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour

{
    private Rigidbody2D rBody;

    [SerializeField] private float velocity, waitFallTime;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rBody.velocity = new Vector3(rBody.velocity.x, velocity, 0.0f);
        StartCoroutine(WaitFallTime());
    }

    IEnumerator WaitFallTime()
    {
        yield return new WaitForSeconds(waitFallTime);
        rBody.velocity = new Vector3(0,0, 0.0f);
        rBody.gravityScale = 2;

    }
}
