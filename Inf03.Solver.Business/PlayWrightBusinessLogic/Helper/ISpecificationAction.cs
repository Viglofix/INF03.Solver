namespace Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
    public interface ISpecificationAction<T>
    {
        void OperationAfterAssertion(T element, Action action);
    }
