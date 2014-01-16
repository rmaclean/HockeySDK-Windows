using System;
using System.Threading.Tasks;

namespace HockeyApp.Extensions
{
    public class TaskEx
    {

        public static async Task<T> Run<T>(Func<T> func)
        {
            return await Task.Run<T>(func);
        }

    }
}
