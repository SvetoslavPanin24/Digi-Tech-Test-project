using TMPro;
using UnityEngine;

public class MultimeterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private TextMeshProUGUI amperageText;
    [SerializeField] private TextMeshProUGUI acVoltageText;
    [SerializeField] private TextMeshProUGUI dcVoltageText;
    [SerializeField] private TextMeshProUGUI resistanceText;
    public void UpdateDisplay(MultimeterMode mode, MultimeterModel model)
    {
        string displayText = "";
        switch (mode)
        {
            case MultimeterMode.Neutral:
                displayText = "0,00";
                break;
            case MultimeterMode.Resistance:
                displayText = model.Resistance.ToString("F2");
                break;
            case MultimeterMode.Current:
                displayText = model.Current.ToString("F2");
                break;
            case MultimeterMode.DCVoltage:
                displayText = model.DCVoltage.ToString("F2");
                break;
            case MultimeterMode.ACVoltage:
                displayText = "0,01";
                break;
        }

        this.displayText.text = displayText;
        amperageText.text = (mode == MultimeterMode.Current ? model.Current.ToString("F2") : "0,00");
        acVoltageText.text = (mode == MultimeterMode.ACVoltage ? "0.01" : "0,00");
        dcVoltageText.text = (mode == MultimeterMode.DCVoltage ? model.DCVoltage.ToString("F2") : "0,00");
        resistanceText.text = (mode == MultimeterMode.Resistance ? model.Resistance.ToString("F2") : "0,00");
    }
}
