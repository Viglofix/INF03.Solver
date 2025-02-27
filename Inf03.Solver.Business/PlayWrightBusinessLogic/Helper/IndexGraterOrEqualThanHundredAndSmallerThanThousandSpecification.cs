namespace Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
public class IndexGraterOrEqualThanHundredAndSmallerThanThousandSpecification : ISpecificationAction<int>
{
    private const int _graterOrEqualHundred = 100;
    private const int _smallerThanThousand = 1000;
    private bool IsSatisfiedBy(int index) =>
        index >= _graterOrEqualHundred && index < _smallerThanThousand;
    public void OperationAfterAssertion(int index, Action action)
    {
        if (IsSatisfiedBy(index))
        {
            action();
        }
    }
}