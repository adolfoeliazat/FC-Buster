using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class ShootProjectile : MonoBehaviour {
    

    // Projectile prefab with a RigidBody component
    public GameObject Projectile;
    GestureRecognizer recognizer;
    public float projectileTime = 1.0f;
    public float forceMultiplier = 20.0f;

    void Start()
    {
        recognizer = new GestureRecognizer();

        recognizer.TappedEvent += Recognizer_TappedEvent;

        recognizer.StartCapturingGestures();
    }

    private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        OnSelect();
    }

    private void Update()
    {
        //if (FizzyoDevice.Instance().ButtonDown() || Input.GetKeyDown(KeyCode.Space))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSelect();
        }
        
    }
    void OnSelect()
    {
        Debug.Log("OnSelect");
        Vector3 projectilePosition = Camera.main.transform.position + Camera.main.transform.forward * 0.45f;

        Vector3 projectileDirection = Camera.main.transform.forward;

        Shoot(projectilePosition, projectileDirection);
    }

    void Shoot(Vector3 start, Vector3 direction)
    {

        GameObject spawnedProjectile = (GameObject)Instantiate(Projectile);
        // Destroy the projectile after 3 secs.
        Destroy(spawnedProjectile, projectileTime);
        // set the projectile's starting location to be slightly in front of user
        spawnedProjectile.transform.position = start;

        // get the RigidBody to apply force to projectile
        Rigidbody rigidBody = spawnedProjectile.GetComponent<Rigidbody>();

        // apply force to the projectile          
        rigidBody.velocity = 20 * direction;

        // make the projectile spin
        rigidBody.angularVelocity = Random.onUnitSphere * forceMultiplier;
    }

    
}
