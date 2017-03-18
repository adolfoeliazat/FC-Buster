using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private float breathPressureCounter = 0f;
    private float minPressure = 0.5f;
    private float minTimeToHold = 15;
    private float pressureNotExhaling = 0.05f;
    // TODO: probably shouldn't be using statics...
    public static int maxNumShotsPerBreath = 3;
    private static int numShotsLeft = maxNumShotsPerBreath;
	// Use this for initialization
    // TODO: Handle MaxFizzyo Pressure like in the example.
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float pressure = FizzyoDevice.Instance().Pressure();
        Debug.Log(pressure.ToString());
        if (pressure <= pressureNotExhaling)
        {
            breathPressureCounter = 0;
            numShotsLeft = maxNumShotsPerBreath;
        } else if (pressure >= minPressure)
        {
            breathPressureCounter++;
        }
    }

    //Singleton
    private static PlayerManager instance;
    private static object threadLock = new System.Object();
    public static PlayerManager Instance()
    {
        if (instance == null)
        {
            lock (threadLock)
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<PlayerManager>();
                }
            }
        }
        return instance;
    }

    public bool CanShoot()
    {
        Debug.Log(breathPressureCounter);
        if (breathPressureCounter >= minTimeToHold && numShotsLeft > 0)
        {
            numShotsLeft--;
            return true;
        }
        {
            return false;
        }
    }
}
