using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace Controllers.RequestQuery
{
    public class RequestQueue
    {
        private List<Request> _requests;
        private UnityWebRequest _actualRequest;
        private bool _isProcessingQueue = false;

        public RequestQueue() => 
            _requests = new List<Request>();

        public void AddRequest(string url, Action<string> callback, string type)
        {
            Request request = new Request(() => GetRequest(url), callback, type);
            _requests.Add(request);
            if (!_isProcessingQueue) 
                ProcessQueue().Forget();
        }

        private async UniTask<string> ProcessQueue()
        {
            _isProcessingQueue = true;
            while (_requests.Count > 0)
            {                
                Request request = _requests.FirstOrDefault();
                _requests.Remove(request);
                string result = await request.Operation();
                request.Callback(result);
            }

            _isProcessingQueue = false;
            return null;
        }

        private async UniTask<string> GetRequest(string url)
        {
            _actualRequest = UnityWebRequest.Get(url);
            try
            {
                await _actualRequest.SendWebRequest();
            }
            catch (Exception e)
            {
                return null;
            }
            
            if (!_actualRequest.isHttpError && !_actualRequest.isNetworkError)
                return _actualRequest.downloadHandler.text;

            return null;
        }

        public void StopRequest()
        {
            if (_actualRequest != null && !_actualRequest.isDone)
                _actualRequest.Abort();
        }

        public void RemoveRequests(string type) => 
            _requests.RemoveAll(x => x.Type.Equals(type));
    }
}