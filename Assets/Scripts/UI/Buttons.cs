using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Buttons : MonoBehaviour
    {
        [Header("Scripts")]
        [SerializeField] private EquationHandler _equationHandler;
        [SerializeField] private EquationPresenter _equationPresenter;

        [Header("Buttons")]
        [SerializeField] private Button _clearButton;
        
        [Header("Number buttons")]
        [SerializeField] private Button[] _numberButtons;

        [Header("Sign buttons")]
        [SerializeField] private Button _additionSign;
        [SerializeField] private Button _divisionSign;
        [SerializeField] private Button _subtractionSign;
        [SerializeField] private Button _multiplicationSign;
        
        private void Awake()
        {
            AssignButtons();
        }

        private void AssignButtons()
        {
            _clearButton.onClick.AddListener(ClearEquation);
            
            // Numbers
            for (int i = 0; i < _numberButtons.Length; i++)
            {
                int number = i;
                _numberButtons[i].onClick.AddListener(()=> _equationHandler.SetNumber(number.ToString()));
            }
            
            // Signs
            _additionSign.onClick.AddListener(()=> _equationHandler.ChooseSign(Signs.Addition));
            _subtractionSign.onClick.AddListener(()=> _equationHandler.ChooseSign(Signs.Subtraction));
            
            _multiplicationSign.onClick.AddListener(()=> _equationHandler.ChooseSign(Signs.Multiplication));
            _divisionSign.onClick.AddListener(()=> _equationHandler.ChooseSign(Signs.Division));
        }
        
        private void ClearEquation()
        {
            _equationPresenter.ClearText();
            _equationHandler.ClearEquation();
        }
    }
}