using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Shipcontroller : MonoBehaviour
{
    public float HF;
    public float LR;
		private Rigidbody rb;
    public Boundary bound;
    public GameObject laser;
    public Transform shotspawn;
    public float fireRate;
    private float nextFire;

    void Start()
    {
	     rb = GetComponent<Rigidbody>();
    }

    void update()
    {
      if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(laser, shotspawn.position, shotspawn.rotation);
          }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 move = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.velocity = move * HF;

        rb.position = new Vector3
        (
            Mathf.Clamp (rb.position.x, bound.xMin, bound.xMax),
            0.0f,
            Mathf.Clamp (rb.position.z, bound.zMin, bound.zMax)
        );

        rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -LR);
    }
}
