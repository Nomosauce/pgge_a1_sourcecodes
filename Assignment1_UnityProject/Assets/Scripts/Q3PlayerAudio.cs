using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q3PlayerAudio : MonoBehaviour
{
    public List<AudioClip> grassSurface;
    public List<AudioClip> metalSurface;
    public List<AudioClip> woodSurface;
    public List<AudioClip> concreteSurface;
    public List<AudioClip> sandSurface;

    enum GroundMaterial
    {
        Grass, Metal, Wood, Concrete, Sand, Empty
    }

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayFootstep()
    {
        //Debug.Log("Footstep Noises");

        AudioClip clip = null;

        GroundMaterial surface = SurfaceSelect();

        switch (surface)
        {
            case GroundMaterial.Grass:
                clip = grassSurface[Random.Range(0, grassSurface.Count)];
                break;
            case GroundMaterial.Metal:
                clip = metalSurface[Random.Range(0, metalSurface.Count)];
                break;
            case GroundMaterial.Wood:
                clip = woodSurface[Random.Range(0, woodSurface.Count)];
                break;
            case GroundMaterial.Concrete:
                clip = concreteSurface[Random.Range(0, concreteSurface.Count)];
                break;
            case GroundMaterial.Sand:
                clip = sandSurface[Random.Range(0, sandSurface.Count)];
                break;
            default:
                break;
        }

        Debug.Log(surface);

        if (surface != GroundMaterial.Empty)
        {
            source.clip = clip;
            source.volume = Random.Range(0.06f, 1.0f);
            source.pitch = Random.Range(0.5f, 1.0f);
            source.Play();
        }
    }

    private GroundMaterial SurfaceSelect()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up * 0.5f, -Vector3.up);
        Material worldMaterial;

        if (Physics.Raycast(ray, out hit, 1.0f, Physics.AllLayers))
        {
            Renderer surfaceRenderer = hit.collider.GetComponentInChildren<Renderer>();
            if (surfaceRenderer)
            {
                worldMaterial = surfaceRenderer ? surfaceRenderer.sharedMaterial : null;
                if (worldMaterial.name.Contains("Grass"))
                {
                    return GroundMaterial.Grass;
                }
                else if (worldMaterial.name.Contains("Metal"))
                {
                    return GroundMaterial.Metal;
                }
                else if (worldMaterial.name.Contains("Wood"))
                {
                    return GroundMaterial.Wood;
                }
                else if (worldMaterial.name.Contains("Concrete"))
                {
                    return GroundMaterial.Concrete;
                }
                else if (worldMaterial.name.Contains("Sand"))
                {
                    return GroundMaterial.Sand;
                }
                else
                {
                    return GroundMaterial.Empty;
                }
            }
        }
        return GroundMaterial.Empty;
    }
}
