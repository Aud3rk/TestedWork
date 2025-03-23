using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace.Buttons
{
    public class ButtonModel : MonoBehaviour
    {
        public string id;
        
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text nameBreed;
        [SerializeField] private GameObject animWindow;
        
        private event Action<string> ButtonClick;
        
        [Inject]
        public void Construct(string id, string nameBreed)
        {
            this.id = id;
            this.nameBreed.text = nameBreed;
            button.onClick.AddListener(AnimationOn);
        }

        public void AddListener(Action<string> action) => 
            ButtonClick += action;

        public void AnimationOn() =>
            animWindow.SetActive(true);
        
        public void AnimationOff() =>
            animWindow.SetActive(false);
        

        private void Start() => 
            button.onClick.AddListener(ButtonEvent);

        private void OnDestroy() =>
            button.onClick.RemoveListener(ButtonEvent);

        private void ButtonEvent() => 
            ButtonClick?.Invoke(id);

        public class Factory : PlaceholderFactory<string, string, ButtonModel>
        {
        }
    }
}