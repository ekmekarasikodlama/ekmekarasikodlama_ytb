   public class Şifreleyici
    {
        NumberConverter.NumberConverter converter = new NumberConverter.NumberConverter();
        List<char> alfabe = new List<char>();

        int alfabeRandomFactor = 1;
      

        void formAlphabet()
        {
            string capitalLetters = "ABCDEFGHIJKLMNOPRSTUVYZXQW";
            string smallLetters = "abcdefghijklmnoprstuvyzxqw";
            string numbers = "0123456789";
            string symbols = "?!'^+%&/() ";

            Random rnd = new Random();
            int prob = rnd.Next(0, 100);
            if (prob > 50)
            {
                alfabeRandomFactor = 1;
            }
            else
            {
                alfabeRandomFactor = 2;
            }

            alfabe.Clear();
            string alfabeString = (alfabeRandomFactor == 1 ? capitalLetters : smallLetters) + (alfabeRandomFactor == 1 ? smallLetters : capitalLetters) + numbers + symbols;
            foreach (char c in alfabeString)
            {
                alfabe.Add(c);
            }
        }

        public string şifrele(string toEncrypt, int randomTranslateMaximum)
        {
            formAlphabet();

            int translateFactor = 0;
            Random rnd = new Random();
            translateFactor = rnd.Next(1, randomTranslateMaximum);

            string encrypted = "";
            string lowered = toEncrypt.ToLower();

            for(int i = 0; i < toEncrypt.Length; i++)
            {
                char currentChar = toEncrypt[i];
                char loweredChar = lowered[i];
                int crnt = alfabe.IndexOf(currentChar) + 1;

                crnt += translateFactor;
               
                encrypted += crnt + "/";
            }

            encrypted += alfabeRandomFactor + "/";

            string octaString = "";
            foreach(int i in converter.decToOct(translateFactor*10))
            {
                octaString += i.ToString();
            }
            encrypted += octaString;



            return encrypted;
        }
    }
