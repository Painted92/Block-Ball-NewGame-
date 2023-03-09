using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightParticles : MonoBehaviour
{
    [SerializeField] private int particlesNumber = 50; // Количество частиц в прицеле
    [SerializeField] private GameObject particlePrefab; // Префаб частицы
    [SerializeField] private ParticleSystem particles; // Система частиц

    private void Start()
    {
        SightHide();
        CreateParticles();
    }

    private void CreateParticles()
    {
        particles.maxParticles = particlesNumber;
        particles.Emit(particlesNumber);

        ParticleSystem.Particle[] particlesArray = new ParticleSystem.Particle[particlesNumber];
        particles.GetParticles(particlesArray);

        float scale = 1f;
        float scaleFactor = scale / particlesNumber;

        for (int i = 0; i < particlesNumber; i++)
        {
            particlesArray[i].position = Vector3.zero;
            particlesArray[i].startSize = scale;

            if (scale > 0.1f)
                scale -= scaleFactor;
        }

        particles.SetParticles(particlesArray, particlesNumber);
    }

    public void VectorParticles(Vector2 dotPos, Vector2 force)
    {
        ParticleSystem.Particle[] particlesArray = new ParticleSystem.Particle[particlesNumber];
        particles.GetParticles(particlesArray);

        float time = 0f;
        for (int i = 0; i < particlesNumber; i++)
        {
            Vector2 newPos = dotPos + force * time;
            particlesArray[i].position = new Vector3(newPos.x, newPos.y, 0f);
            time += 0.1f;
        }

        particles.SetParticles(particlesArray, particlesNumber);
    }

    public void SightShow()
    {
        particles.Play();
    }

    public void SightHide()
    {
        particles.Stop();
    }
}