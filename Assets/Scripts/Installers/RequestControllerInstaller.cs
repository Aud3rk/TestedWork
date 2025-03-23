using Controllers.RequestQuery;
using Interfaces;
using Zenject;

namespace DefaultNamespace.Installers
{
    public class RequestControllerInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<IRequestController>().To<RequestController>().AsSingle();
    }
}