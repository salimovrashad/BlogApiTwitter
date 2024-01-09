namespace GTwitt.BUSINESS.ExternalServices.Interfaces
{
	public interface IEmailServices
    {
        void Send(string toMail, string header, string body, bool isHtml = true);
    }
}
