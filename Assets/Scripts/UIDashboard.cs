using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDashboard : MonoBehaviour
{
    public MeshDeformer meshDeformer;

    public Slider deformStrengthSlider;
    public Slider deformRadiusSlider;

    public Toggle raiseToggle;
    public Button resetButton;

    public TextMeshProUGUI statusText;
    public TextMeshProUGUI fpsText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Bindings
        deformStrengthSlider.onValueChanged.AddListener(value =>
        {
            meshDeformer.deformStrength = value;
            UpdateStatus();
        });

        deformRadiusSlider.onValueChanged.AddListener(value =>
        {
            meshDeformer.deformRadius = value;
            UpdateStatus();
        });

        raiseToggle.onValueChanged.AddListener(isOn =>
        {
            meshDeformer.raiseMode = isOn;
            UpdateStatus();
        });

        resetButton.onClick.AddListener(() => meshDeformer.ResetMesh());

        UpdateStatus();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFPS();
    }

    private void UpdateStatus()
    {
        statusText.text = $"Mode: {GetRaiseModeText()} | " +
            $"Strength: {deformStrengthSlider.value.ToString("0.0")} | " +
            $"Radius: {deformRadiusSlider.value.ToString("0.0")}";
    }

    private void UpdateFPS()
    {
        float fps = 1f / Time.unscaledDeltaTime;
        fpsText.text = "FPS: " + Mathf.Round(fps);
    }

    private string GetRaiseModeText()
    {
        return raiseToggle.isOn ? "Raise" : "Lower";
    }
}
