using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FrameRateManager : MonoBehaviour
{
    public Slider frameRateSlider;
    public Slider vSyncSlider;
    public TextMeshProUGUI targetText;
    public TextMeshProUGUI fpsText;
    private float currentFps;
    private float updateInterval = 0.5f;
    private float accum = 0;
    private int frames = 0;
    private float timeleft;
    private bool fps60 = true;

    private int lastVSync = 1;


    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }


    void Start()
    {
        if (fpsText == null)
        {
            fpsText = GetComponent<TextMeshProUGUI>();
        }
        timeleft = updateInterval;
    }


    public void AdjustFrameRate(float value)
    {
        Application.targetFrameRate = (int)value;

        string format = System.String.Format("Target: {0:F0}", value);
        if (targetText != null)
        {
            targetText.text = format;
        }

        // QualitySettings.vSyncCount - an integer in the range of 0-4.
        // If vSyncCount == 0, Application.targetFrameRate is enabled.
        // If vSyncCount > 0, Application.targetFrameRate is ignored.
        // If vSyncCount > 0, native refresh rate of the display divided by vSyncCount.
        // If vSyncCount == 1, synchronized to the vertical refresh rate of the display.
        // If vSyncCount = 0 && .targetFrameRate = -1, content is rendered unsynchronized as fast as possible.
        // Use Screen.currentResolution.refreshRateRatio to get current display's refresh rate.
    }


    public void ToggleVSync(bool value)
    {
        if(value)
        {
            QualitySettings.vSyncCount = lastVSync;
            frameRateSlider.interactable = false;
            vSyncSlider.interactable = true;
        } else
        {
            QualitySettings.vSyncCount = 0;
            frameRateSlider.interactable = true;
            vSyncSlider.interactable = false;
        }
    }


    public void AdjustVSync(float value)
    {
        QualitySettings.vSyncCount = (int)value;
        lastVSync = (int)value;
    }


    void Update()
    {
        if (Input.GetButtonDown("FPS"))
        {
            fps60 = !fps60;
            if (fps60)
            {
                QualitySettings.vSyncCount = 1;
                Application.targetFrameRate = 60;
            } else
            {
                QualitySettings.vSyncCount = 2;
                Application.targetFrameRate = 30;
            }
        }
        
        timeleft -= Time.unscaledDeltaTime;
        accum += 1.0f / Time.unscaledDeltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            currentFps = accum / frames;
            string format = System.String.Format("{0:F2} FPS\n{1:F1} ms / frame", currentFps, 1000f / currentFps);
            if (fpsText != null)
            {
                fpsText.text = format;
            }

            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }
    }
}