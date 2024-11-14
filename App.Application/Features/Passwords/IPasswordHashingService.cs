namespace App.Application.Features.Passwords
{
    public interface IPasswordHashingService
    {
        void GeneratePasswordhash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
