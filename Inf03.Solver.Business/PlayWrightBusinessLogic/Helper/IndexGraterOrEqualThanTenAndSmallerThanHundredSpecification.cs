namespace Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
public class IndexGraterOrEqualThanTenAndSmallerThanHundredSpecification : ISpecificationAction<int>
{
    private const int _graterOrEqualTen = 10;
    private const int _smallerThanHundred = 100;
    private bool IsSatisfiedBy(int index) =>
        index >= _graterOrEqualTen && index < _smallerThanHundred;
    public void OperationAfterAssertion(int index,Action action)
    {
        if (IsSatisfiedBy(index))
        {
            action();
        }
    }
}

