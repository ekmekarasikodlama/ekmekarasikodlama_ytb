 //solves equation and returns a tuple of x1 and x2
 //denklemi çözer ve tuple içerisinde x1 ve x2'yi döndürür.
 
 Tuple<double, double> solveEquation(double a, double b, double c)
        {
            double delta = discriminant(a, b, c);

            double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double root2 = (-b - Math.Sqrt(delta)) / (2 * a);

            Tuple<double, double> result = new Tuple<double, double>(root1, root2);
            return result;
        }
        
        
          double discriminant(double a, double b, double c)
        {
            double res = 1;

            res = (b * b) + (-4 * (a * c));

            return res;
        }
        
        
        
         string calculateiValue(int power)
        {
            if(power == 0)
            {
                return "1";
            }

            int actual = power % 4;
            if(actual < 0) { actual += 4; }

            if(actual == 0)
            {
                return "1";
            }else if(actual == 1)
            {
                return "i";
            }else if(actual == 2)
            {
                return "-1";
            }else if(actual == 3)
            {
                return "-i";
            }
            else
            {
                return "";
            }
        }
