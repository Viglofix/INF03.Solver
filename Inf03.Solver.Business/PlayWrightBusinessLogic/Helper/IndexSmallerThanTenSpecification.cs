namespace Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
public class IndexSmallerThanTenSpecification : ISpecificationAction<int>
{
    private const int _smallerThanTen = 10;
    private bool IsSatisfiedBy(int index) =>
        index < _smallerThanTen;
    public void OperationAfterAssertion(int index, Action action)
    {
        if (IsSatisfiedBy(index))
        {
            action();
        }
    }
}
