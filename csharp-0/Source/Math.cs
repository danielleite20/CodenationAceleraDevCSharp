using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> Fiboi = new List<int> {0,1};

            int Prox = Fiboi[0] + Fiboi[1];
            do{
                Fiboi.Add(Prox);
                int ProxMenos2 = Fiboi[Fiboi.LastIndexOf(Prox) - 1];
                int ProxMenos1 = Fiboi[Fiboi.LastIndexOf(Prox)];
                Prox = ProxMenos2 + ProxMenos1;
            }

            while (Prox < 350);

            return Fiboi;
        }

        public bool IsFibonacci(int numberToTest)
        {
            return Fibonacci().Contains(numberToTest);
        }
    }
}
