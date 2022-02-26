public class partition
        {
            public partition(char v, long m)
            {
                variable = v;
                multiplier = m;
            }
            public partition()
            {

            }
            public char variable;
            public long multiplier = 1;
        }
        public static long factorial(long n)
        {
            if (n == 0) { return 1; } //Sıfır faktöriyel 1'e eşittir.
            long returnValue = 1;
            for (long i = n; i > 0; i--)
            {
                returnValue *= i; //Sayıyı kendisinden 0'a kadar döngü içinde al, o kadar kez döngü değeriyle çarp.
            }
            return returnValue;
        }
        public static long combination(long n, long r)
        {
            if (r == 0 || r == n) //C(2,2) = 1 ve C(2,0) = 1 durumu gibi
            {
                return 1;
            }
            long up = permutation(n, r); //C(9,2) = (9*8)/2! için
            long down = factorial(r);
            long result = up / down;
            return result;
        }
        public static long permutation(long n, long r)
        {
            long val = n;
            for (int i = 1; i <= r; i++)
            {
                val *= (n - i);
            }
            return val;
        }
        public static long calculatePower(long basePart, long pow)
        {
            if (pow == 0) //2^0 = 1
            {
                return 1;
            }
            else if (pow == 1) // 2^1 = 2
            {
                return basePart;
            }
            long result = basePart;
            for (long i = 1; i < pow; i++) //sayi kuvvet değeri kez kendisiyle çarpılır.
            {
                result *= basePart;
            }
            return result;
        }
        public static partition calculateTerm(partition toCalculate, long power)
        {
            //terimdeki değerler kuvvete göre hesaplanır.
            partition toReturn = new partition(); //döndürülecek değer

            long newMultip = calculatePower(toCalculate.multiplier, power);
            //(ax)^2 için newMultip = a^2 değeri

            toReturn.variable = toCalculate.variable; //değişken aynı
            toReturn.multiplier = newMultip; //çarpan farklı

            return toReturn;
        }
        public static Tuple<string, long, long> calculate(long a, long b, long k, long l, long n, operation op)
        {
            List<string> terms = new List<string>();
            List<long> termCoefficients = new List<long>();

            Tuple<string, long, long> result;

            long sumOfCoefficients = 0;
            partition xMainPartition = new partition('x', a);
            //partition = terim
            //(ax) adlı terimi oluşturduk.
            if (op == operation.subtraction)
            {
                b = -b; //(x-y) durumunda y'nin katsayısı - ile çarpılmalı.
            }
            partition yMainPartition = new partition('y', b);
            //(by) adlı terimi oluşturduk.

            string resultString = "";

            for (long r = 0; r <= n; r++) //n = 5 - r=0 , n= 5 - r=1, n=5 - r=2 ... için döngü (r = n olana kadar)
            {
                long mainCoefficient = combination(n, r);
                //(n,r)(a)^n-r (b)^r için (n,r) değeri ^
                long xPower = n - r;
                long yPower = r;

                partition xResult = calculateTerm(xMainPartition, xPower);
                partition yResult = calculateTerm(yMainPartition, yPower);

                mainCoefficient *= xResult.multiplier;
                mainCoefficient *= yResult.multiplier;
                //(2x+y)^4 && r=1 => (4,1) = 4 * 8 * x^3 * y^1 yerine 32 * x^3 * y^1 oluyor
                xPower *= k;
                yPower *= l;
                //(x^2 + y^1)^3 için r = 1 => (4,1) (x^2)^3 => x^6 yapıyor
                //katsayılar toplamına ekleniyor.

                string xPowString = xPower != 0 && xPower != 1 ? "^" + xPower : "";
                //eğer kuvvet 0 değilse, kuvvet yazılır
                //x^0 = 1 olacağından 1^0 yazmaya gerek yok ama
                //x^3 için ^3 kısmı belirlenmiş olur. ayrıca x^1 = x olacağından 1 yazmaya gerek yok.
                string yPowString = yPower != 0 && yPower != 1 ? "^" + yPower : "";

                string mainCoefficientString = mainCoefficient != 1 && mainCoefficient != -1 ? mainCoefficient.ToString() : (mainCoefficient == 1 ? "" : "-"); //Eğer katsayı 1 veya -1 değilse, olduğu gibi yazılır. Eğer katsayı 1 ise boş bırakılır, -1 ise - yazılır. (-1 ile çarpmak önüne - koymak ile aynı şey=) 
                //ana çarpan 1 ise yazmaya gerek yok

                string xString = xPower != 0 ? "x" : "";
                //eğer x'in kuvveti 0 ise 1 olacağından x'i yazmaya gerek yok.
                string yString = yPower != 0 ? "y" : "";

              
                string combined = ""; //terim sonucu verilecek
                combined += mainCoefficientString + xString + xPowString + " " + yString + yPowString; //terim oluşturulur
                sumOfCoefficients += mainCoefficient;

                terms.Add(combined);
                termCoefficients.Add(mainCoefficient);             
            }

            for(int term = 0; term < terms.Count; term++) //birinci terimden başlanarak bütün terimlerde döngü yapılır
            {
                string thisTerm = terms[term]; //geçerli terim alınır
                if(term != 0) // ilk terim değil ise
                {                
                   if(thisTerm[0] == '-') //işareti - ise
                    {
                        thisTerm = thisTerm.Remove(0, 1); // - işareti kaldırılır. ama katsayılar listesinde işaret hala - olacaktır.
                    }
                }
                resultString += thisTerm; //sonuca eklenir.
               if(term != terms.Count-1) //eğer son terim değil ise. (son terimden sonra bir terim olmayacaktır)
                {
                    long nextCoefficient = termCoefficients[term + 1]; //bir sonraki terimin işareti değerlendirilir ve ekleme yapılır
                    if(nextCoefficient >=0)
                    {
                        resultString += " + ";
                    }
                    else
                    {
                        resultString += " - ";    //bir sonraki terim negatif ise - işareti konulur. daha önce - işareti silindiğinden - iki kez yazılmayacaktır.                  
                    }
                    //eğer sonraki terimin işareti - ise + - yazmaya gerek yok. Bu yüzden boş bırakılır ve geçerli - korunur.
                    //örnek:
                    //(x-y)^2
                    //x^2 + -2xy + y^2 yerine
                    //x^2   -2xy + y^2 yazılır
                }
               
                   
            }

            result = Tuple.Create(resultString, sumOfCoefficients, n + 1);
            //veri paketi oluşturulur

            return result; //ve veri döndürülür
        }
    }
