using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Tools;
using UnityEngine.EventSystems;

namespace MoreMountains.TopDownEngine
{
    /// <summary>
    /// Handles all GUI effects and changes
    /// </summary>
    [AddComponentMenu("TopDown Engine/Managers/GUIManager")]
    public class GUIManager : MMSingleton<GUIManager>
    {
        public GameObject HUD;
        public GameObject PauseScreen;
        public GameObject DeathScreen;
        public CanvasGroup Joystick;
        public Text scoreText;
        public Text timeText;
        protected float _initialJoystickAlpha;
        protected bool _initialized = false;

        [SerializeField]
        private Button restartButton;

        [SerializeField]
        private Button homeButton;

        protected override void Awake()
        {
            base.Awake();
            Initialization();
            restartButton.onClick.AddListener(RestartGame);
            homeButton.onClick.AddListener(BackToHome);
        }

        private void RestartGame()
        {
        }

        private void BackToHome()
        {
            /*ScenesChanger.ChangeScene("Home");*/
        }

        protected virtual void Initialization()
        {
            if (_initialized)
            {
                return;
            }

            if (Joystick != null)
            {
                _initialJoystickAlpha = Joystick.alpha;
            }
            _initialized = true;
        }

        protected virtual void Start()
        {
            SetPauseScreen(false);
            SetDeathScreen(false);
        }

        public virtual void UpdateScore(int updateAmount)
        {
            scoreText.text = updateAmount.ToString();
        }

        public virtual void SetHUDActive(bool state)
        {
            if (HUD != null)
            {
                HUD.SetActive(state);
            }
        }

        public virtual void SetAvatarActive(bool state)
        {
            if (HUD != null)
            {
                HUD.SetActive(state);
            }
        }

        public virtual void SetMobileControlsActive(bool state, InputManager.MovementControls movementControl = InputManager.MovementControls.Joystick)
        {
            Initialization();

            if (Joystick != null)
            {
                Joystick.gameObject.SetActive(state);
                if (state && movementControl == InputManager.MovementControls.Joystick)
                {
                    Joystick.alpha = _initialJoystickAlpha;
                }
                else
                {
                    Joystick.alpha = 0;
                    Joystick.gameObject.SetActive(false);
                }
            }
        }

        public virtual void SetPauseScreen(bool state)
        {
            if (PauseScreen != null)
            {
                PauseScreen.SetActive(state);
                EventSystem.current.sendNavigationEvents = state;
            }
        }

        public void SetTimeText(int time)
        {
            timeText.text = time.ToString();
        }

        public virtual void SetDeathScreen(bool state)
        {
            if (DeathScreen != null)
            {
                DeathScreen.SetActive(state);
                EventSystem.current.sendNavigationEvents = state;
            }
        }
    }
}