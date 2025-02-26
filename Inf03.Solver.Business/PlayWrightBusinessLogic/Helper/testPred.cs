namespace Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
    public class testPred 
    {
        private bool IsSatisfiedBy(int index, Predicate<int> predicate) =>
            predicate(index);
        public void OperationAfterAssertion(int index, Predicate<int> predicate, Action action)
        {
            if (IsSatisfiedBy(index, predicate))
            {
                action();
            }
        }
    }
