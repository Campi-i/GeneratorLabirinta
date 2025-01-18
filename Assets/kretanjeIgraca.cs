using UnityEngine;

public class kretanjeIgraca : MonoBehaviour
{
    private Rigidbody rb;
    public float brzina;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

    }

    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 kretanje = new Vector3 (horizontal, 0.0f, vertical).normalized;

        if(kretanje.magnitude > 0)
        {
            rb.MovePosition(rb.position + kretanje * brzina * Time.fixedDeltaTime);
        }
        
    }
}
