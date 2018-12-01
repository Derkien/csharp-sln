namespace GB1Lesson7
{
    internal class OperationMultiply : IOperationInterface
    {
        public OperationMultiply(OperationTarget operationTarget)
        {
            InitialValue = operationTarget.Number;
        }

        public int InitialValue { get; private set; }

        public OperationTarget Execute()
        {
            return new OperationTarget(InitialValue * 2);
        }

        public OperationTarget Revert()
        {
            return new OperationTarget(InitialValue);
        }

        public override string ToString()
        {
            return "x2";
        }
    }
}
