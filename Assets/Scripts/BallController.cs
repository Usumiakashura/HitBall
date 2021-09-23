using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    private Rigidbody rb;
    private float rotatePlayer;
    private bool rotate, collisionOn = false;
    private int numHits = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rotatePlayer % 360 != 0 && rotate)
        {
            if (rotatePlayer > 0)
                rb.AddForce(Vector3.left * rotatePlayer * 2, ForceMode.Impulse);
            else
                rb.AddForce(Vector3.right * rotatePlayer * -2, ForceMode.Impulse);
        }
    }

    public void Hit()
    {
        rotatePlayer = player.transform.rotation.y;
        
        if (numHits > 0 && rotatePlayer < 0.40f && rotatePlayer > -0.40f)
        {
            rb.AddForce(Vector3.up * 9f, ForceMode.Impulse);
            rb.AddForce(Vector3.forward * 40f, ForceMode.Impulse);

            if (rotatePlayer % 360 != 0)
            {
                rotate = true;
                if (rotatePlayer > 0)
                    rb.AddForce(Vector3.right * rotatePlayer * 60f, ForceMode.Impulse);
                else
                    rb.AddForce(Vector3.left * rotatePlayer * -60f, ForceMode.Impulse);
            }

            numHits--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rotate = false;
        if (!collisionOn && collision.gameObject.name != "Plane")
        {
            if (rotatePlayer > 0)
                rb.AddForce(Vector3.left * rotatePlayer * -20f, ForceMode.Impulse);
            else
                rb.AddForce(Vector3.right * rotatePlayer * 20f, ForceMode.Impulse);

            collisionOn = true;
        }
        
    }
}
