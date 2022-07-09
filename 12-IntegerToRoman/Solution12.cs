namespace _12_IntegerToRoman
{
    public class Solution12
    {
        public string IntToRoman(int num)
        {
            int valueRemaining = num;
            string output = "";

            int baseValue = 10;
            while (valueRemaining > 0)
            {
                int valueToDefine = valueRemaining % baseValue;
                if (valueToDefine != 0)
                {
                    valueRemaining -= valueToDefine;
                    output = GetNumeralAroundBase(valueToDefine, baseValue) + output;
                }
                
                baseValue *= 10;
            }

            return output;
        }

        public string GetNumeralAroundBase(int valueToDefine, int baseValue)
        {
            int lowerBaseValue = baseValue / 10;
            int halfWayPoint = baseValue / 2;

            if (valueToDefine >= halfWayPoint)
            {
                return GetNumeralAroundHalfBase(valueToDefine, lowerBaseValue, baseValue, halfWayPoint);
            }
            else
            {
                return GetNumeralAroundHalfBase(valueToDefine, lowerBaseValue, halfWayPoint, 0);
            }
        }

        public string GetNumeralAroundHalfBase(int valueToDefine, int lowerBaseValue, int topValue, int bottomValue)
        {
            string numeral = "";
            int splitPoint = bottomValue + 3 * lowerBaseValue;

            if (valueToDefine <= splitPoint)
            {
                if(bottomValue != 0) numeral += GetChar(bottomValue);
                
                for (int i = bottomValue; i < valueToDefine; i += lowerBaseValue)
                {
                    numeral += GetChar(lowerBaseValue);
                }
            }
            else
            {
                numeral += GetChar(topValue);
                for (int i = topValue; i > valueToDefine; i -= lowerBaseValue)
                {
                    numeral = GetChar(lowerBaseValue) + numeral;
                }
            }

            return numeral;
        }

        public char GetChar(int roundedInt)
        {
            return roundedInt switch
            {
                1 => 'I',
                5 => 'V',
                10 => 'X',
                50 => 'L',
                100 => 'C',
                500 => 'D',
                1000 => 'M',
                _ => throw new Exception($"Integer {roundedInt} cannot be directly converted into roman character"),
            };
        }
    }
}