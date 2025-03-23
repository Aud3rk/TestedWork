using System;
using Cysharp.Threading.Tasks;

namespace Controllers.RequestQuery
{
    public class Request
    {
        public Func<UniTask<string>> Operation;
        public Action<string> Callback;
        public string Type;


        public Request(Func<UniTask<string>> operation, Action<string> callback, string type)
        {
            Operation = operation;
            Callback = callback;
            Type = type;
        }
    }
}