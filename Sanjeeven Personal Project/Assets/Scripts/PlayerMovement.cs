using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sideForce = 500;
    public SpawnManager spawnManager;

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if ( Input.GetKey("d") ){
            rb.AddForce(sideForce * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }//end if
        if ( Input.GetKey("a") ){
            rb.AddForce(-sideForce * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }//end if
        if(rb.position.y < -4f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }
}
