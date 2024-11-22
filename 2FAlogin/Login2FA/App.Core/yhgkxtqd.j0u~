using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using OpenTokSDK;
using Microsoft.AspNetCore.DataProtection;
namespace App.Core
{
    public class OpenTokService
    {
        private readonly OpenTok _openTok;
        private const string ApiKey = "b669c86a"; // Your OpenTok API Key in string form
        private const string ApiSecret = "EmUl7En92bICAKul"; // Your OpenTok API Secret
        private const string PrivateKeyPath = "D:\\Sdfolder\\SdPractice\\2FAlogin\\PrivateKey\\private.key"; // Path to your private key file

        public OpenTokService()
        {
            string privateKey = File.ReadAllText(PrivateKeyPath);
            _openTok = new OpenTok(ApiKey, ApiSecret);
        }

        public string CreateSession()
        {
            var session = _openTok.CreateSession();
            return session.Id;
        }

        public string GenerateToken(string sessionId)
        {
            return _openTok.GenerateToken(sessionId);
        }

        public Archive StartRecording(string sessionId)
        {
            return _openTok.StartArchive(sessionId, "Recording");
        }

        public void StopRecording(string archiveId)
        {
            _openTok.StopArchive(archiveId);
        }
    }
}
