using System;
using AbilitySystem.Scripts.Configurations;
using Configurations;
using Services;
using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    public static bool Initialized;
    
    [SerializeField] private ProjectConfiguration _projectConfiguration;

    private void Awake()
    {
        if (Initialized)
            throw new Exception("Project context already initialized");
        
        DontDestroyOnLoad(this);
        Initialized = true;
        
        ServiceLocator.Setup(this);
        ServiceLocator.AddService(new ConfigurationService(_projectConfiguration));
    }

    private void OnDestroy()
    {
        Initialized = false;
    }
}
