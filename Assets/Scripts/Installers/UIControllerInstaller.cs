using System;
using Controllers;
using Interfaces;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Installers
{
    public class UIControllerInstaller : MonoInstaller
    {
        [SerializeField] private UIController uiController;

        public override void InstallBindings() => 
            Container.Bind<IUIController>().FromInstance(uiController);
    }
}