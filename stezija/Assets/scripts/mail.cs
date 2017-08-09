using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class mail : MonoBehaviour
{

    string mailBody;
    InputField input;

    Ray ray;
    RaycastHit hit;


    void Update()
    {
        input.GetComponent<InputField>();
        mailBody = input.text;

        if (Input.touchCount == 1)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began && hit.collider.tag == "mainbtn")
                {
                    Main();
                }
            }
        }
    }

    IEnumerator MailSend()
    {
        yield return new WaitForSeconds(2);
        input.text = "Mail has been SENT";
        yield return new WaitForSeconds(2);
        input.text = "Write.......icon to send";

    }




    void Main()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("synesthesia.gruden@gmail.com");
        mail.To.Add("andraz.gruden@gmail.com");
        mail.Subject = "Message from Synesthesia APP";
        mail.Body = mailBody;

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("synesthesia.gruden@gmail.com", "Ursika7915") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        StartCoroutine(MailSend());

    }
}