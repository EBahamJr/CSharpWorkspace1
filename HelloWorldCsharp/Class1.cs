using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldCsharp
{
    class Class1
    {
        int[] a;

        public Class1(int num, int multiples)
        {
            this.a = new int[multiples];
            filler(num, a);
        }

        private void filler(int n, int[] a)
        {
            for (int i = 0; i < a.Length; i++ )
            {
                this.a[i] = n * (i+1);
            }
        }

        public override String ToString()
        {
            var line = "";

            for (int i = 0; i < a.Length; i++)
            {
                line = line + a[i] + " ";
            }

            return line;
        }

    }
}
