namespace Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
public class IndexGraterOrEqualThanHundredAndSmallerThanThousandSpecification : ISpecification
{
    private bool IsSatisfiedBy(int index) =>
        index >= 100 && index < 1000;
    public void OperationAfterAssertion(int index, Action action)
    {
        if (IsSatisfiedBy(index))
        {
            action();
        }
    }
}