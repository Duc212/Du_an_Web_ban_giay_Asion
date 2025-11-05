using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Helper.VNPay
{
    public class VNPayLibrary
    {
     private readonly SortedList<string, string> _requestData = new SortedList<string, string>(new VNPayCompare());
        private readonly SortedList<string, string> _responseData = new SortedList<string, string>(new VNPayCompare());

        public void AddRequestData(string key, string value)
{
    if (!string.IsNullOrEmpty(value))
 {
        _requestData.Add(key, value);
         }
   }

        public void AddResponseData(string key, string value)
        {
if (!string.IsNullOrEmpty(value))
     {
           _responseData.Add(key, value);
      }
  }

     public string GetResponseData(string key)
        {
      return _responseData.TryGetValue(key, out var retValue) ? retValue : string.Empty;
     }

      public string CreateRequestUrl(string baseUrl, string hashSecret)
        {
       var data = new StringBuilder();
            foreach (var kv in _requestData)
   {
              if (!string.IsNullOrEmpty(kv.Value))
   {
          data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
        }
      }

   var queryString = data.ToString();

       if (queryString.Length > 0)
            {
        queryString = queryString.Remove(queryString.Length - 1, 1);
        }

var signData = queryString;
        var vnpSecureHash = HmacSHA512(hashSecret, signData);
            queryString += "&vnp_SecureHash=" + vnpSecureHash;

            var paymentUrl = baseUrl + "?" + queryString;
            return paymentUrl;
        }

        public bool ValidateSignature(string inputHash, string secretKey)
        {
            var rspRaw = GetResponseData();
            var checkSum = HmacSHA512(secretKey, rspRaw);
            return checkSum.Equals(inputHash, StringComparison.InvariantCultureIgnoreCase);
     }

        private string GetResponseData()
        {
   var data = new StringBuilder();
 if (_responseData.ContainsKey("vnp_SecureHashType"))
   {
    _responseData.Remove("vnp_SecureHashType");
        }

        if (_responseData.ContainsKey("vnp_SecureHash"))
            {
_responseData.Remove("vnp_SecureHash");
         }

            foreach (var kv in _responseData)
            {
     if (!string.IsNullOrEmpty(kv.Value))
      {
             data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
          }
      }

      if (data.Length > 0)
            {
     data.Remove(data.Length - 1, 1);
  }

   return data.ToString();
   }

      private string HmacSHA512(string key, string inputData)
        {
            var hash = new StringBuilder();
    var keyBytes = Encoding.UTF8.GetBytes(key);
         var inputBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hmac = new HMACSHA512(keyBytes))
            {
           var hashValue = hmac.ComputeHash(inputBytes);
     foreach (var theByte in hashValue)
                {
                hash.Append(theByte.ToString("x2"));
          }
       }

            return hash.ToString();
     }
    }

    public class VNPayCompare : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
         if (x == y) return 0;
            if (x == null) return -1;
     if (y == null) return 1;
            var vnpCompare = CompareInfo.GetCompareInfo("en-US");
    return vnpCompare.Compare(x, y, CompareOptions.Ordinal);
 }
    }
}
