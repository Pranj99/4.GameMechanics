using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playeRb;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    private float powerupStrength = 10.0f;
    public GameObject powerupInidicator;
    // Start is called before the first frame update
    void Start()
    {
        playeRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playeRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupInidicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupInidicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownroutine()        );
        }
    }

    IEnumerator PowerupCountDownroutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupInidicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + " with Powerup set to " + hasPowerup);
        }
    }
}
