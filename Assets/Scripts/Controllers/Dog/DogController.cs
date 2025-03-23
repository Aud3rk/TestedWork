using System.Collections.Generic;
using Controllers.RequestQuery;
using Data.DogData;
using DefaultNamespace.Buttons;
using Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace Controllers.Dog
{
    public class DogController : IDogController
    {
        private IUIController _uiController;
        private IRequestController _requestController;
        private ButtonModel.Factory _factory;
        private List<ButtonModel> _buttonList;

        public DogController(IRequestController requestController, ButtonModel.Factory factory,
            IUIController uiController)
        {
            _requestController = requestController;
            _factory = factory;
            _uiController = uiController;
            _buttonList = new List<ButtonModel>();
        }

        public void Init()
        {
            _uiController.DogMenu_AddListener(GetDogList);
            _uiController.Gather_AddListener(DeleteButtons);
        }

        public void GetDogList() => 
            _requestController.RequestDogList(ViewActualDogList);

        private void ViewActualDogList(string json)
        {
            if (json == null)
                return;
            
            BreedList breedList = JsonConvert.DeserializeObject<BreedList>(json);
            List<Breed> t = breedList.Data;
            foreach (Breed breed in t)
                InitButton(breed);
            _uiController.ViewDogElements();
        }

        private void InitButton(Breed breed)
        {
            var button = _factory.Create(breed.Id, breed.Attributes.Name);
            _uiController.ViewButton(button);
            button.AddListener(DownloadDogInfo_onButtonClick);
            _buttonList.Add(button);
        }

        private void DownloadDogInfo_onButtonClick(string id)
        {
            _requestController.RequestDog(id, ViewDog);
        }

        private void ViewDog(string json)
        {
            if (json != null)
            {
                BreedJson breedInfo= JsonConvert.DeserializeObject<BreedJson>(json);
                _uiController.ViewDogInfo(breedInfo.Data);
            }
        }

        private void DeleteButtons()
        {
            if (_buttonList.Count == 0 && _buttonList == null)
                return;

            foreach (ButtonModel button in _buttonList)
            {
                _uiController.RemoveButton(button);
                GameObject.Destroy(button.gameObject);
            }
            _buttonList.RemoveAll(x => x.id.Length != 0);
        }

        ~DogController()
        {
            _uiController.DogMenu_RemoveListener(GetDogList);
            _uiController.Gather_RemoveListener(DeleteButtons);
        }
        
    }
}