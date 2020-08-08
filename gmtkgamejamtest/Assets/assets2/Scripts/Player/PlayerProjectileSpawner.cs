using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerProjectileSpawner : MonoBehaviour {
    
	[Header("Spawner Settings")]
	public GameObject projectilePrefab;
	public Transform spawnPoint;

	public float spawnRate;
	private float timer;
    public float bullet_fwd_force = 350f;

	[Header("Particles")]
	public ParticleSystem spawnParticles;


	[Header("Audio")]
	public AudioSource spawnAudioSource;

    PlayerInputActions inputAction;

   

    private void Awake()
    {
        inputAction = new PlayerInputActions();
        inputAction.PlayerControls.FireDirection.performed += ctx => Shoot();
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

  
   
	

	void Shoot()
	{
        GameObject handler;
        handler = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Rigidbody temp_rigidbody;
        temp_rigidbody = handler.GetComponent<Rigidbody>();
        temp_rigidbody.AddForce(handler.transform.forward * bullet_fwd_force);

		if(spawnParticles)
		{
			spawnParticles.Play();
		}

		if(spawnAudioSource)
		{
			spawnAudioSource.Play();
		}
        Destroy(handler, 1f);
       

	}

}
