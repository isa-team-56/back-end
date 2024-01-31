using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
namespace Explorer.Stakeholders.API.Public
{
    public interface IEmailService
    {
        public void SendActivationEmail(string recipientEmail, string activationLink);
        public void SendPasswordResetEmail(string recipientEmail, string resetPasswordLink);
       

    }
}
