using System;
using Interfaces;

namespace Controllers.RequestQuery
{
    public class RequestController : IRequestController
    {
        private const string GATHER_URL = "https://api.weather.gov/gridpoints/TOP/32,81/forecast";
        private const string DOG_URL = "https://dogapi.dog/api/v2/breeds";
        private const string GATHER_REQUEST = "GatherRequest";
        private const string DOG_REQUEST = "DogRequest";
        private readonly RequestQueue _requests;

        public RequestController()
        {
            _requests = new RequestQueue();
        }
        public void RequestGather(Action<string> action)
        {
            _requests.AddRequest(GATHER_URL, action, GATHER_REQUEST);
        }

        public void RequestDogList(Action<string> action)
        {
            _requests.AddRequest(DOG_URL, action, DOG_REQUEST);
        }

        public void RequestDog(string id, Action<string> action)
        {
            string url = DOG_URL + "\\" + id;
            _requests.StopRequest();
            _requests.RemoveRequests(DOG_REQUEST);
            _requests.AddRequest(url, action, DOG_REQUEST);
        }

        public void StopGatherRequest()
        {
            _requests.RemoveRequests(GATHER_REQUEST);
            _requests.StopRequest();
        }
    }
}