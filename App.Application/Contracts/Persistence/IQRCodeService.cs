namespace App.Application.Contracts.Persistence
{
    public interface IQRCodeService
    {
        byte[] GenerateQRCode(string data);
    }
}
