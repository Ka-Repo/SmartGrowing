namespace xamarin_app.Helpers
{
    public static class Constants
    {
        /**
         *  Cosmos DB constants
         */

        // set your Azure Cosmos DB endpoint, for example "https://contosocosmosdb.documents.azure.com:443/"
        public static readonly string CosmosEndpointUrl = "<your-cosmos-db-url>";

        // set your Azure Cosmos DB authentication key, for example "llkP4rr0Hn3ixfYGrrkP4rr0Hn3ixfYGXEgt0uV3atOpcn9Soh5q6tYh0T7BwLsQrmT5SVycUAlYpeh5MlwyyQ!=" 
        public static readonly string CosmosAuthKey = "<your-cosmos-db-auth-key>";

        /**
         *  Azure AD B2C constants
         */

        // set your tenant name, for example "contoso123tenant"
        static readonly string tenantName = "<your-ad-b2c-name>";

        // set your tenant id, for example: "contoso123tenant.onmicrosoft.com"
        static readonly string tenantId = "<your-ad-b2c-tenant-id>";

        // set your client/application id, for example: aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
        static readonly string clientId = "<your-ad-b2c-client-id>";

        // set your sign up/in policy name, for example: "B2C_1_signupsignin"
        static readonly string policySignin = "<your-ad-b2c-signin-policy-name>";

        // set your forgot password policy, for example: "B2C_1_passwordreset"
        static readonly string policyPassword = "<your-ad-b2c-forgot-password-policy-name>";

        // set to a unique value for your app, such as your bundle identifier. Used on iOS to share keychain access.
        static readonly string iosKeychainSecurityGroup = "<your-ios-bundle-id>";

        // The following fields and properties should not need to be changed
        static readonly string[] scopes = { "" };
        static readonly string authorityBase = $"https://{tenantName}.b2clogin.com/tfp/{tenantId}/";
        public static string ClientId
        {
            get
            {
                return clientId;
            }
        }
        public static string AuthoritySignin
        {
            get
            {
                return $"{authorityBase}{policySignin}";
            }
        }
        public static string AuthorityPasswordReset
        {
            get
            {
                return $"{authorityBase}{policyPassword}";
            }
        }
        public static string[] Scopes
        {
            get
            {
                return scopes;
            }
        }
        public static string IosKeychainSecurityGroups
        {
            get
            {
                return iosKeychainSecurityGroup;
            }
        }
    }
}
