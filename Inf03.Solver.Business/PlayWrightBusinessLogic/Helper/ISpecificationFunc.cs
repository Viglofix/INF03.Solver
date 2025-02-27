namespace Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
    public interface ISpecificationFunc<T>
    {
       T OperationAfterAssertion(int index, Func<int,int> func);
    }
