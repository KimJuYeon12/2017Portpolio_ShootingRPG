using UnityEngine;
using System.Collections;

/// <summary>
/// Basic demo script to randomly emit steam particles from assigned emitters.
/// </summary>
public class DemoRandomSteamEmitter : MonoBehaviour
{

    public ParticleEmitter[] emitters;

	// Use this for initialization
	void Start ()
	{
	    InvokeRepeating("EmitSteam", 0.1f, 2f);
	}

    void EmitSteam()
    {
        StartCoroutine(EmitSteamDelay());
    }

    IEnumerator EmitSteamDelay()
    {
        var randomEmitterIndex = Random.Range(0, emitters.Length);
        if (emitters[randomEmitterIndex] != null)
        {
            emitters[randomEmitterIndex].emit = true;
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
            emitters[randomEmitterIndex].emit = false;
        }

        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
