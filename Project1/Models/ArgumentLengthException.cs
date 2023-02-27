namespace Models.CustomException;


[System.Serializable]
public class ArgumentLengthException : System.Exception
{
    public ArgumentLengthException() { }
    public ArgumentLengthException(string message) : base(message) { }
    public ArgumentLengthException(string message, System.Exception inner) : base(message, inner) { }
    protected ArgumentLengthException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}