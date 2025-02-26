namespace Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
    public class IndexGraterOrEqualThanTenAndSmallerThanHundredSpecification : ISpecification
    {
    private bool IsSatisfiedBy(int index) =>
        index >= 10 && index < 100;
    public void OperationAfterAssertion(int index,Action action)
    {
        if (IsSatisfiedBy(index))
        {
            action();
        }
    }
    }

