namespace Helper.Utils.Interfaces
{
  public interface IAvatarUtils
{
        /// <summary>
     /// Generate avatar URL v?i ch? c�i ??u c?a t�n
        /// </summary>
   string GenerateAvatarUrl(string fullName);
    
        /// <summary>
        /// L?y initials t? t�n ??y ?? (VD: Th�i S?n -> TS)
        /// </summary>
      string GetInitials(string fullName);
    }
}