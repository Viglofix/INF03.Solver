namespace Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
public class IndexSmallerThanTenSpecification : ISpecification
{
    private bool IsSatisfiedBy(int index) =>
        index < 10;
    public void OperationAfterAssertion(int index, Action action)
    {
        if (IsSatisfiedBy(index))
        {
            action();
        }
    }
}
