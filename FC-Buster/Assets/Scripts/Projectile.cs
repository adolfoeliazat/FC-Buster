using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    /// Tracks max lifetime of the projectile
    public float MaxLifetime = 3;
    protected bool firstContact = false;


    // Use this for initialization
    void Start () {
        Debug.Log("New projectile");
    }
	
	// Update is called once per frame
	void Update () {
        UpdateProjectile();
    }

    void UpdateProjectile()
    {
        //// If the projectile hasn't hit something, check for time out.
        //if (firstContact == false)
        //{
        //    if (Time.time - StartTime > MaxLifetime)
        //    {
        //        // If we 'time out' just pretend that we hit something.
        //        firstContact = true;
        //    }
        //}
        //else
        //{
        //    // Destroy the projectile.
        //    Destroy(this.gameObject);
        //}
    }
}
