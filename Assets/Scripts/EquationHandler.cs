using System.Collections.Generic;
using Interfaces;
using Math;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class EquationHandler : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private EquationPresenter _equationPresenter;

    [Header("UI")]
    [SerializeField] private Button _calculateButton;

    private readonly float[] _numbers = new float[2];
    private readonly bool[] _isNumberChosen = new bool[2];
    private readonly string[] _figures = { string.Empty, string.Empty};
    
    private readonly Signs[] _signs = new Signs[1];
    
    // private Signs _sign;
    private float _answer;

    private string _number1 = string.Empty;
    private string _number2 = string.Empty;

    private readonly Dictionary<Signs, ICalculate> _mathActions = new Dictionary<Signs, ICalculate>
    {
        { Signs.Addition, new Addition() },
        { Signs.Subtraction, new Subtraction() },
        { Signs.Multiplication, new Multiplication() },
        { Signs.Division, new Division() },
    };

    private readonly Dictionary<Signs, string> _signIcons = new Dictionary<Signs, string>
    {
        { Signs.Addition, "+" },
        { Signs.Subtraction, "-" },
        { Signs.Multiplication, "*" },
        { Signs.Division, "/" },
    };

    public void ClearEquation()
    {
        for (int i = 0; i < _isNumberChosen.Length; i++)
        {
            _isNumberChosen[i] = false;
        }

        _signs[0] = Signs.None;
    }

    public void SetNumber(string number)
    {
        if (AreNumbersFilled()) return;

        if (_signs[0] == Signs.None)
        {
            _figures[0] = _figures[0].Insert(_figures[0].Length, number);
        }
        else
        {
            _figures[1] = _figures[1].Insert(_figures[1].Length, number);
        }

        // if (_sign == Signs.None)
        // {
        //     _number1 = _number1.Insert(_number1.Length, number);
        // }
        // else
        // {
        //     _number2 = _number2.Insert(_number2.Length, number);
        // }
        
        // for (int i = 0; i < _isNumberChosen.Length; i++)
        // {
        //     if (_isNumberChosen[i]) continue;
        //
        //     _numbers[i] = number;
        //     _isNumberChosen[i] = true;
        //     _equationPresenter.WriteText(number.ToString());
        //
        //     break;
        // }
    }

    public void ChooseSign(Signs sign)
    {
        if (_signs[0] != Signs.None) return;
        
        _signs[0] = sign;
        _equationPresenter.WriteText(_signIcons[sign]);
    }

    private void Awake()
    {
        _calculateButton.onClick.AddListener(Calculate);
    }

    private void Calculate()
    {
        for (int i = 0; i < _numbers.Length; i++)
        {
            _numbers[i] = int.Parse(_figures[i]);
        }
        
        ICalculate mathAction = _mathActions[_signs[0]];
        _answer = mathAction.Calculate(_numbers[0], _numbers[1]);

        _equationPresenter.ShowAnswer(_answer);

        ClearEquation();
    }

    private bool AreNumbersFilled() => _isNumberChosen[0] && _isNumberChosen[1];
}