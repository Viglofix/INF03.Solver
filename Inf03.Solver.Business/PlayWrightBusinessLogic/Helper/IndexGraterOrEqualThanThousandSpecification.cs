namespace Inf03.Solver.Business.PlayWrightBusinessLogic.Helper;
public class IndexGraterOrEqualThanThousandSpecification : ISpecification
{
    private bool IsSatisfiedBy(int index) =>
        index >= 1000;
    public void OperationAfterAssertion(int index, Action action)
    {
        if (IsSatisfiedBy(index))
        {
            action();
        }
    }
}