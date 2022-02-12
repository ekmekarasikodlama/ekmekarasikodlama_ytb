 public class NumberConverter
    {
        public static Dictionary<int, char> hexSymbols = new Dictionary<int, char>();
        public NumberConverter()
        {
            for (int i = 0; i < 10; i++)
            {
                hexSymbols.Add(i, i.ToString()[0]);
            }
            hexSymbols.Add(10, 'A');
            hexSymbols.Add(11, 'B');
            hexSymbols.Add(12, 'C');
            hexSymbols.Add(13, 'D');
            hexSymbols.Add(14, 'E');
            hexSymbols.Add(15, 'F');
        }
        public List<int> decToBinary(int number)
        {
            List<int> toReturn = new List<int>();

            int number_ = number;

            while (number != 0)
            {
                int remainder = number % 2;
                number /= 2;
                toReturn.Add(remainder);
            }

            toReturn.Reverse();


            return toReturn;
        }

        public List<int> decToOct(int number)
        {
            List<int> toReturn = new List<int>();

            int number_ = number;

            while (number != 0)
            {
                int remainder = number % 8;
                number /= 8;
                toReturn.Add(remainder);
            }

            toReturn.Reverse();

            return toReturn;
        }

        public List<char> decToHex(int number)
        {
            List<char> toReturn = new List<char>();

            int number_ = number;
            while (number != 0)
            {
                int remainder = number % 16;
                number /= 16;
                toReturn.Add(hexSymbols[remainder]);
            }

            toReturn.Reverse();

            return toReturn;
        }

        public int binToDec(List<int> nums)
        {
            int result = 0;
            nums.Reverse();
            for (int i = 0; i < nums.Count; i++)
            {
                int poweroftwo = (int)Math.Pow(2, i);
                int toAdd = poweroftwo * nums[i];
                result += toAdd;
            }

            return result;
        }
        public int octToDec(List<int> nums)
        {
            int result = 0;
            nums.Reverse();
            for (int i = 0; i < nums.Count; i++)
            {
                int powerofeight = (int)Math.Pow(8, i);
                int toAdd = powerofeight * nums[i];
                result += toAdd;
            }

            return result;
        }

        public int hexToDec(List<char> symbols)
        {
            int result = 0;
            symbols.Reverse();
            for (int i = 0; i < symbols.Count; i++)
            {
                int powerofsixteen = (int)Math.Pow(16, i);
                int toAdd = 0;
                if (int.TryParse(symbols[i].ToString(), out int num))
                {
                    toAdd = powerofsixteen * num;
                }
                else
                {

                    foreach (KeyValuePair<int, char> symbol in hexSymbols)
                    {
                        if (symbol.Value == symbols[i])
                        {
                            toAdd = symbol.Key * powerofsixteen;
                            break;
                        }
                    }
                }

                result += toAdd;
            }

            return result;
        }

        public List<int> binToOct(List<int> numbers)
        {
            int decimalVersion = binToDec(numbers);
            List<int> octVersion = decToOct(decimalVersion);

            return octVersion;
        }

        public List<char> binToHex(List<int> numbers)
        {
            int decimalVersion = binToDec(numbers);
            List<char> hexVersion = decToHex(decimalVersion);

            return hexVersion;
        }

        public List<int> octToBin(List<int> numbers)
        {
            int decimalVersion = octToDec(numbers);
            List<int> binaryVersion = decToBinary(decimalVersion);

            return binaryVersion;
        }

        public List<char> octToHex(List<int> numbers)
        {
            int decimalVersion = octToDec(numbers);
            List<char> hexVersion = decToHex(decimalVersion);

            return hexVersion;
        }

        public List<int> hexToOct(List<char> symbols)
        {
            int decimalVersion = hexToDec(symbols);
            List<int> octVersion = decToOct(decimalVersion);

            return octVersion;
        }

        public List<int> hexToBin(List<char> symbols)
        {
            int decimalVersion = hexToDec(symbols);
            List<int> binaryVersion = decToBinary(decimalVersion);

            return binaryVersion;
        }
    }
