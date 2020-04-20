namespace RPGCalendar.Data.GameObjects
{
    using System.Collections.Generic;

    public abstract class GameObject : FingerPrintEntityBase
    {
        public ICollection<int> CreatePermissions { get; } = new List<int>();
        public ICollection<int> ReadPermissions { get; } = new List<int>();
        public ICollection<int> UpdatePermissions { get; } = new List<int>();
        public ICollection<int> DeletePermissions { get; } = new List<int>();

        public bool HasCreatePermissions(int userId)
            => CreatePermissions.Contains(userId);
        public bool HasReadPermissions(int userId)
            => ReadPermissions.Contains(userId);
        public bool HasUpdatePermissions(int userId)
            => UpdatePermissions.Contains(userId);
        public bool HasDeletePermissions(int userId)
            => DeletePermissions.Contains(userId);

    }
}
