/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/11/4
 * Time: 22:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Mail;
using System.Collections.Generic;

namespace Utils
{
	/// <summary>
	/// Description of EmailHelper.
	/// </summary>
	public class EmailHelper
	{
		SmtpClient client;
		
		public string Subject
		{
			get;set;
		}
		
		public string Body
		{
			get;set;
		}
		
		public EmailHelper(string host, string loginId, string password, int port=25)
		{
			client = new SmtpClient(host, port);
			client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(loginId, password);

		}
		
		public void Send(Dictionary<string, string> receivers, string senderAddress, string senderNick)
		{
			//电子邮件信息类
            System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress(senderAddress, senderNick);//发件人Email,在邮箱是这样显示的,[发件人:小明<panthervic@163.com>;]
            System.Net.Mail.MailAddress toAddress = new System.Net.Mail.MailAddress("43327681@163.com", "小红");//收件人Email,在邮箱是这样显示的, [收件人:小红<43327681@163.com>;]
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage(fromAddress, toAddress);//创建一个电子邮件类
            mailMessage.Subject = "邮件的主题";
            string mailBody = "";
            mailMessage.Body = mailBody;//可为html格式文本
            //mailMessage.Body = "邮件的内容";//可为html格式文本
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;//邮件主题编码
            mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");//邮件内容编码
            mailMessage.IsBodyHtml = true;//邮件内容是否为html格式
            mailMessage.Priority = System.Net.Mail.MailPriority.High;//邮件的优先级,有三个值:高(在邮件主题前有一个红色感叹号,表示紧急),低(在邮件主题前有一个蓝色向下箭头,表示缓慢),正常(无显示).
            try
            {
                client.Send(mailMessage);//发送邮件
                //client.SendAsync(mailMessage, "ojb");异步方法发送邮件,不会阻塞线程.
            }
            catch (Exception)
            {
            }
		}
	}
}
