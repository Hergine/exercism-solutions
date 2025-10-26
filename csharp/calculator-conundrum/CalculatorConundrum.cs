public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        try
        {
            if (operand2 == 0 && operation == "/")
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }  
        }
        catch (Exception ex) when (ex is DivideByZeroException)
        {
            return ex.Message;
        }
        
        
        return operation switch
        {
            "+" => $"{operand1} + {operand2} = {operand1 + operand2}",
            "*" => $"{operand1} * {operand2} = {operand1 * operand2}",
            "/" => $"{operand1} / {operand2} = {operand1 / operand2}",
            "" => throw new ArgumentException("Invalid operation"),
            null => throw new ArgumentNullException(nameof(operation)),
            _ => throw new ArgumentOutOfRangeException($"Operation '{operation}' is not supported")
        };
         
    }
}
