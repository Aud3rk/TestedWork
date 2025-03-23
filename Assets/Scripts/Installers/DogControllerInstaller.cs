using Controllers.Dog;
using Interfaces;
using Zenject;

namespace DefaultNamespace.Installers
{
    public class DogControllerInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<IDogController>().To<DogController>().AsSingle();
    }
}