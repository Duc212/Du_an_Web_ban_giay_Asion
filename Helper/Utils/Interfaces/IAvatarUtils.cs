namespace Helper.Utils.Interfaces
{
  public interface IAvatarUtils
{
        /// <summary>
     /// Generate avatar URL v?i ch? cái ??u c?a tên
        /// </summary>
   string GenerateAvatarUrl(string fullName);
    
        /// <summary>
        /// L?y initials t? tên ??y ?? (VD: Thái S?n -> TS)
        /// </summary>
      string GetInitials(string fullName);
    }
}