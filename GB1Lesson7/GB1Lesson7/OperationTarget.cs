namespace GB1Lesson7
{
    internal class OperationTarget
    {

        public OperationTarget(int number)
        {
            Number = number;
        }

        public int Number { get; private set; }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
