namespace GB1Lesson7
{
    internal class OperationPlus : IOperationInterface
    {
        public OperationPlus(OperationTarget operationTarget)
        {
            InitialValue = operationTarget.Number;
        }

        public int InitialValue { get; private set; }

        public OperationTarget Execute()
        {
            return new OperationTarget(InitialValue + 1);
        }

        public OperationTarget Revert()
        {
            return new OperationTarget(InitialValue);
        }

        public override string ToString()
        {
            return "+1";
        }
    }
}
