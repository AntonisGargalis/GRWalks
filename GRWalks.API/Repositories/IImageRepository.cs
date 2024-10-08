using GRWalks.API.Models.Domain;
using System.Net;

namespace GRWalks.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
