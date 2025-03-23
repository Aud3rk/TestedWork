using System;

namespace Interfaces
{
    public interface IRequestController
    {
        public void StopGatherRequest();
        public void RequestDog(string id, Action<string> action);
        public void RequestDogList(Action<string> action);
        public void RequestGather(Action<string> action);

    }
}