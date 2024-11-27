using UnityEngine;

public class fogScript : MonoBehaviour
{

    public Transform player;
    public Transform playerCamera;
    private Vector3 lastPosition;
    private ParticleSystem particleSystem;
    private ParticleSystem.VelocityOverLifetimeModule velocityModule;

    void Start()
    {
        // Cache components and initialize
        particleSystem = GetComponent<ParticleSystem>();
        velocityModule = particleSystem.velocityOverLifetime;
        lastPosition = player.position;

        // Ensure Velocity Over Lifetime is enabled
        velocityModule.enabled = true;
    }

    void Update()
    {
        // Calculate the player's velocity
        Vector3 playerVelocity = (player.position - lastPosition) / Time.deltaTime;

        // Apply the opposite velocity to the particles
        velocityModule.x = -playerVelocity.x;
        velocityModule.y = -playerVelocity.y;
        velocityModule.z = -playerVelocity.z;

        // Update the last position
        lastPosition = player.position;
    }

    void LateUpdate()
    {
        transform.position = player.position;
        transform.rotation = Quaternion.identity;

        if (playerCamera != null)
        {
            Vector3 direction = (playerCamera.position - transform.position).normalized;
            transform.forward = direction;
        }
    }
}
