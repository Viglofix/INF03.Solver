namespace Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
public class IndexGraterOrEqualThanThousandSpecification : ISpecificationAction<int>
{
    private const int _graterThanThousand = 1000;
    private bool IsSatisfiedBy(int index) =>
        index >= _graterThanThousand;
    public void OperationAfterAssertion(int index, Action action)
    {
        if (IsSatisfiedBy(index))
        {
            action();
        }
    }
}