namespace ParenthesesStructure;
public class ParenthesesStructure {

    public static bool IsValidExpression(string expression)
    {
        Stack<char> stack = new Stack<char>();
        var car = expression.FirstOrDefault(c => c =='(' || c == '[' || c == '{' || c == '<' || c == ')' || c == ']' || c == '}' || c == '>' );
        stack.Push(car);
        var index = expression.IndexOf(car);
        for (int i = index + 1; i < expression.Length; i++) 
        {
            char c = expression[i];
            if(stack.Count() == 0) 
            {
                if(c == '(' || c == '[' || c == '{' || c == '<' || c == ')' || c == ']' || c == '}' || c == '>') 
                {
                    stack.Push(c);
                    continue;
                }
            }

            if ((c == '(' || c == '[' || c == '{' || c == '<' || c == ')' || c == ']' || c == '}' || c == '>') && !CheckType(c, stack.Peek()))
            {
                stack.Push(c);       
            }

            else if ((c == '(' || c == '[' || c == '{' || c == '<' || c == ')' || c == ']' || c == '}' || c == '>') && CheckType(c, stack.Peek())) 
            {
                stack.Pop();
            }
        }
    
        if(stack.Count() == 0) 
        {
            return true;
        }

        return false;
    }

    private static bool CheckType(char c, char a) {
        if((c == '(' || c == ')') && (a == '(' || a == ')')) 
        {
            return true;
        } 
        else if ((c == '{' || c == '}') && (a == '{' || a == '}')) 
        {
            return true;
        } 
        else if ((c == ']' || c == '[') && (a == ']' || a == '[')) 
        {
            return true;
        } 
        else if ((c == '<' || c == '>') && (a == '<' || a == '>')) 
        {
            return true;
        }

        return false;
    }

    public static void Main(string[] args) {
        Console.WriteLine("Unesite izraz:");
        string expression = Console.ReadLine();

          if (IsValidExpression(expression))
            {
                Console.WriteLine("Ispravan izraz.");
            }
            else
            {
                Console.WriteLine("Neispravan izraz.");
            }
        }
    }




