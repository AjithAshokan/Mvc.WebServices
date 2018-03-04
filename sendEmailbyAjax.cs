  public JsonResult ForgotPasswordSend(string emailId)
        {
            int emailValidFlag = 0, employeeId;

            string employeePassword, employeeName;
            try
            {
                ETLLoginService.ETLCenterLoginService obj = new ETLLoginService.ETLCenterLoginService();
                string passwordDetails = obj.forgetPassword(emailId);

                DataTable dt = JsonConvert.DeserializeObject<DataTable>(passwordDetails);
                if (dt.Rows.Count > 0)
                {
                    employeePassword = Convert.ToString(dt.Rows[0]["EmpPassword"]);
                    employeeId = Convert.ToInt32(dt.Rows[0]["ID_Employee"]);
                    employeeName = Convert.ToString(dt.Rows[0]["EmpName"]);
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("aaaaaa@gmail.com");
                    msg.To.Add(emailId);
                    msg.Subject = "Recover your Password";
                    msg.Body = ("Hi <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + employeeName + " your password is <b>" + employeePassword + "</b>");
                    msg.IsBodyHtml = true;

                    SmtpClient smtc = new SmtpClient();
                    smtc.Host = "smtp.gmail.com";
                    System.Net.NetworkCredential ntwd = new NetworkCredential();
                    ntwd.UserName = "aaaaaa@gmail.com";
                    ntwd.Password = "aaaaa";
                    smtc.UseDefaultCredentials = true;
                    smtc.Credentials = ntwd;
                    smtc.Port = 587;
                    smtc.EnableSsl = true;
                    smtc.Send(msg);
                }
                else
                {
                    emailValidFlag = 1;
                }
                return Json(new { id = emailValidFlag }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }
