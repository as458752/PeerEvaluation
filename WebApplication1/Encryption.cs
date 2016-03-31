//author: Jing Liang
//date: 3/31/2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeerEvaluation
{
    public class Encryption
    {
        public static string encrypt(string input,int key)
        {
            bool flag = true;
            string output = "";
            foreach(char c in input)
            {
                int value = (int)c;
                if(flag)
                {
                    value = value + key;
                    flag = false;
                }
                else
                {
                    value = value - key;
                    flag = true;
                }
                output += Convert.ToChar(value);
            }
            return output;
        }

        public static string decrypt(string input, int key)
        {
            bool flag = true;
            string output = "";
            foreach (char c in input)
            {
                int value = (int)c;
                if (flag)
                {
                    value = value - key;
                    flag = false;
                }
                else
                {
                    value = value + key;
                    flag = true;
                }
                output += Convert.ToChar(value);
            }
            return output;
        }
    }
}