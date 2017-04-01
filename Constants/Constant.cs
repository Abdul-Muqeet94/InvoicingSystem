namespace SimpleInvoices
{
    public static class Constant
    {


        public const bool USER_ACTIVE = true;
        public const bool USER_INACTIVE = false;

        public const string TABLE_CUSTOMER="Customer";
        public const string TABLE_BILLER="Biller";
        public const string TABLE_PRODUCT="Product";
        public const bool TRANSATION_SUCCESS = true;
        public const bool TRANSACTION_FAIL = false;

        public const string MAIL_FROM_ADDRESS_NAME="SimplInvoices";
        public const string MAIL_FROM_ADDRESS_EMAIL="M.Fahad2015@outlook.com";
        public const string MAIL_HOST_ADDRESS = "smtp-mail.outlook.com";
        public const int MAIL_HOST_PORT = 587;


        public const string SENDGRID_API_TOKEN="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";
        public const string MAIL_AUTHENTICAITON_USER = "M.Fahad2015@outlook.com";
        public const string MAIL_AUTHENTICATION_PASSWORD = "king0341";

    

//client.Connect ("smtp-mail.outlook.com", 587, true);

		// 		// Note: since we don't have an OAuth2 token, disable
		// 		// the XOAUTH2 authentication mechanism.
		// 		client.AuthenticationMechanisms.Remove ("XOAUTH2");

		// 		// Note: only needed if the SMTP server requires authentication
		// 		client.Authenticate ("M.Fahad2015@outlook.com", "king0341");
				


    }
}