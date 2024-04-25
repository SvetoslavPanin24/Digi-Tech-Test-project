using System.Collections.Generic;
using UnityEngine;

public class MultimeterController : MonoBehaviour
{
    [SerializeField] private MultimeterModel model;
    [SerializeField] private MultimeterView view;
    private MultimeterMode mode; // Текущий режим мультиметра

    [SerializeField] private GameObject spinner; // регулятор
    private bool isMouseOverSpinner = false; // Флаг, показывающий, находится ли мышь над спиннером
    private Dictionary<MultimeterMode, float> modeAngles; // Углы поворота для каждого режима

    public void Start()
    {
        model = new MultimeterModel { Resistance = 1000, Power = 400 };
        view = GetComponent<MultimeterView>();
        mode = MultimeterMode.Neutral;

        // Инициализация углов поворота для каждого режима
        modeAngles = new Dictionary<MultimeterMode, float>
        {
            { MultimeterMode.Neutral, 45},
            { MultimeterMode.DCVoltage, 90 },
            { MultimeterMode.ACVoltage, 170 },
            { MultimeterMode.Current, -90 },
            { MultimeterMode.Resistance, 0 }
        };
    }

    public void Update()
    {
        if (isMouseOverSpinner && Input.mouseScrollDelta.y != 0)
        {
            int modeIndex = ((int)mode + (Input.mouseScrollDelta.y > 0 ? 1 : -1) + 5) % 5;
            Debug.Log(modeIndex);
            mode = (MultimeterMode)modeIndex; // Переключение режимов вперед и назад
            view.UpdateDisplay(mode, model); // Преобразование MultimeterMode в int

            // Вращение спиннера
            float targetAngle = modeAngles[mode];
            spinner.transform.localRotation = Quaternion.Euler(0, 0, targetAngle);
        }
    }

    // Устанавливает значение isMouseOverSpinner
    public void SetIsMouseOverSpinner(bool isOver)
    {
        isMouseOverSpinner = isOver;
    }
}
