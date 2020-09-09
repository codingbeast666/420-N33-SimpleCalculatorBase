using System;

namespace SimpleCalculator
{
    class StringToIntConverter
    {

        public int convert(string input)
        {
            try
            {
                int convertedNumber;
                bool isConvertedSucessfully = int.TryParse(input, out convertedNumber);

                if (!isConvertedSucessfully)
                {
                    throw new Exception("Conversion was not successfull.");

                }

                return convertedNumber;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }

    }
}
