using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using DataAccess;

namespace NFLPicker.Errors
{
    public class ErrorDriver
    {
        private IRepository<Error> _errorRepos;

        public ErrorDriver(IRepository<Error> errorRepos)
        {
            _errorRepos = errorRepos;
        }

        public async Task LogError(Exception ex)
        {
            var error = new Error();

            error.Message = ex.Message;
            error.StackTrace = ex.StackTrace;

            await _errorRepos.SaveAsync(error);
        }

        public async Task<string> HandleTaskError(Task task)
        {
            if (!task.IsFaulted)
                return string.Empty;

            var errorMsg = string.Empty;

            foreach (var error in task.Exception.InnerExceptions)
            {
                await LogError(error);
                errorMsg += String.Format("{0}.\n", error.Message);
            }

            return errorMsg;

        }

        public HttpResponseMessage CreateErrorResponse(string content, HttpStatusCode statusCode)
        {
            var resp = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(content)
            };

            return resp;
        }
    }
}
