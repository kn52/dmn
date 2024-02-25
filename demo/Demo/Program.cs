using System;

int[] getSpflist(int n)
{
    int []spf = new int[n + 1];
    for (int i = 0; i < spf.Length; i++)
    {
        spf[i] = i;
    }
    return spf;

}
int divisors(int number)
{
    int factor = 1;
    int[] spf = getSpflist(number); 
    
    while (number != 1)
    {
        int _p = spf[number];
        int power = 0;
        while (number % _p == 0)
        {
            number = number / _p;
            power++;
        }
        factor *= (power + 1);
    }
    return factor;
}

var A = new List<int>()
{
    2, 3, 4, 5
};
int B = A.Count;
int length = B + 1;
var spf = new int[length];
for (int i = 0; i < length; i++)
{
    spf[i] = i;
}

var ans = new List<int>();
for (int i = 0; i < B; i++)
{
    int _factors = divisors(A[i], spf[A[i]]);
    ans.Add(_factors);
}






var _ans = 0;

Console.WriteLine("Hello World");
Console.WriteLine(_ans);
