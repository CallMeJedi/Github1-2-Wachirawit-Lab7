using UnityEngine;

public class Plane : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] float EnginePower = 20f;
    [SerializeField] float liftBooster = 0.5f;
    [SerializeField] float Drag = 0.001f;
    [SerializeField] float AngularDrag = 0.001f;
    [SerializeField] float YawPower = 50f;
    [SerializeField] float pitchPower = 50f;
    [SerializeField] float rollPower = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce((transform.forward * EnginePower));
        }

        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        rb.linearDamping = rb.linearVelocity.magnitude * Drag;
        rb.angularDamping = rb.angularVelocity.magnitude * AngularDrag;

        float yaw = Input.GetAxis("Horizontal") * YawPower;
        float pitch = Input.GetAxis("Vertical") * pitchPower;
        float roll = Input.GetAxis("Roll") * rollPower;
        
        rb.AddTorque(transform.up * yaw);
        rb.AddTorque(transform.right * pitch);
        rb.AddTorque(transform.forward * roll);


    }
}
