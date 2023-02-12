using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10f;
    public float firstJumpForce = 20f;
    private int jumps = 0;
    private int maxJumps = 1;
    public ZoneDetector zoneDetector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           if(jumps == 0)
            {
                rb.velocity = Vector3.up * firstJumpForce;
                jumps++;
            }
           else if (jumps > 0 && jumps < maxJumps)
           {
                rb.velocity = Vector3.up * jumpForce;
                jumps++;
            }
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * Time.deltaTime;
        }
        Debug.Log(jumps);

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            jumps = 0;
        }
        if (other.gameObject.tag == "HabDobleSalto")
        {
            maxJumps = 5;
        }
    } 

}




