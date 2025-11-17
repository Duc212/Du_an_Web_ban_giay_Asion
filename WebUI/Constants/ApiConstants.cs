namespace WebUI.Constants
{
    public static class ApiEndpoints
    {
        // Auth endpoints
        public const string Register = "/api/Auth/Register";
        public const string Login = "/api/Auth/Login";
        public const string Verify = "/api/Auth/Verify";
        public const string GoogleLogin = "/api/Auth/GoogleLogin";
        public const string FacebookLogin = "/api/Auth/FacebookLogin";
        public const string ForgotPassword = "/api/Auth/ForgotPassword";
        public const string ResetPassword = "/api/Auth/ResetPassword";
        public const string RefreshToken = "/api/Auth/RefreshToken";
        public const string Logout = "/api/Auth/Logout";
        public const string GetUserWithAddress = "/api/Auth/GetUserWithAddress";

        // Product endpoints
        public const string Products = "/api/Products";
        public const string ProductDetails = "/api/Products/{0}";
        public const string ProductSearch = "/api/Products/search";
        public const string ProductCategories = "/api/ProductLanding/GetCategory";
        public const string ProductList = "/api/ProductLanding/GetListProduct";
        public const string ProductShop = "/api/ProductLanding/GetProductShop";
        public const string GetLisBrand = "/api/ProductLanding/GetLisBrand";
        public const string GetProductById = "/api/ProductLanding/GetProductById";


        // Cart endpoints
        public const string Cart = "/api/Cart";
        public const string AddToCart = "/api/Cart/add";
        public const string RemoveFromCart = "/api/Cart/remove";
        public const string UpdateCartItem = "/api/Cart/update";
        public const string ClearCart = "/api/Cart/clear";

        // Order endpoints
        public const string Orders = "/api/Orders";
        public const string CreateOrder = "/api/Orders/CreateOrder";
        public const string OrderDetails = "/api/Orders/{0}";
        public const string OrderHistory = "/api/Orders/history";

        // User endpoints
        public const string UserProfile = "/api/User/profile";
        public const string UpdateProfile = "/api/User/update";
        public const string ChangePassword = "/api/User/change-password";
    }

    public static class LocalStorageKeys
    {
        public const string AuthToken = "abc_mart_token";
        public const string RefreshToken = "abc_mart_refresh_token";
        public const string UserData = "abc_mart_user";
        public const string CartData = "abc_mart_cart";
        public const string GoogleAuthState = "google_auth_state";
    }

    public static class AuthConstants
    {
        public const int TokenExpirationHours = 24;
        public const string JwtIssuer = "ABC_MART";
        public const string JwtAudience = "ABC_MART_USERS";
    }
}