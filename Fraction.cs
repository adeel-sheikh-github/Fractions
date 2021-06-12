using System.Text;

namespace FractionTest
{
    class Fraction
    {
        //a is numerator
        //b is denominator
        private int a, b;

        #region Constructors

        public Fraction ()
        {
            a = 0;
            b = 1;
        }

        /// <summary>
        /// Create a new Fraction
        /// </summary>
        /// <param name="a">Numerator</param>
        /// <param name="b">Denominator</param>
        public Fraction(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        /// <summary>
        /// Create a new fraction from a whole number
        /// </summary>
        /// <param name="a">Numerator. Denominator will be 1</param>
        public Fraction(int a)
        {
            this.a = a;
            this.b = 1;
        }

        /// <summary>
        /// Create a copy of fraction x
        /// </summary>
        /// <param name="x"></param>
        public Fraction(Fraction x)
        {
            this.a = x.a;
            this.b = x.b;
        }
#endregion

        #region Arithmatic Operations


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Fraction Multiply(Fraction other)
        {
            Fraction result = new Fraction();
            result.a = this.a * other.a;
            result.b = this.b * other.b;
            return result;
        }

        public Fraction DividedBy(Fraction other)
        {
            Fraction result = new Fraction();
            result.a = this.a * other.b;
            result.b = this.b * other.a;
            return result;
        }

        public Fraction Add(Fraction other)
        {
            Fraction result = new Fraction();
            result.a = this.a * other.b + other.a * this.b;
            result.b = this.b * other.b;
            return result;
        }

        public Fraction Subtract(Fraction other)
        {
            Fraction result = new Fraction();
            result.a = this.a * other.b - other.a * this.b;
            result.b = this.b * other.b;
            return result;
        }


        #endregion

        #region Utility Functions

        public bool Equal(Fraction other)
        {
            return this.a == other.a && this.b == other.b;
        }
        public bool NotEqual(Fraction other)
        {
            return !Equal(other);
        }

        public bool GreaterThan(Fraction other)
        {
            double x = (double)this.a / this.b;
            double y = (double)other.b / other.b;
            return x > y;
        }

        public bool GreaterThanOrEqual(Fraction other)
        {
            return Equal(other) || GreaterThan(other);
        }

        public bool LessThan(Fraction other)
        {
            return !GreaterThanOrEqual(other);
        }

        public bool LessThanOrEqual(Fraction other)
        {
            return !GreaterThan(other);
        }

        /// <summary>
        /// Greatest Common Divisor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Gcd(int a, int b)
        {
            int t = 0;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }

            return a;
        }

        public void Simplify()
        {
            int divisor = Gcd(this.a, this.b);
            this.a = this.a / divisor;
            this.b = this.b / divisor;
        }

        public Fraction Reduced()
        {
            Fraction result = new Fraction();
            int divisor = Gcd(this.a, this.b);
            result.a = this.a / divisor;
            result.b = this.b / divisor;
            return result;
        }

  

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var localNumerator = a;

            // If the numerator is more than the denominator then there will be a whole part

            if (System.Math.Abs(localNumerator) >= b)
            {
                if (b == 0)
                {
                   stringBuilder.Append("Divide by Zero not allowed");
                   return stringBuilder.ToString();
                }
                int wholePart = localNumerator / b;
                localNumerator -= (wholePart * b);
                stringBuilder.Append(wholePart);

                if (localNumerator != 0)
                {
                    stringBuilder.Append('_');
                    localNumerator = System.Math.Abs(localNumerator);
                }
            }

            // If there is anything left in the numerator, append the fractional part

            if (localNumerator != 0)
            {
                stringBuilder.Append(localNumerator);
                stringBuilder.Append('/');
                stringBuilder.Append(b);
            }

            return stringBuilder.ToString();
        }
        #endregion

    }
}
