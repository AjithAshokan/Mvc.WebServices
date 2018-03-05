 public void ExceptionLog(HttpContextBase Context, string ErrorMessage, string MethodName, string ActionName, string ControllerName)
        {
            try
            {
                
                string FilePath = Context.Server.MapPath("~/Logs/ExceptionLog/" + DateTime.Now.ToShortDateString() + ".txt");
                if (!File.Exists(FilePath))
                {
                    using (FileStream fs = new FileStream(FilePath, FileMode.Create))
                    {
                        //File Creation goes here
                    }
                }
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine("Error Message : " + ErrorMessage);
                    writer.WriteLine("Method Name : " + MethodName);
                    writer.WriteLine("Action Name : " + ActionName);
                    writer.WriteLine("Controller Name : " + ControllerName);
                    writer.WriteLine("Date Time : " + DateTime.Now.ToString());
                    writer.WriteLine("---------------------------------------------------------------------------------");
                }
                
            }
            catch
            {
                
            }
        }
