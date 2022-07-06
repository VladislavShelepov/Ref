using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace labo14_v1
{
    class fromOldLabs
    {
        public static string KeyGen(int degr)
        {
            var sb = new StringBuilder(2 ^ degr);
            var rnd = new Random();
            for (int i = 0; i < sb.Capacity; i++)
            {
                sb.Append(rnd.Next(0, 10));
            }
            string str = sb.ToString();
            BigInteger pNumber = new BigInteger();
            pNumber = BigInteger.Parse(str);
            if (pNumber.IsEven)
                pNumber++;
            while (!pNumber.IsProbablyPrime())
                pNumber += 2;
            return string.Format("{0}", pNumber);
        }

        private static BigInteger modInverse(BigInteger a, BigInteger n)
        {
            BigInteger i = n, v = 0, d = 1;
            while (a > 0)
            {
                BigInteger t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }
        public static BigInteger EuclidExtended(BigInteger a, BigInteger b)
        {
            var si2 = new BigInteger(1);
            var ti2 = new BigInteger(0);
            var si1 = new BigInteger(0);
            var ti1 = new BigInteger(1);
            while (b != 0)
            {
                var k = a / b;
                var si = si2 - k * si1;
                var ti = ti2 - k * ti1;
                si2 = si1;
                ti2 = ti1;
                si1 = si;
                ti1 = ti;
                var r = a % b;
                a = b;
                b = r;
            }
            return si2;
        }
        long inverse(long a, long n)
        {
            long x = 0;
            x = extended_euclid(a, n);
            return x;
        }
        long extended_euclid(long a, long b)
        {
            long q, r, x1, x2, y1, y2;
            long x = 0;
            long y = 0;
            long d = 0;
            if (b == 0)
            {
                d = a;
                x = 1;
                y = 0;
                return x;
            }
            x2 = 1;
            x1 = 0;
            y2 = 0;
            y1 = 1;
            while (b > 0)
            {
                q = a / b;
                r = a - q * b;
                x = x2 - q * x1;
                y = y2 - q * y1;
                a = b;
                b = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }
            d = a;
            x = x2;
            y = y2;
            return x;
        }

    }
    public static class PrimeExtensions
    {
        // Random generator (thread safe)
        private static ThreadLocal<Random> s_Gen = new ThreadLocal<Random>(
          () =>
          {
              return new Random();
          }
        );

        // Random generator (thread safe)
        private static Random Gen
        {
            get
            {
                return s_Gen.Value;
            }
        }

        public static Boolean IsProbablyPrime(this BigInteger value, int witnesses = 10)
        {
            if (value <= 1)
                return false;
            if (witnesses <= 0)
                witnesses = 10;
            BigInteger d = value - 1;
            int s = 0;
            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            Byte[] bytes = new Byte[value.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < witnesses; i++)
            {
                do
                {
                    Gen.NextBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= value - 2);

                BigInteger x = BigInteger.ModPow(a, d, value);
                if (x == 1 || x == value - 1)
                    continue;
                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, value);
                    if (x == 1)
                        return false;
                    if (x == value - 1)
                        break;
                }
                if (x != value - 1)
                    return false;
            }
            return true;
        }
    };
    }
