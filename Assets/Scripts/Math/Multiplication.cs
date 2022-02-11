using Interfaces;

namespace Math
{
    public class Multiplication : ICalculate
    {
        public float Calculate(float number1, float number2)
        {
            return number1 * number2;
        }
    }
}
