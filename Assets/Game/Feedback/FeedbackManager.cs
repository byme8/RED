using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using UnityEngine;


public class FeedbackManager : MonoBehaviour
{
    class SMTPSettings
    {
        public string From { get; set; }
        public string Password { get; set; }
        public string To { get; set; }
    }

    class CredentialProvider : ICredentialsByHost
    {
        private SMTPSettings settings;

        public CredentialProvider(SMTPSettings settings)
        {
            this.settings = settings;
        }

        public NetworkCredential GetCredential(string host, int port, string authType)
        {
            return new NetworkCredential(this.settings.From, this.settings.Password);
        }
    }

    public TextAsset Text;

    private SMTPSettings smtpSettings;

    private void Start()
    {
        this.smtpSettings = JsonConvert.DeserializeObject<SMTPSettings>(this.Text.text);
    }

    public void Send(string body)
    {
        var smtp = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new CredentialProvider(this.smtpSettings),
            EnableSsl = true
        };

        ServicePointManager.ServerCertificateValidationCallback = 
            (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true;

        smtp.SendAsync(this.smtpSettings.From, this.smtpSettings.To, "Feedback", body, null);
    }
}
