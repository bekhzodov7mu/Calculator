using TMPro;
using UnityEngine;

namespace UI
{
    public class EquationPresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _equationText;

        private string _text = string.Empty;

        public void ShowAnswer(float answer)
        {
            _text = $"{answer}";
            UpdateEquationText();
        }
        
        public void ClearText()
        {
            _text = string.Empty;
            UpdateEquationText();
        }

        public void WriteText(string text)
        {
            _text = _text.Insert(_text.Length, text);
            UpdateEquationText();
        }

        private void UpdateEquationText()
        {
            _equationText.text = _text;
        }
    }
}