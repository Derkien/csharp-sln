namespace GB1Lesson7
{
    internal interface IOperationInterface
    {
        OperationTarget Execute();
        OperationTarget Revert();
        string ToString();
    }
}
