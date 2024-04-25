using UnityEngine;

public class SpinnerController : MonoBehaviour
{
    [SerializeField] private MultimeterController multimeterController;
    [SerializeField] private Outline outline;
    public void OnMouseEnter()
    {
        multimeterController.SetIsMouseOverSpinner(true);
        outline.enabled = true;
    }
   
    public void OnMouseExit()
    {
        multimeterController.SetIsMouseOverSpinner(false);
        outline.enabled = false;
    }
}
