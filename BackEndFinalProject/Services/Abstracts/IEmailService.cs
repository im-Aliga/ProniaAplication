using BackEndFinalProject.Contracts.Email;

namespace BackEndFinalProject.Services.Abstracts
{
    public interface IEmailService
    {
        public void Send(MessageDto messageDto);
    }
}
