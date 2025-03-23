using Controllers.Dog;
using Controllers.Gather;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class BootStrap : MonoBehaviour
    {
        private IGatherController _gatherController;
        private IDogController _dogController;

        [Inject]
        public void Construct(IDogController dogController, IGatherController gatherController)
        {
            _dogController = dogController;
            _gatherController = gatherController;
        }
    
        void Start()
        {
            _gatherController.Init();
            _dogController.Init();
            _gatherController.GetGather();
        }
    
    }
}