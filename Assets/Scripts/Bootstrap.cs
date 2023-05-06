using DefaultNamespace;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Bootstrap : LifetimeScope
{
    [SerializeField]
    private Configs _configs;
    [SerializeField] 
    private City _city;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_city);
        builder.RegisterComponent(_configs);
    }
}