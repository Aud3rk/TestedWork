using System;
using System.Collections.Generic;
using System.Linq;
using Data.DogData;
using DefaultNamespace.Buttons;
using DG.Tweening;
using Interfaces;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class UIController : MonoBehaviour, IUIController
    {
        [SerializeField] private RectTransform mainWindow;
    
        [Header("DogMenu")]
        [SerializeField] private CanvasGroup dogElementCanvasGroup;
        [SerializeField] private Transform dogElementTransform;
        [SerializeField] private Transform layoutGroup;
        [SerializeField] private GameObject loadScreen;

        [Header("DogInfo")]
        [SerializeField] private Transform dogInfo;
        [SerializeField] private TMP_Text dogInfoText;
    
        [Header("GatherMenu")]
        [SerializeField] private CanvasGroup gatherElementCanvasGroup;
        [SerializeField] private Transform gatherElementTransform;
        [SerializeField] private TMP_Text temperature;

        private List<ButtonModel> _buttonList;
        private bool _isLoadingDog = false;

        private Vector2 _dogMenuPosition;
        private Vector2 _gatherMenuPosition;

        private Sequence _animationDog;
        private Sequence _animationGather;

        private event Action dogButton;
        private event Action gatherButton;
    
        private readonly float _dogAnimationFadeTime = 0.5f;
        private readonly float _dogAnimationTransformTime1 = 1f;
        private readonly float _gatherAnimationTime1 = 1f;
        private readonly float _gatherAnimationFadeTime1 = 0.6f;
        private readonly int _screenSize = -1920;

        private void Awake() => 
            InitAnimationSettings();

        private void Start() => 
            _buttonList = new List<ButtonModel>();

        public void ViewGather(string actualTemperature) => 
            temperature.text ="Temperature now: "+ actualTemperature;

        public void ViewButton(ButtonModel button)
        {
            _buttonList.Add(button);
            button.transform.SetParent(layoutGroup);
            button.transform.localScale = Vector3.one * 1.2f;
        }

        public void RemoveButton(ButtonModel buttonModel) => 
            _buttonList.Remove(buttonModel);

        public void DogMenu_AddListener(Action action) => 
            dogButton+=action;

        public void Gather_AddListener(Action action) => 
            gatherButton+=action;
    
        public void DogMenu_RemoveListener(Action action) => 
            dogButton-=action;

        public void Gather_RemoveListener(Action action) => 
            gatherButton-=action;

        public void ViewDogInfo(Breed breedData)
        {
            dogInfo.gameObject.SetActive(true);
            dogInfoText.text = breedData.ToString();
            dogInfoText.ForceMeshUpdate();
            _buttonList.First(x=>x.id == breedData.Id).AnimationOff();
        }

        public void DogMenuView()
        {
            AnimationDogWindow();
            _animationDog.AppendCallback(dogButton.Invoke);
            _animationDog.Play();
        }

        public void GatherMenuView()
        {
            AnimationGatherWindow();
            _animationGather.AppendCallback(gatherButton.Invoke);
            _animationGather.Play();
        }

        public void ViewDogElements()
        {
            loadScreen.SetActive(false);
            Sequence _animationDogElemtents = DOTween.Sequence();

            _animationDogElemtents.Append(dogElementCanvasGroup.DOFade(1, _dogAnimationFadeTime).From(0))
                .Join(dogElementTransform.DOMoveY(Screen.height / 2, _dogAnimationTransformTime1).From(-Screen.height / 2));
            _animationDogElemtents.Play();
        }

        private void AnimationDogWindow()
        {
            _animationDog = DOTween.Sequence();
            _animationDog.AppendCallback(()=>loadScreen.SetActive(true));
            _animationDog.Append(mainWindow.DOAnchorPos(_dogMenuPosition, 1f).From(_gatherMenuPosition));
            _animationDog.SetAutoKill(false);
        }

        private void AnimationGatherWindow()
        {
            _animationGather = DOTween.Sequence();
            _animationGather.Append(mainWindow.DOAnchorPos(_gatherMenuPosition, _gatherAnimationTime1).From(_dogMenuPosition));
            _animationGather.Join(dogElementCanvasGroup.DOFade(0, _gatherAnimationFadeTime1).From(1));
            _animationGather.Append(gatherElementCanvasGroup.DOFade(1, _gatherAnimationTime1).From(0))
                .Join(gatherElementTransform.DOMoveY(Screen.height / 2, _gatherAnimationTime1).From(-Screen.height / 2));
            _animationGather.SetAutoKill(false);
        }

        private void InitAnimationSettings()
        {
            _dogMenuPosition = new Vector2(_screenSize, 0);
            _gatherMenuPosition = Vector2.zero;
            mainWindow.anchoredPosition = _gatherMenuPosition;
        }
    }
}