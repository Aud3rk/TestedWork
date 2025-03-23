using System;
using Data.DogData;
using DefaultNamespace.Buttons;

namespace Interfaces
{
    public interface IUIController
    {
        public void ViewDogElements();
        public void GatherMenuView();
        public void DogMenuView();
        public void ViewDogInfo(Breed breedData);
        public void Gather_RemoveListener(Action action);
        public void DogMenu_RemoveListener(Action action);
        public void Gather_AddListener(Action action);
        public void DogMenu_AddListener(Action action);
        public void ViewButton(ButtonModel button);
        public void ViewGather(string actualTemperature);
        public void RemoveButton(ButtonModel buttonModel);
    }
}