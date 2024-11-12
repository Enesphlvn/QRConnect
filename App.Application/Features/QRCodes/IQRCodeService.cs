namespace App.Application.Features.QRCodes
{
    public interface IQRCodeService
    {
        byte[] GenerateQRCode(string data);
    }
}
