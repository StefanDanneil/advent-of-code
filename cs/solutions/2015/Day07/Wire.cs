namespace solutions._2015;

public class Wire
{
    private readonly string _input;
    private int? _signal;
    private readonly Dictionary<string, Wire> _circuit;

    public Wire(string input, Dictionary<string, Wire> circuit)
    {
        _input = input.Trim();
        _circuit = circuit;
    }
    
    public int GetSignal()
    {
        if (_signal is not null)
        {
            return Convert.ToInt32(_signal);
        }
        
        if (_input.Contains("AND"))
        {
            _signal = MakeTwoPartBitwiseOperation("AND");
            return Convert.ToInt32(_signal);
        }
        
        if (_input.Contains("OR"))
        {
            _signal = _signal = MakeTwoPartBitwiseOperation("OR");
            return Convert.ToInt32(_signal);
        }
        
        if (_input.Contains("LSHIFT"))
        {
            _signal = MakeTwoPartBitwiseOperation("LSHIFT");
            return Convert.ToInt32(_signal);;
        }
        
        if (_input.Contains("RSHIFT"))
        {
            _signal = MakeTwoPartBitwiseOperation("RSHIFT");
            return Convert.ToInt32(_signal);
        }
        
        if (_input.Contains("NOT"))
        {
            var wire = _circuit[_input.Split("NOT")[1].Trim()];
            var signal = Convert.ToString(wire.GetSignal(), 2);
            var bitString16 = "1111111111111111";
            var substitute = signal.Aggregate("", (current, t) => current + (t == '0' ? '1' : '0'));

            bitString16 = string.Concat(bitString16.AsSpan(0, 16 - substitute.Length), substitute);
            
            _signal = Convert.ToInt32(bitString16, 2);
            return Convert.ToInt32(_signal);
        }

        _signal = GetValueFromInputPart(_input);
        return Convert.ToInt32(_signal);
    }

    private int GetValueFromInputPart(string inputPart)
    {
        return int.TryParse(inputPart, out var foundFirstSignal)
            ? foundFirstSignal
            : _circuit[inputPart].GetSignal();
    }

    private int MakeTwoPartBitwiseOperation(string bitwiseOperator)
    {
        var connectingSignals = _input.Split(bitwiseOperator);

        if (connectingSignals.Length != 2)
        {
            throw new Exception("The input was not well formatted");
        }
        
        var firstValue = GetValueFromInputPart(connectingSignals[0].Trim());
        var secondValue = GetValueFromInputPart(connectingSignals[1].Trim());

        return bitwiseOperator switch
        {
            "AND" => firstValue & secondValue,
            "OR" => firstValue | secondValue,
            "LSHIFT" => firstValue << secondValue,
            "RSHIFT" => firstValue >> secondValue,
            _ => throw new NotSupportedException($"The operator {bitwiseOperator} is not supported")
        };
    }
}