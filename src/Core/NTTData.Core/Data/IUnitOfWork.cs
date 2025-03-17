namespace NTTData.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
