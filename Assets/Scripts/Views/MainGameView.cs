using EgdFoundation;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainGameView : MonoBehaviour
{
    public GameObject HUD;
    public GameObject PauseScreen;
    public GameObject TimeOutScreen;
    public CanvasGroup Joystick;
    public Text scoreText;
    protected float _initialJoystickAlpha;
    protected bool _initialized = false;

    [SerializeField]
    private Button restartButton;

    [SerializeField]
    private Button homeButton;

    protected void Awake()
    {
        Initialization();
        restartButton.onClick.AddListener(RestartGame);
        homeButton.onClick.AddListener(BackToHome);
        SignalBus.I.Register<UpdatePlayerScore>(UpdatePlayerScoreText);
        SignalBus.I.Register<TimeOutSignal>(TimeOutHandle);
        scoreText.text = "0";
    }

    private void RestartGame()
    {
        ScenesChanger.ChangeScene("MainGame");
    }

    private void TimeOutHandle(TimeOutSignal signal)
    {
        SetTimeOutScreen(true);
    }

    private void UpdatePlayerScoreText(UpdatePlayerScore signal)
    {
        scoreText.text = signal.score.ToString();
    }

    private void BackToHome()
    {
        ScenesChanger.ChangeScene("Home");
        Time.timeScale = 1;
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
        SetTimeOutScreen(false);
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

    public virtual void SetTimeOutScreen(bool state)
    {
        if (TimeOutScreen != null)
        {
            TimeOutScreen.SetActive(state);
            EventSystem.current.sendNavigationEvents = state;
        }
    }

    private void OnDestroy()
    {
        SignalBus.I.Unregister<UpdatePlayerScore>(UpdatePlayerScoreText);
        SignalBus.I.Unregister<TimeOutSignal>(TimeOutHandle);
    }
}