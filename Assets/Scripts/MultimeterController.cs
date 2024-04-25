using System.Collections.Generic;
using UnityEngine;

public class MultimeterController : MonoBehaviour
{
    [SerializeField] private MultimeterModel model;
    [SerializeField] private MultimeterView view;
    private MultimeterMode mode; // ������� ����� �����������

    [SerializeField] private GameObject spinner; // ���������
    private bool isMouseOverSpinner = false; // ����, ������������, ��������� �� ���� ��� ���������
    private Dictionary<MultimeterMode, float> modeAngles; // ���� �������� ��� ������� ������

    public void Start()
    {
        model = new MultimeterModel { Resistance = 1000, Power = 400 };
        view = GetComponent<MultimeterView>();
        mode = MultimeterMode.Neutral;

        // ������������� ����� �������� ��� ������� ������
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
            mode = (MultimeterMode)modeIndex; // ������������ ������� ������ � �����
            view.UpdateDisplay(mode, model); // �������������� MultimeterMode � int

            // �������� ��������
            float targetAngle = modeAngles[mode];
            spinner.transform.localRotation = Quaternion.Euler(0, 0, targetAngle);
        }
    }

    // ������������� �������� isMouseOverSpinner
    public void SetIsMouseOverSpinner(bool isOver)
    {
        isMouseOverSpinner = isOver;
    }
}
