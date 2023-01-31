namespace BackEndFinalProject.Services.Abstracts
{
    public interface IOrderService
    {
        Task<string> GenerateUniqueTrackingCodeAsync();
    }
}
