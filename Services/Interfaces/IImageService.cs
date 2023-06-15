namespace AddressBook.Services.Interfaces
{
    public interface IImageService
    {
        public Task<byte[]> ConvertFileToByteArraySync(IFormFile file);
        public string ConvertByteArrayToFile(byte[] fileData, string extension);
    }
}
