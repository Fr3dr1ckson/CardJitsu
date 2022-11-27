namespace GameScript;

public class SashaLab
{
    public void task27(string arg)
    {
        Console.Write("Enter N");
        int input = int.Parse(Console.ReadLine());
        int[] arr = new int[(int)Math.Pow(input,2)];
        for (int i = 0; i < Math.Pow(input, 2); i++)
        {
            arr[i] = 1+i;
        }
    }
}