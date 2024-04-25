using UnityEngine;

public class MultimeterModel : MonoBehaviour
{
    public float Resistance { get; set; }
    public float Power { get; set; }

    public float Current
    {
        get { return Mathf.Sqrt(Power / Resistance); }
    }

    public float DCVoltage
    {
        get { return Power / Current; }
    }
}
