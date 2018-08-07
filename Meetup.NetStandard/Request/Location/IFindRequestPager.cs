namespace Meetup.NetStandard.Request.Location
{
    public interface IFindRequestPager<T>
    {
        T WithPageSize(int pageSize);
        T OnPage(int pageSize);
    }
}