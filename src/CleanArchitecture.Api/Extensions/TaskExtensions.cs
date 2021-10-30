using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Api.Extensions
{
    public static class TaskExtensions
    {
        public static async void Await(this Task task, Action completedCallback, Action<Exception> exceptionCallbak)
        {
            try
            {
                await task;
                completedCallback?.Invoke();
            }
            catch (Exception ex)
            {
                exceptionCallbak?.Invoke(ex);
            }
        }
    }
}
