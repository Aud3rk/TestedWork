using Controllers.Gather;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GatherControllerInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<IGatherController>().To<GatherController>().AsSingle();
    }
}