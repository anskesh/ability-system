using System;
using System.Collections.Generic;
using System.Linq;
using AbilitySystem.Scripts.Core;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectContext : MonoBehaviour
{
    private static bool _initialized;
    private List<IInstaller> _installers;

    [RuntimeInitializeOnLoadMethod]
    private static void InitializeContext()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
        
        ProjectContext context = Resources.Load<ProjectContext>("ProjectContext");
        Instantiate(context);
    }
    
    private void Awake()
    {
        if (_initialized)
            throw new Exception("Project context already initialized");

        _installers = GetComponents<IInstaller>().ToList();

        foreach (var installer in _installers)
            installer.Install();
        
        ServiceLocator.Setup(this);
        
        DontDestroyOnLoad(this);
        _initialized = true;
        
    }

    private void OnDestroy()
    {
        _initialized = false;
        
        ServiceLocator.Destroy();
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
