			
		String UserIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(UserIP))
        {
                UserIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        } 

			
		public string LongToIP(long longIP)
        {
            string ip = string.Empty;
            for (int i = 0; i< 4; i++)
            {
                int num = (int)(longIP / Math.Pow(256, (3 - i)));
                longIP = longIP - (long) (num* Math.Pow(256, (3 - i)));
                if (i == 0)
                    ip = num.ToString();
                else
                    ip  = ip + "." + num.ToString();
            }
            return ip;
        }  
        public long IP2Long(string ip)
        {
            string[] ipBytes;
            double num = 0;
            if(!string.IsNullOrEmpty(ip))
            {
                ipBytes = ip.Split('.');
                for (int i = ipBytes.Length - 1; i >= 0; i--)
                {
                    num += ((int.Parse(ipBytes[i]) % 256) * Math.Pow(256, (3 - i)));
                }
            }
            return (long) num;
        }