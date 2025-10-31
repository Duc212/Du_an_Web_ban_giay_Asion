using Helper.Utils.Interfaces;
using System.Text;
using System.Web;

namespace Helper.Utils
{
    public class AvatarUtils : IAvatarUtils
    {
        /// <summary>
        /// Generate avatar URL s? d?ng UI Avatars API
        /// </summary>
        public string GenerateAvatarUrl(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return "https://ui-avatars.com/api/?name=User&size=200&background=random";
            }

            var initials = GetInitials(fullName);

            // S? d?ng UI Avatars API (free service)
            // Format: https://ui-avatars.com/api/?name=TS&size=200&background=random
            var encodedName = HttpUtility.UrlEncode(initials);

            // Random background color based on name hash
            var backgroundColor = GetColorFromName(fullName);
            var textColor = "ffffff"; // White text

            return $"https://ui-avatars.com/api/?name={encodedName}&size=200&background={backgroundColor}&color={textColor}&bold=true";
        }

        /// <summary>
        /// L?y ch? cái ??u t? tên (VD: Thái S?n -> TS, Nguy?n V?n A -> NA)
        /// </summary>
        public string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return "U";
            }

            // Remove extra spaces and split
            var parts = fullName.Trim()
                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                return "U";
            }

            // Take first letter of last part and first part
            // VD: "Nguy?n V?n A" -> "A" + "N" = "AN"
            // VD: "Thái S?n" -> "S" + "T" = "ST"
            // But we want "TS" for "Thái S?n", so:

            if (parts.Length == 1)
            {
                // Single name: take first 2 letters or 1 if short
                return parts[0].Length >= 2
                       ? parts[0].Substring(0, 2).ToUpper()
                      : parts[0].Substring(0, 1).ToUpper();
            }

            // Multiple parts: take first letter of first and last name
            var firstInitial = parts[0].Substring(0, 1).ToUpper();
            var lastInitial = parts[parts.Length - 1].Substring(0, 1).ToUpper();

            return firstInitial + lastInitial;
        }

        /// <summary>
        /// Generate consistent color based on name
        /// </summary>
        private string GetColorFromName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "007bff"; // Default blue
            }

            // Generate hash from name
            int hash = 0;
            foreach (char c in name)
            {
                hash = ((hash << 5) - hash) + c;
            }

            // Use hash to pick from predefined nice colors
            string[] colors = new[]
        {
       "007bff", // Blue
      "6610f2", // Indigo
     "6f42c1", // Purple
      "e83e8c", // Pink
 "dc3545", // Red
         "fd7e14", // Orange
     "ffc107", // Yellow
         "28a745", // Green
 "20c997", // Teal
        "17a2b8", // Cyan
    "343a40", // Dark
  "6c757d"  // Gray
      };

            var index = Math.Abs(hash) % colors.Length;
            return colors[index];
        }

        /// <summary>
        /// Alternative: Generate avatar URL using DiceBear API (more styles)
        /// </summary>
        public string GenerateAvatarUrlDiceBear(string fullName, string style = "initials")
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return $"https://api.dicebear.com/7.x/{style}/svg?seed=User";
            }

            var seed = HttpUtility.UrlEncode(fullName);
            return $"https://api.dicebear.com/7.x/{style}/svg?seed={seed}";
        }

        /// <summary>
        /// Alternative: Generate Gravatar URL (if user has Gravatar account)
        /// </summary>
        public string GenerateGravatarUrl(string email, int size = 200)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return $"https://www.gravatar.com/avatar/?s={size}&d=identicon";
            }

            using var md5 = System.Security.Cryptography.MD5.Create();
            var emailBytes = Encoding.UTF8.GetBytes(email.Trim().ToLowerInvariant());
            var hashBytes = md5.ComputeHash(emailBytes);
            var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

            return $"https://www.gravatar.com/avatar/{hash}?s={size}&d=identicon";
        }
    }
}