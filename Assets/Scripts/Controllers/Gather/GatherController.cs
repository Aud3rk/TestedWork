using Controllers.RequestQuery;
using Cysharp.Threading.Tasks;
using Data.GatherData;
using Interfaces;
using Newtonsoft.Json;

namespace Controllers.Gather
{
    public class GatherController : IGatherController
    {
        private IRequestController _requestController;
        private readonly IUIController _uiController;
        private bool _isGatherChecking = false;

        public GatherController(IRequestController requestController, IUIController uiController)
        {
            _requestController = requestController;
            _uiController = uiController;
        }

        public void Init()
        {
            _uiController.Gather_AddListener(CheckGather);
            _uiController.DogMenu_AddListener(StopCheckGather);
        }

        public void CheckGather() => 
            StartGatherCheck();

        private async UniTaskVoid StartGatherCheck()
        {
            _isGatherChecking = true;
            while (_isGatherChecking)
            {
                GetGather();
                await UniTask.Delay(5000);
            }
        }

        public void GetGather() => 
            _requestController.RequestGather(ViewActualGather);

        private void StopCheckGather()
        {
            _isGatherChecking = false;
            _requestController.StopGatherRequest();
        }

        private void ViewActualGather(string json)
        {
            if (json != null)
            {
                WeatherFeature some = JsonConvert.DeserializeObject<WeatherFeature>(json);
                _uiController.ViewGather(some.Properties.Periods[0].Temperature.ToString());
            }
        }

        ~GatherController()
        {
            _uiController.Gather_RemoveListener(CheckGather);
            _uiController.DogMenu_RemoveListener(StopCheckGather);
        }
    }
}