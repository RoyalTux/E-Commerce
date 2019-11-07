namespace BLL.Extensibility.Infrastructure
{
    public class OperationDetailsBll
    {
        public OperationDetailsBll(bool succeeded, string message, string prop)
        {
            this.Succeeded = succeeded;
            this.Message = message;
            this.Property = prop;
        }

        public bool Succeeded { get; }

        public string Message { get; }

        public string Property { get; }
    }
}
