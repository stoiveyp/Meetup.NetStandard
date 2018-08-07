namespace Meetup.NetStandard.Request.Location
{
    public interface IFindNameRequest : IFindRequestPager<IFindNameRequest>
    {
        IFindExecutor AndByCoordinate(double longitude, double latitude);
    }
}