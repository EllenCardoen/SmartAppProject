using System.Threading.Tasks;

namespace Project.Repositories
{
    public interface IShareRepository
    {
        Task ShareContent(string url);
    }
}