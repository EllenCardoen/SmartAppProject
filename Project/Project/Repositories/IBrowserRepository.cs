using System;

namespace Project.Repositories
{
    public interface IBrowserRepository
    {
        void OpenBrowser(Uri uri);
    }
}