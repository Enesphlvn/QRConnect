using QRCoder;

namespace App.Application.Features.QRCodes
{
    public class QRCodeService : IQRCodeService
    {
        public byte[] GenerateQRCode(string data)
        {
            const int pixelSize = 5;
            byte[] foregroundColor = { 0, 0, 0 };
            byte[] backgroundColor = { 255, 255, 255 };

            QRCodeGenerator generator = new();
            QRCodeData qrCodeData = generator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);

            PngByteQRCode qRCode = new(qrCodeData);
            return qRCode.GetGraphic(pixelSize, foregroundColor, backgroundColor);
        }
    }
}
