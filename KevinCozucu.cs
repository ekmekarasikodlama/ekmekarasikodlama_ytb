public class Çözücü
    {
        NumberConverter.NumberConverter converter = new NumberConverter.NumberConverter();
        List<char> alfabe = new List<char>();
        void formAlphabet(int factor)
        {
            string capitalLetters = "ABCDEFGHIJKLMNOPRSTUVYZXQW";
            string smallLetters = "abcdefghijklmnoprstuvyzxqw";
            string numbers = "0123456789";
            string symbols = "?!'^+%&/() ";



            alfabe.Clear();
            string alfabeString = (factor == 1 ? capitalLetters : smallLetters) + (factor == 1 ? smallLetters : capitalLetters) + numbers + symbols;
            foreach (char c in alfabeString)
            {
                alfabe.Add(c);
            }
        }
        public string solve(string statement)
        {
            string result = "";
            string[] partitions = statement.Split('/');

            int alfabeFaktor = int.Parse(partitions[partitions.Count() - 2]);
            formAlphabet(alfabeFaktor);

            string translationFactorString = partitions[partitions.Count() - 1];
            List<int> octList = new List<int>();
            foreach (char c in translationFactorString)
            {
                octList.Add(int.Parse(c.ToString()));
            }

            int translationFactor = converter.octToDec(octList) / 10;

            for(int i = 0; i < partitions.Count() - 2; i++)
            {
                int intified = int.Parse(partitions[i]);
                intified -= translationFactor;
                intified--;
                char corresponds = alfabe[intified];
                result += corresponds;
            }


            return result;
        }
    }
