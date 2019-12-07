using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEDORO_FINAL
{
    public class Controller
    {

        public double num1;
        public double num2;
        public void swap(double num1, double num2)
        {
            double temp = num1;
            num1 = num2;
            num2 = temp;

            this.num1 = num1;
            this.num2 = num2;
        }
        public double MDAS(double num1, string Op, double num2)
        {
            double ans;
            switch (Op)
            {
                case "+":
                    ans = num1 + num2;
                    break;
                case "-":
                    ans = num1 - num2;
                    break;
                case "/":
                    ans = num1 / num2;
                    break;
                case "*":
                    ans = num1 * num2;
                    break;
                case "%":
                    ans = num1 % num2;
                    break;
                default:
                    ans = 0;
                    break;

            }


            return ans;
        }



        public string strManipulation(string fname, string mname, string lname)
        {
            string Mi;

            if(mname.IndexOf(" ") > 0)
            {
                int index = mname.IndexOf(" ");
                Mi = $"{mname.Substring(0,1)}. {mname.Substring(index+1,1)}.";
            }
            else
            {
                Mi = $"{mname.Substring(0, 1)}.";
            }



            return $"{fname} {Mi} {lname}";
        }

    }
}
