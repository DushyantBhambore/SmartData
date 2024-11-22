using Domain;
using OpenTokSDK;
using OpenTokSDK.Exception;

namespace App.Core
{
    public class OpenTokService
    {
        private readonly OpenTok _openTok;
        private const string ApiKey = "b669c86a"; // Your OpenTok API Key in string form
        private const string ApiSecret = "EmUl7En92bICAKul"; // Your OpenTok API Secret

        public OpenTokService()
        {
            int hashedApiKey = ApiKeyHasher.ConvertToInt(ApiKey);
            _openTok = new OpenTok(hashedApiKey, ApiSecret);
        }
        public string CreateSession()
        {
            try 
            {
                var session = _openTok.CreateSession(mediaMode: MediaMode.ROUTED);
                return session.Id;
            }
            catch (OpenTokException ex)
            {
                // Log the exception details
                Console.WriteLine($"Error creating session: {ex.Message}");
                throw;
            }
        }

        public string GenerateToken(string sessionId)
        {
            try
            {
                return _openTok.GenerateToken(sessionId);
            }
            catch (OpenTokException ex)
            {
                // Log the exception details
                Console.WriteLine($"Error generating token: {ex.Message}");
                throw;
            }
        }

        public Archive StartRecording(string sessionId)
        {
            try
            {
                return _openTok.StartArchive(sessionId, "Recording");
            }
            catch (OpenTokException ex)
            {
                // Log the exception details
                Console.WriteLine($"Error starting recording: {ex.Message}");
                throw;
            }
        }

        public void StopRecording(string archiveId)
        {
            try
            {
                _openTok.StopArchive(archiveId);
            }
            catch (OpenTokException ex)
            {
                // Log the exception details
                Console.WriteLine($"Error stopping recording: {ex.Message}");
                throw;
            }
        }
    }
}
