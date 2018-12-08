using System;
using System.Collections.Generic;

namespace GB1Lesson7
{
    internal class Doubler
    {
        private int ExpectedResult;
        private OperationTarget CurrentNumber;
        private Stack<IOperationInterface> OperationsStack;

        public Doubler()
        {
            ExpectedResult = GetNewRandomNumber();
            CurrentNumber = new OperationTarget(0);
            OperationsStack = new Stack<IOperationInterface> { };
        }

        public string GetExpectedResult()
        {
            return ExpectedResult.ToString();
        }

        public string GetCurrentNumberValue()
        {
            return CurrentNumber.Number.ToString();
        }

        public int GetOperationsCount()
        {
            return OperationsStack.Count;
        }

        public int GetNewRandomNumber()
        {
            return (new Random()).Next(1, 200);
        }

        public void ResetCurrentNumberAndOperationStack()
        {
            CurrentNumber = new OperationTarget(0);
            OperationsStack.Clear();
        }

        public string GetLastOperationName()
        {
            return OperationsStack.Peek().ToString();
        }

        public void MakePlusOne()
        {
            ExecuteOperation(new OperationPlus(CurrentNumber));
        }

        public void MakeMultByTwo()
        {
            ExecuteOperation(new OperationMultiply(CurrentNumber));
        }

        private void ExecuteOperation(IOperationInterface operation)
        {
            CurrentNumber = operation.Execute();
            OperationsStack.Push(operation);
        }

        public bool RevertOperation()
        {
            if (OperationsStack.Count == 0)
            {
                return false;
            }

            IOperationInterface Operation = OperationsStack.Pop();
            CurrentNumber = Operation.Revert();

            return true;
        }

        public bool IsPlayerWon()
        {
            return CurrentNumber.Number == ExpectedResult;
        }

        public bool IsPlayerLoose()
        {
            return CurrentNumber.Number > ExpectedResult;
        }
    }
}
