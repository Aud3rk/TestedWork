using System.ComponentModel;
using DefaultNamespace.Buttons;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class ButtonModelFactoryInstaller : MonoInstaller
    {
        [SerializeField] private GameObject buttonPrefab;
 
        public override void InstallBindings() => 
            Container.BindFactory<string, string, ButtonModel, ButtonModel.Factory>().FromComponentInNewPrefab(buttonPrefab);
    }
}