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
    private readonly string[] _figures = { string.Empty, string.Empty};

    private Signs _sign = Signs.None;
    
    private float _answer;
    
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
        for (int i = 0; i < _figures.Length; i++)
        {
            _figures[i] = string.Empty;
        }

        _sign = Signs.None;
    }

    public void SetNumber(string number)
    {
        if (_sign == Signs.None)
        {
            _figures[0] = _figures[0].Insert(_figures[0].Length, number);
            _equationPresenter.WriteText($"{_figures[0]}");
        }
        else
        {
            _figures[1] = _figures[1].Insert(_figures[1].Length, number);
            _equationPresenter.WriteText($"{_figures[0]}{_signIcons[_sign]}{_figures[1]}");
        }
    }

    public void ChooseSign(Signs sign)
    {
        if (_figures[0] == string.Empty || _sign != Signs.None) return;
        
        _sign = sign;
        _equationPresenter.WriteText($"{_figures[0]}{_signIcons[_sign]}");
    }

    private void Awake()
    {
        _calculateButton.onClick.AddListener(Calculate);
    }

    private void Calculate()
    {
        if (_figures[1] == string.Empty) return;
        
        for (int i = 0; i < _numbers.Length; i++)
        {
            _numbers[i] = int.Parse(_figures[i]);
        }
        
        ICalculate mathAction = _mathActions[_sign];
        _answer = mathAction.Calculate(_numbers[0], _numbers[1]);

        _equationPresenter.ShowAnswer(_answer);

        ClearEquation();
    }
}